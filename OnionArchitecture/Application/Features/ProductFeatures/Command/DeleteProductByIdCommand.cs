using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Features.ProductFeatures.Command
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProductByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = _context.Products.Find(command.Id);
                if (product == null)
                {
                    throw new KeyNotFoundException("Product not found.");
                }
                _context.Products.Remove(product);
                await _context.SaveChanges();
                return product.Id;
                ///why we are returning product.Id?
               
            }
        }
    }
}
