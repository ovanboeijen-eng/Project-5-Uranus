using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Account.LoginPage.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public required LoginInput Input { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            if (Input.Email == "admin@test.nl" && Input.Password == "Test123!")
            {
               
                HttpContext.Session.SetString("UserEmail", Input.Email);

                return RedirectToPage("/Index"); // Of een dashboard pagina
            }
            else
            {
                ErrorMessage = "Ongeldige inloggegevens";
                return Page();
            }
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }

    public class LoginInput
    {
        [Required(ErrorMessage = "E-mailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool? RememberMe { get; set; }
    }
}