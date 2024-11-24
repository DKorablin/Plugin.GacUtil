using System;

namespace Plugin.GacUtil
{
	/// <summary>Application execution results</summary>
	public enum ReturnType
	{
		/// <summary>Execution successful</summary>
		Success = 0,
		/// <summary>Exception in code</summary>
		Exception = -1,
		/// <summary>Insufficient parameters</summary>
		InsufficientParameters = -2,
		/// <summary>Command not defined</summary>
		InvalidCommand = -3,
		/// <summary>Assembly not found</summary>
		FileNotFound = -4,
	}
}