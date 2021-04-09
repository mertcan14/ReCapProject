using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class HomePageCar : ICar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int Index { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Status { get; set; }
    }
}
