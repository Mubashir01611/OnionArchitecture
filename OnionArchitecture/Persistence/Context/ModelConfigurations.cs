using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public static class ModelConfigurations
    {
        public static void ConfigureModel( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                modelBuilder.Entity<Product>()
                    .Property(p => p.Rate)
                    .HasPrecision(18, 4);// Adjust precision and scale as needed
            });
        }
    }
}
