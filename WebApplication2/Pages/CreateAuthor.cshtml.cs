using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.Data;
using WebApplication2.Model;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Pages
{
    [BindProperties]
    public class CreateAuthorModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateAuthorModel(AppDbContext context)
        {
            _context = context;
        }

        [Required(ErrorMessage ="Название обязательно к заполнению")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name ="Имя автора:")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия:")]
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Description { get; set; }
        
        public Author newAuthor { get; set; }
        public IActionResult OnPost()
        {
            
            newAuthor = new Author() { 
                FirstName = FirstName,
                LastName = LastName,
                Birthdate = BirthDate,
                Description = Description
            };

            _context.Add(newAuthor);
            _context.SaveChanges();
            return RedirectToPage("/Authors");
        }
    }
}
