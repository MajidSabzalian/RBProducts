namespace RBProducts.Endpoint.WebAPI.Services.Security.Login
{
    public interface ICheckLoginService
    {
        Task<ResultCheckLoginDto> ExecuteAsync(RequestCheckLoginDto model);
    }
}
