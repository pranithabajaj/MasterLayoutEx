using MasterLayoutEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterLayoutEx.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            List<EMPDATA> L = DBEmp.GetAll();
            return View(L);
        }
        public ActionResult Create()
        {
            
            return View();
        }
        public ActionResult Edit(int id)
        {
            EMPDATA E=DBEmp.GetEmp(id);
            return View(E);
        }
        [HttpPost]
        public ActionResult Edit(EMPDATA Emp)
        {
            string s = DBEmp.GetEmpData(Emp);
            ViewBag.msg = s;
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            ViewBag.msg  = DBEmp.DeleteEmp(id);
            
            return View();
        }
        
        public ActionResult Insert(EMPDATA E)
        {
            ViewBag.msg = DBEmp.InsertEmp(E);
            return View();
        }
    }
}