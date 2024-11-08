
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Security.Claims;

namespace Autenticacion.Pages.Account
{
	public class LoginModel : PageModel
	{
        /*[BindProperty]
		public Users User { get; set; }
		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
           

            if (User.Email == "correo@gmail" && User.Password == "123")
			{
				// Se crea los Claim, datos a almacenar en la Cookie
				var claims = new List<Claim>
				{
				new Claim(ClaimTypes.Name, "admin"),
				new Claim(ClaimTypes.Email, User.Email)
				};

				// Se asocia los claims creados a un nombre de una Cookie
				var identity = new ClaimsIdentity(claims, "MyCookieAuth");

				// Se agrega la identidad creada al ClaimsPrincipal de la aplicaci�n
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

				// Se registra exitosamente la autenticaci�n y se crea la cookie en el navegador
				await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
				return RedirectToPage("/Index");
			}

			return Page();
		}*/

        private readonly SumpermarketContext _context;

        public LoginModel(SumpermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users User { get; set; } = default!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Buscar el usuario en la base de datos
            var userInDb = await _context.User
                .FirstOrDefaultAsync(u => u.Email == User.Email && u.Password == User.Password);

            if (userInDb != null)
            {
                // Crear los Claims basados en los datos del usuario en la base de datos
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userInDb.Email),  // Puedes ajustar este valor seg�n la informaci�n que quieras almacenar
                new Claim(ClaimTypes.Email, userInDb.Email)
            };

                // Asociar los claims a una Cookie
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                // Agregar la identidad creada al ClaimsPrincipal
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                // Registrar la autenticaci�n y crear la cookie en el navegador
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");  // Redirigir a la p�gina principal
            }

            // Si las credenciales no son v�lidas, se muestra la p�gina actual con un error
            ModelState.AddModelError(string.Empty, "Correo o contrase�a incorrectos.");
            return Page();
        }
    }
}
