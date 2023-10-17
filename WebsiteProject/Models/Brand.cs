using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteProject.Models
{
    public class Brand
    {
        [Key]
        public long BrandId { get; set; }
        public string BrandName { get; set; }
    }
}