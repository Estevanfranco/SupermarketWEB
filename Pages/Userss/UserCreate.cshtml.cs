using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Userss
{
    public class UserCreateModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public UserCreateModel(SumpermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Users User { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.User == null || User == null)
            {
                // return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./UserIndex");
        }
    }
}
