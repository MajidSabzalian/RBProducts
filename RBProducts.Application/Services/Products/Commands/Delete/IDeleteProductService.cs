using RBProducts.Common.Models;

namespace RBProducts.Application.Services.Products.Commands.Delete
{
    public interface IDeleteProductService
    {
        OperationResultDto<ResultDeleteProductDto> Execute(RequestDeleteProductDto model);
    }
}
