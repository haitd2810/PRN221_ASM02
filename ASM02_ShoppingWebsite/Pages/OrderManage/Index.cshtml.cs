using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASM02_ShoppingWebsite.Models;
using System.Text;

namespace ASM02_ShoppingWebsite.Pages.OrderManage
{
    public class IndexModel : PageModel
    {
        private readonly ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context _context;
        public List<Category> Categories = PRN221_Assignment02Context.ins.Categories.ToList();
        public IndexModel(ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
            }
        }
        public IActionResult OnPostExportTxt(DateTime? fromDate, DateTime? toDate)
        {
            if (fromDate == null) fromDate = DateTime.MinValue;
            if (toDate == null) toDate = DateTime.MaxValue;

            var orders = _context.Orders
                .Include(o => o.Customer)
                .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine("Order Date, Required Date, Shipped Date, Freight, Ship Address, Customer Name");

            foreach (var order in orders)
            {
                sb.AppendLine($"{order.OrderDate?.ToString("dd/MM/yyyy")}, " +
                              $"{order.RequiredDate?.ToString("dd/MM/yyyy")}, " +
                              $"{order.ShippedDate?.ToString("dd/MM/yyyy")}, " +
                              $"{order.Freight}, " +
                              $"{order.ShipAddress}, " +
                              $"{order.Customer.ContactName}");
            }

            var fileContent = Encoding.UTF8.GetBytes(sb.ToString());
            var fileName = $"Orders-{DateTime.Now:yyyyMMddHHmmss}.txt";

            return File(fileContent, "text/plain", fileName);
        }
    }
}
