using RBProducts.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations;

namespace RBProducts.Endpoint.WebAPI.Models.Products
{
    public class RequestInsertModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime ProduceDate { get; set; }
        
        [Required]
        [StringLength(11)]
        public string ManufacturePhone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string ManufactureEmail { get; set; }
        
        [Required]
        public ProductIsAvailable IsAvailable { get; set; }

        public string RequestUserID { set; get; } = "";
    }
}
