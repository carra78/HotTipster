using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotTipster.HistoricData;
using System.Linq;
using System.Collections;

namespace HotTipster.HorseBets
{
	public class RaceCourse //: IEnumerable<RaceCourse>
	{
		public string RaceCourseName { get; set; }
		public int RaceCourseID { get; set; }
		List<RaceCourse> courseList = new List<RaceCourse>();

		public RaceCourse( int id = 0, string raceCourseName)
		{
			RaceCourseName = raceCourseName;
		}
		public RaceCourse()
		{
		}

		//public IEnumerator<RaceCourse> GetEnumerator()
		//{
		//	return courseList.GetEnumerator();
		//}

		//IEnumerator IEnumerable.GetEnumerator()
		//{
		//	return this.GetEnumerator();
		//}

		public List<string> ExistingRaceCourseNames()
		{
			HorseBetDataReader myReader = new HorseBetDataReader(@"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt");
			List<HorseBet> historicBets = myReader.ListOfHistoricHorseBets();
			//var names = historicBets.GroupBy(x => x.RaceCourseName).Select(y => y.First().ToString()).ToList();
			var groupednames = historicBets.GroupBy(x => x.RaceCourseName);
			List<string> names = new List<string>();
			foreach (var rcGroup in groupednames)
			{
				names.Add(rcGroup.Key.ToString());
			}
			names.Sort();
		
			return names;

		}

	}
}
