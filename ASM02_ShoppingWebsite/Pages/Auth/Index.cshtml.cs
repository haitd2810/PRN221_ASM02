using ASM02_ShoppingWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASM02_ShoppingWebsite.Pages.Auth
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            Account acc = PRN221_Assignment02Context.ins.Accounts
                .FirstOrDefault(a => a.UserName.Equals(username) && a.Password.Equals(password));
            if (acc != null) {
                if(acc.Type.Equals("Admin") || acc.Type.Equals("Staff"))
                {
                    return Redirect("/Product/Index");
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }
    }
}
