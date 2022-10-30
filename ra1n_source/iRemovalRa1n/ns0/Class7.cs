using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace ns0
{
	internal class Class7
	{
		internal static void smethod_0()
		{
			while (Class7.string_0 == null)
			{
				try
				{
					string str = Class7.smethod_1("ProcessorId", "WIN32_Processor");
					string str2 = Class7.smethod_1("UUID", "WIN32_ComputerSystemProduct");
					string str3 = Class7.smethod_1("Product", "Win32_BaseBoard");
					Class7.string_0 = Class7.smethod_2(str + str2 + str3);
				}
				catch
				{
				}
			}
		}

		private static string smethod_1(string Key, string Group)
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from " + Group);
			string text = "";
			try
			{
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						try
						{
							text += managementObject[Key].ToString();
							goto IL_71;
						}
						catch
						{
							text += managementObject[Key].ToString();
							goto IL_71;
						}
						IL_63:
						text += "Nothing";
						continue;
						IL_71:
						if (managementObject.Properties.Count <= 0)
						{
							goto IL_63;
						}
					}
				}
			}
			catch
			{
			}
			return text;
		}

		private static string smethod_2(string string_0)
		{
			HashAlgorithm hashAlgorithm = MD5.Create();
			byte[] bytes = Encoding.ASCII.GetBytes(string_0);
			byte[] array = hashAlgorithm.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		internal static string string_0;
	}
}
