using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameUI
{
	
	public class PickAColorForm : Form
	{
		private Color m_UserChoosenColor;
		private Button m_Purple;
		private Button m_Red;
		private Button m_Green;
		private Button m_LightBlue;
		private Button m_Blue;
		private Button m_Yellow;
		private Button m_Brown;
		private Button m_White;
		public PickAColorForm()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.m_Purple = new System.Windows.Forms.Button();
			this.m_Red = new System.Windows.Forms.Button();
			this.m_Green = new System.Windows.Forms.Button();
			this.m_LightBlue = new System.Windows.Forms.Button();
			this.m_Blue = new System.Windows.Forms.Button();
			this.m_Yellow = new System.Windows.Forms.Button();
			this.m_Brown = new System.Windows.Forms.Button();
			this.m_White = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_Purple
			// 
			this.m_Purple.BackColor = System.Drawing.Color.Purple;
			this.m_Purple.Location = new System.Drawing.Point(12, 12);
			this.m_Purple.Name = "m_Purple";
			this.m_Purple.Size = new System.Drawing.Size(61, 52);
			this.m_Purple.TabIndex = 1;
			this.m_Purple.UseVisualStyleBackColor = false;
			this.m_Purple.Click += new System.EventHandler(this.m_Purple_Click);
			// 
			// m_Red
			// 
			this.m_Red.BackColor = System.Drawing.Color.Red;
			this.m_Red.Location = new System.Drawing.Point(79, 12);
			this.m_Red.Name = "m_Red";
			this.m_Red.Size = new System.Drawing.Size(61, 52);
			this.m_Red.TabIndex = 2;
			this.m_Red.UseVisualStyleBackColor = false;
			this.m_Red.Click += new System.EventHandler(this.m_Red_Click);
			// 
			// m_Green
			// 
			this.m_Green.BackColor = System.Drawing.Color.Aqua;
			this.m_Green.Location = new System.Drawing.Point(213, 12);
			this.m_Green.Name = "m_Green";
			this.m_Green.Size = new System.Drawing.Size(61, 52);
			this.m_Green.TabIndex = 3;
			this.m_Green.UseVisualStyleBackColor = false;
			this.m_Green.Click += new System.EventHandler(this.m_Green_Click);
			// 
			// m_LightBlue
			// 
			this.m_LightBlue.BackColor = System.Drawing.Color.Brown;
			this.m_LightBlue.Location = new System.Drawing.Point(146, 70);
			this.m_LightBlue.Name = "m_LightBlue";
			this.m_LightBlue.Size = new System.Drawing.Size(61, 52);
			this.m_LightBlue.TabIndex = 4;
			this.m_LightBlue.UseVisualStyleBackColor = false;
			this.m_LightBlue.Click += new System.EventHandler(this.m_LightBlue_Click);
			// 
			// m_Blue
			// 
			this.m_Blue.BackColor = System.Drawing.Color.Lime;
			this.m_Blue.Location = new System.Drawing.Point(146, 12);
			this.m_Blue.Name = "m_Blue";
			this.m_Blue.Size = new System.Drawing.Size(61, 52);
			this.m_Blue.TabIndex = 5;
			this.m_Blue.UseVisualStyleBackColor = false;
			this.m_Blue.Click += new System.EventHandler(this.m_Blue_Click);
			// 
			// m_Yellow
			// 
			this.m_Yellow.BackColor = System.Drawing.Color.Blue;
			this.m_Yellow.Location = new System.Drawing.Point(12, 70);
			this.m_Yellow.Name = "m_Yellow";
			this.m_Yellow.Size = new System.Drawing.Size(61, 52);
			this.m_Yellow.TabIndex = 6;
			this.m_Yellow.UseVisualStyleBackColor = false;
			this.m_Yellow.Click += new System.EventHandler(this.m_Yellow_Click);
			// 
			// m_Brown
			// 
			this.m_Brown.Location = new System.Drawing.Point(213, 70);
			this.m_Brown.Name = "m_Brown";
			this.m_Brown.Size = new System.Drawing.Size(61, 52);
			this.m_Brown.TabIndex = 7;
			this.m_Brown.UseVisualStyleBackColor = true;
			this.m_Brown.Click += new System.EventHandler(this.m_Brown_Click);
			// 
			// m_White
			// 
			this.m_White.BackColor = System.Drawing.Color.Yellow;
			this.m_White.Location = new System.Drawing.Point(79, 70);
			this.m_White.Name = "m_White";
			this.m_White.Size = new System.Drawing.Size(61, 52);
			this.m_White.TabIndex = 8;
			this.m_White.UseVisualStyleBackColor = false;
			this.m_White.Click += new System.EventHandler(this.m_White_Click);
			// 
			// PickAColorForm
			// 
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(365, 228);
			this.Controls.Add(this.m_White);
			this.Controls.Add(this.m_Brown);
			this.Controls.Add(this.m_Yellow);
			this.Controls.Add(this.m_Blue);
			this.Controls.Add(this.m_LightBlue);
			this.Controls.Add(this.m_Green);
			this.Controls.Add(this.m_Red);
			this.Controls.Add(this.m_Purple);
			this.Name = "PickAColorForm";
			this.ResumeLayout(false);

		}

		private void m_Purple_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Purple;
			this.Hide();
		}

		private void m_Red_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Red;
			this.Hide();
		}

		private void m_Green_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Aqua;
			this.Hide();
		}

		private void m_LightBlue_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Maroon;
			this.Hide();
		}

		private void m_Blue_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Lime;
			this.Hide();
		}

		private void m_Yellow_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Blue;
			this.Hide();
		}

		private void m_Brown_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Brown;
			this.Hide();
		}

		private void m_White_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.White;
			this.Hide();
		}

		public Color UserPickedColor
		{
			get { return m_UserChoosenColor; }
		}
	}
}
