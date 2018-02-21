using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipster.HistoricData
{
	public class DataReader
	{
		//local variables


		//Properties
		public string FilePath { get; set; }

		//Constructors
		public DataReader(string filepath = "")
		{
			FilePath = filepath;
		}


		//Methods
		public List<HorseBet> ListOfHorseBets()
		{
			var result = new List<HorseBet>();
			return result;
		}
	}
}
