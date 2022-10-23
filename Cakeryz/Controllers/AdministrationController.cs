using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Cakeryz.Controllers
{
    public class AdministrationController : Controller
    {
        //private readonly RoleManager<IdentityRole> roleManager;
        //public AdministrationController(RoleManager<IdentityRole> roleManager)
        //{
        //    this.roleManager = roleManager;
        //}

        public IActionResult CreateRole()
        {
            return View();
        }

    }
}
