﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4.PartII
{
    public class Category
    {
        [Column("CategoryId")]
        public int Id { get; set; }
        [Column("CategoryName")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
