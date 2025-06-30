using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorAdmin.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class CreateProductModel : PageModel
    {
        public void OnGet()
        {
            var token = HttpContext.Session.GetString("JWT");
            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect("/Login");
            }
        }
    }
}