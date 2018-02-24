using HotTipster.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.Sqlite;
using HotTipster.HistoricData;
using HotTipster.HorseBets;

namespace HotTipster.DataWriter
{
	public class WriteToSQLite : IDataWriter
	{
		private static string databaseName = "HotTipster.db";
		SqliteConnection dbConnection = new SqliteConnection("Filename=HotTipster.db");
		HorseBetDataReader reader = new HorseBetDataReader(@"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt");
		

		public void WriteData()
		{

		}

		public bool CheckDatabaseExists()
		{

			return MyUtilities.ValidFilePath(Directory.GetCurrentDirectory() + Path.PathSeparator + databaseName);
		}

		public void CreateDatabase()
		{
			using (dbConnection)
			{
				string createHorsesTable = "CREATE TABLE IF NOT EXISTS Horses" +
					"(HorseID INTEGER PRIMARY KEY AUTOINCREMENT, " +
					"HorseName NVARCHAR(150) NOT NULL)";
				string createRaceCoursesTable = "CREATE TABLE IF NOT EXISTS RaceCourses" +
					"(RaceCourseID INTEGER PRIMARY KEY AUTOINCREMENT, " +
					"RaceCourseName NVARCHAR(150) NOT NULL)";
				string createHorseBetsTable = "CREATE TABLE IF NOT EXISTS HorseBets" +
					"(HorseBetID INTEGER PRIMARY KEY AUTOINCREMENT, " +
					"RaceCourseID integer NOT NULL," +
					"RaceDate text NOT NULL," +
					"HorseID integer NULL," +
					"BetResult text NOT NULL," +
					"BetAmount real NOT NULL)";				

				SqliteCommand cmdHorsesTable = new SqliteCommand(createHorsesTable, dbConnection);
				SqliteCommand cmdCoursesTable = new SqliteCommand(createRaceCoursesTable, dbConnection);
				SqliteCommand cmdHorseBetsTable = new SqliteCommand(createHorseBetsTable, dbConnection);

				try
				{
					dbConnection.Open();
					cmdHorsesTable.ExecuteNonQuery();
					cmdCoursesTable.ExecuteNonQuery();
					cmdHorseBetsTable.ExecuteNonQuery();
					
				}
				catch (Exception)
				{

					throw;
				}
			}
		}

		public void InsertExistingRaceCoursesIntoDB()
		{
			using (dbConnection)
			{
				string insertExistingRaceCourseName = "INSERT INTO Racecourses(RaceCourseName) VALUES (@courseName);";
				SqliteCommand cmdInsertRaceCourseNames = new SqliteCommand(insertExistingRaceCourseName, dbConnection);
				SqliteParameter courseName = new SqliteParameter("@courseName", SqliteType.Text);
				cmdInsertRaceCourseNames.Parameters.Add(courseName);
				RaceCourse rc = new RaceCourse();
				try
				{
					dbConnection.Open();
					foreach (var item in rc.ExistingRaceCourseNames())
					{
						courseName.Value = item;
						cmdInsertRaceCourseNames.ExecuteNonQuery();
					}
				}
				catch (Exception)
				{

					throw;
				}

			}
		}

		public List<RaceCourse> RetrieveRaceCourseNamesFromDB()
		{
			string query = "SELECT RaceCourseID, RaceCourseName FROM Racecourses";
			SqliteCommand cmdselectCourseNames = new SqliteCommand(query, dbConnection);
			List<RaceCourse> rcList = new List<RaceCourse>();

			using (dbConnection)
			{				
				dbConnection.Open();
				SqliteDataReader results = cmdselectCourseNames.ExecuteReader();
				while (results.Read())
				{
					RaceCourse rc = new RaceCourse();
					rc.RaceCourseID = results.GetInt32(0);
					rc.RaceCourseName = results.GetString(1);
					rcList.Add(rc);
				}

			}
			return rcList;
		}



		public List<HorseBet> ReplaceCourseNameWithCourseIDHistoricBets()
		{
			IList<RaceCourse> rcList = RetrieveRaceCourseNamesFromDB();
			IList<HorseBet> historicBets = reader.ListOfHistoricHorseBetsOriginal();
			var inputData = historicBets.Join(rcList,
											horseBet => horseBet.RaceCourseName,
											raceCourse => raceCourse.RaceCourseName,
											(horsebet, racecourse) => new
											{
												CourseID = racecourse.RaceCourseID,
												RaceDate = horsebet.RaceDate,
												Result = horsebet.BetResult,
												Amount = horsebet.BetAmount

											}).ToList();
			List<HorseBet> result = new List<HorseBet>();
			foreach (var bet in inputData)
			{
				HorseBet hb = new HorseBet(bet.CourseID, bet.RaceDate, bet.Amount, bet.Result);
				result.Add(hb);
			}

			return result;

		}


		public void InsertExistingBetData()
		{
			

			string insertBets = "INSERT INTO HorseBets (RaceCourseID,RaceDate,BetResult,BetAmount)" +
				"VALUES(@courseID, @raceDate, @result, @amount)";
			SqliteCommand cmdInsertHistoricBets = new SqliteCommand(insertBets, dbConnection);
			SqliteParameter courseID = new SqliteParameter("@courseID", SqliteType.Integer);
			SqliteParameter raceDate = new SqliteParameter("@raceDate", SqliteType.Text);
			SqliteParameter result = new SqliteParameter("@result", SqliteType.Text);
			SqliteParameter amount = new SqliteParameter("@amount", SqliteType.Real);
			

		}


	}
}
