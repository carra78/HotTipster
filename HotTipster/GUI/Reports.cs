using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotTipster.DataAccess;

namespace HotTipster.GUI
{
	public partial class Reports : Form
	{
		//List<HorseBet> hbList = ReadWriteToSQLite.RetrieveHorseBetsFromDB();
		//List<RaceCourse> rcList = ReadWriteToSQLite.RetrieveRaceCourseNamesFromDB();

		public Reports()
		{
			InitializeComponent();
			//List<RaceCourse> rcList = ReadWriteToSQLite.RetrieveRaceCourseNamesFromDB();
			//List<HorseBet> hbList = ReadWriteToSQLite.RetrieveHorseBetsFromDB();

		}

		private void btnReportByYear_Click(object sender, EventArgs e)
		{
			lstDisplay.Visible = false;
			dgvReports.DataSource = null;
			dgvReports.Rows.Clear();
			dgvReports.DataSource = ReportMethods.TotalWonLostToDataTable(ReportMethods.TotalBetsByYear());
			dgvReports.Visible = true;
			
		}

		private void btnReportFavRaceCourse_Click(object sender, EventArgs e)
		{
			dgvReports.Visible = false;

			lstDisplay.Items.Add(string.Format("The most popular racecourse is {0}.", ReportMethods.RaceCourseWithMostBets()));
			lstDisplay.Visible = true;
		}

		private void btnReportAllByDate_Click(object sender, EventArgs e)
		{
			lstDisplay.Visible = false;
			dgvReports.DataSource = null;
			dgvReports.Rows.Clear();
			dgvReports.DataSource = ReportMethods.ListOfBetsToDataTable(ReportMethods.BetsInDateOrder());
			dgvReports.Visible = true;
		}

		private void btnReportMaxWinLose_Click(object sender, EventArgs e)
		{
			lstDisplay.Visible = false;
			dgvReports.DataSource = null;
			dgvReports.Rows.Clear();
			dgvReports.DataSource = ReportMethods.ListOfBetsToDataTable(ReportMethods.BiggestWinAndBiggestLoss());
			dgvReports.Visible = true;
		}

		private void btnReportSuccessRate_Click(object sender, EventArgs e)
		{
			dgvReports.Visible = false;
			lstDisplay.Items.Clear();
			int[] totals = ReportMethods.HotTipsterStats();
			lstDisplay.Items.Add(string.Format("The total number of bets is {0} and the total won is {1}.", totals[0], totals[1]));
			lstDisplay.Visible = true;
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
