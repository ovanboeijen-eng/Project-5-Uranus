using Login.Klant.Page;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RegristratieBezoeker
{
    public class Bezoeker_Registratie_Model : PageModel
    {
        [BindProperty]
        public required RegristratieInput Input { get; set; }

        public string? ErrorMessage { get; set; }

        //public Guid SelectedCampingId { get; set; }




        //public List<Camping> Campings { get; set; } = new List<Camping>()
        //    {

        //        new Camping { Id = Guid.NewGuid(), Name = "Camping De Zon" },
        //        new Camping { Id = Guid.NewGuid(), Name = "Camping Het Bos" },
        //        new Camping { Id = Guid.NewGuid(), Name = "Camping Aan Zee" },
        //        new Camping { Id = Guid.NewGuid(), Name = "Les 3 Sources" }
            };
    }


public class RegristratieInput
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public required string Wachtwoord { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Bevestig Wachtwoord")]
    public required string BevestigWachtwoord { get; set; }

    [Required]
    [Display(Name = "Kenteken")]
    public required string Kenteken { get; set; }

    public void OnGet()
    {
    }

    //public IActionResult OnPostRegister()
    //{

    //    }
    //}

    //public class Camping
    //        {
    //        public Guid Id { get; set; }
    //        public required string Name { get; set; }
    //}
    public class RegisterInput
    {
        [Required(ErrorMessage = "E-mailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
        [Display(Name = "E-mailadres")]
        public required string Email { get; set; }

        //[Required(ErrorMessage = "Kenteken is verplicht")]
        //[RegularExpression(@"^[A-Z0-9\-]{6,10}$", ErrorMessage = "Ongeldig kenteken (6-10 tekens, alleen hoofdletters en cijfers)")]
        //[Display(Name = "Kenteken")]
        //public required string Kenteken { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Wachtwoord moet minimaal 6 tekens zijn")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public required string Wachtwoord { get; set; }

        [Required(ErrorMessage = "Bevestig je wachtwoord")]
        [DataType(DataType.Password)]
        [Display(Name = "Bevestig wachtwoord")]
        [Compare("Wachtwoord", ErrorMessage = "Wachtwoorden komen niet overeen")]
        public required string BevestigWachtwoord { get; set; }
    }
}

