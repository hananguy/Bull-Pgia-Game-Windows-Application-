using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
	public class Player
	{
		private SecretCode m_LastGuess;

		public Player()
		{

		}

		public void GuessSecretCode(SecretCode i_SecretCode)
		{
			m_LastGuess = i_SecretCode;
		}

		public void SetGuess(SecretCode i_Guess)
		{
			m_LastGuess = i_Guess;
		}

		public SecretCode Code
		{
			get { return m_LastGuess; }
			set { m_LastGuess = value; }
		}

		public void SetSecretCode(string code)
		{
			m_LastGuess = new SecretCode(code);
		}
	}
}
