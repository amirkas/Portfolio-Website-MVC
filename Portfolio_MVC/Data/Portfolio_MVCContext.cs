using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio_MVC.Models;

namespace Portfolio_MVC.Data
{
    public class Portfolio_MVCContext : DbContext
    {
        public Portfolio_MVCContext (DbContextOptions<Portfolio_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Portfolio_MVC.Models.PortfolioDetails> PortfolioDetails { get; set; } = default!;
    }
}
