using System;
using System.ComponentModel;

namespace UsbLibrary
{
	// Token: 0x0200001F RID: 31
	public class UsbHidPort : Component
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000123 RID: 291 RVA: 0x00015064 File Offset: 0x00013264
		// (remove) Token: 0x06000124 RID: 292 RVA: 0x000150A0 File Offset: 0x000132A0
		[DisplayName("OnSpecifiedDeviceArrived")]
		[Category("Embedded Event")]
		[Description("The event that occurs when a usb hid device with the specified vendor id and product id is found on the bus")]
		public event EventHandler OnSpecifiedDeviceArrived;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000125 RID: 293 RVA: 0x000150DC File Offset: 0x000132DC
		// (remove) Token: 0x06000126 RID: 294 RVA: 0x00015118 File Offset: 0x00013318
		[Description("The event that occurs when a usb hid device with the specified vendor id and product id is removed from the bus")]
		[DisplayName("OnSpecifiedDeviceRemoved")]
		[Category("Embedded Event")]
		public event EventHandler OnSpecifiedDeviceRemoved;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000127 RID: 295 RVA: 0x00015154 File Offset: 0x00013354
		// (remove) Token: 0x06000128 RID: 296 RVA: 0x00015190 File Offset: 0x00013390
		[DisplayName("OnDeviceArrived")]
		[Description("The event that occurs when a usb hid device is found on the bus")]
		[Category("Embedded Event")]
		public event EventHandler OnDeviceArrived;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000129 RID: 297 RVA: 0x000151CC File Offset: 0x000133CC
		// (remove) Token: 0x0600012A RID: 298 RVA: 0x00015208 File Offset: 0x00013408
		[Category("Embedded Event")]
		[Description("The event that occurs when a usb hid device is removed from the bus")]
		[DisplayName("OnDeviceRemoved")]
		public event EventHandler OnDeviceRemoved;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600012B RID: 299 RVA: 0x00015244 File Offset: 0x00013444
		// (remove) Token: 0x0600012C RID: 300 RVA: 0x00015280 File Offset: 0x00013480
		[Description("The event that occurs when data is recieved from the embedded system")]
		[Category("Embedded Event")]
		[DisplayName("OnDataRecieved")]
		public event DataRecievedEventHandler OnDataRecieved;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600012D RID: 301 RVA: 0x000152BC File Offset: 0x000134BC
		// (remove) Token: 0x0600012E RID: 302 RVA: 0x000152F8 File Offset: 0x000134F8
		[Description("The event that occurs when data is send from the host to the embedded system")]
		[DisplayName("OnDataSend")]
		[Category("Embedded Event")]
		public event EventHandler OnDataSend;

		// Token: 0x0600012F RID: 303 RVA: 0x00015334 File Offset: 0x00013534
		public UsbHidPort()
		{
			this.product_id = 0;
			this.vendor_id = 0;
			this.specified_device = null;
			this.device_class = Win32Usb.HIDGuid;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00015360 File Offset: 0x00013560
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00015378 File Offset: 0x00013578
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		[Description("The product id from the USB device you want to use")]
		public int ProductId
		{
			get
			{
				return this.product_id;
			}
			set
			{
				this.product_id = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00015384 File Offset: 0x00013584
		// (set) Token: 0x06000133 RID: 307 RVA: 0x0001539C File Offset: 0x0001359C
		[Category("Embedded Details")]
		[DefaultValue("(none)")]
		[Description("The vendor id from the USB device you want to use")]
		public int VendorId
		{
			get
			{
				return this.vendor_id;
			}
			set
			{
				this.vendor_id = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000134 RID: 308 RVA: 0x000153A8 File Offset: 0x000135A8
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		[Description("The Device Class the USB device belongs to")]
		public Guid DeviceClass
		{
			get
			{
				return this.device_class;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000153C0 File Offset: 0x000135C0
		[Description("The Device witch applies to the specifications you set")]
		[DefaultValue("(none)")]
		[Category("Embedded Details")]
		public SpecifiedDevice SpecifiedDevice
		{
			get
			{
				return this.specified_device;
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000153D8 File Offset: 0x000135D8
		public void RegisterHandle(IntPtr Handle)
		{
			this.usb_event_handle = Win32Usb.RegisterForUsbEvents(Handle, this.device_class);
			this.handle = Handle;
			this.CheckDevicePresent();
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000153FC File Offset: 0x000135FC
		public bool UnregisterHandle()
		{
			bool flag = 1 == 0;
			return Win32Usb.UnregisterForUsbEvents(this.handle);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00015420 File Offset: 0x00013620
		public void ParseMessages(int msg, IntPtr wParam)
		{
			if (msg == 537)
			{
				int num = wParam.ToInt32();
				if (num != 32768)
				{
					if (num == 32772)
					{
						if (this.OnDeviceRemoved != null)
						{
							this.OnDeviceRemoved(this, new EventArgs());
							this.CheckDevicePresent();
						}
					}
				}
				else if (this.OnDeviceArrived != null)
				{
					this.OnDeviceArrived(this, new EventArgs());
					this.CheckDevicePresent();
				}
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000154B0 File Offset: 0x000136B0
		public void CheckDevicePresent()
		{
			try
			{
				bool flag = false;
				if (this.specified_device != null)
				{
					flag = true;
				}
				this.specified_device = SpecifiedDevice.FindSpecifiedDevice(this.vendor_id, this.product_id);
				if (this.specified_device != null)
				{
					if (this.OnSpecifiedDeviceArrived != null)
					{
						this.OnSpecifiedDeviceArrived(this, new EventArgs());
						this.specified_device.DataRecieved += this.OnDataRecieved.Invoke;
						this.specified_device.DataSend += new DataSendEventHandler(this.OnDataSend.Invoke);
					}
				}
				else if (this.OnSpecifiedDeviceRemoved != null && flag)
				{
					this.OnSpecifiedDeviceRemoved(this, new EventArgs());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000155A4 File Offset: 0x000137A4
		private void DataRecieved(object sender, DataRecievedEventArgs args)
		{
			if (this.OnDataRecieved != null)
			{
				this.OnDataRecieved(sender, args);
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000155D0 File Offset: 0x000137D0
		private void DataSend(object sender, DataSendEventArgs args)
		{
			if (this.OnDataSend != null)
			{
				this.OnDataSend(sender, args);
			}
		}

		// Token: 0x040001CF RID: 463
		private int product_id;

		// Token: 0x040001D0 RID: 464
		private int vendor_id;

		// Token: 0x040001D1 RID: 465
		private Guid device_class;

		// Token: 0x040001D2 RID: 466
		private IntPtr usb_event_handle;

		// Token: 0x040001D3 RID: 467
		private SpecifiedDevice specified_device;

		// Token: 0x040001D4 RID: 468
		private IntPtr handle;
	}
}
