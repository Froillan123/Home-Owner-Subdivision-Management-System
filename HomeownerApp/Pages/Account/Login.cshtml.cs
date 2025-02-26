using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeownerApp.Models; // Reference the Models namespace
using HomeownerApp.Data;   // Reference the Data namespace

namespace HomeownerApp.Pages.Account // Add a namespace for the Account folder
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            // In a real app, use authentication cookies or tokens here
            return RedirectToPage("/Index");
        }
    }
}