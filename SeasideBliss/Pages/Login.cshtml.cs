using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeasideBliss.Models;

namespace SeasideBliss.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _context.User
                    .FirstOrDefaultAsync(u => u.Email == Input.Email && u.Password == Input.Password);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your details.");
                    return Page();
                }

                // Log the user in (use authentication cookies or any necessary logic)

                // Set success message
                TempData["SuccessMessage"] = "Login successful! Welcome back.";

                // Redirect to the Index page or any other page
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
