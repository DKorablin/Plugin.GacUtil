using System;
using System.Reflection;

namespace Plugin.GacUtil.Reflection
{
	[Serializable]
	internal class AssemblyProxy
	{
		internal String GetAssemblyName(String assemblyPath)
		{
			AssemblyName assemblyName = AssemblyName.GetAssemblyName(assemblyPath);
			return $"{assemblyName.Name},Version={assemblyName.Version.ToString()}";
		}
	}
}