using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages
{
    [BindProperties(SupportsGet = true)]
    public class EditBookModel : PageModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }

        private readonly AppDbContext _context;

        public EditBookModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [BindProperty]
        public Book bookToEdit { get; set; }
        public void OnGet()
        {
            bookToEdit = _context.Books.Where(b => b.Id == id).FirstOrDefault();
            Name = bookToEdit.Name;
            Author = bookToEdit.Author;
            Price = bookToEdit.Price;
            PageCount = bookToEdit.PageCount;
        }

        public IActionResult OnPostUpdate(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                book.Name = Name;
                book.Author = Author;
                book.PageCount = PageCount;
                book.Price = Price;
                _context.SaveChanges();

            }
            return RedirectToPage("Index");

        }

    }
}
