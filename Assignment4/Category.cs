﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    class Category
    {
        [Column("categoryid")]
        public int Id { get; set; }
        [Column("categoryname")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}