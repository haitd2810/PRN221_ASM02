using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASM02_ShoppingWebsite.Pages.Auth
{
    public class LogOutModel : PageModel
    {
        
            public IActionResult OnGet()
            {
                HttpContext.Session.Clear(); // Xóa tất cả session khi người dùng đăng xuất
                return Page(); // Chuyển về trang login sau khi đăng xuất
            }
        
    }
}
