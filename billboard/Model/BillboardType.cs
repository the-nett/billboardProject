﻿using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class BillboardType
    {
        [Key]
        public int BillboardTypeId { get; set; }
        public  required string BillboardTypet { get; set; }

        public bool StateDelete { get; set; }

        // Navigation
        public ICollection<Billboard> BillboardType_Billboard { get; } = new List<Billboard>();
        
    }
}
