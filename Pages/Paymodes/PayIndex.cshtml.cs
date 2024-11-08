using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Paymodes
{
    [Authorize]
    public class PayIndexModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public PayIndexModel(SumpermarketContext context)
        {
            _context = context;
        }

        public IList<Paymode> Paymode { get; set; } = default!;


        public async Task OnGetAsync()
        {

            if (_context.Paymode != null)
            {
                Paymode = await _context.Paymode.ToListAsync();
            }
        }
    }
}

