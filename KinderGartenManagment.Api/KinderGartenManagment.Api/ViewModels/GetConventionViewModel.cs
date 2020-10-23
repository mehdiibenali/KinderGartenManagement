using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenManagment.Api.ViewModels
{
    public class GetConventionViewModel
    {
        public int ParentId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateTime { get; set; }
    }
}
