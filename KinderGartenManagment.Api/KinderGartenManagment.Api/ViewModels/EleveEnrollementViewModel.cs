using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenManagment.Api.ViewModels
{
    public class EleveEnrollementViewModel
    {
        public int EleveId { get; set; }
        public int EnrollementId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeFin { get; set; }
        public string SubscriptionType { get; set; }
    }
}
