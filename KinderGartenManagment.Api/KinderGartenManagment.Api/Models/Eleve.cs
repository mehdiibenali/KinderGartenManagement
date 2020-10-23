using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Eleve
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string DateDeNaissance { get; set; }
        public string LieuDeNaissance { get; set; }
        public string Adresse { get; set; }
        public string Sexe { get; set; }
        public virtual ICollection<EleveParent> EleveParents { get; set; }
        public virtual ICollection<EleveEnrollement> EleveEnrollements { get; set; }
        public virtual ICollection<PayementEnrollement> PayementEnrollements { get; set; }
    }
}
