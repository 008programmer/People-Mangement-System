using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class PeopleRelation
    {

        public int Id { get; set; }

        public int RelationTypeId { get; set; }

        public RelationType RelationType { get; set; }

        public int? InRelationTime { get; set; }

        public int? RelationQuality { get; set; }

    }
}