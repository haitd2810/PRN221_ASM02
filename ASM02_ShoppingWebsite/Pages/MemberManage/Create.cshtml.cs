using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASM02_ShoppingWebsite.Models;

namespace ASM02_ShoppingWebsite.Pages.MemberManage
{
    public class CreateModel : PageModel
    {
        private readonly ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context _context;
        public List<Category> Categories = PRN221_Assignment02Context.ins.Categories.ToList();
        public CreateModel(ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Accounts == null || Account == null)
            {
                return Page();
            }

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
