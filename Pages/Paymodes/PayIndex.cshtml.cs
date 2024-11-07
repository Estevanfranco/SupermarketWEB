using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Paymodes
{
    public class PayIndexModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public PayIndexModel(SumpermarketContext context)
        {
            _context = context;
        }

        public IList<Paymode> Paymodes { get; set; } = default!;


        public async Task OnGetAsync()
        {

            if (_context.Paymode != null)
            {
                Paymodes = await _context.Paymode.ToListAsync();
            }
        }
    }
}

