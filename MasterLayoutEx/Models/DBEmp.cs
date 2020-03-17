using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MasterLayoutEx.Models
{
    public class DBEmp
    {
        static TestEntities T = new TestEntities();
        public static List<EMPDATA> GetAll()
        {
            var E = from E1 in T.EMPDATAs
                    select E1;
            return E.ToList();
        }
        public static EMPDATA GetEmp(int id)
        {
            var E = from E1 in T.EMPDATAs
                    where E1.EMPNO == id
                    select E1;
            return E.First();
        }
        public static string GetEmpData(EMPDATA Emp)
        {
            var Emp1 = from E1 in T.EMPDATAs
                       where E1.EMPNO == Emp.EMPNO
                       select E1;
            foreach (var item in Emp1)
            {
                item.JOB = Emp.JOB;
                item.MGR = Emp.MGR;
                item.SAL = Emp.SAL;
                item.COMM = Emp.COMM;
                item.DEPTNO = Emp.DEPTNO;
            }

            T.SaveChanges();
            return "1 row updated";
        }
        public static string DeleteEmp(int Eno)
        {
            var E = from E1 in T.EMPDATAs
                    where E1.EMPNO == Eno
                    select E1;
            T.EMPDATAs.Remove(E.First());
            T.SaveChanges();
            return Eno + " Employee details are deleted";
        }
        public static string InsertEmp(EMPDATA A)
        {
            try
            {
                T.EMPDATAs.Add(A);
                T.SaveChanges();
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
                if (ex.Message.Contains("FK__EMPDATA__DEPTNO__5441852A"))
                {
                    return "No proper deptno";
                }
                else if (ex.Message.Contains("EMP_PK"))
                {
                    return "empno cannot be duplicate";
                }
                else
                    return "Error Occured";
            }
            return "1 row inserted";
        }
    }
}