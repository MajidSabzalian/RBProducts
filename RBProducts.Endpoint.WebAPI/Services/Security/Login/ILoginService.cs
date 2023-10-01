namespace RBProducts.Endpoint.WebAPI.Services.Security.Login
{
    public interface ILoginService
    {
        Task<ResultLoginDto> ExecuteAsync(RequestLoginDto model);
    }
}
