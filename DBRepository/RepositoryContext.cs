using System;
using System.Collections.Generic;
using System.Text;

using Models.Models;
using Models.Models.DataModels;
using Models.Models.ContentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DBRepository
{
    public class RepositoryContext :IdentityDbContext<ApplicationUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        public DbSet<Section> Sections{ get; set;}
        public DbSet<ElementOfSection> ElementOfSections { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Subheading> Subheadings { get; set; }
        public DbSet<Significative> Significatives { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollAnswer> PollAnswers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ElementOfSectionSignificate> ElementOfSectionSignificates { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<DimensionTree> DimensionTrees { get; set; }
        //public DbSet<DimensionTable> DimensionTables { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ElementOfSectionSignificate>()
                .HasOne(eoss => eoss.ElementOfSection)
                .WithMany(eos => eos.ElementOfSectionSignificates)
                .HasForeignKey(eoss => eoss.ElementOfSectionId);

            builder.Entity<ElementOfSectionSignificate>()
                .HasOne(eoss => eoss.Significative)
                .WithMany(s => s.ElementOfSectionSignificates)
                .HasForeignKey(eoss => eoss.SignificativeId);
        }
    }
}
