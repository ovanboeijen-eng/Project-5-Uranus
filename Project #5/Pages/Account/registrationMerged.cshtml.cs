using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project__5.Pages.Account.Bezoeker;


namespace Project.Pages.Account
{
    public class RegisterMergedModel : PageModel
    {
        [BindProperty]
        public RegristratieKlant.RegisterInput DesktopInput { get; set; }


        [BindProperty]
        public RegristratieBezoekerModel MobileInput { get; set; } = new();
    }
}

