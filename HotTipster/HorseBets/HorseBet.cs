using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipster
{
	public class HorseBet
	{
		//local variables
		private int betID;
		private decimal amountWonOrLost;



		//properties
		public string RaceCourseName { get; set; }
		public DateTime RaceDate { get; set; }
		public decimal BetAmount { get; set; }
		public bool WinOrLose { get; set; }

		public int CouseID { get; set; } //course name should be tied to ID or redirect to set up new course
		public string CourseCondition { get; set; } //add enum with allowed values
		public int HorseID { get; set; } //name tied to ID or redirect to Add New
		public int JockeyID { get; set; } //name tied to ID or redirect to Add New
		public int TrainerID { get; set; }
		public int OddsLeft { get; set; }
		public int OddsRight { get; set; }
		public decimal AmountWonOrLost
		{
			get
			{
				return amountWonOrLost;
			}
			set
			{
				if (WinOrLose)
				{
					amountWonOrLost = BetAmount + (BetAmount * OddsLeft / OddsRight);
				}
				else
				{
					amountWonOrLost = BetAmount;
				}
			}
		}





		//		TipID Int PK Y
		//CourseID Int FK Y
		//RaceDate DateTime        Y
		//CourseCondition Enum(Hard, Medium, Soft)       N
		//HorseID Int FK  N
		//JockeyID    Int FK  N
		//TrainerID   Int FK  N
		//BetAmount   Decimal Y
		//Odds varchar(15)     N
		//Win/Lose Bool        Y
		//AmountWon/Lost Decimal     N


		public HorseBet(string raceCourse, DateTime raceDate, decimal betAmount, bool win)
		{
			RaceCourseName = raceCourse;
			RaceDate = raceDate;
			BetAmount = betAmount;
			WinOrLose = win;
		}


	}
}
