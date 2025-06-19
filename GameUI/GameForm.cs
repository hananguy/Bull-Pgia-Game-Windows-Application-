using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using GameUI;
using GameLogic;
using System.Text;

public partial class GameForm : Form
{
	private List<List<Button>> m_ColorGuessButtons = new List<List<Button>>();
	private List<Button> m_ArrowButtons = new List<Button>();
	private List<List<Panel>> m_FeedbackPanels = new List<List<Panel>>();
	private List<Button> m_ComputerChooseButtons = new List<Button>();
	private Dictionary<string, string> m_ColorToLetter;
	private Dictionary<string, string> m_LetterToColor;
	private Game m_GameLogic;
	private FeedBack m_FeedBack;


	private void InitializeComponent()
	{
		InitializeFormAndButtons();
		InitializeColorToLetterDictionary();
		InitializeLetterToColorDictionary();
	}
	public GameForm(int i_NumberOfChances)
	{
		m_GameLogic = new Game(i_NumberOfChances);
		m_FeedBack  = new FeedBack();
		InitializeComponent();
		InitiallizeCompuerSecretCode(m_GameLogic);
	}
	void InitializeColorToLetterDictionary()
	{
		m_ColorToLetter = new Dictionary<string, string>();
		m_ColorToLetter.Add("Fuchsia", "A");
		m_ColorToLetter.Add("Red", "B");
		m_ColorToLetter.Add("Lime", "C");
		m_ColorToLetter.Add("Aqua", "D");
		m_ColorToLetter.Add("Blue", "E");
		m_ColorToLetter.Add("Yellow", "F");
		m_ColorToLetter.Add("Brown", "G");
		m_ColorToLetter.Add("White", "H");
	}
	void InitializeLetterToColorDictionary()
	{
		m_LetterToColor = new Dictionary<string, string>();
		m_LetterToColor.Add("A", "Fuchsia");
		m_LetterToColor.Add("B", "Red");
		m_LetterToColor.Add("C", "Lime");
		m_LetterToColor.Add("D", "Aqua");
		m_LetterToColor.Add("E", "Blue");
		m_LetterToColor.Add("F", "Yellow");
		m_LetterToColor.Add("G", "Brown");
		m_LetterToColor.Add("H", "White");

	}
	private void InitializeFormAndButtons()
	{
		int buttonSize = 50;
		int spacing = 10;
		int arrowWidth = 30;
		int arrowHeight = buttonSize / 2;
		int feedbackSize = buttonSize / 2 - 2;
		int feedbackSpacing = 2;
		int topMargin = 30;
		int computerRowSpacing = 30;

		CreateComputerChooseButtons(buttonSize, spacing, topMargin);
		CreateUserRowsAndArrows(buttonSize, spacing, arrowWidth, arrowHeight, feedbackSize, feedbackSpacing, topMargin, computerRowSpacing);

		//The Current Form Size
		int totalWidth = 4 * (buttonSize + spacing) + spacing + arrowWidth + spacing + 2 * (feedbackSize + feedbackSpacing);
		int totalHeight = topMargin + buttonSize + computerRowSpacing + m_GameLogic.NumberOfGuessesChoosenByUser * (buttonSize + spacing);
		totalWidth += 40;//It was 40
		totalHeight += 10;//It was 10
		this.Text = "Bull Pgia";
		this.ClientSize = new Size(totalWidth, totalHeight);
		this.StartPosition = FormStartPosition.CenterScreen;
		this.BackColor = SystemColors.Info;
	}
	public void InitiallizeCompuerSecretCode(Game i_GameLogic)
	{
		m_GameLogic.ComputerPlayer.CreateSecretCode(m_GameLogic.AvailableLetters, m_GameLogic.NumberOfPinsToGuess);
	}
	public void ShowComputerChoosenColors()
	{
		string colorByString;
		string computerCode = m_GameLogic.ComputerPlayer.SecretCode.Code;

		for(int i = 0; i < m_GameLogic.NumberOfPinsToGuess; i++)
		{
			colorByString = m_LetterToColor[computerCode[i].ToString()];
			m_ComputerChooseButtons[i].BackColor = Color.FromName(colorByString);
		}
	}
	private void CreateComputerChooseButtons(int i_ButtonSize, int i_Spacing, int i_TopMargin)
	{
		for (int col = 0; col < m_GameLogic.NumberOfPinsToGuess; col++)
		{
			Button compBtn = new Button();
			compBtn.BackColor = Color.Black;
			compBtn.Size = new Size(i_ButtonSize, i_ButtonSize);
			compBtn.Location = new Point(col * (i_ButtonSize + i_Spacing), i_TopMargin);
			compBtn.Enabled = false;
			this.Controls.Add(compBtn);
			m_ComputerChooseButtons.Add(compBtn);
		}
	}
	private void CreateUserRowsAndArrows(int i_ButtonSize, int i_Spacing, int i_ArrowWidth, int i_ArrowHeight,int i_FeedbackSize, int feedbackSpacing, int topMargin, int computerRowSpacing)
	{
		for (int row = 0; row < m_GameLogic.NumberOfGuessesChoosenByUser; row++)
		{
			List<Button> buttonRow = CreateColorGuessButtonsRow(row, i_ButtonSize, i_Spacing, topMargin, computerRowSpacing);
			m_ColorGuessButtons.Add(buttonRow);

			Button arrowBtn = CreateArrowButton(row, i_ButtonSize, i_Spacing, i_ArrowWidth, i_ArrowHeight, topMargin + i_ButtonSize / 4, computerRowSpacing);
			m_ArrowButtons.Add(arrowBtn);

			List<Panel> feedbackRow = CreateFeedbackPanels(row, arrowBtn, i_ArrowWidth, i_Spacing, i_FeedbackSize, feedbackSpacing);
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
	private List<Button> CreateColorGuessButtonsRow(int i_Row, int i_ButtonSize, int i_Spacing, int i_TopMargin, int i_ComputerRowSpacing)
	{
		List<Button> buttonRow = new List<Button>();

		for (int col = 0; col < 4; col++)
		{
			Button btn = new Button();
			btn.Size = new Size(i_ButtonSize, i_ButtonSize);
			btn.Location = new Point(col * (i_ButtonSize + i_Spacing), i_TopMargin + i_ButtonSize + i_ComputerRowSpacing + i_Row * (i_ButtonSize + i_Spacing));
			btn.Text = "";
			btn.BackColor = SystemColors.Info;//Color.LightGray;
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
	private Button CreateArrowButton(int i_Row, int i_ButtonSize, int i_Spacing, int i_ArrowWidth, int i_ArrowHeight, int i_TopMargin, int i_ComputerRowSpacing)
	{
		Button arrowBtn = new Button();
		arrowBtn.Size = new Size(i_ArrowWidth, i_ArrowHeight);
		arrowBtn.Location = new Point(
			4 * (i_ButtonSize + i_Spacing) + i_Spacing,
			i_TopMargin + i_ButtonSize + i_ComputerRowSpacing + i_Row * (i_ButtonSize + i_Spacing)
		);
		arrowBtn.Text = "-->";
		arrowBtn.Click += new EventHandler(ArrowButton_Click);
		arrowBtn.Enabled = false;
		this.Controls.Add(arrowBtn);

		return arrowBtn;
	}
	private List<Panel> CreateFeedbackPanels(int i_Row, Button i_ArrowBtn, int i_ArrowWidth, int i_Spacing, int i_FeedbackSize, int i_FeedbackSpacing)
	{
		var feedbackRow = new List<Panel>();
		int feedbackOriginX = i_ArrowBtn.Location.X + i_ArrowWidth + i_Spacing;
		int feedbackOriginY = i_ArrowBtn.Location.Y;

		for (int i = 0; i < 4; i++)
		{
			Panel feedbackPanel = new Panel();
			feedbackPanel.Size = new Size(i_FeedbackSize, i_FeedbackSize);
			int offsetX = (i % 2) * (i_FeedbackSize + i_FeedbackSpacing);
			int offsetY = (i / 2) * (i_FeedbackSize + i_FeedbackSpacing);
			feedbackPanel.Location = new Point(feedbackOriginX + offsetX,feedbackOriginY + offsetY);
			feedbackPanel.BorderStyle = BorderStyle.FixedSingle;
			feedbackPanel.BackColor = Color.White;
			feedbackPanel.Enabled = false;
			this.Controls.Add(feedbackPanel);
			feedbackRow.Add(feedbackPanel);
		}

		return feedbackRow;
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
		string userGuess = GetUserGuessesAsString();
		m_GameLogic.HumanPlayer.SetSecretCode(userGuess);
		SecretCode computerSecretCode = m_GameLogic.ComputerPlayer.SecretCode;
		SecretCode userSecretCode = m_GameLogic.HumanPlayer.Code;
		m_FeedBack.Evaluate(userSecretCode, computerSecretCode);
		
		MarkBullAndHitsOnPanels(m_FeedBack.NumberOfHits, m_FeedBack.NumberOfBulls);
		if(UserWin(m_FeedBack.NumberOfBulls) == true)
		{
			ShowComputerChoosenColors();
			return;
		}
		else
		{
			DiasbleButtonRow(m_GameLogic.CurrentUserTurn);
			if (m_GameLogic.CurrentUserTurn + 1 < m_GameLogic.NumberOfGuessesChoosenByUser)
			{
				m_GameLogic.CurrentUserTurn++;
				EnableUserButtonRow(m_GameLogic.CurrentUserTurn);
			}
			clickedCurrentArrowButton.Enabled = false;
		}
		
	}
	public bool UserWin(int i_NumberOfBulls)
	{
		bool isUserWin = false;

		if (i_NumberOfBulls == m_GameLogic.NumberOfPinsToGuess)
		{
			isUserWin = true;
		}

		return isUserWin;
	}
	string GetUserGuessesAsString()
	{
		StringBuilder playerGuess = new StringBuilder();
		string ColorOfButtonAsString;

		for (int i = 0; i < m_GameLogic.NumberOfPinsToGuess; i++)
		{
			ColorOfButtonAsString = m_ColorToLetter[m_ColorGuessButtons[m_GameLogic.CurrentUserTurn][i].BackColor.Name];
			playerGuess.Append(ColorOfButtonAsString);
		}

		return playerGuess.ToString();
	}
	void MarkBullAndHitsOnPanels(int i_NumberOfHits, int i_NumberOfBulls)
	{
		int idx = 0;
		int j;
		for (j = 0; j < i_NumberOfBulls; j++)
		{
			m_FeedbackPanels[m_GameLogic.CurrentUserTurn][idx].BackColor = Color.Black;
			idx++;
		}

		for (j = 0; j < i_NumberOfHits; j++)
		{
			m_FeedbackPanels[m_GameLogic.CurrentUserTurn][idx].BackColor = Color.Yellow;
			idx++;
		}
	}
	public bool IsRowFilled()
	{
		bool isRowFilled = true;

		for(int i = 0; i < m_GameLogic.NumberOfPinsToGuess; i++)
		{
			if(m_ColorGuessButtons[m_GameLogic.CurrentUserTurn][i].BackColor == SystemColors.Info)
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