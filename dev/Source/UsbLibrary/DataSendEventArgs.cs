using System;

namespace UsbLibrary
{
	// Token: 0x02000018 RID: 24
	public class DataSendEventArgs : EventArgs
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00014BB6 File Offset: 0x00012DB6
		public DataSendEventArgs(byte[] data)
		{
			this.data = data;
		}

		// Token: 0x04000198 RID: 408
		public readonly byte[] data;
	}
}
