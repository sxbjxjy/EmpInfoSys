using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpInfoSys.Models;

namespace EmpInfoSys.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult DeptList()
        {
            using (var db = new Models.Database1Entities2())
            {
                return View(db.Depts.ToList());
            }
        }

        public ActionResult EmpList()
        {
            using (var db = new Models.Database1Entities2())
            {
                return View(db.Emps.ToList());
            }
        }
    }
}