using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
     //   public DbSet<Product> Products { get; set; }
        Task<int> SaveChanges();
    }
}
