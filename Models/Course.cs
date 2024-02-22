using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace uppgift1
{
    public class Course
    {
        [Key]
        public int Id { get; set; } 
        [Required (ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
    }
}