using ContosoUniversity.Models;
using ContosoUniversity.Models.Lookups;
using Microsoft.EntityFrameworkCore;
using static ContosoUniversity.Models.Constants;

namespace CU.Infrastructure.Persistence
{
    public partial class SchoolDbContext //SchoolDbContext2.cs
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region School Entities

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(c => c.CourseID);
                e.Property(c => c.CourseID).ValueGeneratedNever();
                e.ToTable("Course");

                e.HasMany(e => e.CoursePresentationTypes).WithMany(p => p.Courses)
                    .UsingEntity(
                        join => join.ToTable("_coursesPresentationTypes")
                            .Property<int>("CoursesCourseId").HasColumnName("CourseID")
                    );
            });
            #endregion School Entities


            //*******************************************
            #region LookupBaseWith2cKey Subclass Mappings

            modelBuilder.Entity<LookupType>(e =>
            {
                e.HasKey(x => x.Id);
                e.ToTable("xLookupTypes");
            });

            modelBuilder.Entity<LookupBaseWith2cKey>(e =>
            {
                e.HasKey(l => new { l.LookupTypeId, l.Code });
                e.ToTable("xLookups2cKey");

                e.Property(x => x.Code).HasMaxLength(2).IsRequired();
                e.Property(x => x.Name).HasMaxLength(100).IsRequired();

                e.HasIndex(l => new { l.LookupTypeId, l.Name }).IsUnique(true)
                    .HasDatabaseName("LookupTypeAndName");

                e.Property(l => l.SubType).HasColumnName("_SubType");

                e.HasDiscriminator<short>(x => x.SubType)
                    .HasValue<CoursePresentationType>((short)CULookupTypes.CoursePresentationType)
                    .HasValue<RandomLookupType>((short)CULookupTypes.RandomLookupType)
                ;

            });

            #endregion LookupBaseWith2cKey Subclass Mappings
        }
    }
}
