using Microsoft.AspNetCore.Identity;
using RBProducts.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBProducts.Domain.Entities.ApplicationUser
{
    public class AppUser : IdentityUser
    {
        public ICollection<Product> Products { get; set; }
    }
}
