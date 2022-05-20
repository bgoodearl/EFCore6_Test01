using static ContosoUniversity.Models.Constants;

namespace ContosoUniversity.Models.Lookups
{
    public class CourseTopicType : LookupBaseWith10cKey
    {
        public CourseTopicType()
        {
            LookupTypeId = (short)CULookupTypes.CourseTopicType;
        }

        private ICollection<Course>? _courses;
        public virtual ICollection<Course> Courses
        {
            get { return _courses ?? (_courses = new List<Course>()); }
            protected set { _courses = value; }
        }
    }
}
