using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoDucQuanWADAssignment.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category name")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}