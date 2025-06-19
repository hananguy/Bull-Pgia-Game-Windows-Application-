using System;
using System.Collections.Generic;

namespace GameLogic
{
	public struct SecretCode
	{
		private string m_Secret;
		public SecretCode(string i_Secret)
		{
			m_Secret = i_Secret;
		}

		public string Code
		{
			get { return m_Secret; }
			set { m_Secret = value; }
		}
		public override string ToString()
		{
			return m_Secret;
		}
	}
}