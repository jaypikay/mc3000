using System;
using System.Runtime.InteropServices;

namespace UsbLibrary
{
	// Token: 0x02000004 RID: 4
	public class Win32Usb
	{
		// Token: 0x0600000F RID: 15
		[DllImport("hid.dll", SetLastError = true)]
		protected static extern void HidD_GetHidGuid(out Guid gHid);

		// Token: 0x06000010 RID: 16
		[DllImport("setupapi.dll", SetLastError = true)]
		protected static extern IntPtr SetupDiGetClassDevs(ref Guid gClass, [MarshalAs(UnmanagedType.LPStr)] string strEnumerator, IntPtr hParent, uint nFlags);

		// Token: 0x06000011 RID: 17
		[DllImport("setupapi.dll", SetLastError = true)]
		protected static extern int SetupDiDestroyDeviceInfoList(IntPtr lpInfoSet);

		// Token: 0x06000012 RID: 18
		[DllImport("setupapi.dll", SetLastError = true)]
		protected static extern bool SetupDiEnumDeviceInterfaces(IntPtr lpDeviceInfoSet, uint nDeviceInfoData, ref Guid gClass, uint nIndex, ref Win32Usb.DeviceInterfaceData oInterfaceData);

		// Token: 0x06000013 RID: 19
		[DllImport("setupapi.dll", SetLastError = true)]
		protected static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr lpDeviceInfoSet, ref Win32Usb.DeviceInterfaceData oInterfaceData, IntPtr lpDeviceInterfaceDetailData, uint nDeviceInterfaceDetailDataSize, ref uint nRequiredSize, IntPtr lpDeviceInfoData);

