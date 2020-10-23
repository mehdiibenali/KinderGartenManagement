using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class PayementEnrollementViewModel
    {
        public string Section { get; set; }
        public int Paid { get; set; }
        public int? EleveEnrollementId { get; set; }
        public int? EleveId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeFin { get; set; }
    }
}
