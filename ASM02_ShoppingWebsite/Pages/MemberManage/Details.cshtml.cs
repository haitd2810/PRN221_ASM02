using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASM02_ShoppingWebsite.Models;

namespace ASM02_ShoppingWebsite.Pages.MemberManage
{
    public class DetailsModel : PageModel
    {
        private readonly ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context _context;
        public List<Category> Categories = PRN221_Assignment02Context.ins.Categories.ToList();
        public DetailsModel(ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context context)
        {
            _context = context;
        }

      public Account Account { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }
    }
}
