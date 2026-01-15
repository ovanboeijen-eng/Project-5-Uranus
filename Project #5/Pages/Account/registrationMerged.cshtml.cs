using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project__5.Pages.Account.Bezoeker;


namespace Project.Pages.Account
{
    public class RegisterMergedModel : PageModel
    {
        //[BindProperty]
        //public RegristratieKlant.RegisterInput DesktopInput { get; set; }


        [BindProperty]
        public Pages_Account_Bezoeker_RegristratieBezoeker MobileInput { get; set; } = new();

    }
}

