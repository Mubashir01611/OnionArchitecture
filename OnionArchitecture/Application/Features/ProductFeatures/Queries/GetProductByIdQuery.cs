using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>///what is the purpose of IRequest<Product>? how to diff when to pass IRequest<List<Product>> and when to pass IRequest<int>?
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IApplicationDbContext _context;
            public GetProductByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                //var product = await _context.Products.FirstOrDefault(query.Id);
                var product =  _context.Products.Where(p => p.Id == query.Id).FirstOrDefault();
                ///why we are using Where() instead of FirstOrDefault()?
                /// why we are adding condition ?
                if (product == null)
                {
                    throw new KeyNotFoundException("Product Detail not found.");
                }
                return product;
            }
        }
    }
}
