using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetProductsService(IDataBaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PaginationResultDto<GetProductsDto> Execute(RequestGetProductsDto model)
        {
            //var ppp = _context.Products.ToList();
            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(model.Userid) && model.Userid.Length > 0)
            {
                products = products.Where(m => m.AppUserId == model.Userid.Trim());
            }
            int rowscount = 0;
            return new PaginationResultDto<GetProductsDto>()
            {
                Items = products.ToPaged(model.Page, Consts.PageSize, out rowscount)
                    .Select(m => _mapper.Map<GetProductsDto>(m))
                    .ToList(),
                PageCount = (int)Math.Ceiling(rowscount / (double)Consts.PageSize),
                PageSize = Consts.PageSize,
                Page = model.Page,
                RowCount = rowscount
            };
        }
    }
}
