using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASM02_ShoppingWebsite.Models;

namespace ASM02_ShoppingWebsite.Pages.ProductManage
{
    public class IndexModel : PageModel
    {
        public List<Category> Categories = PRN221_Assignment02Context.ins.Categories.ToList();
        private readonly ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context _context;

        public IndexModel(ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                ViewData["Cate"] = Categories;
                Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostSearch()
        {
            string keywords = Request.Form["search"];
            int number;
            Product = await _context.Products
                .Where(p => p.ProductName.Contains(keywords) || p.UnitPrice.ToString() == keywords || p.ProductId.ToString() == keywords)
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();
            return Page();
        }
    }
}
