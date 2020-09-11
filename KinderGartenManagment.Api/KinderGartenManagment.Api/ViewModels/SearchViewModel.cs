using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class SearchViewModel
    {
        public string? Enrollementsearch { get; set; }
        public List<int?> annees { get; set; }
        public int? classeid { get; set; }
    }
}
