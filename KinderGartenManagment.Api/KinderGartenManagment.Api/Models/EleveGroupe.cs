using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class EleveGroupe
    {
        public int EleveId { get; set; }
        public int GroupeId { get; set; }
        public Eleve Eleve { get; set; }
        public Groupe Groupe { get; set; }
    }
}
