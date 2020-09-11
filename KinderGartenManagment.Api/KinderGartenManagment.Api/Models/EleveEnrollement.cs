using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class EleveEnrollement
    {
        public int EleveId { get; set; }
        public int EnrollementId { get; set; }

        public DateTime DateDeDebut { get; set; }
        public DateTime? DateDeFin { get; set; }
        public string SubscriptionType { get; set; }
        public Eleve Eleve { get; set; }
        public Enrollement Enrollement { get; set; }
    }
}
