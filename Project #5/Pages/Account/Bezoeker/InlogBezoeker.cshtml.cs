
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Project__5.Pages.Account.Bezoeker
{
    public class Bezoeker_Inlog_Model : PageModel
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

            var db = new Project__5.Pages.DataBase.DataBase();


            bool success = db.GetHuurderByEmailAndPassword(Input.Email!, Input.Password!);

            if (success)
            {
                HttpContext.Session.SetString("UserEmail", Input.Email!);
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Ongeldige inloggegevens";
                return Page();
            }

        }
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

}

   



