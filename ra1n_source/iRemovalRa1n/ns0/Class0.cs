using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using iMobileDevice;
using iMobileDevice.Usbmuxd;
using ns1;

namespace ns0
{
	internal class Class0
	{
		public void method_0(Form1 main)
		{
			try
			{
				Class0.form1_0 = main;
				Class0.bool_0 = false;
				Class0.socket_0 = null;
				Class0.socket_0 = new Socket(2, SocketType.Stream, ProtocolType.Tcp);
				Class0.socket_0.Bind(new IPEndPoint(IPAddress.Loopback, 1337));
				Class0.socket_0.Listen(100);
				this.method_1();
			}
			catch
			{
			}
		}

		private void method_1()
		{
			Class0.iusbmuxdApi_0.usbmuxd_subscribe(Class0.usbmuxdEventCallBack_0, IntPtr.Zero);
		}

		private static UsbmuxdEventCallBack smethod_0()
		{
			return delegate(ref UsbmuxdEvent devEvent, IntPtr data)
			{
				int @event = devEvent.@event;
				if (@event != 1)
				{
					return;
				}
				Class0.smethod_1(devEvent.device.udid, devEvent.device.handle);
			};
		}

		private static void smethod_1(string newUdid, uint handle)
		{
			int num = Class0.iusbmuxdApi_0.usbmuxd_connect(handle, 1337);
			if (num == 0)
			{
				if (Class0.form1_0 != null)
				{
					Class0.form1_0.method_10(100, "Failed to upload bootstrap.. (0x1)");
				}
				Class0.bool_0 = true;
				return;
			}
			Class0.smethod_2(num);
		}

		private static void smethod_2(int connection)
		{
			Task.Run(delegate()
			{
				while (!Class0.bool_0)
				{
					uint num = 0U;
					byte[] array = new byte[1];
					Class0.iusbmuxdApi_0.usbmuxd_recv(connection, array, 1U, ref num);
					uint num2 = 0U;
					byte[] data = new byte[8];
					Class0.iusbmuxdApi_0.usbmuxd_recv(connection, data, 8U, ref num2);
					string a = BitConverter.ToString(array);
					if (num > 0U || num2 > 0U)
					{
						if (Class0.form1_0 != null)
						{
							Class0.form1_0.method_10(90, "Uploading bootstrap..");
						}
						if (a == "42")
						{
							byte[] byte_ = Class10.Byte_0;
							uint num3 = 0U;
							int num4 = Class0.iusbmuxdApi_0.usbmuxd_send(connection, byte_, (uint)byte_.Length, ref num3);
							if ((ulong)num3 < (ulong)((long)byte_.Length) && num4 != 0)
							{
								if (Class0.form1_0 != null)
								{
									Class0.form1_0.method_10(100, "Failed to upload bootstrap.. (0x2)");
								}
								Class0.bool_0 = true;
								return;
							}
							if (Class0.form1_0 != null)
							{
								Class0.form1_0.method_10(95, "Bootstrap uploaded..");
							}
						}
						Class0.iusbmuxdApi_0.usbmuxd_disconnect(connection);
						Class0.iusbmuxdApi_0.usbmuxd_unsubscribe();
						Class0.socket_0.Close();
						if (Class0.form1_0 != null)
						{
							Class0.form1_0.method_10(100, "All Done");
						}
						Class0.bool_0 = true;
						return;
					}
				}
			});
		}

		private static IUsbmuxdApi iusbmuxdApi_0 = LibiMobileDevice.Instance.Usbmuxd;

		private static readonly UsbmuxdEventCallBack usbmuxdEventCallBack_0 = Class0.smethod_0();

		public static bool bool_0 = false;

		private static Socket socket_0;

		private static Form1 form1_0;
	}
}
