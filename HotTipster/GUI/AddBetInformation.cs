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
	public partial class AddBetInformation : Form
	{
		ReadWriteToSQLite dbaccess = new ReadWriteToSQLite();

		public AddBetInformation()
		{
			InitializeComponent();
			cboRaceCourses.DataSource = HorseBet.ListOfRaceCourseNamesForAddBetComboBox();
			dtpRaceDate.Value = DateTime.Today;
			
			
		}

		private void btnAddBet_Click(object sender, EventArgs e)
		{
			string racecourseName = cboRaceCourses.SelectedItem.ToString();
			DateTime raceDate = dtpRaceDate.Value;
			Decimal betAmount = decimal.Parse(txtBetAmount.Text);
			bool result;
			if (rdoWin.Checked)
			{
				result = true;
			}
			else
			{
				result = false;
			}

			List<RaceCourse> rcList = new List<RaceCourse>();
			rcList = dbaccess.RetrieveRaceCourseNamesFromDB();
			var id = (from rc in rcList
					  where rc.RaceCourseName == racecourseName
					  select rc.RaceCourseID).ToArray();
			int raceCourseID = id[0];
			dbaccess.InsertNewBet(raceCourseID, raceDate, result, betAmount);

			//reset form
			cboRaceCourses.SelectedIndex = 0;
			dtpRaceDate.Value = DateTime.Today;
			txtBetAmount.Clear();
			rdoWin.Checked = true;

		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAddNewRaceCourse_Click(object sender, EventArgs e)
		{
			AddNewRaceCourse rc = new AddNewRaceCourse();
			rc.Show();
			this.Close();
		}
	}
}
