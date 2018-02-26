using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipster.DataAccess
{
	public class ReportMethods
	{
		static List<HorseBet> hbList = ReadWriteToSQLite.RetrieveHorseBetsFromDB();
		static List<RaceCourse> rcList = ReadWriteToSQLite.RetrieveRaceCourseNamesFromDB();

		public static List<dynamic> TotalBetsByYear()
		{
			var winningBets = (from hb in hbList
							   where hb.BetResult == true
							   select hb).ToList();
			var winsByYear = (from hb in winningBets
							  group hb by new { hb.RaceDate.Year } into y
							  select new { y.Key.Year, Total = y.Sum(hb => hb.BetAmount) }).ToList();

			var losingBets = (from hb in hbList
							  where hb.BetResult == false
							  select hb).ToList();
			var lossesByYear = (from hb in losingBets
								group hb by new { hb.RaceDate.Year } into y
								select new { y.Key.Year, Total = y.Sum(hb => hb.BetAmount) }).ToList();

			var totals = (from w in winsByYear
						  join l in lossesByYear
						  on w.Year equals l.Year
						  select new { w.Year, TotalW = w.Total, TotalL = l.Total }).ToList();

			return totals.ToList<dynamic>();
		}

		//had to split from selection to test selection of data from the database was correct
		public static DataTable TotalWonLostToDataTable(List<dynamic> list)
		{
			//Create new data table to hold results
			DataTable table = new DataTable();
			//Add heading
			table.Columns.Add("Year");
			table.Columns.Add("Total Won");
			table.Columns.Add("Total Lost");			
			
			foreach (var item in list)
			{
				var row = table.NewRow();
				
				row["Year"] = item.Year;
				row["Total Won"] = item.TotalW;
				row["Total Lost"] = item.TotalL;
				table.Rows.Add(row);
			}

			return table;

		}

		public static string RaceCourseWithMostBets()
		{
			var query = (from hb in hbList
						 group hb by hb.CourseID into gr
						 orderby gr.Count() descending
						 select new { Key = gr.Key, Count = gr.Count() }).First();
			string queryResult = query.Key.ToString();
			int id = int.Parse(queryResult);
			string result = "";
			foreach (var raceCourse in rcList)
			{
				if (id == raceCourse.RaceCourseID)
				{
					result = raceCourse.RaceCourseName;
				}
			}
			return result;
		}

		public static List<HorseBet> BetsInDateOrder()
		{
			var dateOrder = (from hb in hbList
							orderby hb.RaceDate descending
							select hb).ToList<HorseBet>();
			List<HorseBet> result = HorseBet.AddCoursenNameToRetrievedHorseBetData(dateOrder);
			return result;
		}

		public static DataTable ListOfBetsToDataTable(List<HorseBet> bets)
		{
			DataTable table = new DataTable();
			//Add heading
			table.Columns.Add("BetID");
			table.Columns.Add("RaceCourseID");
			table.Columns.Add("RaceCourseName");
			table.Columns.Add("RaceDate");
			table.Columns.Add("BetAmount");
			table.Columns.Add("BetResult");

			foreach (var item in bets)
			{
				var row = table.NewRow();

				row["BetID"] = item.BetID;
				row["RaceCourseID"] = item.CourseID;
				row["RaceCourseName"] = item.RaceCourseName;
				row["RaceDate"] = item.RaceDate.ToShortDateString();
				row["BetAmount"] = item.BetAmount;
				if (item.BetResult == true)
				{
					row["BetResult"] = "Win";
				}
				else
				{
					row["BetResult"] = "Loss";
				}
				table.Rows.Add(row);
			}

			return table;
		}

		public static List<HorseBet> BiggestWinAndBiggestLoss()
		{
			var winningBets = (from hb in hbList
							   where hb.BetResult == true
							   select hb).ToList();

			var highestWinAmt = winningBets.Max(x => x.BetAmount);

			var winner = (from hb in winningBets
						  where hb.BetAmount == highestWinAmt
						  select hb).ToList();
			var losingBets = (from hb in hbList
							  where hb.BetResult == false
							  select hb).ToList();

			var highestLossAmt = losingBets.Max(x => x.BetAmount);

			var loser = (from hb in losingBets
						  where hb.BetAmount == highestLossAmt
						  select hb).ToList();

			winner.AddRange(loser);
			winner = HorseBet.AddCoursenNameToRetrievedHorseBetData(winner);

			return winner;						  
		}

		public static int[] HotTipsterStats()
		{
			var winningBets = (from hb in hbList
							   where hb.BetResult == true
							   select hb).ToList();

			int[] result = { hbList.Count(), winningBets.Count() };
			return result;
		}




	}
}
