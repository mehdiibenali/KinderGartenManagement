using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class ParentConvention
    {
        public int ParentId { get; set; }
        public int ConventionId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateDeFin { get; set; }
        public Parent Parent { get; set; }
        public Convention Convention { get; set; }
    }
}
