using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Chess_club_web_app.Data;
using Chess_club_web_app.Models;

namespace Chess_club_web_app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Chess_club_web_app.Data.Context _context;

        public IndexModel(Chess_club_web_app.Data.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (Student.Email != null)
            {
                _context.Students.Add(Student);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Index");
        }
    }
}
