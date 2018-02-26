using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotTipster.DataAccess;

namespace HotTipster
{
	public class HorseBet //: IEnumerable<HorseBet>
	{
		//local variables
		//private int betID;
		//List<HorseBet> betList = new List<HorseBet>();


		//properties
		public string RaceCourseName { get; set; }
		public DateTime RaceDate { get; set; }
		public decimal BetAmount { get; set; }
		public bool BetResult { get; set; }
		public int CourseID { get; set; } //course name should be tied to ID or redirect to set up new course
		//public int HorseID { get; set; } //name tied to ID or redirect to Add New
		public int BetID { get; set; }
		
		public HorseBet(string raceCourse, DateTime raceDate, decimal betAmount, bool win, int courseID, int id = 0)
		{
			RaceCourseName = raceCourse;
			RaceDate = raceDate;
			BetAmount = betAmount;
			BetResult = win;
			CourseID = courseID;
			//HorseID = horseID;
			BetID = id;
		}

		public HorseBet()
		{
		}
		
		public static List<HorseBet> AddCourseIDToHistoricBetData()
		{
			//ReadWriteToSQLite writer = new ReadWriteToSQLite();
			HistoricDataReader reader = new HistoricDataReader();//@"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt");
			List<RaceCourse> rcList = ReadWriteToSQLite.RetrieveRaceCourseNamesFromDB();
			List<HorseBet> historicBets = reader.ListOfHistoricHorseBetsOriginal();
			foreach (var bet in historicBets)
			{
				var id = (from rc in rcList
						  where rc.RaceCourseName == bet.RaceCourseName
						  select rc.RaceCourseID).ToArray();
				bet.CourseID = id[0];
			}

			return historicBets;

		}

		public static List<HorseBet> AddCoursenNameToRetrievedHorseBetData(List<HorseBet> bets)
		{
			List<RaceCourse> rcList = ReadWriteToSQLite.RetrieveRaceCourseNamesFromDB();
			foreach (var bet in bets)
			{
				var id = (from rc in rcList
						  where rc.RaceCourseID == bet.CourseID
						  select rc.RaceCourseName).ToArray();
				bet.RaceCourseName = id[0];
			}

			return bets;

		}

		public static List<string> ListOfRaceCourseNamesForAddBetComboBox()
		{
			//no unit test - rely on test for retrieve racecourse list from DB and observation of result in combo box
			//ReadWriteToSQLite reader = new ReadWriteToSQLite();
			List<RaceCourse> rcList = ReadWriteToSQLite.RetrieveRaceCourseNamesFromDB();
			var comboList = (from rc in rcList
							 select rc.RaceCourseName).ToList();

			return comboList;
		}


	}
}
