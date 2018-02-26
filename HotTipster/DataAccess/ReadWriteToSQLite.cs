using HotTipster.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.Sqlite;
using HotTipster;
using HotTipster.DataAccess;




namespace HotTipster.DataAccess
{
	public class ReadWriteToSQLite : IDataWriter
	{
		static string databaseName = "HotTipster.db";
		static SqliteConnection dbConnection = new SqliteConnection("Filename=HotTipster.db");
		private HistoricDataReader reader = new HistoricDataReader();//@"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt");
		private List<HorseBet> originalBets = new List<HorseBet>();


		public void WriteData()
		{

		}

		public bool OutputFileExists()
		{

			return MyUtilities.ValidFilePath(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + databaseName);
		}

		public void CreateDatabase()
		{
			using (dbConnection)
			{
				//string createHorsesTable = "CREATE TABLE IF NOT EXISTS Horses" +
				//	"(HorseID INTEGER PRIMARY KEY AUTOINCREMENT, " +
				//	"HorseName NVARCHAR(150) NOT NULL)";
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

				SqliteCommand cmdCoursesTable = new SqliteCommand(createRaceCoursesTable, dbConnection);
				SqliteCommand cmdHorseBetsTable = new SqliteCommand(createHorseBetsTable, dbConnection);

				try
				{
					dbConnection.Open();
					cmdCoursesTable.ExecuteNonQuery();
					cmdHorseBetsTable.ExecuteNonQuery();
					
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public void InsertExistingRaceCoursesIntoDB() //REFACTOR TO ADD RC 
		{
			//Add if file exists?  May not need if this only fires once
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

		public void InsertNewRaceCourse(string racecourseName) 
		{
			using (dbConnection)
			{
				string insertExistingRaceCourseName = "INSERT INTO Racecourses(RaceCourseName) VALUES (@courseName);";
				SqliteCommand cmdInsertRaceCourseNames = new SqliteCommand(insertExistingRaceCourseName, dbConnection);
				SqliteParameter courseName = new SqliteParameter("@courseName", SqliteType.Text);
				cmdInsertRaceCourseNames.Parameters.Add(courseName);
				
				try
				{					
					List<RaceCourse> existing = RetrieveRaceCourseNamesFromDB();
					var name = (from rc in existing
								select rc.RaceCourseName).ToArray();
					if (!name.Contains(racecourseName))
					{
						dbConnection.Open();
						courseName.Value = racecourseName;
						cmdInsertRaceCourseNames.ExecuteNonQuery();
					}
					
				}
				catch (Exception)
				{

					throw;
				}
			}
		}

		public static List<RaceCourse> RetrieveRaceCourseNamesFromDB()
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

		public void InsertListOfBets(List<HorseBet> bets)
		{
			string insertBets = "INSERT INTO HorseBets (RaceCourseID,RaceDate,BetResult,BetAmount)" +
				"VALUES(@courseID, @raceDate, @result, @amount)";
			SqliteCommand cmdInsertBet = new SqliteCommand(insertBets, dbConnection);
			SqliteParameter courseID = new SqliteParameter("@courseID", SqliteType.Integer);
			SqliteParameter raceDate = new SqliteParameter("@raceDate", SqliteType.Text);
			SqliteParameter result = new SqliteParameter("@result", SqliteType.Text);
			SqliteParameter amount = new SqliteParameter("@amount", SqliteType.Real);
			//SqliteParameter horseID = new SqliteParameter("@horseID", SqliteType.Integer);
			cmdInsertBet.Parameters.Add(courseID);
			cmdInsertBet.Parameters.Add(raceDate);
			cmdInsertBet.Parameters.Add(result);
			cmdInsertBet.Parameters.Add(amount);
			//cmdInsertBet.Parameters.Add(horseID);
			//HorseBet hb = new HorseBet();
			using (dbConnection)
			{
				try
				{
					dbConnection.Open();
					foreach (var bet in bets)
					{
						courseID.Value = bet.CourseID;
						raceDate.Value = bet.RaceDate;
						//horseID.Value = bet.HorseID;
						result.Value = bet.BetResult.ToString();
						amount.Value = bet.BetAmount;
						
						cmdInsertBet.ExecuteNonQuery();
					}

				}
				catch (Exception)
				{

					throw;
				}
			}
		}

		public void InsertNewBet(int rcID, DateTime date, bool betResult, decimal betAmount)
		{
			string insertBets = "INSERT INTO HorseBets (RaceCourseID,RaceDate,BetResult,BetAmount)" +
				"VALUES(@courseID, @raceDate, @result, @amount)";
			SqliteCommand cmdInsertBet = new SqliteCommand(insertBets, dbConnection);
			SqliteParameter courseID = new SqliteParameter("@courseID", SqliteType.Integer);
			SqliteParameter raceDate = new SqliteParameter("@raceDate", SqliteType.Text);
			SqliteParameter result = new SqliteParameter("@result", SqliteType.Text);
			SqliteParameter amount = new SqliteParameter("@amount", SqliteType.Real);
			cmdInsertBet.Parameters.Add(courseID);
			cmdInsertBet.Parameters.Add(raceDate);
			cmdInsertBet.Parameters.Add(result);
			cmdInsertBet.Parameters.Add(amount);
			using (dbConnection)
			{
				try
				{
					dbConnection.Open();
					courseID.Value = rcID;
					raceDate.Value = date;
					result.Value = betResult.ToString();
					amount.Value = betAmount;
					cmdInsertBet.ExecuteNonQuery();
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public static List<HorseBet> RetrieveHorseBetsFromDB()//add parameters? Apply filtering in code using linq instead?
		{
			//SqliteConnection dbConnection = new SqliteConnection("Filename=HotTipster.db");
			string select = "SELECT HorseBetID, RaceCourseID, RaceDate, BetResult, BetAmount FROM Horsebets";
			SqliteCommand selectBets = new SqliteCommand(select, dbConnection);
			List<HorseBet> retrievedBet = new List<HorseBet>();
			using (dbConnection)
			{
				dbConnection.Open();
				SqliteDataReader reader = selectBets.ExecuteReader();
				while (reader.Read())
				{
					HorseBet hb = new HorseBet();
					hb.BetID = reader.GetInt32(0);
					hb.CourseID = reader.GetInt32(1);
					//hb.CourseID = int.Parse(reader.GetString(0));
					hb.RaceDate = DateTime.Parse(reader.GetString(2));
					//hb.HorseID = reader.GetInt32(2);
					hb.BetResult = bool.Parse(reader.GetString(3));
					hb.BetAmount = decimal.Parse(reader.GetString(4));
					retrievedBet.Add(hb);
				}
			}
			return retrievedBet;
		}

	}
}
