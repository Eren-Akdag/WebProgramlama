﻿using Hastane.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hastane.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class UsersController : Controller
    {

        private IApplicationUserService _userService;

        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int PageNumber = 1 , int PageSize=10)
        {
            return View(_userService.GetAll(PageNumber,PageSize));
        }
    }
}
