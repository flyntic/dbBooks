using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages
{
    [BindProperties(SupportsGet = true)]
    public class EditAuthorModel : PageModel
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Description { get; set; }

        private readonly AppDbContext _context;

        public EditAuthorModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [BindProperty]
        public Author authorToEdit { get; set; }
        public void OnGet()
        {
            authorToEdit = _context.Authors.Where(b => b.Id == id).FirstOrDefault();
            FirstName = authorToEdit.FirstName;
            LastName = authorToEdit.LastName;
            BirthDate = authorToEdit.Birthdate;
            Description= authorToEdit.Description;
        }

        public IActionResult OnPostUpdate(int id)
        {
            Author author = _context.Authors.FirstOrDefault(b => b.Id == id);
            if (author != null)
            {
                author.FirstName = FirstName;
                author.LastName = LastName;
                author.Birthdate = BirthDate;
                author.Description = Description;
                _context.SaveChanges();

            }
            return RedirectToPage("Authors");

        }

    }
}
