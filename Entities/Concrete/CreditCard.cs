using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:ICar
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreditNumber { get; set; }
        public string NameOnCard { get; set; }
        public string CardCvv { get; set; }
    }
}
