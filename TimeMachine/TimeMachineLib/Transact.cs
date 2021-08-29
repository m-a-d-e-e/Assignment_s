using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMachineLib
{
    public class Transact
    {
        public Transact(decimal gateNo, decimal transNo, decimal empId, DateTime dt, string op)
        {
            GateNo = gateNo;
            TransNo = transNo;
            EmpId = empId;
            DT = dt;
            Opertion = op;
        }

        public decimal GateNo { get; private set; }
        public decimal TransNo { get; private set; }
        public decimal EmpId { get; private set; }
        public DateTime DT { get; private set; }
        public string Opertion { get; private set; }


        public override string ToString()
        {
            return string.Format($"GateNo: {GateNo}  TransNo: {TransNo}  EmpId: {EmpId}  DT: {DT}  Opertion: {Opertion}");
        }

    }
}
