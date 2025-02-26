using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeownerApp.Models; // Reference the Models namespace
using HomeownerApp.Data;   // Reference the Data namespace

namespace HomeownerApp.Pages.Account // Add a namespace for the Account folder
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User
            {
                Username = Username,
                Email = Email,
                Password = Password // In a real app, hash the password!
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToPage("/Account/Login");
        }
    }
}