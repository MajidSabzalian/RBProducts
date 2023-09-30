using RBProducts.Common.Models;

namespace RBProducts.Application.Services.Products.Commands.Insert
{
    public interface IInsertProductService
    {
        OperationResultDto<ResultInsertProductDto> Execute(RequestInsertProductDto model);
    }
}
