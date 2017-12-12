using System;

namespace UsbLibrary
{
	// Token: 0x0200000E RID: 14
	public abstract class InputReport : Report
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00008E7C File Offset: 0x0000707C
		public InputReport(HIDDevice oDev) : base(oDev)
		{
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00008E88 File Offset: 0x00007088
		public void SetData(byte[] arrData)
		{
			base.SetBuffer(arrData);
			this.ProcessData();
		}

		// Token: 0x0600005A RID: 90
		public abstract void ProcessData();
	}
}
