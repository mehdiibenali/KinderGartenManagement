using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Enrollement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeFin { get; set; }
        public int? ClasseId { get; set; }
        public int? Fee { get; set; }

        public virtual Classe Classe { get; set; }  
        public virtual ICollection<EleveEnrollement> EleveEnrollements { get; set; }
    }
}
