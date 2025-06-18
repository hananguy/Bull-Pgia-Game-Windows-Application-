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
		private Button m_FuchsiaButton;
		private Button m_RedButton;
		private Button m_LimeButton;
		private Button m_AquaButton;
		private Button m_BlueButton;
		private Button m_YellowButton;
		private Button m_BrownButton;
		private Button m_WhiteButton;
		private Color m_UserChoosenColor;

		
		public PickAColorForm()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.m_FuchsiaButton = new System.Windows.Forms.Button();
			this.m_RedButton = new System.Windows.Forms.Button();
			this.m_LimeButton = new System.Windows.Forms.Button();
			this.m_AquaButton = new System.Windows.Forms.Button();
			this.m_BlueButton = new System.Windows.Forms.Button();
			this.m_YellowButton = new System.Windows.Forms.Button();
			this.m_BrownButton = new System.Windows.Forms.Button();
			this.m_WhiteButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_FuchsiaButton
			// 
			this.m_FuchsiaButton.BackColor = System.Drawing.Color.Fuchsia;
			this.m_FuchsiaButton.Location = new System.Drawing.Point(12, 12);
			this.m_FuchsiaButton.Name = "m_PurpleButton";
			this.m_FuchsiaButton.Size = new System.Drawing.Size(57, 54);
			this.m_FuchsiaButton.TabIndex = 0;
			this.m_FuchsiaButton.UseVisualStyleBackColor = false;
			this.m_FuchsiaButton.Click += new System.EventHandler(this.m_FuchsiaButton_Click);
			// 
			// m_RedButton
			// 
			this.m_RedButton.BackColor = System.Drawing.Color.Red;
			this.m_RedButton.ForeColor = System.Drawing.SystemColors.Control;
			this.m_RedButton.Location = new System.Drawing.Point(79, 12);
			this.m_RedButton.Name = "m_RedButton";
			this.m_RedButton.Size = new System.Drawing.Size(57, 54);
			this.m_RedButton.TabIndex = 1;
			this.m_RedButton.UseVisualStyleBackColor = false;
			this.m_RedButton.Click += new System.EventHandler(this.m_RedButton_Click);
			// 
			// m_LimeButton
			// 
			this.m_LimeButton.BackColor = System.Drawing.Color.Lime;
			this.m_LimeButton.Location = new System.Drawing.Point(142, 12);
			this.m_LimeButton.Name = "m_GreenButton";
			this.m_LimeButton.Size = new System.Drawing.Size(57, 54);
			this.m_LimeButton.TabIndex = 2;
			this.m_LimeButton.UseVisualStyleBackColor = false;
			this.m_LimeButton.Click += new System.EventHandler(this.m_LimeButton_Click);
			// 
			// m_AquaButton
			// 
			this.m_AquaButton.BackColor = System.Drawing.Color.Aqua;
			this.m_AquaButton.Location = new System.Drawing.Point(205, 12);
			this.m_AquaButton.Name = "m_AquaButton";
			this.m_AquaButton.Size = new System.Drawing.Size(57, 54);
			this.m_AquaButton.TabIndex = 3;
			this.m_AquaButton.UseVisualStyleBackColor = false;
			this.m_AquaButton.Click += new System.EventHandler(this.m_AquaButton_Click);
			// 
			// m_BlueButton
			// 
			this.m_BlueButton.BackColor = System.Drawing.Color.Blue;
			this.m_BlueButton.Location = new System.Drawing.Point(12, 82);
			this.m_BlueButton.Name = "m_BlueButton";
			this.m_BlueButton.Size = new System.Drawing.Size(57, 54);
			this.m_BlueButton.TabIndex = 4;
			this.m_BlueButton.UseVisualStyleBackColor = false;
			this.m_BlueButton.Click += new System.EventHandler(this.m_BlueButton_Click);
			// 
			// m_YellowButton
			// 
			this.m_YellowButton.BackColor = System.Drawing.Color.Yellow;
			this.m_YellowButton.Location = new System.Drawing.Point(79, 82);
			this.m_YellowButton.Name = "m_YellowButton";
			this.m_YellowButton.Size = new System.Drawing.Size(57, 54);
			this.m_YellowButton.TabIndex = 5;
			this.m_YellowButton.UseVisualStyleBackColor = false;
			this.m_YellowButton.Click += new System.EventHandler(this.m_YellowButton_Click);
			// 
			// m_BorwnButton
			// 
			this.m_BrownButton.BackColor = System.Drawing.Color.Brown;
			this.m_BrownButton.Location = new System.Drawing.Point(142, 82);
			this.m_BrownButton.Name = "m_BrownButton";
			this.m_BrownButton.Size = new System.Drawing.Size(57, 54);
			this.m_BrownButton.TabIndex = 6;
			this.m_BrownButton.UseVisualStyleBackColor = false;
			this.m_BrownButton.Click += new System.EventHandler(this.m_BrownButton_Click);
			// 
			// m_WhiteButton
			// 
			this.m_WhiteButton.BackColor = System.Drawing.Color.White;
			this.m_WhiteButton.Location = new System.Drawing.Point(205, 82);
			this.m_WhiteButton.Name = "button1";
			this.m_WhiteButton.Size = new System.Drawing.Size(57, 54);
			this.m_WhiteButton.TabIndex = 7;
			this.m_WhiteButton.UseVisualStyleBackColor = false;
			this.m_BrownButton.Click += new System.EventHandler(this.m_WhiteButton_Click);
			// 
			// PickAColorForm
			// 
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(287, 149);
			this.Controls.Add(this.m_WhiteButton);
			this.Controls.Add(this.m_BrownButton);
			this.Controls.Add(this.m_YellowButton);
			this.Controls.Add(this.m_BlueButton);
			this.Controls.Add(this.m_AquaButton);
			this.Controls.Add(this.m_LimeButton);
			this.Controls.Add(this.m_RedButton);
			this.Controls.Add(this.m_FuchsiaButton);
			this.Name = "PickAColorForm";
			this.ResumeLayout(false);

		}
		public Color UserPickedColor
		{
			get { return m_UserChoosenColor; }
		}

		private void m_FuchsiaButton_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Fuchsia;
			this.Hide();
		}

		private void m_RedButton_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Red;
			this.Hide();
		}

		private void m_LimeButton_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Lime;
			this.Hide();
		}

		private void m_AquaButton_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Aqua;
			this.Hide();
		}

		private void m_BlueButton_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Blue;
			this.Hide();
		}

		private void m_YellowButton_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Yellow;
			this.Hide();
		}

		private void m_BrownButton_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.Brown;
			this.Hide();
		}
		private void m_WhiteButton_Click(object sender, EventArgs e)
		{
			m_UserChoosenColor = Color.White;
			this.Hide();
		}
	}
}
