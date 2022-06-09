using Microsoft.AspNetCore.Mvc;
using MvcFullCrudDay58O.Models;
using MvcFullCrudDay58O.Models.Services;

namespace MvcFullCrudDay58O.Controllers
{
    public class DepartmentController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var departmentService = new DepartmentService();
            var dept = await departmentService.GetAllAsync();
            return View(dept);
        }
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var departmentService = new DepartmentService();
            var dept = await departmentService.GetByIdAsync(id);

            return View(dept);
        }

        public IActionResult Create(Department department)
        {
            return View(department);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Department department)
        {
            var departmentService = new DepartmentService();
            await departmentService.CreateAsync(department);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var departmentService = new DepartmentService();
            var dept = await departmentService.GetByIdAsync(id);
            return View(dept);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            var departmentService = new DepartmentService();
            await departmentService.EditAsync(department);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var departmentService = new DepartmentService();
            var dept = await departmentService.GetByIdAsync(id);
            return View(dept);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var departmentService = new DepartmentService();
            await departmentService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
