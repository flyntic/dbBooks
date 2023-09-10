using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        public List<Book> Books { get; set; }

        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Books = _context.Books.ToList();
        }


        public  IActionResult OnPostEdit(int? id)
        {

            return RedirectToPage("/EditBook", new { id });
            //Book book = _context.Books.Where(c => c.Id == id).FirstOrDefault();
            //return RedirectToPage("/EditBook", 
            //    new { book.Name, book.Author,book.Price,book.PageCount });
        }
        
        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}