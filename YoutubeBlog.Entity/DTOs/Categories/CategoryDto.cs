﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeBlog.Entity.DTOs.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
       public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
            public bool IsDeleted { get; set; }
    }
}
