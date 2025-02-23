using System.Reflection;
using System.Runtime.InteropServices;

[assembly: Guid("cb031700-ccb4-4d14-ba1a-7f243f67fd41")]
[assembly: System.CLSCompliant(false)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://github.com/DKorablin/Plugin.GacUtil")]
#else

[assembly: AssemblyDescription("User friendly wrapper around Fusion.dll for installing or uninstalling assemblies to the Global Assembly Cache")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2016")]
#endif