using Microsoft.AspNetCore.Mvc;
using TezMektepKz.Exceptions;
using TezMektepKz.Models.Identity;
using TezMektepKz.Services.Interfaces;

namespace TezMektepKz.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Organization organization)
        {
            try
            {
                await organizationService.AddAsync(organization);
                return Redirect("/Identity/Account/Register");

            }
            catch (BusinessException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(organization); 
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
