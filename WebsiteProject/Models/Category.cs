using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteProject.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}