using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models.Lookups
{
    //[Table("xLookups10cKey")]
    public class LookupBaseWith10cKey
    {
        //[Column(Order = 1)]
        //[Key]
        [MaxLength(10)]
        //[Required]
        public string Code { get; set; } = string.Empty;

        //[Column(Order = 0)]
        //[ForeignKey("LookupType")]
        //[Index("LookupTypeAndName", 1, IsUnique = true)]
        //[Key]
        public short LookupTypeId { get; protected set; }
        public virtual LookupType LookupType { get; set; }

        //[Index("LookupTypeAndName", 2, IsUnique = true)]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public int? SortOrder { get; set; }

        public short SubType { get; protected set; } //Added with EF Core 6
    }
}
