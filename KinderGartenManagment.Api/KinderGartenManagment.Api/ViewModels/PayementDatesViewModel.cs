using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class PayementDatesViewModel
    {
        public DateTime DateDeDebut { get; set; }
        public DateTime DateDeFin { get; set; }
        public int PayementEnrollementId { get; set; }
    }
}
