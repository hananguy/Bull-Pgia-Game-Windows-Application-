using System;

namespace GameLogic
{
	public class ValidationResult
	{
		private bool m_IsValid;
		private SecretCode m_ParsedCode;
		private readonly string m_ErrorMessage;

		public bool IsValid
		{
			get => m_IsValid;
			set => m_IsValid = value;
		}

		public SecretCode ParsedCode
		{
			get => m_ParsedCode;
			set => m_ParsedCode = value;
		}

		public string ErrorMessage => m_ErrorMessage;

		public ValidationResult(bool isValid, SecretCode parsedCode, string errorMessage)
		{
			this.m_IsValid = isValid;
			this.m_ParsedCode = parsedCode;
			this.m_ErrorMessage = errorMessage;
		}
	}
}
