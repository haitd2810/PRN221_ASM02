using ASM02_ShoppingWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASM02_ShoppingWebsite.Pages.UserPage
{
    public class ViewOrderHistoryModel : PageModel
    {
        private readonly PRN221_Assignment02Context _context;

        public ViewOrderHistoryModel(PRN221_Assignment02Context context)
        {
            _context = context;
        }

        public List<Order> Orders { get; set; } = new List<Order>();

        public async Task OnGetAsync()
        {
            // Giả sử bạn lưu CustomerID trong session khi người dùng đăng nhập
            var UserId = int.Parse( HttpContext.Session.GetString("UserId"));

            // Lấy danh sách đơn hàng cho khách hàng hiện tại
            Orders = await _context.Orders
                .Where(o => o.CustomerId == UserId)
                .ToListAsync();
        }
    }
}
