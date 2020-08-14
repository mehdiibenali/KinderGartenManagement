using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Eleve
    {
        public int Id { get; set; }
        public string Prénom { get; set; }
        public string Nom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string LieuDeNaissance { get; set; }
        public string Adresse { get; set; }
        public string Sexe { get; set; }
    }
}
