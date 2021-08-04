using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartApartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartApartment.Application.CQRS.ProductFeature.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IAppDbContext _context;
            public GetProductByIdQueryHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (product == null) return null;
                return product;
            }
        }
    }
}
