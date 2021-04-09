using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class HomePageCarManagerDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int Index { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Status { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public double DailyPrice { get; set; }
    }
}
