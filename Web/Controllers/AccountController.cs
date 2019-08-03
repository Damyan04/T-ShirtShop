﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_T.Models.Login;

namespace Shop_T.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }
        public IActionResult Register(string returnUrl = "")
        {
           // var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View();
        }

    }
}