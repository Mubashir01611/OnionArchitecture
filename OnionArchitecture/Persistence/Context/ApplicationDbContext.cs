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
        public DbSet<User> users { get; set; }
        public DbSet<User> Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<int> SaveChanges()
        {
                return await base.SaveChangesAsync();
        }
    }
}
