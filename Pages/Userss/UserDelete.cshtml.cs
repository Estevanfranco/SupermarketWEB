using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Userss
{
    public class UserDeleteModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public UserDeleteModel(SumpermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var Users = await _context.User.FirstOrDefaultAsync(m => m.Id == id);

            if (Users == null)
            {
                return NotFound();
            }
            else
            {
                User = Users;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Verifica si el ID es nulo o si no hay categor�as en el contexto
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            // Busca la categor�a con el ID especificado
            var Users = await _context.User.FindAsync(id);

            // Si la categor�a no se encuentra, devuelve un error 404
            if (Users != null)
            {

                User = Users;
                _context.User.Remove(User);
                await _context.SaveChangesAsync();
            }
            // Redirige a la p�gina de �ndice despu�s de eliminar la categor�a
            return RedirectToPage("./UserIndex");
        }
    }
}
