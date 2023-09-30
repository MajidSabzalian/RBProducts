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
            if (_model != null) {
                _model.IsRemovedRecord = true;
                var _effected = _context.SaveChanges();
                if (_effected > 0)
                {
                    return OperationResultDto<ResultDeleteProductDto>.Success(new ResultDeleteProductDto() { Id = _model.Id });
                }
            }
            return OperationResultDto<ResultDeleteProductDto>.Fail("Error When Save Changed Exception");
        }
    }
}
