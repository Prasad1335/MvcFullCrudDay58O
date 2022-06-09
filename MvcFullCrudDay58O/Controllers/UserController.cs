using Microsoft.AspNetCore.Mvc;
using MvcFullCrudDay58O.Models;
using MvcFullCrudDay58O.Models.Services;

namespace MvcFullCrudDay58O.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var userService = new UserService();
            var users = await userService.GetAllAsync();

            return View(users);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var userService = new UserService();
            var user = await userService.GetByIdAsync(id);

            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var user = Utility.GenerateFakeData();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var userService = new UserService();
            await userService.CreateAsync(user);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userService = new UserService();
            var user = await userService.GetByIdAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            var userService = new UserService();
            await userService.UpdateAsync(user);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userService = new UserService();
            var user = await userService.GetByIdAsync(id);

            return View(user);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var userService = new UserService();
            await userService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}