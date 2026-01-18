using Login.Klant.Page;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Registratie.Pages
{
    public class Registratie_Model : PageModel
    {
        [BindProperty]
        public required RegistratieInput Input { get; set; }

        public string? ErrorMessage { get; set; }

        
    };
}


public class RegistratieInput
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

    public class RegisterInput
    {
        [Required(ErrorMessage = "E-mailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
        [Display(Name = "E-mailadres")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Kenteken is verplicht")]
        [RegularExpression(@"^[A-Z0-9\-]{6,10}$", ErrorMessage = "Ongeldig kenteken (6-10 tekens, alleen hoofdletters en cijfers)")]
        [Display(Name = "Kenteken")]
        public required string Kenteken { get; set; }

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

