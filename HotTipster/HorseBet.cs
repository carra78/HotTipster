using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipster
{
	public class HorseBet
	{
		public string RaceCourseName { get; set; }
		public DateTime RaceDate { get; set; }
		public decimal BetAmount { get; set; }
		public bool WinOrLose { get; set; }

		public HorseBet(string raceCourse, DateTime raceDate, decimal betAmount, bool win)
		{
			RaceCourseName = raceCourse;
			RaceDate = raceDate;
			BetAmount = betAmount;
			WinOrLose = win;
		}


	}
}
