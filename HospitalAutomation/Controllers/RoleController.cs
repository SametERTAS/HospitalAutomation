using HospitalAutomation.Models.Identity;
using HospitalAutomation.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AppRole role)
        {
            role.Id = Guid.NewGuid().ToString();
            role.CreateDate = DateTime.Now;
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            IdentityResult result = await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            AppRole role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }
        public IActionResult ListUsers()
        {
            return View(_userManager.Users.ToList());
        }



        public async Task<IActionResult> RoleAssign(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            List<AppRole> allRoles = _roleManager.Roles.ToList();
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignViewModel> assignRoles = new List<RoleAssignViewModel>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignViewModel
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));

            return View(assignRoles);
        }

        [HttpPost]
        public async Task<ActionResult> RoleAssign(List<RoleAssignViewModel> modelList, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignViewModel role in modelList)
            {
                if (role.HasAssign)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return RedirectToAction("ListUsers");
        }
    }
}
