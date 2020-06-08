using EmpInfoSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpInfoSys.Controllers
{
    public class AddController : Controller
    {
        // GET: Add
        public ActionResult DeptIndex()
        {
            return View();            
        }
        public ActionResult DeptAdd(Dept dept)
        {
            using (var db = new Models.Database1Entities2())
            {
                Dept d = dept;
                db.Depts.Add(d);
                db.SaveChanges();
                return View(d);
            }
        }




        public ActionResult EmpIndex()
        {
            using (var db = new Database1Entities2())
            {
                var emp = new Emp();
                var eDeptItem = db.Depts.
                    Select(x => new SelectListItem
                    {
                        Value = x.DeptId.ToString(),
                        Text = x.DeptName
                    }).ToList();
                var n = new SelectListItem { Value = null, Text = "--" };
                eDeptItem.Add(n);
                emp.DeptItems = eDeptItem;
                return View(emp);
            }
        }
        public ActionResult EmpAdd(Emp emp)
        {
            using (var db = new Database1Entities2())
            {
                if (!ModelState.IsValid)
                {
                    var eDeptItem = db.Depts.
                    Select(x => new SelectListItem
                    {
                        Value = x.DeptId.ToString(),
                        Text = x.DeptName
                    }).ToList();
                    var n = new SelectListItem { Value = null, Text = "--" };
                    eDeptItem.Add(n);
                    emp.DeptItems = eDeptItem;
                    return View("EmpIndex", emp);
                }

                db.Emps.Add(emp);
                db.SaveChanges();
                Dept d = db.Depts.Find(emp.DeptId);
                emp.Dept = d;
                
            }
            return View("EmpAdd", emp);

        }
    }
}