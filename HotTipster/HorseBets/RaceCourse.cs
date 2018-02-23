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

		public RaceCourse(string raceCourseName)
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
			List<HorseBet> historicBets = myReader.ListOfHorseBets();
			var names = historicBets.GroupBy(x => x.RaceCourseName).Select(y => y.First().ToString()).ToList();

			return names;

		}

	}
}
