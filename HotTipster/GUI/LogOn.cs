using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotTipster.BusinessLogic;
using HotTipster.GUI;

namespace HotTipster
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//Add HashCode Class to the Form
		HashCode hc = new HashCode();

		//variable to hold the username and password that will allow log-on to happen
		//hard coded here but would be a database look up in live environment
		string userName = "admin";
		string validPass = "2321811361251236021560571032095019514717622921715220";

		private void btnLogin_Click_1(object sender, EventArgs e)
		{
			//this code was used to get the value for validPass variable above using password "cornfield".
			//txtPass.Text = hc.HashData("cornfield");

			string user = txtUser.Text.ToLower();

			//hash the password value input by the user before checking against stored value
			string pass = hc.HashData(txtPass.Text.ToLower());

			if (user == userName)
			{
				if (pass == validPass)
				{
					HotTipsterMenu m = new HotTipsterMenu();
					m.Show();
					this.Hide();


				}
				else
				{
					MessageBox.Show("Invalid Password");
				}
			}
			else
			{
				MessageBox.Show("Invalid Username");
			}
		}
	}
}
