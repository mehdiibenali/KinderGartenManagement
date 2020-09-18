using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class SearchConventionViewModel
    {
        public string? Name { get; set; }
        public List<int?> annees { get; set; }
    }
}
