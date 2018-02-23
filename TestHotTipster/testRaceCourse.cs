using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster.HorseBets;
using System.Collections.Generic;

namespace TestHotTipster
{
	[TestClass]
	public class testRaceCourse
	{
		[TestMethod]
		public void TestRaceCourseClassExists()
		{
			RaceCourse course = new RaceCourse("Aintree");
			Assert.IsInstanceOfType(course, typeof(RaceCourse));
			
		}

		

	}
}
