﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class PayementViewModel
    {
        public int ReceiptNumber { get; set; }
        public ICollection<PayementEnrollementViewModel> PayementEnrollementModels { get; set; }
        public ICollection<ModaliteViewModel> ModaliteModels { get; set; }

    }
}
