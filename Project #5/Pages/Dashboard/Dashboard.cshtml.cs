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
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Campinghuis nummer is verplicht")]
        [Display(Name = "Campinghuis Nr.")]
        public int CampinghuisNummer { get; set; }

        [Required(ErrorMessage = "Kenteken is verplicht")]
        [StringLength(20, ErrorMessage = "Kenteken mag maximaal 20 karakters zijn")]
        [Display(Name = "Kenteken")]
        public required string Kenteken { get; set; }

        [Display(Name = "Betaald")]
        public bool IsBetaald { get; set; }

        public DateTime AangemaaktOp { get; set; }

        public void OnGet()
        {
            var db = new Project__5.Pages.DataBase.DataBase();
        }

        public IActionResult OnPostSubmit()
        {
            var db = new Project__5.Pages.DataBase.DataBase();
            db.Create(Email, CampinghuisNummer.ToString(), Kenteken);
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
            db.PasAan(Email, CampinghuisNummer.ToString(), Kenteken);
            return RedirectToPage();
        }
    }
}
