using System;

namespace UsbLibrary
{
	// Token: 0x0200000D RID: 13
	public abstract class Report
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00008E1D File Offset: 0x0000701D
		public Report(HIDDevice oDev)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00008E28 File Offset: 0x00007028
		protected void SetBuffer(byte[] arrBytes)
		{
			this.m_arrBuffer = arrBytes;
			this.m_nLength = this.m_arrBuffer.Length;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00008E40 File Offset: 0x00007040
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00008E58 File Offset: 0x00007058
		public byte[] Buffer
		{
			get
			{
				return this.m_arrBuffer;
			}
			set
			{
				this.m_arrBuffer = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00008E64 File Offset: 0x00007064
		public int BufferLength
		{
			get
			{
				return this.m_nLength;
			}
		}

		// Token: 0x040000B4 RID: 180
		private byte[] m_arrBuffer;

		// Token: 0x040000B5 RID: 181
		private int m_nLength;
	}
}
