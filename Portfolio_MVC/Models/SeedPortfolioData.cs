using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio_MVC.Data;
using System;
using System.Linq;

namespace Portfolio_MVC.Models
{
    public class SeedPortfolioData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context= new Portfolio_MVCContext(
                serviceProvider.GetRequiredService<DbContextOptions<Portfolio_MVCContext>>()))
            {
                if (context.PortfolioDetails.Any())
                {
                    return;
                }
                context.PortfolioDetails.AddRange(

                    new PortfolioDetails
                    {
                        ClassName = "Physics105",
                        ClassGrade = "A",
                        Description = "Analytic Mechanics"
                    },
                    new PortfolioDetails
                    {
                        ClassName = "Physics137A",
                        ClassGrade = "A",
                        Description = "Quantum Mechanics"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
