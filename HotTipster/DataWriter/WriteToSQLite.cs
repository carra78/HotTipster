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
		//static SqliteConnection dbConnection = new SqliteConnection(string.Format("Filename='{0}'", databaseName));
		SqliteConnection dbConnection = new SqliteConnection("Filename=HotTipster.db");

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


	}
}
