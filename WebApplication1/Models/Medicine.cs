using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicinesTracking.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}
