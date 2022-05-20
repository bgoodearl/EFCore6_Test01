using ContosoUniversity.Models;
using ContosoUniversity.Models.Lookups;
using Microsoft.EntityFrameworkCore;

namespace CU.Infrastructure.Persistence
{
    public partial class SchoolDbContext : DbContext //SchoolDbContext.cs
    {
        public SchoolDbContext(DbContextOptions options)
            : base(options)
        {
            InitializeDbSets();
        }


        /// <summary>
        /// InitializeDbSets - using lamda expressions for initializing DbSets
        /// caused problems after handling exception
        /// </summary>
        private void InitializeDbSets()
        {
            #region Persistent Entities

            Courses = Set<Course>();

            #endregion Persistent Entities


            #region Lookups

            LookupsWith2cKey = Set<LookupBaseWith2cKey>();
            LookupTypes = Set<LookupType>();

            CoursePresentationTypes = Set<CoursePresentationType>();
            RandomLookupTypes = Set<RandomLookupType>();

            #endregion Lookups
        }

        internal static DbContextOptions<SchoolDbContext> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SchoolDbContext>(), connectionString).Options;
        }



        #region Persistent Entities

        public DbSet<Course> Courses { get; private set; } // => Set<Course>();

        #endregion Persistent Entities


        #region Lookups

        public DbSet<LookupBaseWith2cKey> LookupsWith2cKey { get; private set; }
        public DbSet<LookupType> LookupTypes { get; private set; }

        public DbSet<CoursePresentationType> CoursePresentationTypes { get; private set; }
        public DbSet<RandomLookupType> RandomLookupTypes { get; private set; }

        #endregion Lookups

    }
}
