using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.ViewModels
{
    public class CreateOrEditViewModel
    {

        public Person Person { get; set; }

        public IEnumerable<RelationType> RelationTypes { get; set; }

    }
}