using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_Tracker.Repository;
using Book_Tracker.Repository.Models;

namespace Book_Tracker.Pages.Category
{
    public class EditModel : PageModel
    {
        private readonly Book_Tracker.Repository.booktrackerDbContext _context;

        public EditModel(Book_Tracker.Repository.booktrackerDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategoryTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryTableExists(CategoryTable.CategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryTableExists(int id)
        {
            return _context.CategoryTables.Any(e => e.CategoryId == id);
        }
    }
}
