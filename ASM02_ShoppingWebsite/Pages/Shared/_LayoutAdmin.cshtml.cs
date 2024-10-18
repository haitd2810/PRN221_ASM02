using ASM02_ShoppingWebsite.Models;

namespace ASM02_ShoppingWebsite.Pages.Shared
{
    public class _LayoutAdmin
    {
        public List<Category> Categories = PRN221_Assignment02Context.ins.Categories.ToList();
    }
}
