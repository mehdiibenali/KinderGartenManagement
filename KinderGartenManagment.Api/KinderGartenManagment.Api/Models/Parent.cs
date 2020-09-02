using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Parent
    {
        public int Id { get; set; }
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
        public virtual ICollection<EleveParent> EleveParents { get; set; }
        public virtual ICollection<ParentConvention> ParentConventions { get; set; }
    }
}
