using System;
using System.IO;
using AlphaOmega.Reflection;
using Plugin.GacUtil.Reflection;

namespace Plugin.GacUtil
{
	public static class Fusion
	{
		public static void InstallAssembly(String assemblyPath)
			=> AssemblyCache.InstallAssembly(IASSEMBLYCACHE_INSTALL_FLAG.Unknown, assemblyPath, null);

		public static void UninstallAssembly(String assemblyPath)
		{
			if(!File.Exists(assemblyPath))
				throw new FileNotFoundException("Assembly not found", assemblyPath);

			String assemblyName;
			using(AssemblyLoader<AssemblyProxy> loader = new AssemblyLoader<AssemblyProxy>())
			{//TODO: Переделать на PEReder, иначе не будет работать с более новыми версиями...
				assemblyName = loader.Proxy.GetAssemblyName(assemblyPath);
			}

			FUSION_INSTALL_REFERENCE fusionReference = null;
			IASSEMBLYCACHE_UNINSTALL_DISPOSITION disp = AssemblyCache.UninstallAssembly(assemblyName, fusionReference);
			if(disp != IASSEMBLYCACHE_UNINSTALL_DISPOSITION.UNINSTALLED)
				throw new ApplicationException($"Assembly {Path.GetFileName(assemblyPath)} uninstalled from GAC, but Fusion reports status: {disp}");
		}
	}
}