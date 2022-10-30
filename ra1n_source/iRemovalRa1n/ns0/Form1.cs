using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iMobileDevice;
using LibMobileDevice;
using LibMobileDevice.Enumerates;
using LibMobileDevice.Event;
using ns1;

namespace ns0
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			this.InitializeComponent();
			base.Load += this.Form1_Load;
		}

		public static bool smethod_0()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		private static string smethod_1(byte[] rawData)
		{
			string result;
			using (SHA256 sha = SHA256.Create())
			{
				byte[] array = sha.ComputeHash(rawData);
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		public void method_0(string fileName)
		{
			new Process
			{
				StartInfo = 
				{
					FileName = fileName,
					UseShellExecute = true,
					Verb = "runas"
				}
			}.Start();
		}

		private void method_1()
		{
			while (Form1.bool_0)
			{
				try
				{
					Process[] processes = Process.GetProcesses();
					for (int i = 0; i < processes.Length; i++)
					{
						Process[] array = processes;
						int num = i;
						if (array[num].ProcessName == "WireShark" || array[num].MainWindowTitle.Contains("WireShark"))
						{
							array[num].Kill();
							Process.GetCurrentProcess().Kill();
						}
						if (array[num].ProcessName == "CharlesProxy" || array[num].MainWindowTitle.Contains("CharlesProxy"))
						{
							array[num].Kill();
							Process.GetCurrentProcess().Kill();
						}
						if (array[num].MainWindowTitle == "Progress Telerik Fiddler Web Debugger")
						{
							array[num].Kill();
							Process.GetCurrentProcess().Kill();
						}
						if (array[num].ProcessName.Contains("python"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName == "Fiddler Everywhere")
						{
							array[num].Kill();
							Process.GetCurrentProcess().Kill();
						}
						if (array[num].ProcessName == "Fiddler")
						{
							array[num].Kill();
							Process.GetCurrentProcess().Kill();
						}
						if (array[num].ProcessName.Contains("powershell"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("conemu"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("mobaxterm"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("hyper"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("wsl"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("bash"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("cscript"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("putty"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("winscp"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("git-bash"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("dnSpy"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("ida"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("ghidra"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("HxD"))
						{
							array[num].Kill();
						}
						if (array[num].ProcessName.Contains("3uTools") || array[num].ProcessName.Contains("iTunes"))
						{
							array[num].Kill();
						}
					}
					Thread.Sleep(1000);
					if (!Form1.bool_0)
					{
						Process.GetCurrentProcess().Kill();
					}
					goto IL_2C7;
				}
				catch (Exception)
				{
					Process.GetCurrentProcess().Kill();
					goto IL_2C7;
				}
				IL_2B8:
				Process.GetCurrentProcess().Kill();
				continue;
				IL_2C7:
				if (!Form1.bool_0)
				{
					goto IL_2B8;
				}
			}
		}

		private bool method_2(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			X509Certificate2 x509Certificate = new X509Certificate2(certificate);
			return x509Certificate.Verify() & "CN=s13.iremovalpro.com".Equals(x509Certificate.Subject);
		}

		private void method_3(object sender, FormClosingEventArgs e)
		{
			if (Form1.thread_0 != null)
			{
				Form1.thread_0.Abort();
				Form1.thread_0 = null;
			}
			Form1.bool_0 = false;
			Process.GetCurrentProcess().Kill();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://s13.iremovalpro.com/checkra1n.php");
				httpWebRequest.UserAgent = "RestSharp/106.11.4.0";
				string a;
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					using (Stream responseStream = httpWebResponse.GetResponseStream())
					{
						using (StreamReader streamReader = new StreamReader(responseStream))
						{
							a = streamReader.ReadToEnd();
						}
					}
				}
				if (a != "1.1")
				{
					Process.GetCurrentProcess().Kill();
				}
				if (Form1.smethod_1(File.ReadAllBytes(Environment.CurrentDirectory + "\\bin\\libimobiledevice\\win-x64\\libusb-1.0.dll")) != "42af741f79058f0f26acaa2e697e888057061ea8f732f222b1c9894b087f703d")
				{
					Process.GetCurrentProcess().Kill();
				}
				if (Form1.smethod_1(File.ReadAllBytes(Environment.CurrentDirectory + "\\bin\\libimobiledevice\\win-x86\\libusb-1.0.dll")) != "6537e42da73b9eb8fbcc652ab8afbf7292a556bc2eb11316ae46a5994a8afd69")
				{
					Process.GetCurrentProcess().Kill();
				}
				string text = Form1.string_0;
				if (text.Contains("Windows 11"))
				{
					if (!Class3.smethod_5().Contains("22000"))
					{
						MessageBox.Show("Your Windows 11 version is a beta insider build which is NOT supported!\nPlease update to Windows 11 Release!");
						Process.GetCurrentProcess().Kill();
					}
				}
				else if (!text.Contains("Windows 7") && !text.Contains("Windows 8") && !text.Contains("Windows 10"))
				{
					MessageBox.Show("Only Windows 7/8/10/11 32/64 bits are supported currently!");
					Process.GetCurrentProcess().Kill();
				}
				if (!Form1.smethod_0())
				{
					this.method_0(AppDomain.CurrentDomain.FriendlyName);
					Process.GetCurrentProcess().Kill();
				}
				if (this.Text != "iRemovalRa1n v1.1" || this.label3.Text != "Made by: argp, axi0mx, danyl931, ifpdz, jaywalker, kirb, littlelailo, nitoTV," || this.label4.Text != "never_released, nullpixel, pimskeks, qwertyoruiop, sbinger, siguza")
				{
					Process.GetCurrentProcess().Kill();
				}
				Form1.thread_0 = new Thread(new ThreadStart(this.method_1));
				Form1.thread_0.IsBackground = true;
				Form1.thread_0.Start();
				if (!Class3.smethod_4().Contains("AppleMobileDevice"))
				{
					MessageBox.Show("Detected missing driver!\n\niRemovalRa1n app require AppleMobileDevice to work correctly.\nPlease install iTunes to get it working!");
					Process.GetCurrentProcess().Kill();
				}
				List<Class3.Class5> list = Class3.smethod_6();
				bool flag = false;
				foreach (Class3.Class5 @class in list)
				{
					if (@class.String_4.Contains("05/19/2017 6.0.9999.69"))
					{
						flag = true;
					}
					if (@class.String_2.Contains("libusbK"))
					{
						Class3.smethod_11(@class.String_0);
					}
					if (@class.String_1.Contains("wpdmtp"))
					{
						Class3.smethod_11(@class.String_0);
					}
				}
				if (!flag)
				{
					Class3.smethod_8();
				}
				Class3.smethod_10();
			}
			catch (Exception)
			{
				Process.GetCurrentProcess().Kill();
			}
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				NativeLibraries.Load(Environment.CurrentDirectory + "\\bin\\libimobiledevice");
				if (Form1.iOSDeviceManager_0 == null)
				{
					Form1.iOSDeviceManager_0 = new iOSDeviceManager();
					Form1.iOSDeviceManager_0.CommonConnectEvent += this.method_4;
					Form1.iOSDeviceManager_0.RecoveryConnectEvent += this.method_5;
					Form1.iOSDeviceManager_0.ListenErrorEvent += this.method_6;
					new Thread(new ThreadStart(Form1.iOSDeviceManager_0.StartListen))
					{
						IsBackground = true
					}.Start();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("error");
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.method_2);
				base.CenterToScreen();
				base.MaximizeBox = false;
				this.backgroundWorker_0 = new BackgroundWorker();
				this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
				this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
				this.backgroundWorker_0.RunWorkerAsync();
			}
			catch (Exception)
			{
				Process.GetCurrentProcess().Kill();
			}
		}

		private void method_4(object sender, DeviceCommonConnectEventArgs e)
		{
			if (e.Message == ConnectNotificationMessage.Connected)
			{
				Form1.iOSDevice_0 = e.Device;
				if (!Form1.iOSDevice_0.IsConnected)
				{
					base.Invoke(new MethodInvoker(delegate()
					{
						this.label2.Text = "Failed to connect to lockdownd (-21)";
					}));
				}
				string deviceName = "";
				if (Form1.iOSDevice_0 != null && Form1.iOSDevice_0.IsConnected)
				{
					foreach (KeyValuePair<string, string> keyValuePair in Form1.dictionary_0)
					{
						if (keyValuePair.Key == Form1.iOSDevice_0.ProductType)
						{
							deviceName = keyValuePair.Value;
							break;
						}
					}
					base.Invoke(new MethodInvoker(delegate()
					{
						if (string.IsNullOrEmpty(deviceName))
						{
							this.label2.Name = "Unsupported device";
							this.button2.Enabled = false;
							return;
						}
						if (!Form1.iOSDevice_0.ProductVersion.Contains("12.") && !Form1.iOSDevice_0.ProductVersion.Contains("13.") && !Form1.iOSDevice_0.ProductVersion.Contains("14."))
						{
							this.label2.Text = deviceName + " (" + Form1.iOSDevice_0.ProductVersion + ") is not supported at this point. Only iOS 12.0\nto iOS 14.8.1 are supported!";
							this.button2.Enabled = false;
							return;
						}
						this.label2.Text = deviceName + " (" + Form1.iOSDevice_0.ProductVersion + ") connected in Normal mode";
						this.button2.Enabled = true;
					}));
				}
			}
			if (e.Message == ConnectNotificationMessage.Disconnected)
			{
				base.Invoke(new MethodInvoker(delegate()
				{
					this.label2.Text = "Connect your iPhone, iPod touch, iPad, or AppleTV to begin";
					this.button2.Enabled = false;
				}));
			}
		}

		public static string smethod_2(string arg, string key, bool ret = true, bool dfu = false)
		{
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = Environment.CurrentDirectory + "\\bin\\irecovery.exe",
					Arguments = arg,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				}
			};
			process.Start();
			if (!ret)
			{
				return "";
			}
			if (dfu)
			{
				if (process.WaitForExit(500) && process.StandardOutput.ReadToEnd().Contains(key))
				{
					return key;
				}
			}
			else
			{
				string text;
				while ((text = process.StandardOutput.ReadLine()) != null)
				{
					if (text.Contains(key))
					{
						return text;
					}
				}
			}
			return "";
		}

		private void method_5(object sender, DeviceRecoveryConnectEventArgs e)
		{
			Form1.<RecoveryConnectDevice>d__21 <RecoveryConnectDevice>d__;
			<RecoveryConnectDevice>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<RecoveryConnectDevice>d__.<>4__this = this;
			<RecoveryConnectDevice>d__.args = e;
			<RecoveryConnectDevice>d__.<>1__state = -1;
			<RecoveryConnectDevice>d__.<>t__builder.Start<Form1.<RecoveryConnectDevice>d__21>(ref <RecoveryConnectDevice>d__);
		}

		private void method_6(object sender, ListenErrorEventHandlerEventArgs e)
		{
			if (e.ErrorType == ListenErrorEventType.StartListen)
			{
				MessageBox.Show(e.ErrorMessage);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (Form1.bool_1)
			{
				this.dfuPanel.Visible = true;
				return;
			}
			this.recoveryPanel.Visible = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.recoveryPanel.Visible = false;
		}

		private Task method_7()
		{
			Form1.<SendAliveMessageAsync>d__27 <SendAliveMessageAsync>d__;
			<SendAliveMessageAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SendAliveMessageAsync>d__.<>4__this = this;
			<SendAliveMessageAsync>d__.<>1__state = -1;
			<SendAliveMessageAsync>d__.<>t__builder.Start<Form1.<SendAliveMessageAsync>d__27>(ref <SendAliveMessageAsync>d__);
			return <SendAliveMessageAsync>d__.<>t__builder.Task;
		}

		private Task method_8()
		{
			Form1.<asyncDrv>d__28 <asyncDrv>d__;
			<asyncDrv>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<asyncDrv>d__.<>1__state = -1;
			<asyncDrv>d__.<>t__builder.Start<Form1.<asyncDrv>d__28>(ref <asyncDrv>d__);
			return <asyncDrv>d__.<>t__builder.Task;
		}

		public static DialogResult smethod_3(string msg)
		{
			return MessageBox.Show(msg, "iRemovalRa1n", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
		}

		private Task method_9()
		{
			Form1.<waitdfu>d__30 <waitdfu>d__;
			<waitdfu>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<waitdfu>d__.<>1__state = -1;
			<waitdfu>d__.<>t__builder.Start<Form1.<waitdfu>d__30>(ref <waitdfu>d__);
			return <waitdfu>d__.<>t__builder.Task;
		}

		public Task Task_0 { get; private set; }

		public void method_10(int value, string text)
		{
			base.Invoke(new MethodInvoker(delegate()
			{
				this.progressBar1.Value = value;
				this.label22.Text = text;
				this.label22.Visible = true;
				if (value == 100)
				{
					this.button8.Enabled = true;
				}
			}));
		}

		private void NextButt_Click(object sender, EventArgs e)
		{
			Form1.<NextButt_Click>d__39 <NextButt_Click>d__;
			<NextButt_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<NextButt_Click>d__.<>4__this = this;
			<NextButt_Click>d__.<>1__state = -1;
			<NextButt_Click>d__.<>t__builder.Start<Form1.<NextButt_Click>d__39>(ref <NextButt_Click>d__);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Form1.<button6_Click>d__40 <button6_Click>d__;
			<button6_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<button6_Click>d__.<>4__this = this;
			<button6_Click>d__.<>1__state = -1;
			<button6_Click>d__.<>t__builder.Start<Form1.<button6_Click>d__40>(ref <button6_Click>d__);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Form1.<button5_Click>d__42 <button5_Click>d__;
			<button5_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<button5_Click>d__.<>4__this = this;
			<button5_Click>d__.<>1__state = -1;
			<button5_Click>d__.<>t__builder.Start<Form1.<button5_Click>d__42>(ref <button5_Click>d__);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			Form1.<button7_Click>d__43 <button7_Click>d__;
			<button7_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<button7_Click>d__.<>4__this = this;
			<button7_Click>d__.<>1__state = -1;
			<button7_Click>d__.<>t__builder.Start<Form1.<button7_Click>d__43>(ref <button7_Click>d__);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			this.button8.Enabled = false;
			this.checkrainPanel.Visible = false;
			this.progressBar1.Value = 0;
		}

		private void label25_Click(object sender, EventArgs e)
		{
			Process.Start("https://t.me/iremoval");
		}

		private void label26_Click(object sender, EventArgs e)
		{
			Process.Start("https://iremovalpro.com");
		}

		internal static iOSDeviceManager iOSDeviceManager_0;

		internal static iOSDevice iOSDevice_0;

		private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>
		{
			{
				"iPhone7,1",
				"iPhone 6 Plus"
			},
			{
				"iPhone7,2",
				"iPhone 6"
			},
			{
				"iPhone8,1",
				"iPhone 6s"
			},
			{
				"iPhone8,2",
				"iPhone 6s Plus"
			},
			{
				"iPhone8,4",
				"iPhone SE (1st gen)"
			},
			{
				"iPhone9,1",
				"iPhone 7 (Global)"
			},
			{
				"iPhone9,2",
				"iPhone 7 Plus (Global)"
			},
			{
				"iPhone9,3",
				"iPhone 7 (GSM)"
			},
			{
				"iPhone9,4",
				"iPhone 7 Plus (GSM)"
			},
			{
				"iPhone10,1",
				"iPhone 8 (Global)"
			},
			{
				"iPhone10,2",
				"iPhone 8 Plus (Global)"
			},
			{
				"iPhone10,3",
				"iPhone X (Global)"
			},
			{
				"iPhone10,4",
				"iPhone 8 (GSM)"
			},
			{
				"iPhone10,5",
				"iPhone 8 Plus (GSM)"
			},
			{
				"iPhone10,6",
				"iPhone X (GSM)"
			},
			{
				"iPod9,1",
				"iPod Touch (7th gen)"
			},
			{
				"iPad5,1",
				"iPad mini 4 (WiFi)"
			},
			{
				"iPad5,2",
				"iPad mini 4 (Cellular)"
			},
			{
				"iPad6,3",
				"iPad Pro 9.7-inch (WiFi)"
			},
			{
				"iPad6,4",
				"iPad Pro 9.7-inch (Cellular)"
			},
			{
				"iPad6,7",
				"iPad Pro 12.9-inch (1st gen, WiFi)"
			},
			{
				"iPad6,8",
				"iPad Pro 12.9-inch (1st gen, Cellular)"
			},
			{
				"iPad6,11",
				"iPad (5th gen, WiFi)"
			},
			{
				"iPad6,12",
				"iPad (5th gen, Cellular)"
			},
			{
				"iPad7,1",
				"iPad Pro 12.9-inch (2nd gen, WiFi)"
			},
			{
				"iPad7,2",
				"iPad Pro 12.9-inch (2nd gen, Cellular)"
			},
			{
				"iPad7,3",
				"iPad Pro 10.5-inch (WiFi)"
			},
			{
				"iPad7,4",
				"iPad Pro 10.5-inch (Cellular)"
			},
			{
				"iPad7,5",
				"iPad (6th gen, WiFi)"
			},
			{
				"iPad7,6",
				"iPad (6th gen, Cellular)"
			},
			{
				"iPad7,11",
				"iPad (7th gen, WiFi)"
			},
			{
				"iPad7,12",
				"iPad (7th gen, Cellular)"
			}
		};

		private static Thread thread_0;

		private static bool bool_0 = true;

		internal static string string_0 = Class3.smethod_9();

		private BackgroundWorker backgroundWorker_0;

		private static bool bool_1;

		private static bool bool_2 = false;

		[CompilerGenerated]
		private Task task_0;

		private static bool bool_3;

		private static bool bool_4;

		private static bool bool_5;

		private static string string_1;
	}
}
