﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class News_Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public virtual List<News_Item> Items { get; set; }
    }
}
