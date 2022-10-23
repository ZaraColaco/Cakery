using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Cakeryz.Controllers
{
    public class AdminController : Controller
    {
        public AdminController(RoleManager<IdentityRole>roleManager)
        {
        
        }
    }
}
