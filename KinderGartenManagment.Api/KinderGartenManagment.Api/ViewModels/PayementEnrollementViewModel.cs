using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class PayementEnrollementViewModel
    {
        public string Section { get; set; }
        public int Paid { get; set; }
        public int PayementId { get; set; }
        public int? EleveEnrollementId { get; set; }
    }
}
