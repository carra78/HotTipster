﻿namespace HotTipster.GUI
{
	partial class AddBetInformation
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnQuit = new System.Windows.Forms.Button();
			this.btnAddBet = new System.Windows.Forms.Button();
			this.txtBetAmount = new System.Windows.Forms.TextBox();
			this.dtpRaceDate = new System.Windows.Forms.DateTimePicker();
			this.rdoLose = new System.Windows.Forms.RadioButton();
			this.rdoWin = new System.Windows.Forms.RadioButton();
			this.btnAddNewRaceCourse = new System.Windows.Forms.Button();
			this.cboRaceCourses = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnQuit);
			this.groupBox1.Controls.Add(this.btnAddBet);
			this.groupBox1.Controls.Add(this.txtBetAmount);
			this.groupBox1.Controls.Add(this.dtpRaceDate);
			this.groupBox1.Controls.Add(this.rdoLose);
			this.groupBox1.Controls.Add(this.rdoWin);
			this.groupBox1.Controls.Add(this.btnAddNewRaceCourse);
			this.groupBox1.Controls.Add(this.cboRaceCourses);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(23, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(433, 455);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btnQuit
			// 
			this.btnQuit.Location = new System.Drawing.Point(261, 301);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(135, 53);
			this.btnQuit.TabIndex = 11;
			this.btnQuit.Text = "Quit";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// btnAddBet
			// 
			this.btnAddBet.Location = new System.Drawing.Point(64, 301);
			this.btnAddBet.Name = "btnAddBet";
			this.btnAddBet.Size = new System.Drawing.Size(127, 53);
			this.btnAddBet.TabIndex = 10;
			this.btnAddBet.Text = "Add Bet";
			this.btnAddBet.UseVisualStyleBackColor = true;
			this.btnAddBet.Click += new System.EventHandler(this.btnAddBet_Click);
			// 
			// txtBetAmount
			// 
			this.txtBetAmount.Location = new System.Drawing.Point(158, 174);
			this.txtBetAmount.Name = "txtBetAmount";
			this.txtBetAmount.Size = new System.Drawing.Size(247, 37);
			this.txtBetAmount.TabIndex = 9;
			// 
			// dtpRaceDate
			// 
			this.dtpRaceDate.CustomFormat = "";
			this.dtpRaceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpRaceDate.Location = new System.Drawing.Point(160, 110);
			this.dtpRaceDate.Name = "dtpRaceDate";
			this.dtpRaceDate.Size = new System.Drawing.Size(245, 37);
			this.dtpRaceDate.TabIndex = 8;
			// 
			// rdoLose
			// 
			this.rdoLose.AutoSize = true;
			this.rdoLose.Location = new System.Drawing.Point(261, 237);
			this.rdoLose.Name = "rdoLose";
			this.rdoLose.Size = new System.Drawing.Size(82, 33);
			this.rdoLose.TabIndex = 7;
			this.rdoLose.Text = "Lose";
			this.rdoLose.UseVisualStyleBackColor = true;
			// 
			// rdoWin
			// 
			this.rdoWin.AutoSize = true;
			this.rdoWin.Checked = true;
			this.rdoWin.Location = new System.Drawing.Point(160, 239);
			this.rdoWin.Name = "rdoWin";
			this.rdoWin.Size = new System.Drawing.Size(78, 33);
			this.rdoWin.TabIndex = 6;
			this.rdoWin.TabStop = true;
			this.rdoWin.Text = "Win";
			this.rdoWin.UseVisualStyleBackColor = true;
			// 
			// btnAddNewRaceCourse
			// 
			this.btnAddNewRaceCourse.Location = new System.Drawing.Point(330, 34);
			this.btnAddNewRaceCourse.Name = "btnAddNewRaceCourse";
			this.btnAddNewRaceCourse.Size = new System.Drawing.Size(75, 41);
			this.btnAddNewRaceCourse.TabIndex = 5;
			this.btnAddNewRaceCourse.Text = "New";
			this.btnAddNewRaceCourse.UseVisualStyleBackColor = true;
			this.btnAddNewRaceCourse.Click += new System.EventHandler(this.btnAddNewRaceCourse_Click);
			// 
			// cboRaceCourses
			// 
			this.cboRaceCourses.FormattingEnabled = true;
			this.cboRaceCourses.Location = new System.Drawing.Point(160, 37);
			this.cboRaceCourses.Name = "cboRaceCourses";
			this.cboRaceCourses.Size = new System.Drawing.Size(164, 37);
			this.cboRaceCourses.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 239);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 29);
			this.label4.TabIndex = 3;
			this.label4.Text = "Bet Result";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 177);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(131, 29);
			this.label3.TabIndex = 2;
			this.label3.Text = "Bet Amount";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 110);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 29);
			this.label2.TabIndex = 1;
			this.label2.Text = "Race Date";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Race Course";
			// 
			// AddBetInformation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(502, 492);
			this.Controls.Add(this.groupBox1);
			this.Name = "AddBetInformation";
			this.Text = "AddBetInformation";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.Button btnAddBet;
		private System.Windows.Forms.TextBox txtBetAmount;
		private System.Windows.Forms.DateTimePicker dtpRaceDate;
		private System.Windows.Forms.RadioButton rdoLose;
		private System.Windows.Forms.RadioButton rdoWin;
		private System.Windows.Forms.Button btnAddNewRaceCourse;
		private System.Windows.Forms.ComboBox cboRaceCourses;
	}
}