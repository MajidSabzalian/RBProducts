using RBProducts.Domain.Entities.Products;
using System.ComponentModel;

namespace RBProducts.Application.Services.Products.Commands.Insert
{
    public class RequestInsertProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public ProductIsAvailable IsAvailable { get; set; }
    }
}
