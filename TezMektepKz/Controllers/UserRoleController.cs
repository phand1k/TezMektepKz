using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using TezMektepKz.Data;
using TezMektepKz.Models.Identity;

namespace TezMektepKz.Controllers
{
    public class UserRoleController : Controller
    {
        private ApplicationDbContext context;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<AspNetUser> userManager;
        public UserRoleController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AspNetUser> userManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
