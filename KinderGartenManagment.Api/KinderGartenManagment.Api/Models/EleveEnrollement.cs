using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenManagment.Api.Models
{
    public class EleveEnrollement
    {
        public int Id { get; set; }
        public int EleveId { get; set; }
        public int EnrollementId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateDeFin { get; set; }
        public string SubscriptionType { get; set; }
        public Eleve Eleve { get; set; }
        public Enrollement Enrollement { get; set; }
        public virtual ICollection<PayementEnrollement> PayementEnrollements { get; set; }
    }
}
