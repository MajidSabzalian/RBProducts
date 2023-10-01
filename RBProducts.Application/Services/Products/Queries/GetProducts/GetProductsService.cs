using RBProducts.Application.Common;
using RBProducts.Application.Contexts;
using RBProducts.Common;
using RBProducts.Common.Models;
using System.Data;

namespace RBProducts.Application.Services.Products.Queries.GetProducts
{
    public class GetProductsService : IGetProductsService
    {
        private readonly IDataBaseContext _context;
        public GetProductsService(IDataBaseContext context)
        {
            _context = context;
        }

        public PaginationResultDto<GetProductsDto> Execute(RequestGetProductsDto model)
        {
            //var ppp = _context.Products.ToList();
            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(model.Userid) && model.Userid.Length > 0)
            {
                products = products.Where(m => m.AppUserId == model.Userid);
            }
            int rowscount = 0 , pagecount = 0;
            return new PaginationResultDto<GetProductsDto>()
            {
                Items = products.ToPaged(model.Page, Consts.PageSize, out rowscount).Select(m => new GetProductsDto
                {
                    Id = m.Id,
                    IsAvailable = m.IsAvailable,
                    ManufactureEmail = m.ManufactureEmail,
                    ManufacturePhone = m.ManufacturePhone,
                    ProduceDate = m.ProduceDate,
                    Name = m.Name
                }).ToList(),
                PageCount = (int)Math.Ceiling(rowscount / (double)Consts.PageSize),
                PageSize = Consts.PageSize,
                Page = model.Page,
                RowCount = rowscount
            };
        }
    }
}
