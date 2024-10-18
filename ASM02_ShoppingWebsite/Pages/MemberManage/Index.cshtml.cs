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
    public class IndexModel : PageModel
    {
        private readonly ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context _context;
        public List<Category> Categories = PRN221_Assignment02Context.ins.Categories.ToList();
        public IndexModel(ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Accounts != null)
            {
                Account = await _context.Accounts.ToListAsync();
            }
        }
    }
}
