using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeasideBliss.Models;
using System.Threading.Tasks;

namespace SeasideBliss.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Name { get; set; }
            public string ContactNumber { get; set; }
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
                var userProfile = new UserProfile
                {
                    Name = Input.Name,
                    ContactNumber = Input.ContactNumber,
                    Email = Input.Email,
                    Password = Input.Password // Make sure to hash passwords securely in a real application
                };

                _context.User.Add(userProfile);
                await _context.SaveChangesAsync();

                // Set the success message to be shown on the login page
                TempData["SuccessMessage"] = "Registration successful! You can now log in securely.";

                // Redirect to the login page
                return RedirectToPage("/Login");
            }

            // If the form is invalid, return the same page with validation errors
            return Page();
        }
    }
}
