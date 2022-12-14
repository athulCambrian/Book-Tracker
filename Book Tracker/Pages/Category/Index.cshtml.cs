using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_Tracker.Repository;
using Book_Tracker.Repository.Models;

namespace Book_Tracker.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly Book_Tracker.Repository.booktrackerDbContext _context;

        public IndexModel(Book_Tracker.Repository.booktrackerDbContext context)
        {
            _context = context;
        }

        public IList<CategoryTable> CategoryTable { get;set; }

        public async Task OnGetAsync()
        {
            CategoryTable = await _context.CategoryTables.ToListAsync();
        }
    }
}
