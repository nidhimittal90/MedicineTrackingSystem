using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicinesUI.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required]
        public string MedicineName { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public DateTime? ExpiryDate { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}
