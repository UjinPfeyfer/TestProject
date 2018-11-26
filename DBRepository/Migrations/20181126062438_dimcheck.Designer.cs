﻿// <auto-generated />
using System;
using DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBRepository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20181126062438_dimcheck")]
    partial class dimcheck
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsNeedChangePassword");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Position")
                        .IsRequired();

                    b.Property<string>("SecondName")
                        .IsRequired();

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Subdivision")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Models.Models.ContentModels.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatingTime");

                    b.Property<string>("Header");

                    b.Property<string>("NewsText");

                    b.Property<DateTime>("UpdatingTime");

                    b.HasKey("NewsId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Models.Models.ContentModels.Poll", b =>
                {
                    b.Property<int>("PollId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatingTime");

                    b.Property<string>("CreatorId");

                    b.Property<string>("Header");

                    b.Property<int>("IntervieweeCount");

                    b.Property<string>("Question");

                    b.Property<DateTime>("UpdatingTime");

                    b.HasKey("PollId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("Models.Models.ContentModels.PollAnswer", b =>
                {
                    b.Property<int>("PollAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAnswerRight");

                    b.Property<string>("PollAnswerText");

                    b.Property<int>("PollId");

                    b.HasKey("PollAnswerId");

                    b.HasIndex("PollId");

                    b.ToTable("PollAnswers");
                });

            modelBuilder.Entity("Models.Models.DataModels.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Models.Models.DataModels.Dimension", b =>
                {
                    b.Property<int>("DimensionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DimensionName");

                    b.Property<int>("DimensionTableId");

                    b.Property<int?>("DimentionTableId");

                    b.HasKey("DimensionId");

                    b.HasIndex("DimentionTableId");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("Models.Models.DataModels.DimensionTree", b =>
                {
                    b.Property<int>("DimensionTreeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DescendantId");

                    b.Property<int>("DimensionId");

                    b.Property<int>("Level");

                    b.Property<int>("ParentId");

                    b.HasKey("DimensionTreeId");

                    b.HasIndex("DimensionId");

                    b.ToTable("DimentionTrees");
                });

            modelBuilder.Entity("Models.Models.DataModels.DimentionTable", b =>
                {
                    b.Property<int>("DimentionTableId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DimentionTableName");

                    b.HasKey("DimentionTableId");

                    b.ToTable("DimentionTable");
                });

            modelBuilder.Entity("Models.Models.DataModels.ElementOfSection", b =>
                {
                    b.Property<int>("ElementOfSectionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ElementOfSectionName");

                    b.Property<int>("SectionId");

                    b.HasKey("ElementOfSectionId");

                    b.HasIndex("SectionId");

                    b.ToTable("ElementOfSections");
                });

            modelBuilder.Entity("Models.Models.DataModels.ElementOfSectionSignificate", b =>
                {
                    b.Property<int>("ElementOfSectionSignificateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Count");

                    b.Property<int>("CountryId");

                    b.Property<int>("ElementOfSectionId");

                    b.Property<int>("SignificativeId");

                    b.HasKey("ElementOfSectionSignificateId");

                    b.HasIndex("CountryId");

                    b.HasIndex("ElementOfSectionId");

                    b.HasIndex("SignificativeId");

                    b.ToTable("ElementOfSectionSignificates");
                });

            modelBuilder.Entity("Models.Models.DataModels.Heading", b =>
                {
                    b.Property<int>("HeadingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HeadingName");

                    b.HasKey("HeadingId");

                    b.ToTable("Headings");
                });

            modelBuilder.Entity("Models.Models.DataModels.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SectionName");

                    b.HasKey("SectionId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Models.Models.DataModels.Significative", b =>
                {
                    b.Property<int>("SignificativeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId");

                    b.Property<string>("SignificativeName");

                    b.Property<int>("SubheadingId");

                    b.HasKey("SignificativeId");

                    b.HasIndex("CountryId");

                    b.HasIndex("SubheadingId");

                    b.ToTable("Significatives");
                });

            modelBuilder.Entity("Models.Models.DataModels.Subheading", b =>
                {
                    b.Property<int>("SubheadingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeadingId");

                    b.Property<string>("SubheadingName");

                    b.HasKey("SubheadingId");

                    b.HasIndex("HeadingId");

                    b.ToTable("Subheadings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Models.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Models.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Models.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Models.ContentModels.Poll", b =>
                {
                    b.HasOne("Models.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("Models.Models.ContentModels.PollAnswer", b =>
                {
                    b.HasOne("Models.Models.ContentModels.Poll", "Poll")
                        .WithMany("Answers")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Models.DataModels.Dimension", b =>
                {
                    b.HasOne("Models.Models.DataModels.DimentionTable", "DimentionTable")
                        .WithMany()
                        .HasForeignKey("DimentionTableId");
                });

            modelBuilder.Entity("Models.Models.DataModels.DimensionTree", b =>
                {
                    b.HasOne("Models.Models.DataModels.Dimension", "Dimension")
                        .WithMany()
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Models.DataModels.ElementOfSection", b =>
                {
                    b.HasOne("Models.Models.DataModels.Section", "Section")
                        .WithMany("ElementOfSections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Models.DataModels.ElementOfSectionSignificate", b =>
                {
                    b.HasOne("Models.Models.DataModels.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Models.DataModels.ElementOfSection", "ElementOfSection")
                        .WithMany("ElementOfSectionSignificates")
                        .HasForeignKey("ElementOfSectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Models.DataModels.Significative", "Significative")
                        .WithMany("ElementOfSectionSignificates")
                        .HasForeignKey("SignificativeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Models.DataModels.Significative", b =>
                {
                    b.HasOne("Models.Models.DataModels.Country")
                        .WithMany("Significatives")
                        .HasForeignKey("CountryId");

                    b.HasOne("Models.Models.DataModels.Subheading", "Subheading")
                        .WithMany("Significatives")
                        .HasForeignKey("SubheadingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Models.DataModels.Subheading", b =>
                {
                    b.HasOne("Models.Models.DataModels.Heading", "Heading")
                        .WithMany("Subheadings")
                        .HasForeignKey("HeadingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
