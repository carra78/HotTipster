using System;
using System.Collections.Generic;
using HotTipster;
using HotTipster.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;

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
			HorseBet testBet = new HorseBet("Aintree", new DateTime(2017, 5, 12), 11.58m, true, 0);
			Assert.IsInstanceOfType(testBet, typeof(Object));
		}

		[TestMethod]
		public void testHorseBetConstructor()
		{
			HorseBet testHorseBet = new HorseBet("Aintree", new DateTime(2017, 5, 12), 11.58m, true, 0);
			object actualtype = testHorseBet.GetType();
			object expectedtype = typeof(HorseBet);
			Assert.AreEqual(actualtype, expectedtype);
		}

		[TestMethod]
		public void AddCourseIDToHistoricBetData()
		{
			List<HorseBet> bets;
			ReadWriteToSQLite dataWriter = new ReadWriteToSQLite();
			dataWriter.CreateDatabase();
			dataWriter.InsertExistingRaceCoursesIntoDB();
			bets = HorseBet.AddCourseIDToHistoricBetData();

			HorseBet test = new HorseBet("Aintree", new DateTime(2017, 5, 12), 11.58m, true,0);

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
			HistoricDataReader reader = new HistoricDataReader();// @"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt");
			IList<RaceCourse> rcList = ReadWriteToSQLite.RetrieveRaceCourseNamesFromDB();
			List<HorseBet> historicBets = reader.ListOfHistoricHorseBetsOriginal();

			foreach (var bet in historicBets)
			{
				var id = (from rc in rcList
						  where rc.RaceCourseName == bet.RaceCourseName
						  select rc.RaceCourseID).ToArray();
				bet.CourseID = id[0];
			}

			List<HorseBet> actualResult = historicBets;
			List<HorseBet> expectedResult = expectedResult = reader.ListOfHistoricHorseBetsWithCourseID();

			Assert.AreEqual(expectedResult.Count, actualResult.Count);
			Assert.AreEqual(expectedResult[0].CourseID, actualResult[0].CourseID);
			Assert.AreEqual(expectedResult[0].RaceCourseName, actualResult[0].RaceCourseName);
			Assert.AreEqual(expectedResult[0].RaceDate, actualResult[0].RaceDate);
			Assert.AreEqual(expectedResult[10].CourseID, actualResult[10].CourseID);
			Assert.AreEqual(expectedResult[10].RaceCourseName, actualResult[10].RaceCourseName);
			Assert.AreEqual(expectedResult[10].RaceDate, actualResult[10].RaceDate);
			//Assert.AreEqual(expectedResult[0], actualResult[0]); //Error = Assert.AreEqual failed. Expected:<HotTipster.HorseBet>. Actual:<HotTipster.HorseBet>. 

			//CollectionAssert.AreEquivalent(expectedResult, actualResult); // Can't get this to work
		}

		[TestMethod]
		public void TestBetListAddedToDatabase()
		{
			List<HorseBet> test = new List<HorseBet>();
			test.Add(new HorseBet("Aintree", new DateTime(2017, 5, 12), 11.58m, true, 1));

			ReadWriteToSQLite writer = new ReadWriteToSQLite();
			writer.InsertListOfBets(test);
			List<HorseBet> retrievedBet = new List<HorseBet>();
			retrievedBet = ReadWriteToSQLite.RetrieveHorseBetsFromDB();
			
			Assert.AreEqual(test[0].CourseID, retrievedBet[0].CourseID);
			Assert.AreEqual(test[0].BetAmount, retrievedBet[0].BetAmount);
			Assert.AreEqual(test[0].BetResult, retrievedBet[0].BetResult);
			Assert.AreEqual(test[0].RaceDate, retrievedBet[0].RaceDate);
			Assert.AreEqual(test.Count(), retrievedBet.Count());
		}

		[TestMethod]
		public void TestInsertNewHorseBet()
		{
			ReadWriteToSQLite dataWriter = new ReadWriteToSQLite();
			List<HorseBet> beforeList = ReadWriteToSQLite.RetrieveHorseBetsFromDB();
			dataWriter.InsertNewBet(3, new DateTime(2018, 2, 25), true, 25.00M);
			List<HorseBet> afterList = ReadWriteToSQLite.RetrieveHorseBetsFromDB();

			Assert.AreEqual(afterList.Count, beforeList.Count+1);
		}

	}

	//included this as part of attempt to get CollectionAssert.Equivalent to work..
	class HorseBetCompare : Comparer<HorseBet>
	{
		public override int Compare(HorseBet x, HorseBet y)
		{
			if (x.CourseID.CompareTo(y.CourseID) != 0)
			{
				return x.CourseID.CompareTo(y.CourseID);
			}
			else if (x.RaceCourseName.CompareTo(y.RaceCourseName) !=0)
			{
				return x.RaceCourseName.CompareTo(y.RaceCourseName);
			}
			else if (x.RaceDate.CompareTo(y.RaceDate) !=0)
			{
				return x.RaceDate.CompareTo(y.RaceDate);
			}
			else if (x.BetAmount.CompareTo(y.BetAmount) !=0)
			{
				return x.BetAmount.CompareTo(y.BetAmount);
			}
			else if (x.BetResult.CompareTo(y.BetResult) != 0)
			{
				return x.BetResult.CompareTo(y.BetResult);
			}
			//else if (x.HorseID.CompareTo(y.HorseID) !=0)
			//{
			//	return x.HorseID.CompareTo(y.HorseID);
			//}
			else
			{
				return 0;
			}

			throw new NotImplementedException();
		}
	}
}
