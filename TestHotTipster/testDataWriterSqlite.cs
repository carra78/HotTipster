using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster.DataWriter;

namespace TestHotTipster
{
	[TestClass]
	public class testDataWriterSqlite
	{
		[TestMethod]
		public void TestCreateDatabase()
		{
			string filepath = "test";
			WriteToSQLite dataWriter = new WriteToSQLite();
			dataWriter.CreateDatabase();
			string actualFilePath = string.Format(Directory.GetCurrentDirectory() + Path.PathSeparator + "HotTipster.db");
			//Assert.AreEqual(filepath, actualFilePath);

		}
	}
}
