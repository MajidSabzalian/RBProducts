using RBProducts.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBProducts.Application.Services.Products.Queries.GetProducts
{
    public interface IGetProductsService
    {
        PaginationResultDto<GetProductsDto> Execute(RequestGetProductsDto model);
    }
}
