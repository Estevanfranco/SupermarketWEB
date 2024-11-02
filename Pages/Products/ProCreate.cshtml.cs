using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class ProCreateModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public ProCreateModel(SumpermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || product == null)
            {
               // return Page();
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ProIndex");
        }
    }
}
