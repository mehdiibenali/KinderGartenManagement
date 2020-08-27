using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class GroupeViewModel
    {
        public string Name { get; set; }
        public string DateDeDebut { get; set; }
        public string DateDeFin { get; set; }
        public int ClasseId { get; set; }
    }
}
