using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class SearchEnrollementViewModel
    {
        public string? EnrollementSearch { get; set; }
        public int? EleveId { get; set; }
        public int? ClasseId { get; set; }
        public int? Year { get; set; }
    }
}
