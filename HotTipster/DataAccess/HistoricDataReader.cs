using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotTipster.Utilities;
using System.IO;


namespace HotTipster.DataAccess
{
	public class HistoricDataReader
	{
		//local variables
		private string[] stringSplitCommaSeparator = { "," };
		string filepath = @"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt";

		//Properties
		//public string FilePath { get; set; }
		

		//Constructors
		
		public HistoricDataReader()
		{
		}


		//Methods
		public List<HorseBet> ListOfHistoricHorseBetsOriginal()
		{
			var result = new List<HorseBet>();
			try
			{
				using (FileStream fs = File.OpenRead(filepath))
				using (TextReader myreader = new StreamReader(fs, Encoding.UTF8))
				{
					while (myreader.Peek() > -1)
					{
						string line = myreader.ReadLine();
						string[] bet = line.Split(stringSplitCommaSeparator, StringSplitOptions.RemoveEmptyEntries);
						bet = MyUtilities.TrimArrayStrings(bet);
						bet[1] = bet[1].Substring(1, 4);
						bet[3] = bet[3].Substring(0, 2);
						bet[4] = bet[4].Substring(0, bet[4].Length - 1);

						result.Add(new HorseBet(bet[0], new DateTime(int.Parse(bet[1]), int.Parse(bet[2]), int.Parse(bet[3])), decimal.Parse(bet[4]), bool.Parse(bet[5]),0 ));
					}
				}
			}
			catch 
			{

				throw  new Exception("File input does not match expected datatypes");
			}
			
			return result;
		}


		public List<HorseBet> ListOfHistoricHorseBetsWithCourseID()
		{
			var result = new List<HorseBet>();
			try
			{
				using (FileStream fs = File.OpenRead(@"C:\Users\carra\Documents\HotTipster\RevisedData.txt"))
				using (TextReader myreader = new StreamReader(fs, Encoding.UTF8))
				{
					while (myreader.Peek() > -1)
					{
						string line = myreader.ReadLine();
						string[] bet = line.Split(stringSplitCommaSeparator, StringSplitOptions.RemoveEmptyEntries);
						bet = MyUtilities.TrimArrayStrings(bet);
						bet[1] = bet[1].Substring(1, 4);
						bet[3] = bet[3].Substring(0, 2);
						bet[4] = bet[4].Substring(0, bet[4].Length - 1);
						

						result.Add(new HorseBet(bet[0], new DateTime(int.Parse(bet[1]), int.Parse(bet[2]), int.Parse(bet[3])), decimal.Parse(bet[4]), bool.Parse(bet[5]), int.Parse(bet[6])));
					}
				}
			}
			catch
			{

				throw new Exception("File input does not match expected datatypes");
			}

			return result;
		}
	}
}
