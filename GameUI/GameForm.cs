using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

public partial class GameForm : Form
{
	private readonly int m_NumberOfChances;
	private List<List<Button>> buttonRows = new List<List<Button>>();
	private List<Button> arrowButtons = new List<Button>();
	private List<List<Panel>> feedbackPanels = new List<List<Panel>>();
	private List<Button> computerChooseButtons = new List<Button>();

	private void InitializeComponent()
	{
		InitializeButtons();
	}
	public GameForm(int i_NumberOfChances)
	{
		m_NumberOfChances = i_NumberOfChances;
		InitializeComponent();
	}
	
	private void InitializeButtons()
	{
		int buttonSize = 40;
		int spacing = 10;
		int arrowWidth = 30;
		int arrowHeight = buttonSize;
		int feedbackSize = buttonSize / 2 - 2;
		int feedbackSpacing = 2;
		int topMargin = 30;
		int computerRowSpacing = 30;

		CreateComputerChooseButtons(buttonSize, spacing, topMargin);
		CreateUserRowsAndArrows(buttonSize, spacing, arrowWidth, arrowHeight, feedbackSize, feedbackSpacing, topMargin, computerRowSpacing);
	}

	private void CreateComputerChooseButtons(int buttonSize, int spacing, int topMargin)
	{
		for (int col = 0; col < 4; col++)
		{
			Button compBtn = new Button();
			compBtn.Size = new Size(buttonSize, buttonSize);
			compBtn.Location = new Point(col * (buttonSize + spacing), topMargin);
			compBtn.Enabled = false;
			this.Controls.Add(compBtn);
			computerChooseButtons.Add(compBtn);
		}
	}

	private void CreateUserRowsAndArrows(int buttonSize, int spacing, int arrowWidth, int arrowHeight,int feedbackSize, int feedbackSpacing, int topMargin, int computerRowSpacing)
	{
		for (int row = 0; row < m_NumberOfChances; row++)
		{
			var buttonRow = CreateUserRow(row, buttonSize, spacing, topMargin, computerRowSpacing);
			buttonRows.Add(buttonRow);

			Button arrowBtn = CreateArrowButton(row, buttonSize, spacing, arrowWidth, arrowHeight, topMargin, computerRowSpacing);
			arrowButtons.Add(arrowBtn);

			var feedbackRow = CreateFeedbackPanels(row, arrowBtn, arrowWidth, spacing, feedbackSize, feedbackSpacing);
			feedbackPanels.Add(feedbackRow);
		}
	}

	private List<Button> CreateUserRow(int row, int buttonSize, int spacing, int topMargin, int computerRowSpacing)
	{
		var buttonRow = new List<Button>();
		for (int col = 0; col < 4; col++)
		{
			Button btn = new Button();
			btn.Size = new Size(buttonSize, buttonSize);
			btn.Location = new Point(
				col * (buttonSize + spacing),
				topMargin + buttonSize + computerRowSpacing + row * (buttonSize + spacing)
			);
			btn.Text = "";
			this.Controls.Add(btn);
			buttonRow.Add(btn);
		}
		return buttonRow;
	}

	private Button CreateArrowButton(int row, int buttonSize, int spacing, int arrowWidth, int arrowHeight, int topMargin, int computerRowSpacing)
	{
		Button arrowBtn = new Button();
		arrowBtn.Size = new Size(arrowWidth, arrowHeight);
		arrowBtn.Location = new Point(
			4 * (buttonSize + spacing) + spacing,
			topMargin + buttonSize + computerRowSpacing + row * (buttonSize + spacing)
		);
		arrowBtn.Text = "-->";
		this.Controls.Add(arrowBtn);
		return arrowBtn;
	}

	private List<Panel> CreateFeedbackPanels(int row, Button arrowBtn, int arrowWidth, int spacing, int feedbackSize, int feedbackSpacing)
	{
		var feedbackRow = new List<Panel>();
		int feedbackOriginX = arrowBtn.Location.X + arrowWidth + spacing;
		int feedbackOriginY = arrowBtn.Location.Y;

		for (int i = 0; i < 4; i++)
		{
			Panel feedbackPanel = new Panel();
			feedbackPanel.Size = new Size(feedbackSize, feedbackSize);
			int offsetX = (i % 2) * (feedbackSize + feedbackSpacing);
			int offsetY = (i / 2) * (feedbackSize + feedbackSpacing);
			feedbackPanel.Location = new Point(
				feedbackOriginX + offsetX,
				feedbackOriginY + offsetY
			);
			feedbackPanel.BorderStyle = BorderStyle.FixedSingle;
			feedbackPanel.BackColor = Color.White;
			feedbackPanel.Click += FeedbackPanel_Click;
			this.Controls.Add(feedbackPanel);
			feedbackRow.Add(feedbackPanel);
		}
		return feedbackRow;
	}

	private void FeedbackPanel_Click(object sender, EventArgs e)
	{
		Panel panel = sender as Panel;
		panel.BackColor = panel.BackColor == Color.Red ? Color.White : Color.Red;
	}
}