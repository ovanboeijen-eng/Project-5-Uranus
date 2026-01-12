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

        public List<Camping> Campings { get; set; } = new List<Camping>()
            {
                new Camping { Id = Guid.NewGuid(), Name = "Camping De Zon" },
                new Camping { Id = Guid.NewGuid(), Name = "Camping Het Bos" },
                new Camping { Id = Guid.NewGuid(), Name = "Camping Aan Zee" },
                new Camping { Id = Guid.NewGuid(), Name = "Les 3 Sources" }
            };

        public IActionResult OnPostLogin()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Input.Email = "admin@test.nl";
            Input.Password = "Test123!";
            if (Input.Email == "admin@test.nl" && Input.Password == "Test123!")
            {
                HttpContext.Session.SetString("UserEmail", Input.Email);

                return RedirectToPage("/Index");
            }

            else
            {
                ErrorMessage = "Ongeldige inloggegevens";
                return Page();
            }
        }

        public IActionResult OnPostSelectCamping()
        {
            if (SelectedCampingId == Guid.Empty)
            {
                ModelState.AddModelError("", "Selecteer een camping.");
                return Page();
            }

            return RedirectToPage("Index");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Account/Klant/InlogKlant");
        }
    }
    //hallo
    public class Camping
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }

    public class LoginInput
    {
        [Required(ErrorMessage = "E-mailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Selecteer een camping")]
        //public string? Camping { get; set; }
        public Guid CampingId { get; set; }



        public bool? RememberMe { get; set; }
    }
}