using System;

namespace UsbLibrary
{
	// Token: 0x0200000F RID: 15
	public class SpecifiedInputReport : InputReport
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00008E9A File Offset: 0x0000709A
		public SpecifiedInputReport(HIDDevice oDev) : base(oDev)
		{
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00008EA6 File Offset: 0x000070A6
		public override void ProcessData()
		{
			this.arrData = base.Buffer;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00008EB8 File Offset: 0x000070B8
		public byte[] Data
		{
			get
			{
				return this.arrData;
			}
		}

		// Token: 0x040000B6 RID: 182
		private byte[] arrData;
	}
}
