using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages
{
    public class AuthorsModel : PageModel
    {
        public List<Author> Authors { get; set; };

        private readonly AppDbContext _context;
        public AuthorsModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Authors = _context.Authors.ToList();
        }


        public  IActionResult OnPostEdit(int? id)
        {

            return RedirectToPage("/EditAuthor", new { id });
            //Book book = _context.Books.Where(c => c.Id == id).FirstOrDefault();
            //return RedirectToPage("/EditBook", 
            //    new { book.Name, book.Author,book.Price,book.PageCount });
        }
        
        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            var book = await _context.Authors.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Authors.Remove(book);
            _context.SaveChanges();
            return RedirectToPage("Authors");
        }
    }
}