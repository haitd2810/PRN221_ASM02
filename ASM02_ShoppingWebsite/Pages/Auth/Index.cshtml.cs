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

            if (acc != null)
            {
                if (acc.Type.Equals("Admin") || acc.Type.Equals("Staff"))
                {
                    HttpContext.Session.SetString("FullName", acc.FullName);
                    HttpContext.Session.SetString("UserId", acc.AccountId.ToString());
                    return Redirect("/ProductManage/Index");
                }
                else
                {
                    HttpContext.Session.SetString("FullName", acc.FullName);
                    HttpContext.Session.SetString("UserId", acc.AccountId.ToString());
                    return Redirect("/ProductCustomer/Index");
                }
            }

        // Thêm thông báo lỗi nếu tài khoản không hợp lệ
        ModelState.AddModelError(string.Empty, "Username or Password is incorrect.");
            return Page();
        }
    }
}
