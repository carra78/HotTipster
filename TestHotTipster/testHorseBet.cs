using System;
using System.Collections.Generic;
using HotTipster;
using HotTipster.DataWriter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

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
	}
}
