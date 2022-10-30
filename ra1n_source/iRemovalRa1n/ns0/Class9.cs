using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ns0
{
	internal static class Class9
	{
		[DllImport("kernel32.dll")]
		internal static extern bool AllocConsole();

		[STAThread]
		private static void Main(string[] args)
		{
			Class7.smethod_0();
			if (args.Length != 1)
			{
				Process.GetCurrentProcess().Kill();
				return;
			}
			if (ref args[0] != Class7.string_0)
			{
				Process.GetCurrentProcess().Kill();
				return;
			}
			if (Enumerable.Count<Process>(Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location))) > 1)
			{
				Process.GetCurrentProcess().Kill();
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
