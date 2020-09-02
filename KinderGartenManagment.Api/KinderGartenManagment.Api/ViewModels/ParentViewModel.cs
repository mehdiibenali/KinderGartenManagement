using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class ParentViewModel
    {
        public string Prenom { get; set; }
        public string NomDeFamille { get; set; }
        public int NCin { get; set; }
        public string Profession { get; set; }
        public string Employeur { get; set; }
        public string Matricule { get; set; }
        public int Tel1 { get; set; }
        public int Tel2 { get; set; }
        public int Tel3 { get; set; }
        public string AdresseMail { get; set; }
    }
}
