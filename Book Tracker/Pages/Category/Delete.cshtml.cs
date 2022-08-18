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
    public class DeleteModel : PageModel
    {
        private readonly Book_Tracker.Repository.booktrackerDbContext _context;

        public DeleteModel(Book_Tracker.Repository.booktrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryTable CategoryTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryTable = await _context.CategoryTables.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (CategoryTable == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryTable = await _context.CategoryTables.FindAsync(id);

            if (CategoryTable != null)
            {
                _context.CategoryTables.Remove(CategoryTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
