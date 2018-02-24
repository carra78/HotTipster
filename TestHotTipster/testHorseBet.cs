using System;
using System.Collections.Generic;
using HotTipster;
using HotTipster.DataWriter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using HotTipster.HorseBets;
using HotTipster.HistoricData;

namespace TestHotTipster
{
	[TestClass]
	public class testHorseBet
	{
		[TestInitialize]
		public void Initialze()
		{
			string file = string.Format(Directory.GetCurrentDirectory() + Path.PathSeparator + "HotTipster.db");
			if (File.Exists(file))
			{
				File.Delete(file);
			}
		}

		[TestMethod]
		public void testHorseBetClassExists()
		{
			HorseBet testBet = new HorseBet("Aintree", new DateTime(2017, 5, 12), 11.58m, true);
			Assert.IsInstanceOfType(testBet, typeof(Object));
		}

		[TestMethod]
		public void testHorseBetConstructor()
		{
			HorseBet testHorseBet = new HorseBet("Aintree", new DateTime(2017, 5, 12), 11.58m, true);
			object actualtype = testHorseBet.GetType();
			object expectedtype = typeof(HorseBet);
			Assert.AreEqual(actualtype, expectedtype);
		}

		[TestMethod]
		public void AddCourseIDToHistoricBetData()
		{
			List<HorseBet> bets;
			WriteToSQLite dataWriter = new WriteToSQLite();
			dataWriter.CreateDatabase();
			dataWriter.InsertExistingRaceCoursesIntoDB();
			bets = dataWriter.ReplaceCourseNameWithCourseIDHistoricBets();

			HorseBet test = new HorseBet(1, new DateTime(2017, 5, 12), 11.58m, true);


			//CollectionAssert.Contains(bets, test);
			Assert.IsTrue(bets.Any(bet => bet.CourseID == 1));
			Assert.IsTrue(bets.Any(bet => bet.CourseID == 6));
			Assert.IsTrue(bets.Any(bet => bet.CourseID == 13));
			Assert.IsTrue(bets.Any(bet => bet.CourseID == 18));
			Assert.IsFalse(bets.Any(bet => bet.CourseID == 20));

		}


		[TestMethod]
		public void ReplaceCourseNameWithCourseID()
		{
			WriteToSQLite writer = new WriteToSQLite();
			HorseBetDataReader reader = new HorseBetDataReader(@"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt");
			IList<RaceCourse> rcList = writer.RetrieveRaceCourseNamesFromDB();
			List<HorseBet> historicBets = reader.ListOfHistoricHorseBetsOriginal();
			//var inputData = historicBets.Join(rcList,
			//								horseBet => horseBet.RaceCourseName,
			//								raceCourse => raceCourse.RaceCourseName,
			//								(horsebet, racecourse) => new
			//								{
			//									CourseID = racecourse.RaceCourseID,
			//									RaceDate = horsebet.RaceDate,
			//									Result = horsebet.BetResult,
			//									Amount = horsebet.BetAmount

			//								});
			foreach (var bet in historicBets)
			{
				var id = (from rc in rcList
						 where rc.RaceCourseName == bet.RaceCourseName
						 select rc.RaceCourseID).ToArray();
				bet.CourseID = id[0];
			}

			//List<HorseBet> actualResult = new List<HorseBet>();
			//foreach (var bet in inputData)
			//{
			//	HorseBet hb = new HorseBet(bet.CourseID, bet.RaceDate, bet.Amount, bet.Result);
			//	actualResult.Add(hb);
			//}
			List<HorseBet> expectedResult = reader.ListOfHistoricHorseBetsWithCourseID();

			CollectionAssert.AreEquivalent(expectedResult, historicBets);


		}

	}
}
