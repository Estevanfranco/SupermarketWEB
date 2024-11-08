using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Userss
{
    public class UserIndexModel : PageModel
    {
        private readonly SumpermarketContext _context;

        public UserIndexModel(SumpermarketContext context)
        {
            _context = context;
        }
     
        public IList<Users> Users { get; set; } = default!;


        public async Task OnGetAsync()
        {

            if (_context.User != null)
            {
                Users = await _context.User.ToListAsync();
            }
        }
    }
}
