using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TezMektepKz.Models;
using TezMektepKz.Services.Interfaces;

namespace TezMektepKz.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService gradeService;
        public GradeController(IGradeService gradeService)
        {
            this.gradeService = gradeService;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Grade grade)
        {
            if (ModelState.IsValid)
            {
                await gradeService.AddAsync(grade);
                return RedirectToAction("Index");
            }
            return View(grade);
        }

        public async Task<IActionResult> Index()
        {
            var grades = await gradeService.GetAllAsync();
            return View(grades);
        }


    }
}
