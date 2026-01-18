using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Project__5.Pages.Dashboard
{
    public class DashboardModel : PageModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is verplicht")]
        [EmailAddress(ErrorMessage = "Ongeldig email adres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campinghuis nummer is verplicht")]
        public int Huisje { get; set; }

        [Required(ErrorMessage = "Kenteken is verplicht")]
        [StringLength(20)]
        public string Kenteken { get; set; } = string.Empty;

        public bool IsBetaald { get; set; }

        public void OnGet()
        {
        }

       
        public IActionResult OnPostSubmit()
        {
            if (!ModelState.IsValid)
                return Page();

            var db = new Project__5.Pages.DataBase.DataBase();

            bool success = db.CreateGeheel(
                Email,
                Huisje.ToString(),
                Kenteken
            );

            if (!success)
            {
                ModelState.AddModelError("", "Opslaan mislukt.");
                return Page();
            }

            return RedirectToPage();
        }

       
        public IActionResult OnPostVerwijder(string id)
        {
            var db = new Project__5.Pages.DataBase.DataBase();
            db.Verwijder(id);
            return RedirectToPage();
        }

        public IActionResult OnPostBetaal(string id)
        {
            var db = new Project__5.Pages.DataBase.DataBase();
            db.DashboardBetaald(id);
            return RedirectToPage();
        }

        public IActionResult OnPostPasAan()
        {
            var db = new Project__5.Pages.DataBase.DataBase();
            db.PasAan(
                Email,
                Huisje.ToString(),
                Kenteken
            );
            return RedirectToPage();
        }
    }
}
