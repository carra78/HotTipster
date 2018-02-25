namespace HotTipster.GUI
{
	partial class HotTipsterMenu
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
			this.btnAddBetInfo = new System.Windows.Forms.Button();
			this.btnReports = new System.Windows.Forms.Button();
			this.btnQuit = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnQuit);
			this.groupBox1.Controls.Add(this.btnReports);
			this.groupBox1.Controls.Add(this.btnAddBetInfo);
			this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(31, 29);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(326, 317);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btnAddBetInfo
			// 
			this.btnAddBetInfo.Location = new System.Drawing.Point(48, 37);
			this.btnAddBetInfo.Name = "btnAddBetInfo";
			this.btnAddBetInfo.Size = new System.Drawing.Size(232, 60);
			this.btnAddBetInfo.TabIndex = 0;
			this.btnAddBetInfo.Text = "Add Bet Information";
			this.btnAddBetInfo.UseVisualStyleBackColor = true;
			this.btnAddBetInfo.Click += new System.EventHandler(this.btnAddBetInfo_Click);
			// 
			// btnReports
			// 
			this.btnReports.Location = new System.Drawing.Point(48, 118);
			this.btnReports.Name = "btnReports";
			this.btnReports.Size = new System.Drawing.Size(232, 57);
			this.btnReports.TabIndex = 1;
			this.btnReports.Text = "Reports";
			this.btnReports.UseVisualStyleBackColor = true;
			this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
			// 
			// btnQuit
			// 
			this.btnQuit.Location = new System.Drawing.Point(48, 200);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(232, 57);
			this.btnQuit.TabIndex = 2;
			this.btnQuit.Text = "Quit";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// HotTipsterMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 358);
			this.Controls.Add(this.groupBox1);
			this.Name = "HotTipsterMenu";
			this.Text = "Menu";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.Button btnReports;
		private System.Windows.Forms.Button btnAddBetInfo;
	}
}