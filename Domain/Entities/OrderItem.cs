﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem

    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal Quautity { get; set; }
        public string Unit { get; set; }
    }
}
