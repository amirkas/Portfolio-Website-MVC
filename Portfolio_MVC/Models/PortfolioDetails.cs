using System.ComponentModel.DataAnnotations;

namespace Portfolio_MVC.Models
{
    public class PortfolioDetails
    {
        public int Id { get; set; }
        public string? ClassName { get; set; }
        public string? ClassGrade { get; set; } 
        public string? Description { get; set; } 
        public string? ClassDepartment {  get; set; }
    }
}
