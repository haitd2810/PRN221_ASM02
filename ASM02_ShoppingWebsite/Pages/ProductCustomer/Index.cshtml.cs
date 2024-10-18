using ASM02_ShoppingWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASM02_ShoppingWebsite.Pages.ProductCustomer
{
    public class IndexModel : PageModel
    {
        public List<Product> proList { get; set; }
        public void OnGet()
        {
            proList = PRN221_Assignment02Context.ins.Products.Include(p => p.Category).ToList();
        }
    }
}
