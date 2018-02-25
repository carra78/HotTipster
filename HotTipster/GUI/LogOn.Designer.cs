namespace HotTipster
{
	partial class Form1
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
			this.grbLogin = new System.Windows.Forms.GroupBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblUserName = new System.Windows.Forms.Label();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.grbLogin.SuspendLayout();
			this.SuspendLayout();
			// 
			// grbLogin
			// 
			this.grbLogin.Controls.Add(this.btnLogin);
			this.grbLogin.Controls.Add(this.lblPassword);
			this.grbLogin.Controls.Add(this.lblUserName);
			this.grbLogin.Controls.Add(this.txtPass);
			this.grbLogin.Controls.Add(this.txtUser);
			this.grbLogin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grbLogin.Location = new System.Drawing.Point(37, 26);
			this.grbLogin.Name = "grbLogin";
			this.grbLogin.Size = new System.Drawing.Size(318, 295);
			this.grbLogin.TabIndex = 0;
			this.grbLogin.TabStop = false;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(78, 219);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(158, 42);
			this.btnLogin.TabIndex = 4;
			this.btnLogin.Text = "Log in";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPassword.Location = new System.Drawing.Point(29, 173);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(79, 22);
			this.lblPassword.TabIndex = 3;
			this.lblPassword.Text = "Password";
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUserName.Location = new System.Drawing.Point(33, 81);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(92, 22);
			this.lblUserName.TabIndex = 2;
			this.lblUserName.Text = "User Name";
			// 
			// txtPass
			// 
			this.txtPass.Location = new System.Drawing.Point(33, 133);
			this.txtPass.Name = "txtPass";
			this.txtPass.PasswordChar = '*';
			this.txtPass.Size = new System.Drawing.Size(248, 37);
			this.txtPass.TabIndex = 1;
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(33, 37);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(248, 37);
			this.txtUser.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(398, 341);
			this.Controls.Add(this.grbLogin);
			this.Name = "Form1";
			this.Text = "HotTipster - Log in";
			this.grbLogin.ResumeLayout(false);
			this.grbLogin.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grbLogin;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.TextBox txtUser;
	}
}

