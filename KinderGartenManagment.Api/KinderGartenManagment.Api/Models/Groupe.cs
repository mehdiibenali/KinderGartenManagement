using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateDeDebut { get; set; }
        public string DateDeFin { get; set; }
        public int ClasseId { get; set; }
        public virtual Classe Classe { get; set; }
        public virtual ICollection<EleveGroupe> EleveGroupes { get; set; }
    }
}
