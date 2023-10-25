using Microsoft.EntityFrameworkCore;
using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Database
{
	public class RealEstateContext : DbContext
	{
        public RealEstateContext(DbContextOptions<RealEstateContext> options)
            :base(options)
        {
            
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
