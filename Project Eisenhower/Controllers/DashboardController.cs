using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Eisenhower.Models;
using Project_Eisenhower.Repositories;
using Project_Eisenhower.ViewModels;

namespace Project_Eisenhower.Controllers
{
    public class DashboardController : Controller
    {
        private readonly PEDEVDBContext _context;
        private readonly PEDEVDBRepo _repo;
        private readonly UserManager<IdentityUser> _userManager;


        public DashboardController(PEDEVDBContext context, PEDEVDBRepo PEDEVDBRepo, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _repo = PEDEVDBRepo;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin,FieldOwner")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            DashboardVM vm = _repo.GetDashboardInfo(currentUser);

            return View(vm);
        }
    }
}