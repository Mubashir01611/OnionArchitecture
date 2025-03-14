using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
         

        

        public DbSet<Product> Products { get; set; }

       public async Task<int> SaveChanges()
        {
                return await base.SaveChangesAsync();
        }
    }
}
