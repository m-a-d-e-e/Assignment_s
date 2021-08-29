using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryBreakUpLib;
using System.Configuration;

namespace SalaryBreakUp_App
{
    class Program
    {
        static void Main(string[] args)
        {
            double basic_percent = Convert.ToDouble(ConfigurationManager.AppSettings["BasicPercent"]);
            double hra_percent = Convert.ToDouble(ConfigurationManager.AppSettings["HraPercent"]);
            double conv_per_mnth = Convert.ToDouble(ConfigurationManager.AppSettings["ConvAllowancePerMonth"]);
            double med_per_mnth = Convert.ToDouble(ConfigurationManager.AppSettings["MedicalReimburstPerMonth"]);
            double pf_limit_per_mnth = Convert.ToDouble(ConfigurationManager.AppSettings["PfLimitPerMonth"]);
            double pf_percent = Convert.ToDouble(ConfigurationManager.AppSettings["PfPercent"]);
            double esic_limit_per_mnth = Convert.ToDouble(ConfigurationManager.AppSettings["EsicLimitPerMonth"]);
            double esic_percent = Convert.ToDouble(ConfigurationManager.AppSettings["EsicPercent"]);

            Dictionary<string, double> limits = new Dictionary<string, double>()
            {
                { "basic_percent", basic_percent },
                {"hra_percent", hra_percent },
                {"conv_per_mnth", conv_per_mnth },
                {"med_per_mnth", med_per_mnth },
                {"pf_limit_per_mnth", pf_limit_per_mnth },
                {"pf_percent", pf_percent },
                {"esic_limit_per_mnth", esic_limit_per_mnth },
                {"esic_percent", esic_percent }

            };

            double ctc;
            Console.WriteLine("Enter ctc");
            ctc = Convert.ToDouble(Console.ReadLine());

            Salary salary = new Salary(limits);
            salary.FindSalaryBreakUp(ctc);

            Console.WriteLine( salary.ToString() );
            Console.ReadLine();

        }
    }
}
