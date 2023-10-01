using RBProducts.Application.Contexts;
using RBProducts.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RBProducts.Application.Services.Products.Commands.Delete
{
    public class DeleteProductService : IDeleteProductService
    {
        IDataBaseContext _context;
        public DeleteProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public OperationResultDto<ResultDeleteProductDto> Execute(RequestDeleteProductDto model)
        {
            var _model = _context.Products.Find(model.Id);
            if (_model != null)
            {
                if (_model.UserId == model.RequestUserID)
                {
                    _model.IsRemovedRecord = true;
                    var _effected = _context.SaveChanges();
                    if (_effected > 0)
                    {
                        return OperationResultDto<ResultDeleteProductDto>.Success(new ResultDeleteProductDto() { Id = _model.Id });
                    }
                    return OperationResultDto<ResultDeleteProductDto>.Fail("There is a problem in Saving and the operation is unsuccessful");
                }
                return OperationResultDto<ResultDeleteProductDto>.Fail("The requesting user is not allowed to change the selected record");
            }
            return OperationResultDto<ResultDeleteProductDto>.Fail("Your requested item was not found");
        }
    }
}
