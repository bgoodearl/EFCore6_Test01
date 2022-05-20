using ContosoUniversity.Models;
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

        }

        internal static DbContextOptions<SchoolDbContext> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SchoolDbContext>(), connectionString).Options;
        }



        #region Persistent Entities

        public DbSet<Course> Courses { get; private set; } // => Set<Course>();

        #endregion Persistent Entities
    }
}
