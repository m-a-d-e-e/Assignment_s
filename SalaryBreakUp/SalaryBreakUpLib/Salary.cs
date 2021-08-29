using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SalaryBreakUpLib
{
    public class Salary
    {
        #region Properties

        public Dictionary<string, double> Limits { get; private set; }
        public double Ctc { get; private set; }
        public double Basic { get; private set; }
        public double Hra { get; private set; }
        public double Conv { get; private set; }
        public double Spa { get; private set; }
        public double Medical { get; private set; }
        public double Pf { get; private set; }
        public double Esic { get; private set; }
        public double Lta { get; private set; }

        public double MonthlyBasic { get; private set; }
        public double MonthlyHra { get; private set; }
        public double MonthlyConv { get; private set; }
        public double MonthlySpa { get; private set; }
        public double MonthlyMedical { get; private set; }
        public double MonthlyPf { get; private set; }
        public double MonthlyEsic { get; private set; }
        public double MonthlyLta { get; private set; }

        #endregion

        #region Constructor

        public Salary(Dictionary<string,double> limits)
        {
            Limits = limits;
        }

        #endregion

        #region Methods

        public void FindSalaryBreakUp(double ctc)
        {
            
            Ctc = ctc;
            Basic = CalculateBasic(Limits["basic_percent"]);
            Hra = CalculateHra(Limits["hra_percent"]);
            Conv = CalculateConv(Limits["conv_per_mnth"]);
            Medical = CalculateMed(Limits["med_per_mnth"]);
            Pf = CalculatePf(Limits["pf_limit_per_mnth"], Limits["pf_percent"]);
            Lta = CalculateLta();
            Esic = CalculateEsic(Limits["esic_limit_per_mnth"], Limits["esic_percent"]);
            Spa = CalculateSpa();

            MonthlyBasic = Math.Round(Basic / 12);
            MonthlyHra = Math.Round(Hra / 12);
            MonthlyConv = Math.Round(Conv / 12);
            MonthlyMedical = Math.Round(Medical / 12);
            MonthlyPf = Math.Round(Pf / 12);
            MonthlyLta = Math.Round(Lta / 12);
            MonthlyEsic = Math.Round(Esic / 12);
            MonthlySpa = Math.Round(Spa / 12);
        }

        private double CalculateBasic(double per)
        {
            return Math.Round(Ctc * per);
        }

        private double CalculateHra(double per)
        {
            return Math.Round(Basic * per);
        }

        private double CalculateConv(double amt)
        {
            return (Math.Round(amt * 12));
        }

        private double CalculateMed(double amt)
        {
            return (Math.Round(amt * 12));
        }

        private double CalculatePf(double limit, double per )
        {
            if (Basic / 12 < limit)
            {
                return Math.Round(per * Basic);
            }
            else
            {
                return Math.Round( per * limit * 12);
            }
        }

        private double CalculateLta()
        {
            return (Math.Round(Basic / 12));
        }

        private double CalculateEsic(double limit, double per)
        {
            double spa_temp = (Ctc - ((1 + 0.0475) * (Basic + Hra + Conv + Medical)) - Lta - Pf) / 1.0475;
            double temp = Basic + Hra + Conv + spa_temp + Medical;

            if (temp < limit * 12)
            {
                return Math.Round( per * temp);
            }
            else
            {
                return 0;
            }
        }

        private double CalculateSpa()
        {
            return (Math.Round(Ctc - (Basic + Hra + Conv + Medical + Pf + Lta + Esic)));
        }

        public override string ToString()
        {
            return string.Format($"Annual break up --- Basic={Basic} hra={Hra} conv={Conv} med={Medical} pf={Pf} esci={Esic} spa={Spa} lta={Lta}" +
                $"\nMonthly break up --- Basic={MonthlyBasic} hra={MonthlyHra} conv={MonthlyConv} med={MonthlyMedical} pf={MonthlyPf} esci={MonthlyEsic} spa={MonthlySpa} lta={MonthlyLta}");
                                  
        }

        #endregion
    }
}
