using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_Tracker.Repository;
using Book_Tracker.Repository.Models;

namespace Book_Tracker.Pages.Type
{
    public class DetailsModel : PageModel
    {
        private readonly Book_Tracker.Repository.booktrackerDbContext _context;

        public DetailsModel(Book_Tracker.Repository.booktrackerDbContext context)
        {
            _context = context;
        }

        public CategoryType CategoryType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryType = await _context.CategoryTypes.FirstOrDefaultAsync(m => m.CategoryTypeId == id);

            if (CategoryType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
