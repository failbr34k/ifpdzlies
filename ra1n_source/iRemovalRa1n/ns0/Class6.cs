using System;
using System.Runtime.InteropServices;

namespace ns0
{
	internal class Class6
	{
		[DllImport("kernel32.dll")]
		private static extern IntPtr CreateWaitableTimer(IntPtr lpTimerAttributes, bool bManualReset, string lpTimerName);

		[DllImport("kernel32.dll")]
		private static extern bool SetWaitableTimer(IntPtr hTimer, [In] ref Class6.Struct0 pDueTime, int lPeriod, Class6.Delegate0 pfnCompletionRoutine, IntPtr lpArgToCompletionRoutine, bool fResume);

		[DllImport("kernel32.dll")]
		private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr hObject);

		private static void smethod_0(long sleepTime)
		{
			IntPtr intPtr = Class6.CreateWaitableTimer(IntPtr.Zero, true, null);
			Class6.Struct0 @struct = new Class6.Struct0
			{
				long_0 = sleepTime
			};
			Class6.SetWaitableTimer(intPtr, ref @struct, 0, null, IntPtr.Zero, false);
			Class6.WaitForSingleObject(intPtr, uint.MaxValue);
			Class6.CloseHandle(intPtr);
		}

		public static void smethod_1(long microsec)
		{
			Class6.smethod_0(-(10L * Math.Abs(microsec)));
		}

		public static void smethod_2(long nanosec)
		{
			Class6.smethod_0(-(Math.Abs(nanosec) / 100L));
		}

		public static ushort smethod_3(ushort swapValue)
		{
			return new Class6.Struct1(swapValue).ushort_0;
		}

		[StructLayout(LayoutKind.Explicit)]
		private struct Struct0
		{
			[FieldOffset(0)]
			public int int_0;

			[FieldOffset(4)]
			public int int_1;

			[FieldOffset(0)]
			public long long_0;
		}

		private delegate void Delegate0();

		[StructLayout(LayoutKind.Explicit, Pack = 1)]
		internal struct Struct1
		{
			public Struct1(ushort x)
			{
				this.ushort_0 = 0;
				this.byte_1 = (byte)(x >> 8);
				this.byte_0 = (byte)(x & 255);
			}

			[FieldOffset(0)]
			public readonly ushort ushort_0;

			[FieldOffset(0)]
			public readonly byte byte_0;

			[FieldOffset(1)]
			public readonly byte byte_1;
		}
	}
}
