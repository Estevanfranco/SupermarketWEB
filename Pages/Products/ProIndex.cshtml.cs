using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class ProIndexModel : PageModel
    {
        private readonly  SumpermarketContext _context;

public ProIndexModel(SumpermarketContext context)
{
    _context = context;
}

public IList<Product> Products { get; set; } = default!;
       

        public async Task OnGetAsync()
           {
            
            if (_context.Products != null)
            {
                Products = await _context.Products.ToListAsync();
            }
           }
    }
}