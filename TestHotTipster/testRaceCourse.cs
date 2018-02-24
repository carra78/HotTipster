﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster.HorseBets;
using System.Collections.Generic;
using System.IO;

namespace TestHotTipster
{
	[TestClass]
	public class testRaceCourse
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




	}
}
