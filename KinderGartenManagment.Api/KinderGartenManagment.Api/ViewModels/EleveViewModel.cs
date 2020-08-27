using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class EleveViewModel
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string DateDeNaissance { get; set; }
        public string LieuDeNaissance { get; set; }
        public string Adresse { get; set; }
        public string Sexe { get; set; }
    }
}
