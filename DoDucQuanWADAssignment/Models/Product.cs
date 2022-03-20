using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoDucQuanWADAssignment.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product name")]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public string Thumbnail { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}