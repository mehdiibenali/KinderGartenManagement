using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class ParentConventionViewModel
    {
        public int ParentId { get; set; }
        public int ConventionId { get; set; }
        public DateTime DateDeDebut { get; set; }
        public DateTime? DateDeFin { get; set; }
        public bool Active { get; set; }
    }
}
