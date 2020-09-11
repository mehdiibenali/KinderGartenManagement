using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Payement
    {
        public int Id { get; set; }
        public DateTime DateDeDebut { get; set; }
        public DateTime DateDeFin { get; set; }
        public int Expected { get; set; }
        public string Paid { get; set; }
        public string Comment { get; set; }
        public int EleveEnrollementId { get; set; }
        public virtual EleveEnrollement EleveEnrollement { get; set; }
    }
}
