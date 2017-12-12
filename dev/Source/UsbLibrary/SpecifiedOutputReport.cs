using System;

namespace UsbLibrary
{
	// Token: 0x02000016 RID: 22
	public class SpecifiedOutputReport : OutputReport
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x00014B63 File Offset: 0x00012D63
		public SpecifiedOutputReport(HIDDevice oDev) : base(oDev)
		{
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00014B70 File Offset: 0x00012D70
		public bool SendData(byte[] data)
		{
			byte[] buffer = base.Buffer;
			for (int i = 1; i < buffer.Length; i++)
			{
				buffer[i] = data[i];
			}
			return true;
		}
	}
}
