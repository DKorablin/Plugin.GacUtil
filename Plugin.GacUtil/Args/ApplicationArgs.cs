using System;
using AlphaOmega.Console;
using System.IO;

namespace Plugin.GacUtil
{
	internal class ApplicationArgs : CmdLineProcessor
	{
		[CmdLine("Install", "I", "Install assembly to GAC")]
		public Boolean Install { get; set; }

		/// <summary>Remove assembly from GAC</summary>
		[CmdLine("Uninstall", "U", "Uninstall assembly from GAC")]
		public Boolean Uninstall { get; set; }

		[CmdLine("Path","P","Assembly path")]
		public String Path { get; set; }

		public ApplicationArgs()
			: base() { }

		public ApplicationArgs(String[] args)
			: base(args) { }

		public ReturnType Validate()
		{
			if(!base.IsValid)
				return ReturnType.InsufficientParameters;

			if(!this.Install && !this.Uninstall || String.IsNullOrEmpty(this.Path))
				return ReturnType.InvalidCommand;

			if(!File.Exists(this.Path))
				return ReturnType.FileNotFound;

			return ReturnType.Success;
		}
	}
}