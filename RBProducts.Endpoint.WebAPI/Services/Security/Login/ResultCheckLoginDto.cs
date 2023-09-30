namespace RBProducts.Endpoint.WebAPI.Services.Security.Login
{
    public class ResultCheckLoginDto
    {
        public string token { set; get; }
        public DateTime expiration { set; get; }
    }
}
