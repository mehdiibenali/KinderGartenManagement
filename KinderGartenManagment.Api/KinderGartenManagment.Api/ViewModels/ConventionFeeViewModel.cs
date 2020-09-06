using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class ConventionFeeViewModel
    {
        public string Code { get; set; }
        public int Tarif { get; set; }
        public int ConventionId { get; set; }
    }
}
