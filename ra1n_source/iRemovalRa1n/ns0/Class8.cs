using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ns0
{
	internal class Class8
	{
		public string String_0
		{
			get
			{
				return this.string_0;
			}
		}

		public unsafe int method_0(ushort mode, bool srnm, bool nousbdk = true)
		{
			if (GClass0.libusb_init(out Class8.intptr_0) < 0)
			{
				return -1;
			}
			if (nousbdk && GClass0.libusb_set_option(Class8.intptr_0, 1) < 0)
			{
				return -1;
			}
			GClass0.GStruct2** devs;
			int count = GClass0.libusb_get_device_list(Class8.intptr_0, out devs);
			this.pGstruct2_0 = this.method_1(devs, count, mode);
			if (this.pGstruct2_0 == null)
			{
				GClass0.libusb_exit(Class8.intptr_0);
				return -1;
			}
			if (GClass0.libusb_open(this.pGstruct2_0, out this.intptr_1) < 0)
			{
				GClass0.libusb_exit(Class8.intptr_0);
				return -662;
			}
			if (GClass0.libusb_claim_interface(this.intptr_1, 0) < 0)
			{
				GClass0.libusb_exit(Class8.intptr_0);
				return -662;
			}
			if (srnm)
			{
				StringBuilder stringBuilder = new StringBuilder(2048);
				if (GClass0.libusb_get_string_descriptor_ascii(this.intptr_1, this.gstruct0_0.byte_8, stringBuilder, stringBuilder.Capacity) < 0)
				{
					return -664;
				}
				this.string_0 = stringBuilder.ToString();
			}
			return 0;
		}

		private unsafe GClass0.GStruct2* method_1(GClass0.GStruct2** devs, int count, ushort stage)
		{
			for (int i = 0; i < count; i++)
			{
				GClass0.GStruct0 gstruct;
				if (GClass0.libusb_get_device_descriptor(*(IntPtr*)(devs + (IntPtr)i * (IntPtr)sizeof(GClass0.GStruct2*) / (IntPtr)sizeof(GClass0.GStruct2*)), out gstruct) < 0)
				{
					return null;
				}
				if (gstruct.ushort_2 == stage)
				{
					this.gstruct0_0 = gstruct;
					return *(IntPtr*)(devs + (IntPtr)i * (IntPtr)sizeof(GClass0.GStruct2*) / (IntPtr)sizeof(GClass0.GStruct2*));
				}
			}
			return null;
		}

		public int method_2(uint time, ushort stage, bool srnm, bool nousbdk = true)
		{
			int num = 0;
			while ((long)num < (long)((ulong)time))
			{
				if (this.intptr_1 != IntPtr.Zero)
				{
					this.method_4();
				}
				if (this.method_0(stage, srnm, nousbdk) == 0)
				{
					return 0;
				}
				Thread.Sleep(500);
				num++;
			}
			Class8.intptr_0 = IntPtr.Zero;
			this.intptr_1 = IntPtr.Zero;
			return -1;
		}

		public int method_3()
		{
			return GClass0.libusb_reset_device(this.intptr_1);
		}

		public void method_4()
		{
			GClass0.libusb_release_interface(this.intptr_1, 0);
			GClass0.libusb_close(this.intptr_1);
			GClass0.libusb_exit(Class8.intptr_0);
			this.intptr_1 = IntPtr.Zero;
			this.pGstruct2_0 = null;
			Class8.intptr_0 = IntPtr.Zero;
		}

		public int method_5(byte bm_request_type, byte b_request, ushort w_value, ushort w_index, byte[] data, ushort w_length)
		{
			return GClass0.libusb_control_transfer(this.intptr_1, bm_request_type, b_request, w_value, w_index, data, w_length, 0U);
		}

		public unsafe int method_6(byte bmRequestType, byte bRequest, ushort wValue, ushort wIndex, byte[] data, ushort fsfs)
		{
			int result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(bmRequestType);
					binaryWriter.Write(bRequest);
					binaryWriter.Write(wValue);
					binaryWriter.Write(wIndex);
					binaryWriter.Write(fsfs);
					binaryWriter.Write(data);
					GCHandle gchandle = GCHandle.Alloc(memoryStream.ToArray(), GCHandleType.Pinned);
					IntPtr intptr_ = gchandle.AddrOfPinnedObject();
					GClass0.GStruct6* ptr = GClass0.libusb_alloc_transfer(0);
					ptr->intptr_0 = this.intptr_1;
					ptr->byte_1 = 0;
					ptr->byte_2 = 0;
					ptr->uint_0 = 0U;
					ptr->intptr_3 = intptr_;
					ptr->int_0 = (int)(8 + fsfs);
					ptr->intptr_2 = IntPtr.Zero;
					ptr->intptr_1 = IntPtr.Zero;
					ptr->int_2 = 0;
					ptr->intptr_4 = IntPtr.Zero;
					int num = GClass0.libusb_submit_transfer(ptr);
					if (num != 0)
					{
						throw new Exception(string.Format("libusb_submit_transfer failed: {0}", num));
					}
					num = GClass0.libusb_cancel_transfer(ptr);
					if (num != 0)
					{
						throw new Exception(string.Format("libusb_cancel_transfer failed: {0}", num));
					}
					GClass0.libusb_handle_events(Class8.intptr_0);
					while (ptr->byte_3 != 3)
					{
					}
					int int_ = ptr->int_1;
					gchandle.Free();
					result = int_;
				}
			}
			return result;
		}

		public unsafe int method_7(byte bmRequestType, byte bRequest, ushort wValue, ushort wIndex, byte[] data, ushort fsfddf)
		{
			int result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(bmRequestType);
					binaryWriter.Write(bRequest);
					binaryWriter.Write(wValue);
					binaryWriter.Write(wIndex);
					binaryWriter.Write(fsfddf);
					binaryWriter.Write(data);
					GCHandle gchandle = GCHandle.Alloc(memoryStream.ToArray(), GCHandleType.Pinned);
					IntPtr intptr_ = gchandle.AddrOfPinnedObject();
					GClass0.GStruct6* ptr = GClass0.libusb_alloc_transfer(0);
					ptr->intptr_0 = this.intptr_1;
					ptr->byte_1 = 0;
					ptr->byte_2 = 0;
					ptr->uint_0 = 0U;
					ptr->intptr_3 = intptr_;
					ptr->int_0 = (int)(8 + fsfddf);
					ptr->intptr_2 = IntPtr.Zero;
					ptr->intptr_1 = IntPtr.Zero;
					ptr->int_2 = 0;
					ptr->intptr_4 = IntPtr.Zero;
					int num = GClass0.libusb_submit_transfer(ptr);
					if (num != 0)
					{
						throw new Exception(string.Format("libusb_submit_transfer failed: {0}", num));
					}
					num = GClass0.libusb_cancel_transfer(ptr);
					if (num != 0)
					{
						throw new Exception(string.Format("libusb_cancel_transfer failed: {0}", num));
					}
					GClass0.libusb_handle_events(Class8.intptr_0);
					int int_ = ptr->int_1;
					gchandle.Free();
					result = int_;
				}
			}
			return result;
		}

		public int method_8(byte bm_request_type, byte b_request, ushort w_value, ushort w_index, byte[] data, ushort w_length, uint time)
		{
			return GClass0.libusb_control_transfer(this.intptr_1, bm_request_type, b_request, w_value, w_index, data, w_length, time);
		}

		public int method_9(Class1.Class2 payload)
		{
			for (int i = 0; i < (int)payload.ushort_2; i += 2048)
			{
				int num = 2048;
				if (2048 + i > (int)payload.ushort_2)
				{
					num = (int)payload.ushort_2 - i;
				}
				byte[] array = new byte[num];
				Array.Copy(payload.byte_2, i, array, 0, num);
				if (this.method_5(33, 1, 0, 0, array, (ushort)array.Length) != num)
				{
					return -1;
				}
			}
			Class6.smethod_1(1000L);
			this.method_8(33, 4, 0, 0, null, 0, 0U);
			Class6.smethod_1(1000L);
			return 0;
		}

		public int method_10(Class1.Class2 payload_)
		{
			byte[] data = new byte[8];
			byte[] byte_ = payload_.byte_3;
			this.method_5(64, 64, 1000, 500, null, 0);
			for (int i = 0; i < byte_.Length; i += 2048)
			{
				int num = 2048;
				if (2048 + i > byte_.Length)
				{
					num = byte_.Length - i;
				}
				byte[] array = new byte[num];
				Array.Copy(byte_, i, array, 0, num);
				if (this.method_5(33, 1, 0, 0, array, (ushort)array.Length) != num)
				{
					return -1;
				}
			}
			Class6.smethod_1(10000L);
			this.method_5(33, 1, 0, 0, null, 0);
			this.method_5(161, 3, 0, 0, data, 8);
			this.method_5(161, 3, 0, 0, data, 8);
			this.method_5(161, 3, 0, 0, data, 8);
			Class6.smethod_1(10000L);
			return 0;
		}

		public int method_11(Class1.Class2 payload)
		{
			this.method_3();
			this.method_4();
			int num = 0;
			while (this.method_2(15U, Class8.ushort_2, false, false) != 0)
			{
				if (num == 15000)
				{
					return -1;
				}
				Thread.Sleep(500);
				num += 500;
			}
			Class6.smethod_1(10000L);
			if (this.method_10(payload) != 0)
			{
				return -1;
			}
			this.method_3();
			this.method_4();
			return 0;
		}

		public static ushort ushort_0 = 1452;

		public static ushort ushort_1 = 4647;

		public static ushort ushort_2 = 4920;

		private static IntPtr intptr_0;

		private IntPtr intptr_1;

		private unsafe GClass0.GStruct2* pGstruct2_0;

		private string string_0;

		private GClass0.GStruct0 gstruct0_0;
	}
}
