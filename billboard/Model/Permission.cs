﻿using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Permission
    {
        [Key]
        public int Id_Permission { get; set; }

        public required string Permissions { get; set; }

    }
}
