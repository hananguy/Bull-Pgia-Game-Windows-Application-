using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using GameUI;
using GameLogic;

public partial class GameForm : Form
{
	private readonly int m_NumberOfChances;
	private List<List<Button>> m_ColorGuessButtons = new List<List<Button>>();
	private List<Button> m_ArrowButtons = new List<Button>();
	private List<List<Panel>> m_FeedbackPanels = new List<List<Panel>>();
	private List<Button> m_ComputerChooseButtons = new List<Button>();
	private Dictionary<string, string> m_ColorsToChar;
	private Game m_GameLogic;


	private void InitializeComponent()
	{
		InitializeButtons();
		InitializeDictionary();
	}
	public GameForm(int i_NumberOfChances)
	{
		m_GameLogic = new Game();
		m_GameLogic.NumberOfGuessesChoosenByUser = i_NumberOfChances;
		m_NumberOfChances = i_NumberOfChances;
		InitializeComponent();
	}

	void InitializeDictionary()
	{
		m_ColorsToChar = new Dictionary<string, string>();
		m_ColorsToChar.Add("Purple", "A");
		m_ColorsToChar.Add("Red", "B");
		m_ColorsToChar.Add("Green", "C");
		m_ColorsToChar.Add("LightBlue", "D");
		m_ColorsToChar.Add("Blue", "E");
		m_ColorsToChar.Add("Yellow", "F");
		m_ColorsToChar.Add("Brown", "G");
		m_ColorsToChar.Add("White", "H");
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

		//The Current Form Size
		int totalWidth = 4 * (buttonSize + spacing) + spacing + arrowWidth + spacing + 2 * (feedbackSize + feedbackSpacing);
		int totalHeight = topMargin + buttonSize + computerRowSpacing + m_NumberOfChances * (buttonSize + spacing);

		totalWidth += 40;
		totalHeight += 10;

		this.ClientSize = new Size(totalWidth, totalHeight);
	}

	private void CreateComputerChooseButtons(int buttonSize, int spacing, int topMargin)
	{
		for (int col = 0; col < 4; col++)
		{
			System.Windows.Forms.Button compBtn = new System.Windows.Forms.Button();
			compBtn.Size = new Size(buttonSize, buttonSize);
			compBtn.Location = new Point(col * (buttonSize + spacing), topMargin);
			compBtn.Enabled = false;
			this.Controls.Add(compBtn);
			m_ComputerChooseButtons.Add(compBtn);
		}
	}

	private void CreateUserRowsAndArrows(int buttonSize, int spacing, int arrowWidth, int arrowHeight,int feedbackSize, int feedbackSpacing, int topMargin, int computerRowSpacing)
	{
		for (int row = 0; row < m_GameLogic.NumberOfGuessesChoosenByUser; row++)
		{
			List<Button> buttonRow = CreateColorGuessButtonsRow(row, buttonSize, spacing, topMargin, computerRowSpacing);
			m_ColorGuessButtons.Add(buttonRow);

			Button arrowBtn = CreateArrowButton(row, buttonSize, spacing, arrowWidth, arrowHeight, topMargin, computerRowSpacing);
			m_ArrowButtons.Add(arrowBtn);

			List<Panel> feedbackRow = CreateFeedbackPanels(row, arrowBtn, arrowWidth, spacing, feedbackSize, feedbackSpacing);
			m_FeedbackPanels.Add(feedbackRow);
		}
		EnableUserButtonRow(0);
		
	}
	void EnableUserButtonRow(int i_Row)
	{
		for(int i = 0; i < m_GameLogic.NumberOfPinsToGuess; i++)
		{
			m_ColorGuessButtons[i_Row][i].Enabled = true;
		}
	}
	void DiasbleButtonRow(int i_Row)
	{
		for (int i = 0; i < m_GameLogic.NumberOfPinsToGuess; i++)
		{
			m_ColorGuessButtons[i_Row][i].Enabled = false;
		}
	}

	private List<Button> CreateColorGuessButtonsRow(int row, int buttonSize, int spacing, int topMargin, int computerRowSpacing)
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
			btn.Enabled = false;
			btn.Click += new EventHandler(ColorGuessButton_Click);
			this.Controls.Add(btn);
			buttonRow.Add(btn);
		}

		return buttonRow;
	}

	private bool IsNewColor(Color i_ChoosenColor)
	{
		bool isNewColor = true;

		for(int i = 0; i < m_GameLogic.NumberOfPinsToGuess; i++)
		{
			Color btnColor = m_ColorGuessButtons[m_GameLogic.CurrentUserTurn][i].BackColor;
			if(i_ChoosenColor == btnColor)
			{
				isNewColor = false;
			}
		}
		return isNewColor;
	}
	private Button CreateArrowButton(int row, int buttonSize, int spacing, int arrowWidth, int arrowHeight, int topMargin, int computerRowSpacing)
	{
		System.Windows.Forms.Button arrowBtn = new System.Windows.Forms.Button();
		arrowBtn.Size = new Size(arrowWidth, arrowHeight);
		arrowBtn.Location = new Point(
			4 * (buttonSize + spacing) + spacing,
			topMargin + buttonSize + computerRowSpacing + row * (buttonSize + spacing)
		);
		arrowBtn.Text = "-->";
		arrowBtn.Click += new EventHandler(ArrowButton_Click);
		arrowBtn.Enabled = false;
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
			feedbackPanel.Enabled = false;
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

	private void ColorGuessButton_Click(object sender, EventArgs e)
	{
		Button clickedButton = sender as Button;
		Color guessColor = GetGuessColorFromUser();
		if(IsNewColor(guessColor))
		{
			clickedButton.BackColor = guessColor;
			if(IsRowFilled())
			{
				m_ArrowButtons[m_GameLogic.CurrentUserTurn].Enabled = true;
			}
		}
		else
		{
			MessageBox.Show("Duplicate Color!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );	
		}

	}
	private void ArrowButton_Click(Object sender, EventArgs e)
	{
		Button clickedCurrentArrowButton = sender as Button;

		//Check the user Guess
		//
		//
		//
		//
		//

		//Turn on next row of guesses
		DiasbleButtonRow(m_GameLogic.CurrentUserTurn);
		if (m_GameLogic.CurrentUserTurn < m_GameLogic.NumberOfGuessesChoosenByUser)
		{
			m_GameLogic.CurrentUserTurn++;
			EnableUserButtonRow(m_GameLogic.CurrentUserTurn);
		}
		clickedCurrentArrowButton.Enabled = false;
	}
	public bool IsRowFilled()
	{
		bool isRowFilled = true;
		for(int i = 0; i < m_GameLogic.NumberOfPinsToGuess; i++)
		{
			if(m_ColorGuessButtons[m_GameLogic.CurrentUserTurn][i].BackColor == SystemColors.Control)
			{
				isRowFilled = false;
				break;
			}
		}
		return isRowFilled;
	}
	public Color GetGuessColorFromUser()
	{
		Color color;
		PickAColorForm colorPicking = new PickAColorForm();
		colorPicking.ShowDialog();
		color = colorPicking.UserPickedColor;
		return color;
	}


}