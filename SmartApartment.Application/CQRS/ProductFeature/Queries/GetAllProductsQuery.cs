using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartApartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartApartment.Application.CQRS.ProductFeature.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IAppDbContext _context;
            public GetAllProductsQueryHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
