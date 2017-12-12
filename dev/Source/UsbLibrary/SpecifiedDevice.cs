using System;

namespace UsbLibrary
{
	// Token: 0x0200001B RID: 27
	public class SpecifiedDevice : HIDDevice
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000FF RID: 255 RVA: 0x00014BC8 File Offset: 0x00012DC8
		// (remove) Token: 0x06000100 RID: 256 RVA: 0x00014C04 File Offset: 0x00012E04
		public event DataRecievedEventHandler DataRecieved;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000101 RID: 257 RVA: 0x00014C40 File Offset: 0x00012E40
		// (remove) Token: 0x06000102 RID: 258 RVA: 0x00014C7C File Offset: 0x00012E7C
		public event DataSendEventHandler DataSend;

		// Token: 0x06000103 RID: 259 RVA: 0x00014CB8 File Offset: 0x00012EB8
		public override InputReport CreateInputReport()
		{
			return new SpecifiedInputReport(this);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00014CD0 File Offset: 0x00012ED0
		public static SpecifiedDevice FindSpecifiedDevice(int vendor_id, int product_id)
		{
			return (SpecifiedDevice)HIDDevice.FindDevice(vendor_id, product_id, typeof(SpecifiedDevice));
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00014CF8 File Offset: 0x00012EF8
		protected override void HandleDataReceived(InputReport oInRep)
		{
			if (this.DataRecieved != null)
			{
				SpecifiedInputReport specifiedInputReport = (SpecifiedInputReport)oInRep;
				this.DataRecieved(this, new DataRecievedEventArgs(specifiedInputReport.Data));
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00014D34 File Offset: 0x00012F34
		public void SendData(byte[] data)
		{
			SpecifiedOutputReport specifiedOutputReport = new SpecifiedOutputReport(this);
			if (specifiedOutputReport.SendData(data))
			{
				try
				{
					base.Write(specifiedOutputReport);
					if (this.DataSend != null)
					{
						this.DataSend(this, new DataSendEventArgs(data));
					}
				}
				catch (HIDDeviceException ex)
				{
					Console.WriteLine(ex.ToString());
				}
				catch (Exception ex2)
				{
					Console.WriteLine(ex2.ToString());
				}
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00014DC4 File Offset: 0x00012FC4
		protected override void Dispose(bool bDisposing)
		{
			if (bDisposing)
			{
			}
			base.Dispose(bDisposing);
		}
	}
}
