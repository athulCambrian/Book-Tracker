using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_Tracker.Repository;
using Book_Tracker.Repository.Models;

namespace Book_Tracker.Pages.myBook
{
    public class DetailsModel : PageModel
    {
        private readonly Book_Tracker.Repository.booktrackerDbContext _context;

        public DetailsModel(Book_Tracker.Repository.booktrackerDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.CategoryNavigation).FirstOrDefaultAsync(m => m.BookId == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
