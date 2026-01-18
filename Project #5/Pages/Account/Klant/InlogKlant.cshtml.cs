using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Login.Klant.Page
{
    public class LoginKlantModel : PageModel
    {
       
        [BindProperty]
        public required LoginInput Input { get; set; }

        public string? ErrorMessage { get; set; }

        public Guid SelectedCampingId { get; set; }

     
        public void OnGet()
        {
        }

        public IActionResult OnPostLogin()
        {
        
            var db = new Project__5.Pages.DataBase.DataBase();

          
            bool success = db.GetHuurderByEmailAndPassword(Input.Email!, Input.Wachtwoord!);

            if (success)
            {
                HttpContext.Session.SetString("Email", Input.Email!);
                return RedirectToPage("/Dashboard/Dashboard");
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
            return RedirectToPage("/Account/Klant/InlogKlant");
        }
    }
    //hallo

    public class LoginInput
    {
        [Required(ErrorMessage = "E-mailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [DataType(DataType.Password)]
        public string? Wachtwoord { get; set; }

  

        public bool? RememberMe { get; set; }
    }
}
