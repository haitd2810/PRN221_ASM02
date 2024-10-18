using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM02_ShoppingWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ASM02_ShoppingWebsite.Pages.ProductManage
{
    public class CreateModel : PageModel
    {
        public List<Category> Categories = PRN221_Assignment02Context.ins.Categories.ToList();
        private readonly ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context _context;

        public CreateModel(ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
