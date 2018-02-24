using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipster
{
	public class HorseBet //: IEnumerable<HorseBet>
	{
		//local variables
		private int betID;
		private decimal amountWonOrLost;
		List<HorseBet> betList = new List<HorseBet>();


		//properties
		public string RaceCourseName { get; set; }
		public DateTime RaceDate { get; set; }
		public decimal BetAmount { get; set; }
		public bool BetResult { get; set; }
		public int CourseID { get; set; } //course name should be tied to ID or redirect to set up new course
		public int HorseID { get; set; } //name tied to ID or redirect to Add New
		
		public HorseBet(string raceCourse, DateTime raceDate, decimal betAmount, bool win)
		{
			RaceCourseName = raceCourse;
			RaceDate = raceDate;
			BetAmount = betAmount;
			BetResult = win;
		}
		public HorseBet(int raceCourseID,
						DateTime raceDate,
						decimal betAmount,
						bool win,
						int horseID = 0)
		{
			CourseID = raceCourseID;
			RaceDate = raceDate;
			BetAmount = betAmount;
			BetResult = win;
			HorseID = horseID;

		}
		public HorseBet(string raceCourse, DateTime raceDate, decimal betAmount, bool win, int courseID)
		{
			RaceCourseName = raceCourse;
			RaceDate = raceDate;
			BetAmount = betAmount;
			BetResult = win;
			CourseID = courseID;
		}


		//public IEnumerator<HorseBet> GetEnumerator()
		//{
		//	return betList.GetEnumerator();
		//}

		//IEnumerator IEnumerable.GetEnumerator()
		//{
		//	return this.GetEnumerator();
		//}



	}
}
