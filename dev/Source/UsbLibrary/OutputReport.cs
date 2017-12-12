using System;

namespace UsbLibrary
{
	// Token: 0x02000011 RID: 17
	public abstract class OutputReport : Report
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00009A85 File Offset: 0x00007C85
		public OutputReport(HIDDevice oDev) : base(oDev)
		{
			base.SetBuffer(new byte[oDev.OutputReportLength]);
		}
	}
}
