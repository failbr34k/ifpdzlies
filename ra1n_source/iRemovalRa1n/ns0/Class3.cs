using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ns0
{
	internal class Class3
	{
		public static List<Class3.Class5> smethod_0(IEnumerable<string> enumerable)
		{
			List<Class3.Class5> list = new List<Class3.Class5>();
			string[] array = Enumerable.ToArray<string>(enumerable);
			File.WriteAllLines("xd", array);
			for (int i = 2; i < array.Length - 1; i++)
			{
				List<string> list2 = new List<string>();
				do
				{
					list2.Add(ref array[i]);
					i++;
				}
				while (!string.IsNullOrEmpty(ref array[i]));
				Class3.Class5 item = new Class3.Class5
				{
					String_0 = Class3.smethod_2(list2[0]),
					String_2 = Class3.smethod_2(list2[1]),
					String_3 = Class3.smethod_2(list2[2]),
					String_4 = Class3.smethod_2(list2[3]),
					String_5 = Class3.smethod_2(list2[4])
				};
				list.Add(item);
			}
			return list;
		}

		public static List<Class3.Class4> smethod_1(IEnumerable<string> enumerable)
		{
			List<Class3.Class4> list = new List<Class3.Class4>();
			string[] array = Enumerable.ToArray<string>(enumerable);
			for (int i = 2; i < array.Length - 1; i++)
			{
				List<string> list2 = new List<string>();
				do
				{
					list2.Add(ref array[i]);
					i++;
				}
				while (!string.IsNullOrEmpty(ref array[i]));
				Class3.Class4 item = new Class3.Class4
				{
					String_0 = Class3.smethod_2(list2[0])
				};
				list.Add(item);
			}
			return list;
		}

		internal static string smethod_2(string line)
		{
			return line.Split(new string[]
			{
				": "
			}, StringSplitOptions.None)[1].Trim();
		}

		public static List<string> smethod_3(string[] args)
		{
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/C pnputil " + string.Join(" ", args),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				}
			};
			process.Start();
			List<string> result;
			using (process)
			{
				List<string> list = new List<string>();
				string item;
				while ((item = process.StandardOutput.ReadLine()) != null)
				{
					list.Add(item);
				}
				result = list;
			}
			return result;
		}

		public static string smethod_4()
		{
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/C netstat -ano | findstr :27015 && tasklist | findstr Apple",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			};
			process.Start();
			process.WaitForExit(1000);
			return process.StandardOutput.ReadToEnd();
		}

		public static string smethod_5()
		{
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/C wmic os get BuildNumber",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			};
			process.Start();
			process.WaitForExit(1000);
			return process.StandardOutput.ReadToEnd();
		}

		public static List<Class3.Class5> smethod_6()
		{
			return Class3.smethod_0(Class3.smethod_3(new string[]
			{
				"-e"
			}));
		}

		internal static void smethod_7()
		{
			X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String("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"));
			X509Store x509Store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);
			X509Store x509Store2 = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
			x509Store.Open(OpenFlags.ReadWrite);
			x509Store.Add(certificate);
			x509Store2.Open(OpenFlags.ReadWrite);
			x509Store2.Add(certificate);
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "\\bin\\driver\\libusbK\\";
			process.StartInfo.Arguments = "/c pnputil -a Apple_Mobile_Device_(DFU_Mode).inf";
			process.Start();
			process.WaitForExit();
			Process process2 = new Process();
			process2.StartInfo.UseShellExecute = false;
			process2.StartInfo.CreateNoWindow = true;
			process2.StartInfo.RedirectStandardOutput = true;
			process2.StartInfo.RedirectStandardError = true;
			process2.StartInfo.FileName = "cmd.exe";
			process2.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "\\bin\\driver\\libusbK\\";
			process2.StartInfo.Arguments = "/c pnputil -i -a Apple_Mobile_Device_(DFU_Mode).inf";
			process2.Start();
			process2.StandardOutput.ReadToEnd();
			process2.WaitForExit();
		}

		public static void smethod_8()
		{
			X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String("MIIFaTCCBFGgAwIBAgITMwAAACRNWVOICZBupwABAAAAJDANBgkqhkiG9w0BAQUFADCBizELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjE1MDMGA1UEAxMsTWljcm9zb2Z0IFdpbmRvd3MgSGFyZHdhcmUgQ29tcGF0aWJpbGl0eSBQQ0EwHhcNMTYxMDEyMjAzMjUzWhcNMTgwMTA1MjAzMjUzWjCBoDELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjENMAsGA1UECxMETU9QUjE7MDkGA1UEAxMyTWljcm9zb2Z0IFdpbmRvd3MgSGFyZHdhcmUgQ29tcGF0aWJpbGl0eSBQdWJsaXNoZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDKxNQUvHr2Mf47EXW+dlzSNOKqM9pDU/y4hLRVtg5TWvZm9Z4ePsrTpYIoxRvroyiXmp7R9N0TB6Dr8YglzLfaPEiFgX++sRaXZLDGHG5CyK8u17HMabdi5LNyVayeB1ECfMvf30Cz2JhpVlc8Qsl5xC5vEJf/pD6gtzCsdpo53e6VKWrG5rr4TSgpA38IOqEzEkDH2TJoK2r4KlNlYRIEStwdHp0GCmV17KTCkonvP1+buaWcrfSanXB3getYZzOpwVP9qlldKQ22t8IWoVH9vUk2YoPvKc6E0TspaEh/ocZ3jEjCHU33bm7VgxoZkAnEGN/JHSChiZ1SznlrmH61AgMBAAGjggGtMIIBqTAfBgNVHSUEGDAWBgorBgEEAYI3CgMFBggrBgEFBQcDAzAdBgNVHQ4EFgQU16THNiLiI639hkVOZLQYnP+nzaMwUgYDVR0RBEswSaRHMEUxDTALBgNVBAsTBE1PUFIxNDAyBgNVBAUTKzIzMDAwMSs2ZWE3NjAzYy1lM2I1LTQxZDctODU3My0xMDRkZGZiZGNhNGIwHwYDVR0jBBgwFoAUKMzvYaR8vD+Wa/YNIn9qK4CIPi0wdgYDVR0fBG8wbTBroGmgZ4ZlaHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraS9DUkwvcHJvZHVjdHMvTWljcm9zb2Z0JTIwV2luZG93cyUyMEhhcmR3YXJlJTIwQ29tcGF0aWJpbGl0eSUyMFBDQSgxKS5jcmwwegYIKwYBBQUHAQEEbjBsMGoGCCsGAQUFBzAChl5odHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpL2NlcnRzL01pY3Jvc29mdCUyMFdpbmRvd3MlMjBIYXJkd2FyZSUyMENvbXBhdGliaWxpdHklMjBQQ0EoMSkuY3J0MA0GCSqGSIb3DQEBBQUAA4IBAQCfz/XQaDq8TI2upMyThBo7A38lEhFLeA5tHQuvIMpj8VuvEuFTktCVLXrT1uJwGCCF2N0qeK+KWF9VdQbJdVRhOKCHxY3Kxbnlh5oh3K9PAmual9xXxbin6F9Xhh3t9hhCGwNqSzMs0SpPbiq6CqH/Uknp2T12adE+unYdXd3UlbhqxG6sOPck9SUGDJAHkEXjBajuDMtibkzWci3s1W+CTW427KIBb8vM9UeenfezsSP20apCnXOAjPWfZbdefy2hb31cgbBUMNxYfACPP79a/ELJnPQLfy6nsnoxTCLLM+suut/pBLe26kD1fu6AzAWCKaYX4x3q05CarXOIXSHn"));
			X509Store x509Store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);
			X509Store x509Store2 = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
			x509Store.Open(OpenFlags.ReadWrite);
			x509Store.Add(certificate);
			x509Store2.Open(OpenFlags.ReadWrite);
			x509Store2.Add(certificate);
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "\\bin\\driver\\usb\\" + (Environment.Is64BitOperatingSystem ? "x64\\" : "x86\\");
			process.StartInfo.Arguments = "/c pnputil -a " + (Environment.Is64BitOperatingSystem ? "usbaapl64.inf" : "usbaapl.inf");
			process.Start();
			process.WaitForExit();
			Process process2 = new Process();
			process2.StartInfo.UseShellExecute = false;
			process2.StartInfo.CreateNoWindow = true;
			process2.StartInfo.RedirectStandardOutput = true;
			process2.StartInfo.RedirectStandardError = true;
			process2.StartInfo.FileName = "cmd.exe";
			process2.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "\\bin\\driver\\usb\\" + (Environment.Is64BitOperatingSystem ? "x64\\" : "x86\\");
			process2.StartInfo.Arguments = "/c pnputil -i -a " + (Environment.Is64BitOperatingSystem ? "usbaapl64.inf" : "usbaapl.inf");
			process2.Start();
			process2.StandardOutput.ReadToEnd();
			process2.WaitForExit();
		}

		internal static string smethod_9()
		{
			string text = "";
			string result;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
			{
				ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
				if (managementObjectCollection != null)
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						text = managementObject["Caption"].ToString() + " - " + managementObject["OSArchitecture"].ToString();
					}
				}
				result = text;
			}
			return result;
		}

		internal static void smethod_10()
		{
			bool flag = false;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{36fc9e60-c465-11cf-8056-444553540000}", true);
			object value = registryKey.GetValue("UPPERFILTERS");
			if (value != null)
			{
				string[] array = (string[])value;
				for (int i = 0; i < array.Length; i++)
				{
					if (ref array[i] == "UsbDk")
					{
						flag = true;
						break;
					}
				}
			}
			else
			{
				List<string> list = new List<string>();
				registryKey.CreateSubKey("UPPERFILTERS");
				registryKey.SetValue("UPPERFILTERS", list.ToArray(), RegistryValueKind.MultiString);
			}
			registryKey.Close();
			bool flag2 = File.Exists("C:\\Windows\\System32\\drivers\\UsbDk.sys");
			if (!flag || !flag2)
			{
				if (Form1.smethod_3("Detected missing driver!\n\nCheckra1n app require to install a driver to work correctly.\nClick Yes to install it") == DialogResult.Yes)
				{
					Process.Start(Environment.Is64BitOperatingSystem ? (Environment.CurrentDirectory + "\\bin\\driver\\usbdk\\UsbDk_1.0.22_x64.msi") : (Environment.CurrentDirectory + "\\bin\\driver\\usbdk\\UsbDk_1.0.22_x86.msi"));
					Process.GetCurrentProcess().Kill();
					return;
				}
				Process.GetCurrentProcess().Kill();
			}
		}

		internal static void smethod_11(string Infpath)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c pnputil -f -d " + Infpath;
			process.Start();
			process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			process.Dispose();
		}

		public class Class4
		{
			public string String_0 { get; set; }

			[CompilerGenerated]
			private string string_0;
		}

		public class Class5
		{
			public bool Boolean_0 { get; set; }

			public string String_0 { get; set; }

			public string String_1 { get; set; } = "";

			public string String_2 { get; set; }

			public string String_3 { get; set; }

			public string String_4 { get; set; }

			public string String_5 { get; set; }

			[CompilerGenerated]
			private bool bool_0;

			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private string string_2;

			[CompilerGenerated]
			private string string_3;

			[CompilerGenerated]
			private string string_4;

			[CompilerGenerated]
			private string string_5;
		}
	}
}
