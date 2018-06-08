using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEventos.Controllers
{
    public class PermissionController : Controller
    {
        [HttpGet]
        public ActionResult Confirm()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Denied()
        {
            return View();
        }
    }
}