using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project__5.Pages.Account.Bezoeker; 


namespace Project.Pages.Account
{
    public class LoginMergedModel : PageModel
    {
        [BindProperty]
        public Login.Klant.Page.LoginInput DesktopInput { get; set; } = new();

        [BindProperty]
        public Bezoeker_Inlog_Model.LoginInput MobileInput { get; set; } = new();


    }
}

