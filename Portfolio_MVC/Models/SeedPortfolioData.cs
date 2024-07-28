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
                //if (context.PortfolioDetails.Any())
                //{
                //    return;
                //}
                context.PortfolioDetails.AddRange(

                    new PortfolioDetails
                    {
                        ClassName = "Physics105",
                        ClassGrade = "A",
                        Description = "Analytic Mechanics",
                        ClassDepartment = "Physics"
                        
                    },
                    new PortfolioDetails
                    {
                        ClassName = "Physics137A",
                        ClassGrade = "A",
                        Description = "Quantum Mechanics",
                        ClassDepartment= "Physics"
                    },
                    new PortfolioDetails
                    {
                        ClassName = "Compsci186",
                        ClassGrade = "A",
                        Description = "Introduction to Database Systems",
                        ClassDepartment = "CS"
                    },
                    new PortfolioDetails
                    {
                        ClassName = "Compsci162",
                        ClassGrade = "A",
                        Description = "Operating Systems and System Programming",
                        ClassDepartment = "CS"
                    },
                    new PortfolioDetails
                    {
                        ClassName = "Compsci170",
                        ClassGrade = "A",
                        Description = "Efficient Algorithms and Intractable Problems",
                        ClassDepartment = "CS"
                    },
                    new PortfolioDetails
                    {
                        ClassName = "Compsci188",
                        ClassGrade = "A",
                        Description = "Introduction to Artificial Security",
                        ClassDepartment = "CS"
                    },
                    new PortfolioDetails
                    {
                        ClassName = "Compsci161",
                        ClassGrade = "A",
                        Description = "Computer Security",
                        ClassDepartment = "CS"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
