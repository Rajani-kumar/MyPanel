﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    public class JQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}