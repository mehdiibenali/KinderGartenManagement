using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class ModaliteViewModel
    {
        public int Amount { get; set; }
        public string Method { get; set; }
        public string Bank { get; set; }
        public int? CheckNumber { get; set; }
        public string Comment { get; set; }
        public int PayementId { get; set; }
    }
}
