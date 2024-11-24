using System;
using System.IO;
using System.Reflection;
using Plugin.GacUtil.Properties;

namespace Plugin.GacUtil
{
	public class Program
	{
		static void Main(String[] args)
		{
			ApplicationArgs argsEx = new ApplicationArgs(args);
			ReturnType result = argsEx.Validate();
			try
			{
				switch(result)
				{
				case ReturnType.Success:
					if(argsEx.Install)
					{
						Fusion.InstallAssembly(argsEx.Path);
						Console.WriteLine("Assembly {0} succesfully instaled to GAC", Path.GetFileName(argsEx.Path));
					} else if(argsEx.Uninstall)
					{
						Fusion.UninstallAssembly(argsEx.Path);
						Console.WriteLine("Assembly {0} successfully uninstalled from GAC", Path.GetFileName(argsEx.Path));
					} else
						throw new NotImplementedException();
					break;
				case ReturnType.FileNotFound:
					Console.WriteLine("File {0} not found", argsEx.Path);
					break;
				case ReturnType.InsufficientParameters:
				case ReturnType.InvalidCommand:
					Program.ShowHelp(argsEx);
					break;
				}
			} catch(Exception exc)
			{
				Console.WriteLine(exc.Message);
				if(exc.InnerException != null)
					Console.WriteLine(exc.InnerException.Message);

				result = ReturnType.Exception;
#if DEBUG
				throw;
#endif
			}

			Environment.Exit((Int32)result);
		}

		private static void ShowHelp(ApplicationArgs args)
		{
			Console.WriteLine(Resources.Help);
			Console.Write(Assembly.GetExecutingAssembly().GetName().Name);
			Console.Write(args.GetShortKeyList());
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(args.GetFullKeyList());
		}
	}
}