using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PLinqDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
			Customer[] customers =  {
									new Customer { ID = 1,  FirstName = "Sandeep"  , LastName = "Ramani" },
									new Customer { ID = 2,  FirstName = "Dharmik"  , LastName = "Chotaliya" },
									new Customer { ID = 3,  FirstName = "Nisar"    , LastName = "Kalia" } ,
									new Customer { ID = 4,  FirstName = "Ravi"     , LastName = "Mapara" } ,
									new Customer { ID = 5,  FirstName = "Hardik"   , LastName = "Mistry" },
									new Customer { ID = 6,  FirstName = "Sandy"    , LastName = "Ramani" },
									new Customer { ID = 7,  FirstName = "Jigar"    , LastName = "Shah" },
									new Customer { ID = 8,  FirstName = "Kaushal"  , LastName = "Parik" } ,
									new Customer { ID = 9,  FirstName = "Abhishek" , LastName = "Swarnker" } ,
									new Customer { ID = 10, FirstName = "Sanket"   , LastName = "Patel" },
									new Customer { ID = 11, FirstName = "Dinesh"   , LastName = "Prajapati" },
									new Customer { ID = 12, FirstName = "Jayesh"   , LastName = "Patel" },
									new Customer { ID = 13, FirstName = "Nimesh"   , LastName = "Mishra" } ,
									new Customer { ID = 14, FirstName = "Shiva"    , LastName = "Reddy" } ,
									new Customer { ID = 15, FirstName = "Jasmin"   , LastName = "Malviya" },
									new Customer { ID = 16, FirstName = "Haresh"   , LastName = "Bhanderi" },
									new Customer { ID = 17, FirstName = "Ankit"    , LastName = "Ramani" },
									new Customer { ID = 18, FirstName = "Sanket"   , LastName = "Shah" } ,
									new Customer { ID = 19, FirstName = "Amit"     , LastName = "Shah" } ,
									new Customer { ID = 20, FirstName = "Nilesh"   , LastName = "Soni" }       
			};

			var results = from c in customers
						  where c.FirstName.StartsWith("San") || c.LastName.StartsWith("S")
						  select c;

			var parallelResults = from c in customers.AsParallel()
								  where c.FirstName.StartsWith("San") || c.LastName.StartsWith("S")
								  select c;

			Console.WriteLine("------- Using Linq -----------\n");

			foreach (var item in results)
			{
				Console.WriteLine(item.ToString());
			}


			Console.WriteLine("\n------- Using Plinq -----------\n");


			foreach (var item in parallelResults)
			{
				Console.WriteLine(item.ToString());
			}

		
			Console.ReadLine();
		}
    }

	class Customer
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public override string ToString()
		{
			return string.Format($"ID: {ID} \t FirstName: {FirstName} \t LastName: {LastName} ");
		}
	}
}
