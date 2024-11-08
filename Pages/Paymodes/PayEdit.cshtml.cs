using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Paymodes
{
    public class PayEditModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public PayEditModel(SumpermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Paymode Paymodes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Paymode == null)
            {
                return NotFound();
            }

            var paymode = await _context.Paymode.FirstOrDefaultAsync(m => m.Id == id);

            if (paymode == null)
            {
                return NotFound();
            }

            Paymodes = paymode;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Paymodes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Paymodes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./PayIndex");
        }

        private bool CategoryExists(int id)
        {
            return (_context.Paymode?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
