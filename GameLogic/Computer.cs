using System;

namespace GameLogic
{
	public class Computer
	{
		private static readonly Random sr_Random = new Random();
		private SecretCode m_Secret;

		public void CreateSecretCode(char[] i_AvailableCharacters, int i_SecretSize = 4)
		{
			char[] secretChars = new char[i_SecretSize];
			int index = 0;

			while (index < i_SecretSize)
			{
				char randomChar = i_AvailableCharacters[sr_Random.Next(i_AvailableCharacters.Length)];

				bool alreadyExists = false;
				for (int i = 0; i < index; i++)
				{
					if (secretChars[i] == randomChar)
					{
						alreadyExists = true;
						break;
					}
				}

				if (!alreadyExists)
				{
					secretChars[index] = randomChar;
					index++;
				}
			}

			m_Secret = new SecretCode(string.Join(" ", secretChars));
		}

		public SecretCode SecretCode
		{
			get { return m_Secret; }
		}
	}
}
