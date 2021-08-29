using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeMachineLib
{
    public class DataCollector
    {
        public List<Transact> ValidTransacts { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }

        public LogTable Log { get; set; }

        public DataCollector(List<Transact> validTransacts, string filename, string path, LogTable log)
        {
            ValidTransacts = validTransacts;
            Filename = filename;
            Path = path;
            Log = log;
        }


        public void ValidateRecords(string connStr)
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    string line;
                    EmpMasterTable employee = new EmpMasterTable(connStr);

                    while ((line = sr.ReadLine()) != null)
                    {
                        var words = line.Split(' ');
                        if (employee.IsEmployeeExist((Convert.ToDecimal(words[2]))))
                        {
                            Transact transact = new Transact(Convert.ToDecimal(words[0]), Convert.ToDecimal(words[1]), Convert.ToDecimal(words[2]), Convert.ToDateTime(words[3] + " " + words[4]), words[5]);
                            ValidTransacts.Add(transact);
                            TimeMachine machine = new TimeMachine(connStr);
                            machine.InsertRecord(transact);
                        }
                        else
                        {
                            Log.InsertLog(line);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
