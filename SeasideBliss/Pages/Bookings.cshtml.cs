using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeasideBliss.Models;
using System.Threading.Tasks;

namespace SeasideBliss.Pages
{
    public class BookingsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BookingsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Destination { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public int NumberOfAdults { get; set; }
            public int NumberOfChildren { get; set; }
            public string Accommodation { get; set; }
            public string UserEmail { get; set; }  // Capture the user's email
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var booking = new Booking
                {
                    Destination = Input.Destination,
                    CheckInDate = Input.CheckInDate,
                    CheckOutDate = Input.CheckOutDate,
                    NumberOfAdults = Input.NumberOfAdults,
                    NumberOfChildren = Input.NumberOfChildren,
                    AccommodationType = Input.Accommodation,
                    UserEmail = Input.UserEmail  // Save the email to the database
                };

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                // Set the success message
                TempData["SuccessMessage"] = "Your booking was successful! Feel free to explore our gallery.";

                // Redirect to the gallery page
                return RedirectToPage("/Gallery");
            }

            // Return the page with any validation errors
            return Page();
        }
    }
}
