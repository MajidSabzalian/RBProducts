using RBProducts.Common.Models;

namespace RBProducts.Application.Services.Products.Commands.Update
{
    public interface IUpdateProductService
    {
        OperationResultDto<ResultUpdateProductDto> Execute(RequestUpdateProductDto model);
    }
}
