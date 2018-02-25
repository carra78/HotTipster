using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster;
using System.Collections.Generic;
using System.IO;
using HotTipster.DataAccess;

namespace TestHotTipster
{
	[TestClass]
	public class testRaceCourse
	{
		[TestMethod]
		public void TestRaceCourseClassExists()
		{
			RaceCourse rc = new RaceCourse("Aintree");
			Assert.IsInstanceOfType(rc, typeof(RaceCourse));
			
		}

		[TestMethod]
		public void TestRaceCourseListFromExistingDataIsAsExpected()
		{
			List<string> expectedNames = new List<string> {"Aintree", "Ascot", "Ayr", "Bangor", "Chester", "Cork",
				"Doncaster", "Dundalk", "Fairyhouse", "Goodwood", "Haydock", "Kelso", "Kilbeggan",
				"Perth", "Punchestown", "Sandown", "Towcester", "York"};

			RaceCourse rc = new RaceCourse();
			List<string> actualNames = rc.ExistingRaceCourseNames();

			CollectionAssert.AreEquivalent(expectedNames, actualNames); //order not relevant
			CollectionAssert.AreEqual(expectedNames, actualNames); // order must be the same
		}

		[TestMethod]
		public void TestAddNewRaceCourse()
		{
			ReadWriteToSQLite dataWriter = new ReadWriteToSQLite();
			List<RaceCourse> beforeList = dataWriter.RetrieveRaceCourseNamesFromDB();
			dataWriter.InsertNewRaceCourse("Ballinrobe");
			List<RaceCourse> afterList = dataWriter.RetrieveRaceCourseNamesFromDB();

			Assert.AreEqual(afterList.Count, beforeList.Count + 1);
		}

		[TestMethod]
		public void TestAddNewRaceCourseUsingExistingName()
		{
			ReadWriteToSQLite dataWriter = new ReadWriteToSQLite();
			List<RaceCourse> beforeList = dataWriter.RetrieveRaceCourseNamesFromDB();
			dataWriter.InsertNewRaceCourse("Aintree");
			List<RaceCourse> afterList = dataWriter.RetrieveRaceCourseNamesFromDB();

			Assert.AreEqual(afterList.Count, beforeList.Count);
		}



	}
}
