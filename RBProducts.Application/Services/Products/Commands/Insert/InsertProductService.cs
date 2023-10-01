using RBProducts.Application.Contexts;
using RBProducts.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RBProducts.Application.Services.Products.Commands.Insert
{
    public class InsertProductService : IInsertProductService
    {
        IDataBaseContext _context;
        public InsertProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public OperationResultDto<ResultInsertProductDto> Execute(RequestInsertProductDto model)
        {
            var _model = new Domain.Entities.Products.Product()
            {
                IsAvailable = model.IsAvailable,
                ManufactureEmail = model.ManufactureEmail,
                ManufacturePhone = model.ManufacturePhone,
                Name = model.Name,
                ProduceDate = model.ProduceDate,
                AppUserId = model.RequestUserID
            };
            _context.Products.Add(_model);
            var _effected = _context.SaveChanges();
            if (_effected > 0)
            {
                return OperationResultDto<ResultInsertProductDto>.Success(new ResultInsertProductDto() { Id = _model.Id });
            }
            return OperationResultDto<ResultInsertProductDto>.Fail("Error When Save Changed Exception");
        }
    }
}
