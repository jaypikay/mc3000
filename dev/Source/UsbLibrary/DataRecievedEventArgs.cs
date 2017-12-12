using System;

namespace UsbLibrary
{
	// Token: 0x02000017 RID: 23
	public class DataRecievedEventArgs : EventArgs
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x00014BA4 File Offset: 0x00012DA4
		public DataRecievedEventArgs(byte[] data)
		{
			this.data = data;
		}

		// Token: 0x04000197 RID: 407
		public readonly byte[] data;
	}
}
