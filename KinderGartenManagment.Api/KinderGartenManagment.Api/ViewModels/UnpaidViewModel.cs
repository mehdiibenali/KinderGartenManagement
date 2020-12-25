using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class UnpaidViewModel
    {
        public int EleveId { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int? EnrollementId { get; set; }
        public string? EnrollementName { get; set; }
        public string? Section { get; set; }
        public int? EleveEnrollementId { get; set; }
        public string DateDeDebut { get; set; }
        public string DateDeFin { get; set; }
        public int? Paid { get; set; }
        public string? Max { get; set; }
        public string? EnrollementPaid { get; set; }
        public string? ConventionName { get; set; }
    }
}
