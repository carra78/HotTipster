using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster.DataWriter;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using HotTipster.HorseBets;

namespace TestHotTipster
{
	[TestClass]
	public class testDataWriterSqlite
	{
		WriteToSQLite dataWriter = new WriteToSQLite();

		[TestInitialize]
		public void Initialize()
		{
			string file = @"C:\Users\carra\Documents\HotTipster\TestHotTipster\bin\Debug\HotTipster.db";
			if (File.Exists(file))
			{
				File.Delete(file);
			}
			dataWriter.CreateDatabase();

		}

		[TestMethod]
		public void TestCreateDatabase()
		{
			//dataWriter.CreateDatabase(); //creates SQLite DB in TestHotTipster Project in bin\Debug folder
			string expectedFilepath = string.Format(Directory.GetCurrentDirectory() + Path.PathSeparator + "HotTipster.db"); 
			string actualFilePath = @"C:\Users\carra\Documents\HotTipster\TestHotTipster\bin\Debug;HotTipster.db";
			Assert.AreEqual(expectedFilepath, actualFilePath);

		}

		[TestMethod]
		public void check18RaceCourseNamesAddedToDB()
		{
			dataWriter = new WriteToSQLite();
			List<RaceCourse> rcList = new List<RaceCourse>();
			SqliteConnection dbConnection = new SqliteConnection("Filename=HotTipster.db");

			//set up query using parameters
			string query = "SELECT RaceCourseID, RaceCourseName FROM Racecourses";
			SqliteCommand cmdselectCourseNames = new SqliteCommand(query, dbConnection);
			
			using (dbConnection)
			{
				dbConnection.Open();
				dataWriter.InsertExistingRaceCoursesIntoDB();
				SqliteDataReader results = cmdselectCourseNames.ExecuteReader();
				while (results.Read())
				{
					RaceCourse rc = new RaceCourse();
					rc.RaceCourseID = results.GetInt32(0);
					rc.RaceCourseName = results.GetString(1);
					rcList.Add(rc);
				}
				
			}

			int expectedLength = 18; //number of unique racecourse names in historic data
			int actualLenght = rcList.Count;

			Assert.AreEqual(expectedLength, actualLenght);


		}


		
	}
}
