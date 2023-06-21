using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Ecommerce.Models
{
    public class Category
    {

        [Key]
        
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30 , ErrorMessage = "The Category name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Display order Field is Required")]
        [DisplayName("Display Order")]
        [Range(1,100 , ErrorMessage = "Please Insert Display order must be between 1 and 100 ") ]
        
        public int DisplayOrder { get; set; }
    }
}
