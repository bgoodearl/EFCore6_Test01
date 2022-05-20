using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            });
            #endregion School Entities
        }
    }
}
