using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? Salary { get; set; }


        public override string ToString()
        {
            return string.Format($"EmpNo : {EmpNo}  EmpName : {EmpName}  HireDate : {HireDate}  Salary : {Salary}");
        }
    }
}
