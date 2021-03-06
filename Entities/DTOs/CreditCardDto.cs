﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CreditCardDto:IDto
    {
        public int totalPrice { get; set; }
        public int customerId { get; set; }
        public string creditNumber { get; set; }
        public string nameOnCard { get; set; }
        public string cardCVV { get; set; }
    }
}
