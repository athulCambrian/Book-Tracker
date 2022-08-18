using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Book_Tracker.Repository;
using Book_Tracker.Repository.Models;

namespace Book_Tracker.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly Book_Tracker.Repository.booktrackerDbContext _context;

        public CreateModel(Book_Tracker.Repository.booktrackerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CategoryTable CategoryTable { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategoryTables.Add(CategoryTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