		// Token: 0x06000014 RID: 20
		[DllImport("setupapi.dll", SetLastError = true)]
		protected static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr lpDeviceInfoSet, ref Win32Usb.DeviceInterfaceData oInterfaceData, ref Win32Usb.DeviceInterfaceDetailData oDetailData, uint nDeviceInterfaceDetailDataSize, ref uint nRequiredSize, IntPtr lpDeviceInfoData);

		// Token: 0x06000015 RID: 21
		[DllImport("user32.dll", SetLastError = true)]
		protected static extern IntPtr RegisterDeviceNotification(IntPtr hwnd, Win32Usb.DeviceBroadcastInterface oInterface, uint nFlags);

		// Token: 0x06000016 RID: 22
		[DllImport("user32.dll", SetLastError = true)]
		protected static extern bool UnregisterDeviceNotification(IntPtr hHandle);

		// Token: 0x06000017 RID: 23
		[DllImport("hid.dll", SetLastError = true)]
		protected static extern bool HidD_GetPreparsedData(IntPtr hFile, out IntPtr lpData);

		// Token: 0x06000018 RID: 24
		[DllImport("hid.dll", SetLastError = true)]
		protected static extern bool HidD_FreePreparsedData(ref IntPtr pData);

		// Token: 0x06000019 RID: 25
		[DllImport("hid.dll", SetLastError = true)]
		protected static extern int HidP_GetCaps(IntPtr lpData, out Win32Usb.HidCaps oCaps);

		// Token: 0x0600001A RID: 26
		[DllImport("kernel32.dll", SetLastError = true)]
		protected static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPStr)] string strName, uint nAccess, uint nShareMode, IntPtr lpSecurity, uint nCreationFlags, uint nAttributes, IntPtr lpTemplate);

		// Token: 0x0600001B RID: 27
		[DllImport("kernel32.dll", SetLastError = true)]
		protected static extern int CloseHandle(IntPtr hFile);

		// Token: 0x0600001C RID: 28 RVA: 0x00003B78 File Offset: 0x00001D78
		public static IntPtr RegisterForUsbEvents(IntPtr hWnd, Guid gClass)
		{
			Win32Usb.DeviceBroadcastInterface deviceBroadcastInterface = new Win32Usb.DeviceBroadcastInterface();
			deviceBroadcastInterface.Size = Marshal.SizeOf(deviceBroadcastInterface);
			deviceBroadcastInterface.ClassGuid = gClass;
			deviceBroadcastInterface.DeviceType = 5;
			deviceBroadcastInterface.Reserved = 0;
			return Win32Usb.RegisterDeviceNotification(hWnd, deviceBroadcastInterface, 0u);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003BBC File Offset: 0x00001DBC
		public static bool UnregisterForUsbEvents(IntPtr hHandle)
		{
			return Win32Usb.UnregisterDeviceNotification(hHandle);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00003BD4 File Offset: 0x00001DD4
		public static Guid HIDGuid
		{
			get
			{
				Guid result;
				Win32Usb.HidD_GetHidGuid(out result);
				return result;
			}
		}

		// Token: 0x0400001E RID: 30
		public const int WM_DEVICECHANGE = 537;

		// Token: 0x0400001F RID: 31
		public const int DEVICE_ARRIVAL = 32768;

		// Token: 0x04000020 RID: 32
		public const int DEVICE_REMOVECOMPLETE = 32772;

		// Token: 0x04000021 RID: 33
		protected const int DIGCF_PRESENT = 2;

		// Token: 0x04000022 RID: 34
		protected const int DIGCF_DEVICEINTERFACE = 16;

		// Token: 0x04000023 RID: 35
		protected const int DEVTYP_DEVICEINTERFACE = 5;

		// Token: 0x04000024 RID: 36
		protected const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;

		// Token: 0x04000025 RID: 37
		protected const uint PURGE_TXABORT = 1u;

		// Token: 0x04000026 RID: 38
		protected const uint PURGE_RXABORT = 2u;

		// Token: 0x04000027 RID: 39
		protected const uint PURGE_TXCLEAR = 4u;

		// Token: 0x04000028 RID: 40
		protected const uint PURGE_RXCLEAR = 8u;

		// Token: 0x04000029 RID: 41
		protected const uint GENERIC_READ = 2147483648u;

		// Token: 0x0400002A RID: 42
		protected const uint GENERIC_WRITE = 1073741824u;

		// Token: 0x0400002B RID: 43
		protected const uint FILE_SHARE_WRITE = 2u;

		// Token: 0x0400002C RID: 44
		protected const uint FILE_SHARE_READ = 1u;

		// Token: 0x0400002D RID: 45
		protected const uint FILE_FLAG_OVERLAPPED = 1073741824u;

		// Token: 0x0400002E RID: 46
		protected const uint OPEN_EXISTING = 3u;

		// Token: 0x0400002F RID: 47
		protected const uint OPEN_ALWAYS = 4u;

		// Token: 0x04000030 RID: 48
		protected const uint ERROR_IO_PENDING = 997u;

		// Token: 0x04000031 RID: 49
		protected const uint INFINITE = 4294967295u;

		// Token: 0x04000032 RID: 50
		public static IntPtr NullHandle = IntPtr.Zero;

		// Token: 0x04000033 RID: 51
		protected static IntPtr InvalidHandleValue = new IntPtr(-1);

		// Token: 0x02000005 RID: 5
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		protected struct Overlapped
		{
			// Token: 0x04000034 RID: 52
			public uint Internal;

			// Token: 0x04000035 RID: 53
			public uint InternalHigh;

			// Token: 0x04000036 RID: 54
			public uint Offset;

			// Token: 0x04000037 RID: 55
			public uint OffsetHigh;

			// Token: 0x04000038 RID: 56
			public IntPtr Event;
		}

		// Token: 0x02000006 RID: 6
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		protected struct DeviceInterfaceData
		{
			// Token: 0x04000039 RID: 57
			public int Size;

			// Token: 0x0400003A RID: 58
			public Guid InterfaceClassGuid;

			// Token: 0x0400003B RID: 59
			public int Flags;

			// Token: 0x0400003C RID: 60
			public int Reserved;
		}

		// Token: 0x02000007 RID: 7
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		protected struct HidCaps
		{
			// Token: 0x0400003D RID: 61
			public short Usage;

			// Token: 0x0400003E RID: 62
			public short UsagePage;

			// Token: 0x0400003F RID: 63
			public short InputReportByteLength;

			// Token: 0x04000040 RID: 64
			public short OutputReportByteLength;

			// Token: 0x04000041 RID: 65
			public short FeatureReportByteLength;

			// Token: 0x04000042 RID: 66
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
			public short[] Reserved;

			// Token: 0x04000043 RID: 67
			public short NumberLinkCollectionNodes;

			// Token: 0x04000044 RID: 68
			public short NumberInputButtonCaps;

			// Token: 0x04000045 RID: 69
			public short NumberInputValueCaps;

			// Token: 0x04000046 RID: 70
			public short NumberInputDataIndices;

			// Token: 0x04000047 RID: 71
			public short NumberOutputButtonCaps;

			// Token: 0x04000048 RID: 72
			public short NumberOutputValueCaps;

			// Token: 0x04000049 RID: 73
			public short NumberOutputDataIndices;

			// Token: 0x0400004A RID: 74
			public short NumberFeatureButtonCaps;

			// Token: 0x0400004B RID: 75
			public short NumberFeatureValueCaps;

			// Token: 0x0400004C RID: 76
			public short NumberFeatureDataIndices;
		}

		// Token: 0x02000008 RID: 8
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct DeviceInterfaceDetailData
		{
			// Token: 0x0400004D RID: 77
			public int Size;

			// Token: 0x0400004E RID: 78
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string DevicePath;
		}

		// Token: 0x02000009 RID: 9
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
		public class DeviceBroadcastInterface
		{
			// Token: 0x0400004F RID: 79
			public int Size;

			// Token: 0x04000050 RID: 80
			public int DeviceType;

			// Token: 0x04000051 RID: 81
			public int Reserved;

			// Token: 0x04000052 RID: 82
			public Guid ClassGuid;

			// Token: 0x04000053 RID: 83
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string Name;
		}
	}
}
