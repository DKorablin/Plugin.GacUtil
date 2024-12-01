using System;
using SAL.Flatbed;
using System.Diagnostics;

namespace Plugin.GacUtil
{
	public class Plugin : IPlugin
	{
		private TraceSource _trace;

		/// <summary>Трассировка сообщений</summary>
		internal TraceSource Trace
		{
			get => this._trace ?? (this._trace = Plugin.CreateTraceSource<Plugin>());
		}

		/// <summary>Установить сборку в GAC</summary>
		/// <param name="assemblyPath">Физический путь к сборке на диске</param>
		public void InstallAssembly(String assemblyPath)
		{
			if(String.IsNullOrEmpty(assemblyPath))
				throw new ArgumentNullException("assemblyPath");

			this.Trace.TraceInformation("Installing assembly {0} to GAC...", assemblyPath);

			Fusion.InstallAssembly(assemblyPath);
		}

		/// <summary>Удалить сборку из GAC</summary>
		/// <param name="assemblyPath">Физический путь к сборке на диске</param>
		public void UninstallAssembly(String assemblyPath)
		{
			if(String.IsNullOrEmpty(assemblyPath))
				throw new ArgumentNullException("assemblyPath");

			this.Trace.TraceInformation("Uninstalling assembly {0} from GAC...", assemblyPath);

			Fusion.UninstallAssembly(assemblyPath);
		}

		Boolean IPlugin.OnConnection(ConnectMode mode)
			=> true;

		Boolean IPlugin.OnDisconnection(DisconnectMode mode)
			=> true;

		private static TraceSource CreateTraceSource<T>(String name = null) where T : IPlugin
		{
			TraceSource result = new TraceSource(typeof(T).Assembly.GetName().Name + name);
			result.Switch.Level = SourceLevels.All;
			result.Listeners.Remove("Default");
			result.Listeners.AddRange(System.Diagnostics.Trace.Listeners);
			return result;
		}
	}
}