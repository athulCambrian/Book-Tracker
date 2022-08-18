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
    public class IndexModel : PageModel
    {
        private readonly Book_Tracker.Repository.booktrackerDbContext _context;

        public IndexModel(Book_Tracker.Repository.booktrackerDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.CategoryNavigation).ToListAsync();
        }
    }
}
