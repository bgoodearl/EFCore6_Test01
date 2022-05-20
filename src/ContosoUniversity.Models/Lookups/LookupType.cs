﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ContosoUniversity.Models.Constants;

namespace ContosoUniversity.Models.Lookups
{
    public class LookupType
    {
        public LookupType()
        {
        }

        private LookupType(CULookupTypes cLookupType, Type lookupType)
        {
            Id = (short)cLookupType;
            CLookupType = cLookupType;
            TypeName = lookupType.Name;
            if ((lookupType.BaseType == null) || lookupType.BaseType.Name.Equals(typeof(Object).Name))
                BaseTypeName = lookupType.Name;
            else
                BaseTypeName = lookupType.BaseType.Name;
        }


        private static List<LookupType>? _lookupTypesList = null;

        public static List<LookupType> LookupTypesList
        {
            get
            {
                if (_lookupTypesList == null)
                {
                    _lookupTypesList = new List<LookupType>()
                    {
                        new LookupType(CULookupTypes.CoursePresentationType, typeof(CoursePresentationType)), //1
                        new LookupType(CULookupTypes.RandomLookupType, typeof(RandomLookupType)), //3
                        new LookupType(CULookupTypes.CourseTopicType, typeof(CourseTopicType)),
                        new LookupType(CULookupTypes.RandomLookupType10c, typeof(RandomLookupType10c)),
                    };
                }
                return _lookupTypesList;
            }
        }

        public static LookupType? GetLookupType(CULookupTypes lookupType)
        {
            return LookupTypesList.Where(lt => lt.CLookupType == lookupType).FirstOrDefault();
        }

        public static CULookupTypes? GetLookupType(short lookupTypeId)
        {
            CULookupTypes? lookupType = null;
            if (typeof(CULookupTypes).IsEnumDefined(lookupTypeId))
                lookupType = (CULookupTypes)lookupTypeId;

            return lookupType;
        }

        public static List<LookupType> GetDbInitializationList()
        {
            return LookupTypesList;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Id { get; protected set; }

        [NotMapped]
        public CULookupTypes CLookupType { get; protected set; }

        [MaxLength(50)]
        [Required]
        public string TypeName { get; protected set; }

        [MaxLength(50)]
        [Required]
        public string BaseTypeName { get; protected set; }

    }
}
