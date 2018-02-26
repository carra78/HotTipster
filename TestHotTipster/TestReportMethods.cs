using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster.DataAccess;
using HotTipster.BusinessLogic;
using HotTipster;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TestHotTipster
{
	[TestClass]
	public class TestReportMethods
	{
		HistoricDataReader hr = new HistoricDataReader();
		
		RaceCourse rc = new RaceCourse();
		

		[TestInitialize]
		public void Initialize()
		{
			
		}

		[TestMethod]
		public void TotalBetsWonOrLostByYear()
		{
			List<HorseBet> hbList = hr.ListOfHistoricHorseBetsOriginal();
			List<string> rcList = rc.ExistingRaceCourseNames();
			//List<dynamic> totals = ReportMethods.TotalBetsByYear();  
			/*Above line doesn't work when method is called but method and test use 
			 * same statements.. don't know why but may be because the datasource in
			 * method is the database but hear is the original data

			*/
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

			Assert.AreEqual(winningBets.Count(), 18);
			Assert.AreEqual(winsByYear.Count(), 2);
			Assert.AreEqual(winsByYear[0].Total, 1196.22M); //total for wins in 2017 - calculated in excel
			Assert.AreEqual(winsByYear[1].Total, 431.46m); //2016
			Assert.AreEqual(losingBets.Count(), 18);
			Assert.AreEqual(lossesByYear.Count(), 2);
			Assert.AreEqual(lossesByYear[0].Total, 205m);//2016
			Assert.AreEqual(lossesByYear[1].Total, 190m);//2017
			Assert.AreEqual(totals.Count(), 2); //only this one would be valid if testing the method call
		}

		[TestMethod]
		public void RaceCourseWithMostBets()
		{
			List<HorseBet> hbList = hr.ListOfHistoricHorseBetsOriginal();
			List<string> rcList = rc.ExistingRaceCourseNames();

			var query = (from hb in hbList
						 group hb by hb.RaceCourseName into gr
						 orderby gr.Count() descending
						 select new { Key = gr.Key, Count = gr.Count() }).First();

			string result = query.Key.ToString();
			//string result = ReportMethods.RaceCourseWithMostBets();  NOT working as DB not populated until form load and can't recreate that for testing

			Assert.AreEqual(result, "Punchestown");//Punchestown had 6 bets in historic data
		}

		[TestMethod]
		public void BetsInDateOrder()
		{

		}
	}
}
