using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenManagment.Api.ViewModels
{
    public class ParentConventionViewModel
    {
        public int ParentId { get; set; }
        public int ConventionId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateDeFin { get; set; }
    }
}
