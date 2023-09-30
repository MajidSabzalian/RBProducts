using System.ComponentModel.DataAnnotations;

namespace RBProducts.Endpoint.WebAPI.Models
{
    public class SecurityRequestModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
