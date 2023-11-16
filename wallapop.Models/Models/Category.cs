﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallapop.Models.Enums;

namespace wallapop.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public CategoryEnum CategoryEnum { get; set; }
    }
}
