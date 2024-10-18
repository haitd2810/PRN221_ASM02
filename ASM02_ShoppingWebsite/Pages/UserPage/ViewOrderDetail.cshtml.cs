using ASM02_ShoppingWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASM02_ShoppingWebsite.Pages.UserPage
{
    public class ViewOrderDetailModel : PageModel
    {
        private readonly PRN221_Assignment02Context _context;

        public ViewOrderDetailModel(PRN221_Assignment02Context context)
        {
            _context = context;
        }

        public Order Order { get; set; } = default!;
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public async Task OnGetAsync(int id)
        {
            // Lấy đơn hàng theo OrderId
            Order = await _context.Orders
                .Include(o => o.OrderDetails) // Bao gồm chi tiết đơn hàng
                    .ThenInclude(od => od.Product) // Bao gồm sản phẩm từ chi tiết đơn hàng
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (Order != null)
            {
                OrderDetails = Order.OrderDetails.ToList(); // Lấy danh sách chi tiết đơn hàng
            }
        }
    }
}
