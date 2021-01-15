using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class GetElevesByEnrollementIdAndMonthViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int EnrollementId { get; set; }
    }
}
