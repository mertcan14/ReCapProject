using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Color:ICar
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
