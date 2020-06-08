using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpInfoSys.Models;


namespace EmpInfoSys.Controllers
{
    public class RemoveController : Controller
    {
        // GET: Remove
        public ActionResult DeptIndex()
        //public ActionResult DeptIndex(int deptId)
        {
            using (var db = new Models.Database1Entities2())
            {
                Dept dept = db.Depts.Find(8);
                //Dept dept = db.Depts.Find(deptId);
                return View(dept);
            }
        }
        public ActionResult DeptRemove(int deptId)
        //public ActionResult DeptRemove(string pass, int deptId)
        {
            
                using (var db = new Models.Database1Entities2())
                {
                    Dept dept = db.Depts.Find(deptId);
                    db.Depts.Remove(dept);
                    db.SaveChanges();
                    return Redirect("/List/DeptList");
                }
                       
        }
        public ActionResult EmpIndex()
        //public ActionResult EmpIndex(int empId)
        {
            using (var db = new Models.Database1Entities2())
            {
                Emp emp = db.Emps.Find(3);
                //Emp emp = db.Emps.Find(empId);
                emp.Dept = db.Depts.Find(emp.DeptId);
                return View(emp);
            }
        }
        public ActionResult EmpRemove(int empId)
        //public ActionResult EmpRemove(string pass, int empId)
        {
            using (var db = new Models.Database1Entities2())
            {
                Emp emp = db.Emps.Find(empId);
                db.Emps.Remove(emp);
                db.SaveChanges();
                return Redirect("/List/EmpList");
            }
        }
    }
}