﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:ICar
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
    }
}
