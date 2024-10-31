using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public DeleteModel(SumpermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Verifica si el ID es nulo o si no hay categorías en el contexto
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            // Busca la categoría con el ID especificado
            var category = await _context.Categories.FindAsync(id);

            // Si la categoría no se encuentra, devuelve un error 404
            if (category != null)
            {
                
                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }
             // Redirige a la página de índice después de eliminar la categoría
            return RedirectToPage("./Index");
        }
    }
}
