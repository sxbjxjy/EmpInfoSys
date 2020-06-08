using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpInfoSys.Models;

namespace EmpInfoSys.Controllers
{
    public class ModifyController : Controller
    {
        // GET: Modify
        public ActionResult DeptIndex()
        //public ActionResult DeptIndex(int deptId)
        {
            using (var db = new Models.Database1Entities2())
            {
                
                Dept dept = db.Depts.Find(6);
                //Dept dept = db.Depts.Find(deptId);
                return View(dept);
            }
        }
        public ActionResult DeptModify(Dept dept)
        //public ActionResult DeptModify(string pass, Dept dept)
        {
            using (var db = new Models.Database1Entities2())
            {
                if (!ModelState.IsValid)
                {
                    return View("DeptIndex");
                }
                Dept d = db.Depts.Find(dept.DeptId);
                d.DeptName = dept.DeptName;
                d.Address = dept.Address;
                d.Tel = dept.Tel;
                db.SaveChanges();
                return View(d);
            }
        }

        public ActionResult EmpIndex()
        //public ActionResult EmpIndex(int empId)
        {
            using (var db = new Database1Entities2())
            {
                var emp = db.Emps.Find(2);
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
        public ActionResult EmpModify(Emp emp)
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
                Emp e = db.Emps.Find(emp.EmpId);
                e.Name = emp.Name;
                e.BirthDay = emp.BirthDay;
                e.DeptId = emp.DeptId;
                db.SaveChanges();
                Dept d = db.Depts.Find(emp.DeptId);
                e.Dept = d;
                return View(e);
            }
        }
    }
}