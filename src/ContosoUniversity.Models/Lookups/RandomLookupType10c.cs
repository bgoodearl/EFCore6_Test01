using static ContosoUniversity.Models.Constants;

namespace ContosoUniversity.Models.Lookups
{
    public class RandomLookupType10c : LookupBaseWith10cKey
    {
        public RandomLookupType10c()
        {
            LookupTypeId = (short)CULookupTypes.RandomLookupType10c;
        }
    }
}
