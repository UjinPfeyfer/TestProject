using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Models.DataModels;
using Models.Models.StructModels;

namespace DBRepository.Repository
{
    public class StructRepository:BaseRepository, IStructRepository
    {
        private List<Heading> Headings { get; set; }
        private List<Subheading> Subheadings { get; set; }
        private List<Significative> Significatives { get; set; }
        private RepositoryContext Context { get; }

        private List<Dimension> Dimensions { get; set; }
        private List<DimensionTree> DimensionTrees { get; set; }
        public StructRepository(RepositoryContext context)
        {
            Context = context;
            
        }
        public List<Heading> GetStruct()
        {
            
            List<Heading> Struct = new List<Heading>();
            try
            {
                Headings = Context.Headings.ToList();
                Subheadings = Context.Subheadings.ToList();
                Significatives = Context.Significatives.ToList();
                Struct = Headings;
                foreach (Heading strct in Struct)
                {
                    strct.Subheadings = Subheadings
                        .Select(x => new Subheading{SubheadingId = x.SubheadingId, SubheadingName = x.SubheadingName, HeadingId = x.HeadingId })
                        .Where(x => x.HeadingId == strct.HeadingId).ToList();
                    foreach (Subheading subhd in strct.Subheadings)
                    {
                        subhd.Significatives = Significatives
                            .Select(x => new Significative { SignificativeId = x.SignificativeId, SignificativeName = x.SignificativeName, SubheadingId = x.SubheadingId })
                            .Where(x => x.SubheadingId == subhd.SubheadingId).ToList();
                    }
                }
            }
            catch (Exception e)
            { }
            return Struct;
        }

        public async Task AddSubheading(string subheadName, int subheadHeadId)
        {
            Context.Subheadings.Add(new Subheading { SubheadingName = subheadName, HeadingId = subheadHeadId });
            await Context.SaveChangesAsync();
        }

        public async Task UpdateSubheading (int subheadId, string subheadName, int subheadHeadId)
        {
            Subheading subheading = Context.Subheadings.FirstOrDefault(x => x.SubheadingId == subheadId);
            if (subheading != null)
            {
                subheading.SubheadingName = subheadName;
                subheading.SubheadingId = subheadHeadId;
                Context.Subheadings.Update(subheading);
            }
            await Context.SaveChangesAsync();
        }

        public async Task AddSignifficative(string significativeName, int subheadId)
        {
            try
            {
                Context.Significatives.Add(new Significative { SignificativeName = significativeName, SubheadingId = subheadId });
                await Context.SaveChangesAsync();
            }
            catch (Exception ex) { }
        }

        public async Task UpdateSignificative(int significativeId, string significativeName, int subheadingId)
        {
            Significative significative = Context.Significatives.FirstOrDefault(x => x.SignificativeId == significativeId);
            if (significative != null)
            {
                significative.SignificativeName = significativeName;
                significative.SubheadingId = subheadingId;
                Context.Significatives.Update(significative);
            }
            await Context.SaveChangesAsync();
        }

        public async Task AddDimension(string dimensionName, int dimensionParrent)
        {
            try
            {
                Dimension dim = new Dimension() { DimensionName = dimensionName };
                //DimensionTable dimTable = Context.DimensionTables.Where()
                Context.Dimensions.Add(dim);
                await Context.SaveChangesAsync();
                var dimensTree = Context.DimensionTrees.Where(x => x.DescendantId == dimensionParrent).ToList();
                DimensionTree parent = new DimensionTree() { Level = -1, ParentId = 0 };
                if (dimensTree.Count != 0)
                {
                    parent = dimensTree.Where(x => x.DimensionId == x.DescendantId).FirstOrDefault();
                }
                foreach (DimensionTree tree in dimensTree)
                {
                    Context.DimensionTrees.Add(new DimensionTree()
                    {
                        DimensionId = tree.DimensionId,
                        DescendantId = dim.DimensionId,
                        Level = parent.Level + 1,
                        ParentId = parent.DimensionId
                    });
                }
                Context.DimensionTrees.Add(new DimensionTree()
                {
                    DimensionId = dim.DimensionId,
                    DescendantId = dim.DimensionId,
                    Level = parent.Level + 1,
                    ParentId = parent.DimensionId
                });
                await Context.SaveChangesAsync();
            }
            catch (Exception ex) { }
        }

        public async Task GetMainDimensions()
        {
            // вывод данных на основе таблицы связи показателя и среза (show data on base many-to-many table between significative and dimension)
        }

        public async Task<List<Dimension>> GetAllMainDimensions()
        {
            try
            {
                List<Dimension> mainDimensions = await Context.DimensionTrees
                    .Where(dim => dim.ParentId == 0)
                    .Join(Context.Dimensions, dimtree => dimtree.DimensionId, dim => dim.DimensionId, (dim, dimtree) => dimtree).ToListAsync();
                return mainDimensions;
            }
            catch (Exception ex) { }
            return null;
        }

        public async Task<Dictionary<int, AllStructValueObject>> GetAllDimensions()
        {
            try
            {
                InitDimentions();
                Dictionary<int, AllStructValueObject> allStructs = new Dictionary<int, AllStructValueObject>();
                foreach (DimensionTree tree in DimensionTrees)
                {
                    addElement(allStructs, tree);
                }
                   
                return allStructs;
            }
            catch (Exception ex) { }
            return null;
        }

        private Dictionary<int, AllStructValueObject> addElement(Dictionary<int, AllStructValueObject> list, DimensionTree tree)
        {

            if (tree.ParentId == 0 || (tree.Level == 0 && tree.ParentId == tree.DimensionId))
            {

                string Name = Dimensions.Where(dim => dim.DimensionId == tree.DescendantId).FirstOrDefault().DimensionName;
                list.Add(tree.DescendantId, new AllStructValueObject()
                {
                    Name = Name,
                    Descendants = new Dictionary<int, AllStructValueObject>()
                });
            }
            else
            {
                if (tree.DimensionId != tree.DescendantId)
                {
                    tree.Level -= 1;
                    addElement(list[tree.DimensionId].Descendants, tree);
                }
            }
            return list;
        }

        private void InitDimentions()
        {
            try
            {
                Dimensions = Context.Dimensions.ToList();
                DimensionTrees = Context.DimensionTrees.ToList();
            }
            catch (Exception ex) { }
        }
    }
}
