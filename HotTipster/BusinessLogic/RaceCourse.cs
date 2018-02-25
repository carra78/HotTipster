using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotTipster.DataAccess;
using System.Collections;


namespace HotTipster
{
	public class RaceCourse //: IEnumerable<RaceCourse>
	{
		public string RaceCourseName { get; set; }
		public int RaceCourseID { get; set; }
		List<RaceCourse> courseList = new List<RaceCourse>();

		public RaceCourse( string raceCourseName, int id = 0)
		{
			RaceCourseName = raceCourseName;
			RaceCourseID = id;
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
			HistoricDataReader myReader = new HistoricDataReader(@"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt");
			List<HorseBet> historicBets = myReader.ListOfHistoricHorseBetsOriginal();
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
