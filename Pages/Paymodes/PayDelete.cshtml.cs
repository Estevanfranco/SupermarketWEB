using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Paymodes
{
    public class PayDeleteModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public PayDeleteModel(SumpermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
         public Paymode Paymode { get; set; } = default!; 

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
            else
            {
                Paymode = paymode;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Verifica si el ID es nulo o si no hay categorías en el contexto
            if (id == null || _context.Paymode == null)
            {
                return NotFound();
            }

            // Busca la categoría con el ID especificado
            var paymode = await _context.Paymode.FindAsync(id);

            // Si la categoría no se encuentra, devuelve un error 404
            if (paymode != null)
            {

                Paymode = Paymode;
                _context.Paymode.Remove(paymode);
                await _context.SaveChangesAsync();
            }
            // Redirige a la página de índice después de eliminar la categoría
            return RedirectToPage("./PayIndex");
        }
    }
}
