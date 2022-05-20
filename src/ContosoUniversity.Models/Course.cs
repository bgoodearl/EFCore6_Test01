//using ContosoUniversity.Models.Lookups;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Course
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Course()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public Course(int courseID, string title)
        {
            CourseID = courseID;
            Title = title;
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        //private ICollection<CoursePresentationType>? _coursePresentationTypes;
        //public virtual ICollection<CoursePresentationType> CoursePresentationTypes
        //{
        //    get { return _coursePresentationTypes ?? (_coursePresentationTypes = new List<CoursePresentationType>()); }
        //    protected set { _coursePresentationTypes = value; }
        //}

    }
}