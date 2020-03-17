using MasterLayoutEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterLayoutEx.Controllers
{
    public class BindingExController : Controller
    {
        // GET: BindingEx
        [ActionName("Example")]
        public ActionResult Sample()
        {
            return View("Sample");
        }
        public ActionResult Index()
        {
            return View();
        }
        //Binding to primitive type
        public ActionResult Update(int id)
        {
            return View("Index",DBEmp.GetEmp(id));
        }
        //Binding to complex type
        //[HttpPost]
        //public ActionResult Update(EMPDATA E)
        //{
        //    return View();
        //}
        //basic type not suggested
        //[HttpPost]
        //public ActionResult Update(int EMPNO,string ENAME,string JOB,int MGR,DateTime HIREDATE,int SAL,int COMM,int DEPTNO)
        //{
        //    return View();
        //}
        //form collections not suggested
        //[HttpPost]
        //public ActionResult Update(FormCollection F)
        //{
        //    int eno = int.Parse(F["EMPNO"]);
        //    string ename = F["ENAME"];
        //    string job = F["JOB"];
        //    int mgr = int.Parse(F["MGR"]);
            
        //    int sal = int.Parse(F["SAL"]);
        //    int com = int.Parse(F["COMM"]);
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Update([Bind(Include="ENAME,JOB")]EMPDATA E)
        // {
        //    return View();
        //}
        [HttpPost]
        public ActionResult Update([Bind(Exclude = "ENAME,JOB")]EMPDATA E)
        {
            return View();
        }
    }
}