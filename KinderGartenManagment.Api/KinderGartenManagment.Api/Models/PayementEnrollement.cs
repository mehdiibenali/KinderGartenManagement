using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenManagment.Api.Models
{
    public class PayementEnrollement
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public int Paid { get; set; }
        public int PayementId { get; set; }
        public int? EleveId { get; set; }
        public int? EleveEnrollementId { get; set; }
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeDebut { get; set; }
        [DataType(DataType.Date)]

        public DateTime DateDeFin { get; set; }
        public virtual Payement Payement { get; set; }
        public virtual Eleve Eleve { get; set; }
        public virtual EleveEnrollement EleveEnrollement { get; set; }
    }
}
