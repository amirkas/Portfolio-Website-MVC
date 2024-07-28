using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio_MVC.Data;
using Portfolio_MVC.Models;




namespace Portfolio_MVC.Controllers
{
    public class ResumeController : Controller
    {

        private IWebHostEnvironment _hostEnvironement;
        private readonly Portfolio_MVCContext _context;


        public ResumeController(IWebHostEnvironment environment, Portfolio_MVCContext context)
        {
            _hostEnvironement = environment;
            _context = context;
        }

        public async Task<IActionResult> Index(string? class_1, string? class_2)
        {
            
            if (String.IsNullOrEmpty(class_1) && String.IsNullOrEmpty(class_2))
            {
                return View(new List<Portfolio_MVC.Models.PortfolioDetails>());
                
            }
            
            var classes = from c in _context.PortfolioDetails select c;
            if (String.IsNullOrEmpty(class_2))
            {
                classes = classes.Where(s => s.ClassDepartment.ToUpper().Contains(class_1.ToUpper()));
            }
            else
            {
                classes = classes.Where(s => s.ClassDepartment.ToUpper().Contains(class_1.ToUpper()) || s.ClassDepartment.ToUpper().Contains(class_2.ToUpper()));
            }
            
            

            return View(await classes.ToListAsync());
        }

        public IActionResult GetResumePDF()
        {
            string resumeFilePath = Path.Combine(_hostEnvironement.WebRootPath, "files/documents/Amir_Abdou_Resume.pdf");
            var fileStream = new FileStream(resumeFilePath, FileMode.Open, FileAccess.Read);
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }

        



    }
}
