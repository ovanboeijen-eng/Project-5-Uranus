using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project__5.Pages
{
    public class IndexModel : PageModel
    {
        //public void OnGet()
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToPage("/Account/Klant/InlogKlant");
            }

            return Page();
            //of een willekeurige andere pagina zoals
            //return RedirectToPage("/Account/Klant/MijnNieuwePagina");

        }
    }
}
