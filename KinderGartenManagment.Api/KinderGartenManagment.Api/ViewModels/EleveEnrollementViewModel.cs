using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class EleveEnrollementViewModel
    {
        public int EleveId { get; set; }
        public int EnrollementId { get; set; }
        public DateTime DateDeDebut { get; set; }
        public DateTime DateDeFin { get; set; }
        public string SubscriptionType { get; set; }
    }
}
