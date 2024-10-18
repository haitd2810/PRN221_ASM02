using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASM02_ShoppingWebsite.Models;

namespace ASM02_ShoppingWebsite.Pages.Auth
{
    public class SignupModel : PageModel
    {
        private readonly ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context _context;

        public SignupModel(ASM02_ShoppingWebsite.Models.PRN221_Assignment02Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra xem tài khoản đã tồn tại chưa
            var existingAccount = _context.Accounts.FirstOrDefault(a => a.UserName == Account.UserName);
            if (existingAccount != null)
            {
                ModelState.AddModelError("Account.UserName", "Username already exists.");
                return Page();
            }

            // Gán giá trị type là "User" cho tài khoản mới
            Account.Type = "User";

            try
            {
                // Thêm tài khoản mới vào cơ sở dữ liệu
                _context.Accounts.Add(Account);
                await _context.SaveChangesAsync();

                // Thông báo đăng ký thành công
                TempData["SuccessMessage"] = "Account created successfully. Please login.";

                // Chuyển hướng đến trang đăng nhập
                return RedirectToPage("/Auth/Index");
            }
            catch (Exception ex)
            {
                // Nếu có lỗi khi lưu vào cơ sở dữ liệu, hiển thị thông báo lỗi
                ModelState.AddModelError(string.Empty, $"Error occurred while creating account: {ex.Message}");
                return Page();
            }
        }

    }
}
