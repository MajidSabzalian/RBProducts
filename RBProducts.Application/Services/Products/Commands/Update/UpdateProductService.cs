using RBProducts.Application.Contexts;
using RBProducts.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RBProducts.Application.Services.Products.Commands.Update
{
    public class UpdateProductService : IUpdateProductService
    {
        IDataBaseContext _context;
        public UpdateProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public OperationResultDto<ResultUpdateProductDto> Execute(RequestUpdateProductDto model)
        {
            var _model = _context.Products.Find(model.Id);
            if (_model != null) {
                if (_model.AppUserId == model.RequestUserID)
                {
                    if (!_model.IsRemovedRecord)
                    {
                        _model.ManufactureEmail = model.ManufactureEmail;
                        _model.ProduceDate = model.ProduceDate;
                        _model.ManufacturePhone = model.ManufacturePhone;
                        _model.Name = model.Name;
                        _model.IsAvailable = model.IsAvailable;

                        var _effected = _context.SaveChanges();
                        if (_effected > 0)
                        {
                            return OperationResultDto<ResultUpdateProductDto>.Success(new ResultUpdateProductDto() { Id = _model.Id });
                        }
                        return OperationResultDto<ResultUpdateProductDto>.Fail("There is a problem in Saving and the operation is unsuccessful");
                    }
                    return OperationResultDto<ResultUpdateProductDto>.Fail("Your requested item has already been deleted and cannot be changed");
                }
                return OperationResultDto<ResultUpdateProductDto>.Fail("The requesting user is not allowed to change the selected record");
            }
            return OperationResultDto<ResultUpdateProductDto>.Fail("Your requested item was not found");
        }
    }
}
