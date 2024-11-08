using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Paymodes
{
    public class PayCreateModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public PayCreateModel(SumpermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Paymode Paymodes { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Paymode == null || Paymodes == null)
            {
               //return Page();
            }

            _context.Paymode.Add(Paymodes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./PayIndex");
        }
    }
}
