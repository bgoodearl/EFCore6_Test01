﻿// <auto-generated />
using CU.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CU.Infrastructure.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContosoUniversity.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseID");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("ContosoUniversity.Models.Lookups.LookupBaseWith2cKey", b =>
                {
                    b.Property<short>("LookupTypeId")
                        .HasColumnType("smallint");

                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<short>("SubType")
                        .HasColumnType("smallint")
                        .HasColumnName("_SubType");

                    b.HasKey("LookupTypeId", "Code");

                    b.HasIndex("LookupTypeId", "Name")
                        .IsUnique()
                        .HasDatabaseName("LookupTypeAndName");

                    b.ToTable("xLookups2cKey", (string)null);

                    b.HasDiscriminator<short>("SubType");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Lookups.LookupType", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("BaseTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("xLookupTypes", (string)null);
                });

            modelBuilder.Entity("CourseCoursePresentationType", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<short>("CoursePresentationTypesLookupTypeId")
                        .HasColumnType("smallint");

                    b.Property<string>("CoursePresentationTypesCode")
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("CoursesCourseId", "CoursePresentationTypesLookupTypeId", "CoursePresentationTypesCode");

                    b.HasIndex("CoursePresentationTypesLookupTypeId", "CoursePresentationTypesCode");

                    b.ToTable("_coursesPresentationTypes", (string)null);
                });

            modelBuilder.Entity("ContosoUniversity.Models.Lookups.CoursePresentationType", b =>
                {
                    b.HasBaseType("ContosoUniversity.Models.Lookups.LookupBaseWith2cKey");

                    b.HasDiscriminator().HasValue((short)1);
                });

            modelBuilder.Entity("ContosoUniversity.Models.Lookups.RandomLookupType", b =>
                {
                    b.HasBaseType("ContosoUniversity.Models.Lookups.LookupBaseWith2cKey");

                    b.HasDiscriminator().HasValue((short)3);
                });

            modelBuilder.Entity("CourseCoursePresentationType", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContosoUniversity.Models.Lookups.CoursePresentationType", null)
                        .WithMany()
                        .HasForeignKey("CoursePresentationTypesLookupTypeId", "CoursePresentationTypesCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
