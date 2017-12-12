using System;
using System.Runtime.InteropServices;

namespace UsbLibrary
{
	// Token: 0x02000003 RID: 3
	public class HIDDeviceException : ApplicationException
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00003B1C File Offset: 0x00001D1C
		public HIDDeviceException(string strMessage) : base(strMessage)
		{
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00003B28 File Offset: 0x00001D28
		public static HIDDeviceException GenerateWithWinError(string strMessage)
		{
			return new HIDDeviceException(string.Format("Msg:{0} WinEr:{1:X8}", strMessage, Marshal.GetLastWin32Error()));
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00003B54 File Offset: 0x00001D54
		public static HIDDeviceException GenerateError(string strMessage)
		{
			return new HIDDeviceException(string.Format("Msg:{0}", strMessage));
		}
	}
}
