using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenManagment.Api.ViewModels
{
    public class ConventionViewModel
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateDeFin { get; set; }

    }
}
