using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.Data;
using WebApplication2.Model;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Pages
{
    [BindProperties]
    public class CreateBookModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateBookModel(AppDbContext context)
        {
            _context = context;
        }

        [Required(ErrorMessage ="Название обязательно к заполнению")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name ="Название книги:")]
        public string BookName { get; set; }

        [Required]
        [Display(Name = "Стоимость книги:")]
        public decimal BookPrice { get; set; }
        public string BookAuthor { get; set; }
        public int Pages { get; set; }
        
        public Book newBook { get; set; }
        public IActionResult OnPost()
        {
            
            newBook = new Book() { 
                Name = BookName,
                Price = BookPrice,
                Author = BookAuthor,
                PageCount = Pages
            };

            _context.Add(newBook);
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
