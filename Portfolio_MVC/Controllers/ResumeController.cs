using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Portfolio_MVC.Models;
using System.Diagnostics;
using System.Text;




namespace Portfolio_MVC.Controllers
{
    public class ResumeController : Controller
    {

        private IWebHostEnvironment _hostEnvironement;

        public ResumeController(IWebHostEnvironment environment)
        {
            _hostEnvironement = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
        {
            string resumeFilePath = Path.Combine(_hostEnvironement.WebRootPath, "files/documents/Amir_Abdou_Resume.pdf");
            var fileStream = new FileStream(resumeFilePath, FileMode.Open, FileAccess.Read);
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            
           
            return fsResult;
        }
        
    }
}
