using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class ConventionViewModel
    {
        public string Name { get; set; }
        public DateTime DateDeDebut { get; set; }
        public DateTime? DateDeFin { get; set; }

    }
}
