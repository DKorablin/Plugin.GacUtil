using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: Guid("cb031700-ccb4-4d14-ba1a-7f243f67fd41")]
[assembly: System.CLSCompliant(false)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://github.com/DKorablin/Plugin.GacUtil")]
#else

[assembly: AssemblyTitle("Plugin.GacUtil")]
[assembly: AssemblyDescription("User friendly wrapper around Fusion.dll for installing or uninstalling assemblies to the Global Assembly Cache")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Danila Korablin")]
[assembly: AssemblyProduct("Plugin.GacUtil")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2016")]
#endif