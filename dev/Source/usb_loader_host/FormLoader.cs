using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using UpgradeFirmware;
using UpgradeFirmware.Properties;
using UsbLibrary;

namespace usb_loader_host
{
	// Token: 0x02000012 RID: 18
	public class FormLoader : Form
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00009B98 File Offset: 0x00007D98
		public FormLoader()
		{
			bool[] array = new bool[4];
			this.bfinish = array;
			this.font = new Font("arial", 8f);
			this.font2 = new Font("black", 10f, FontStyle.Bold);
			this.pen = new Pen(Color.Blue, 2f);
			this.bMeasure = new bool[4];
			this.index_scale = new float[4];
			this.li_mode = new string[]
			{
				"Charge",
				"Refresh",
				"Storage",
				"DisCharge",
				"Cycle"
			};
			this.ni_mode = new string[]
			{
				"Charge",
				"Refresh",
				"BreakIn",
				"DisCharge",
				"Cycle"
			};
			this.max_add = 0;
			this.addSend = 0;
			this.packet_counter = 0;
			this.checkSum = 0u;
			this.request = FormLoader.REQENUM.get_information;
			this.updataStep = FormLoader.UPDATAENUM.get_device_infomation;
			this.waitAck = false;
			this.downLoadFail = false;
			this.timerCounter = 0;
			this.vectorStart = false;
			this.vector = 0;
			this.vectorBytes = 0;
			this.vectorBytesSended = 0;
			this.vectorDelay = 0;
			this.BinText = new StringBuilder();
			this.hexchar = new char[]
			{
				'0',
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9',
				'A',
				'B',
				'C',
				'D',
				'E',
				'F'
			};
			this.in_count = 0;
			this.solt_id = 0;
			this.stop_count = 0;
			this.bread_chrager_data = false;
			this.bwrite_chrager_data = false;
			this.components = null;
			base..ctor();
			this.InitializeComponent();
			this.usb = new UsbHidPort();
			this.usb.ProductId = 1;
			this.usb.VendorId = 0;
			this.usb.OnSpecifiedDeviceArrived += this.usbOnSpecifiedDeviceArrived;
			this.usb.OnSpecifiedDeviceRemoved += this.usbOnSpecifiedDeviceRemoved;
			this.usb.OnDeviceArrived += this.usbOnDeviceArrived;
			this.usb.OnDeviceRemoved += this.usbOnDeviceRemoved;
			this.usb.OnDataRecieved += this.usbOnDataRecieved;
			this.usb.OnDataSend += this.usbOnDataSend;
			base.SuspendLayout();
			this.param = new Param();
			this.Batt_Type = new Battery();
			this.Curve_Volt = new bool[4];
			this.Curve_Cur = new bool[4];
			this.Curve_Caps = new bool[4];
			this.Curve_Tem = new bool[4];
			this.bstop = new bool[4];
			this.bstop[0] = false;
			this.bstop[1] = false;
			this.bstop[2] = false;
			this.bstop[3] = false;
			this.Pool_Index = new int[4];
			this.Data_Index = new int[4];
			this.vMax = new int[4];
			this.vMin = new int[4];
			this.cMax = new int[4];
			this.cMin = new int[4];
			this.curMax = new int[4];
			this.curMin = new int[4];
			this.temMax = new int[4];
			this.temMin = new int[4];
			this.yUnit = new float[4];
			this.Cap_yUnit = new float[4];
			this.Cur_yUnit = new float[4];
			this.Tem_yUnit = new float[4];
			this.xUnit = new int[4];
			this.Label_Width = new int[4];
			this.Label_Heigh = new int[4];
			this.Voltage_Pool = new int[4][];
			this.Cur_Pool = new int[4][];
			this.Caps_Pool = new int[4][];
			this.Batt_Tem_Pool = new int[4][];
			this.Voltage_Data = new int[4][];
			this.Cur_Data = new int[4][];
			this.Caps_Data = new int[4][];
			this.Batt_Tem_Data = new int[4][];
			this.work_time = new int[4];
			this.tMax = new int[4];
			this.tick2 = new int[4];
			this.Update_Unit = new int[4];
			this.BatInfo = new string[4];
			this.Voltage = new int[4];
			this.Current = new int[4];
			this.Caps = new int[4];
			this.dCaps = new int[4];
			this.Caps_Decimal = new int[4];
			this.Batt_Tem = new int[4];
			for (int i = 0; i < 4; i++)
			{
				this.Voltage_Pool[i] = new int[this.label_SOLT1.Width - 2];
				this.Cur_Pool[i] = new int[this.label_SOLT1.Width - 2];
				this.Caps_Pool[i] = new int[this.label_SOLT1.Width - 2];
				this.Batt_Tem_Pool[i] = new int[this.label_SOLT1.Width - 2];
				this.index_scale[i] = 1f;
				this.bMeasure[i] = false;
				this.Voltage_Data[i] = new int[864000];
				this.Cur_Data[i] = new int[864000];
				this.Caps_Data[i] = new int[864000];
				this.Batt_Tem_Data[i] = new int[864000];
				this.Pool_Index[i] = 0;
				this.Data_Index[i] = 0;
				this.vMax[i] = 0;
				this.vMin[i] = 50000;
				this.cMax[i] = 0;
				this.cMin[i] = 50000;
				this.curMax[i] = 0;
				this.curMin[i] = 50000;
				this.temMax[i] = 0;
				this.temMin[i] = 50000;
				this.tMax[i] = 20;
				this.tick2[i] = 0;
				this.yUnit[i] = 1f;
				this.Update_Unit[i] = 1;
				this.Curve_Volt[i] = true;
				this.Curve_Cur[i] = true;
				this.Curve_Caps[i] = false;
				this.Curve_Tem[i] = false;
			}
			this.xUnit[0] = (this.label_SOLT1.Width - 100) / 20;
			this.xUnit[1] = (this.label_SOLT2.Width - 100) / 20;
			this.xUnit[2] = (this.label_SOLT3.Width - 100) / 20;
			this.xUnit[3] = (this.label_SOLT4.Width - 100) / 20;
			this.Label_Width[0] = this.label_SOLT1.Width;
			this.Label_Width[1] = this.label_SOLT2.Width;
			this.Label_Width[2] = this.label_SOLT3.Width;
			this.Label_Width[3] = this.label_SOLT4.Width;
			this.Label_Heigh[0] = this.label_SOLT1.Height;
			this.Label_Heigh[1] = this.label_SOLT2.Height;
			this.Label_Heigh[2] = this.label_SOLT3.Height;
			this.Label_Heigh[3] = this.label_SOLT4.Height;
			this.BatParam = new ChargerData[4];
			for (int i = 0; i < 4; i++)
			{
				this.BatParam[i] = new ChargerData();
				this.BatParam[i].Type = 0;
				this.BatParam[i].Mode = 0;
				this.BatParam[i].Caps = 2000;
				this.BatParam[i].Cur = 1000;
				this.BatParam[i].dCur = 500;
				this.BatParam[i].CutTime = 180;
				this.BatParam[i].CutTemp = 450;
				this.BatParam[i].End_Volt = 4200;
				this.BatParam[i].Cut_Volt = 3300;
				this.BatParam[i].End_Cur = 100;
				this.BatParam[i].End_dCur = 400;
				this.BatParam[i].Cycle_Mode = 0;
				this.BatParam[i].Cycle_Count = 1;
				this.BatParam[i].Cycle_Delay = 10;
				this.BatParam[i].Trickle = 50;
				this.BatParam[i].Peak_Sense = 3;
				this.BatParam[i].Hold_Volt = 4180;
			}
			this.param.Init_datagridview();
			this.timer3.Start();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000A50C File Offset: 0x0000870C
		private void Encryption()
		{
			for (int i = 0; i < 59392; i += 128)
			{
				for (int j = 0; j < 64; j++)
				{
					byte[] binBuffer = this.BinBuffer;
					int num = i + j;
					binBuffer[num] ^= this.BinBuffer[i + j + 64];
				}
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000A570 File Offset: 0x00008770
		protected override void OnHandleCreated(EventArgs e)
		{
			this.usb.RegisterHandle(base.Handle);
			base.OnHandleCreated(e);
			if (this.usb.SpecifiedDevice == null)
			{
				this.Text = "ChargeMonitor V2 DisConnect";
				this.label_usb_status.Text = "USB OFF";
				this.label_usb_status.ForeColor = Color.Red;
			}
			else
			{
				this.Text = "ChargeMonitor V2 Connect";
				this.label_usb_status.Text = "USB ON";
				this.label_usb_status.ForeColor = Color.Green;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000A60F File Offset: 0x0000880F
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			this.usb.ParseMessages(m.Msg, m.WParam);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000A634 File Offset: 0x00008834
		private void usbOnDataRecieved(object sender, DataRecievedEventArgs args)
		{
			if (base.InvokeRequired)
			{
				try
				{
					base.Invoke(new DataRecievedEventHandler(this.usbOnDataRecieved), new object[]
					{
						sender,
						args
					});
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
			else
			{
				this.packet_counter++;
				for (int i = 0; i < 65; i++)
				{
					this.inPacket[i] = args.data[i];
				}
				this.dataReceived = true;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000A6D8 File Offset: 0x000088D8
		private void usbOnDeviceArrived(object sender, EventArgs e)
		{
			if (!this.DeviceFounded)
			{
				this.usbSendConnectData();
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000A6FC File Offset: 0x000088FC
		private void usbOnSpecifiedDeviceRemoved(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new EventHandler(this.usbOnSpecifiedDeviceRemoved), new object[]
				{
					sender,
					e
				});
			}
			else
			{
				this.DeviceFounded = false;
				this.lb_verson.Text = "";
				this.timer2.Enabled = false;
				this.Text = "ChargeMonitor V2 DisConnect";
				this.label_usb_status.Text = "USB OFF";
				this.label_usb_status.ForeColor = Color.Red;
				this.disable_all_button();
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000A79C File Offset: 0x0000899C
		private void usbOnSpecifiedDeviceArrived(object sender, EventArgs e)
		{
			this.DeviceFounded = true;
			this.timer2.Enabled = true;
			this.timer2.Start();
			this.Text = "ChargeMonitor V2 Connect";
			this.label_usb_status.Text = "USB ON";
			this.label_usb_status.ForeColor = Color.Green;
			this.bread_chrager_data = true;
			this.solt_id = 0;
			this.timer3.Start();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000A814 File Offset: 0x00008A14
		private void usbOnDeviceRemoved(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new EventHandler(this.usbOnDeviceRemoved), new object[]
				{
					sender,
					e
				});
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000A858 File Offset: 0x00008A58
		private void usbOnDataSend(object sender, EventArgs e)
		{
			this.Text = "ChargeMonitor V2 Connect";
			this.label_usb_status.Text = "USB ON";
			this.label_usb_status.ForeColor = Color.Green;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000A889 File Offset: 0x00008A89
		private void loadApp()
		{
			this.DownLoad.Enabled = true;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000A89B File Offset: 0x00008A9B
		private void buttonCheckDevice_Click(object sender, EventArgs e)
		{
			MessageBox.Show("ok!");
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000A8AC File Offset: 0x00008AAC
		private void usbSendConnectData()
		{
			if (!this.DeviceFounded)
			{
				try
				{
					this.usb.ProductId = 1;
					this.usb.VendorId = 0;
					this.usb.CheckDevicePresent();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000A910 File Offset: 0x00008B10
		private void UFirmware()
		{
			if (!this.DeviceFounded)
			{
				MessageBox.Show("Not Found a Device！");
				this.usbSendConnectData();
			}
			else if (this.FileLoaded)
			{
				this.outPacket[0] = 0;
				this.outPacket[1] = 15;
				this.outPacket[2] = 3;
				this.outPacket[3] = 136;
				this.outPacket[4] = 0;
				this.outPacket[5] = 136;
				this.outPacket[6] = byte.MaxValue;
				this.outPacket[7] = byte.MaxValue;
				this.usb.SpecifiedDevice.SendData(this.outPacket);
				this.start_update = 0;
				this.addSend = 0;
				this.progressBar1.Value = 0;
				this.updataStep = FormLoader.UPDATAENUM.get_device_infomation;
				this.request = FormLoader.REQENUM.get_information;
				this.waitAck = false;
				this.downLoadFail = false;
				this.timerCounter = 0;
				this.vectorStart = false;
				this.vectorBytesSended = 0;
				this.vector = 0;
				this.wait_count = 0;
				this.timer2.Enabled = false;
				this.timer3.Enabled = false;
				this.timer1.Enabled = true;
				this.DownLoad.Text = "Wait...";
				this.dataReceived = false;
			}
			else
			{
				MessageBox.Show("File not Load");
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000AA6A File Offset: 0x00008C6A
		private void DownLoad_Click(object sender, EventArgs e)
		{
			MessageBox.Show(HIDDevice.OutputLength.ToString());
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000AA80 File Offset: 0x00008C80
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (++this.start_update < 200)
			{
				if (this.start_update == 100)
				{
					this.dataReceived = false;
					this.outGetDviceInfomation();
					this.packet_counter = 0;
				}
			}
			else
			{
				this.start_update = 300;
				if (this.waitAck)
				{
					if (!this.dataReceived)
					{
						if (++this.timerCounter >= 20)
						{
							this.timerCounter = 0;
							if (this.request == FormLoader.REQENUM.get_information)
							{
								this.waitAck = false;
							}
							else
							{
								this.DownLoad.Text = "Update";
								this.downLoadFail = true;
								this.timer1.Enabled = false;
								if (this.request == FormLoader.REQENUM.start_updata)
								{
									MessageBox.Show("start updata err1");
								}
								else if (this.request == FormLoader.REQENUM.start_vector)
								{
									MessageBox.Show("start vector err1");
								}
								else if (this.request == FormLoader.REQENUM.get_result)
								{
									MessageBox.Show("get result err1");
								}
								this.button_update.Enabled = true;
								this.timer2.Enabled = true;
							}
						}
						return;
					}
					this.dataReceived = false;
					this.timerCounter = 0;
					bool flag = !this.checkAck();
					this.waitAck = false;
					if (flag)
					{
						this.DownLoad.Text = "Update";
						this.downLoadFail = true;
						this.timer1.Enabled = false;
						if (this.request == FormLoader.REQENUM.start_updata)
						{
							MessageBox.Show("start updata err2");
						}
						else if (this.request == FormLoader.REQENUM.start_vector)
						{
							MessageBox.Show("start vector err2");
						}
						else if (this.request == FormLoader.REQENUM.get_result)
						{
							MessageBox.Show("get result err2");
						}
						this.timerCounter = 0;
						this.button_update.Enabled = true;
						this.timer2.Enabled = true;
						return;
					}
				}
				if (this.updataStep == FormLoader.UPDATAENUM.get_device_infomation)
				{
					this.outGetDviceInfomation();
					this.waitAck = true;
					this.timerCounter = 0;
					this.request = FormLoader.REQENUM.get_information;
				}
				else if (this.updataStep == FormLoader.UPDATAENUM.start_updata)
				{
					this.outStartSignal();
					this.waitAck = true;
					this.timerCounter = 0;
					this.request = FormLoader.REQENUM.start_updata;
				}
				else if (this.updataStep == FormLoader.UPDATAENUM.send_code)
				{
					if (this.outCodeDate())
					{
						this.outCheckResult();
						this.waitAck = true;
						this.timerCounter = 0;
						this.request = FormLoader.REQENUM.get_result;
						this.updataStep = FormLoader.UPDATAENUM.check_result;
					}
				}
				else if (this.updataStep == FormLoader.UPDATAENUM.check_result)
				{
					this.outExecutApp();
					this.vectorStart = false;
					this.downLoadFail = false;
					this.timer1.Enabled = false;
					this.FileLoaded = true;
					this.btn_app.Enabled = true;
					this.btn_boot.Enabled = true;
					this.DownLoad.Text = "Update";
					MessageBox.Show("Upgrade Complete");
					this.label_version.Text = "Current Version:" + this.update_ok_version;
					this.updataStep = FormLoader.UPDATAENUM.finsh;
					this.button_update.Enabled = true;
					this.groupBox_solt1.Enabled = true;
					this.groupBox_solt2.Enabled = true;
					this.groupBox_solt3.Enabled = true;
					this.groupBox_solt4.Enabled = true;
					this.button_start.Enabled = true;
					this.button_system.Enabled = true;
					this.button_save_all.Enabled = true;
					this.button_load_all.Enabled = true;
					this.timer2.Enabled = true;
				}
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000AE88 File Offset: 0x00009088
		private void outCheckResult()
		{
			this.outPacket[0] = 0;
			this.outPacket[1] = 4;
			for (int i = 2; i < 33; i++)
			{
				this.outPacket[i] = 0;
			}
			if (this.usb.SpecifiedDevice != null)
			{
				this.usb.SpecifiedDevice.SendData(this.outPacket);
			}
			else
			{
				this.DownLoad.Text = "Update";
				this.timer1.Enabled = false;
				MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000AF1C File Offset: 0x0000911C
		private void outGetDviceInfomation()
		{
			this.outPacket[0] = 0;
			this.outPacket[1] = 0;
			for (int i = 2; i < 33; i++)
			{
				this.outPacket[i] = 0;
			}
			if (this.usb.SpecifiedDevice != null)
			{
				this.usb.SpecifiedDevice.SendData(this.outPacket);
			}
			else
			{
				this.DownLoad.Text = "Update";
				this.timer1.Enabled = false;
				this.timer2.Enabled = false;
				MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000AFC0 File Offset: 0x000091C0
		private void outStartSignal()
		{
			this.checkSum = 0u;
			for (int i = 0; i < this.max_add; i++)
			{
				this.checkSum += (uint)this.BinBuffer[i];
			}
			this.outPacket[0] = 0;
			this.outPacket[1] = 1;
			this.outPacket[2] = (byte)(this.max_add >> 24 & 255);
			this.outPacket[3] = (byte)(this.max_add >> 16 & 255);
			this.outPacket[4] = (byte)(this.max_add >> 8 & 255);
			this.outPacket[5] = (byte)(this.max_add & 255);
			this.outPacket[6] = (byte)(this.checkSum >> 24 & 255u);
			this.outPacket[7] = (byte)(this.checkSum >> 16 & 255u);
			this.outPacket[8] = (byte)(this.checkSum >> 8 & 255u);
			this.outPacket[9] = (byte)(this.checkSum & 255u);
			for (int i = 10; i < 33; i++)
			{
				this.outPacket[i] = 0;
			}
			if (this.usb.SpecifiedDevice != null)
			{
				this.usb.SpecifiedDevice.SendData(this.outPacket);
			}
			else
			{
				this.DownLoad.Text = "Update";
				this.timer1.Enabled = false;
				MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000B144 File Offset: 0x00009344
		private void outExecutApp()
		{
			this.outPacket[0] = 0;
			this.outPacket[1] = 5;
			for (int i = 2; i < 33; i++)
			{
				this.outPacket[i] = 0;
			}
			if (this.usb.SpecifiedDevice != null)
			{
				this.usb.SpecifiedDevice.SendData(this.outPacket);
			}
			else
			{
				this.DownLoad.Text = "Update";
				this.timer1.Enabled = false;
				MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000B1D8 File Offset: 0x000093D8
		private bool checkAck()
		{
			bool result = false;
			if (this.request == FormLoader.REQENUM.get_information)
			{
				if (this.checkDeviceInformationACK())
				{
					this.updataStep = FormLoader.UPDATAENUM.start_updata;
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else if (this.request == FormLoader.REQENUM.start_updata)
			{
				if (this.checkStartAck())
				{
					this.updataStep = FormLoader.UPDATAENUM.send_code;
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else if (this.request == FormLoader.REQENUM.start_vector)
			{
				if (this.checkVectorACK())
				{
					result = true;
					this.vectorStart = true;
					this.vectorBytesSended = 0;
				}
			}
			else if (this.request == FormLoader.REQENUM.get_result)
			{
				if (this.checkResultACK())
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000B2A8 File Offset: 0x000094A8
		private bool checkResultACK()
		{
			int num = 0;
			if (this.inPacket[1] != 4)
			{
				num++;
			}
			if (this.inPacket[2] != 1)
			{
				num++;
			}
			return num == 0;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000B2F8 File Offset: 0x000094F8
		private bool checkDeviceInformationACK()
		{
			int num = 0;
			if (this.inPacket[1] != 0)
			{
				num++;
			}
			if (this.inPacket[2] == 0 || this.inPacket[2] == 255)
			{
				num++;
			}
			else
			{
				this.lb_verson.Text = "Boot Version:" + ((int)(this.inPacket[2] / 10)).ToString() + "." + ((int)(this.inPacket[2] % 10)).ToString();
			}
			return this.inPacket[3] == 85 && this.inPacket[4] == 85 && this.inPacket[5] == 85;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000B3C4 File Offset: 0x000095C4
		private bool checkStartAck()
		{
			int num = 0;
			for (int i = 0; i < 33; i++)
			{
				if (this.inPacket[i] != this.outPacket[i])
				{
					num++;
				}
			}
			return num == 0;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000B418 File Offset: 0x00009618
		private bool checkVectorACK()
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				if (this.inPacket[i] != this.outPacket[i])
				{
					num++;
				}
			}
			if (this.inPacket[8] != 1)
			{
				num++;
			}
			return num == 0;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000B480 File Offset: 0x00009680
		private bool outCodeDate()
		{
			if (!this.vectorStart)
			{
				this.outVectorStart();
				this.waitAck = true;
				this.timerCounter = 0;
				this.request = FormLoader.REQENUM.start_vector;
			}
			else if (this.vectorDelay == 0)
			{
				if (this.outVectorCode())
				{
					this.vector = this.addSend;
					this.vectorBytesSended = 0;
					this.vectorDelay = 5;
				}
			}
			else
			{
				if (this.vectorDelay > 0)
				{
					this.vectorDelay--;
				}
				if (this.vectorDelay == 0)
				{
					this.vectorStart = false;
				}
			}
			int num = this.addSend * 100 / this.max_add;
			if (num > 100)
			{
				num = 100;
			}
			this.progressBar1.Value = num;
			bool result;
			if (this.addSend >= this.max_add)
			{
				this.vector = 0;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000B580 File Offset: 0x00009780
		private void outVectorStart()
		{
			if (this.max_add - this.vector >= 1024)
			{
				this.vectorBytes = 1024;
			}
			else
			{
				this.vectorBytes = this.max_add - this.vector;
			}
			this.outPacket[0] = 0;
			this.outPacket[1] = 2;
			this.outPacket[2] = (byte)(this.vector >> 24 & 255);
			this.outPacket[3] = (byte)(this.vector >> 16 & 255);
			this.outPacket[4] = (byte)(this.vector >> 8 & 255);
			this.outPacket[5] = (byte)(this.vector & 255);
			this.outPacket[6] = (byte)(this.vectorBytes >> 8);
			this.outPacket[7] = (byte)(this.vectorBytes & 255);
			for (int i = 8; i < 33; i++)
			{
				this.outPacket[i] = 0;
			}
			if (this.usb.SpecifiedDevice != null)
			{
				this.usb.SpecifiedDevice.SendData(this.outPacket);
			}
			else
			{
				MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000B6B4 File Offset: 0x000098B4
		private bool outVectorCode()
		{
			this.outPacket[0] = 0;
			this.outPacket[1] = 3;
			for (int i = 0; i < 31; i++)
			{
				if (this.vectorBytesSended < this.vectorBytes)
				{
					this.outPacket[i + 2] = this.BinBuffer[this.addSend];
					this.vectorBytesSended++;
					this.addSend++;
				}
				else
				{
					this.outPacket[i + 2] = 0;
				}
			}
			if (this.usb.SpecifiedDevice != null)
			{
				this.usb.SpecifiedDevice.SendData(this.outPacket);
			}
			else
			{
				MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
			}
			return this.vectorBytesSended == this.vectorBytes;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000B78C File Offset: 0x0000998C
		private byte[] ConvertToBin(string HexFile)
		{
			int i = 0;
			int num = 0;
			byte[] array = new byte[131072];
			this.max_add = 0;
			for (int j = 0; j < 131072; j++)
			{
				array[j] = byte.MaxValue;
			}
			byte[] result;
			if (HexFile[i] != ':')
			{
				MessageBox.Show("Err hex");
				this.FileLoaded = false;
				result = array;
			}
			else
			{
				while (i < HexFile.Length)
				{
					if (HexFile[i] == ':')
					{
						i++;
						string s = HexFile.Substring(i, 2);
						int num2 = int.Parse(s, NumberStyles.HexNumber);
						i += 2;
						s = HexFile.Substring(i, 4);
						int num3 = int.Parse(s, NumberStyles.HexNumber);
						i += 4;
						s = HexFile.Substring(i, 2);
						int num4 = int.Parse(s, NumberStyles.HexNumber);
						i += 2;
						if (num4 == 4)
						{
							s = HexFile.Substring(i, 4);
							num = int.Parse(s, NumberStyles.HexNumber);
							num <<= 16;
							i += 4;
						}
						else if (num4 == 0)
						{
							for (int j = 0; j < num2; j++)
							{
								s = HexFile.Substring(i, 2);
								i += 2;
								if (num + num3 < 134234112)
								{
									MessageBox.Show("Not STM32 Hex File");
									this.FileLoaded = false;
									return array;
								}
								array[num + num3 - 134234112] = (byte)int.Parse(s, NumberStyles.HexNumber);
								num3++;
							}
							s = HexFile.Substring(i, 2);
							i += 2;
							int num5 = num + num3 - 134234112;
							if (this.max_add <= num5)
							{
								this.max_add = num5;
							}
						}
					}
					i++;
				}
				this.max_add += 1024 - this.max_add % 1024;
				if (this.max_add > 114688)
				{
					MessageBox.Show("hex length Err!");
					this.FileLoaded = false;
					result = array;
				}
				else
				{
					this.FileLoaded = true;
					result = array;
				}
			}
			return result;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000B9E8 File Offset: 0x00009BE8
		private string ConvertToHex(byte data)
		{
			string arg = null;
			char c = this.hexchar[(int)(data / 16)];
			char c2 = this.hexchar[(int)(data % 16)];
			arg += c;
			return arg + c2;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000BA30 File Offset: 0x00009C30
		private void FormLoader_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "Hex Files|*.hex|Text Files|*.txt|All Files|*.*";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					StreamReader streamReader = new StreamReader(openFileDialog.FileName);
					this.BinBuffer = this.ConvertToBin(streamReader.ReadToEnd());
					this.btn_app.Enabled = false;
					this.btn_boot.Enabled = false;
					this.DownLoad.Enabled = true;
				}
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000BABD File Offset: 0x00009CBD
		private void btn_boot_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000BAC0 File Offset: 0x00009CC0
		private void Update_yUnit(int volt, int caps, int cur, int t, int j)
		{
			if (volt > this.vMax[j] - 20)
			{
				this.vMax[j] = volt + 20;
			}
			if (volt < this.vMin[j] + 20)
			{
				this.vMin[j] = volt - 20;
			}
			this.yUnit[j] = (float)(this.vMax[j] - this.vMin[j]) / (float)(this.Label_Heigh[j] - 30);
			if (caps > this.cMax[j] - 20)
			{
				this.cMax[j] = caps + 20;
			}
			if (caps < this.cMin[j] + 2)
			{
				this.cMin[j] = caps - 2;
			}
			this.Cap_yUnit[j] = (float)(this.cMax[j] - this.cMin[j]) / (float)(this.Label_Heigh[j] - 30);
			if (cur > this.curMax[j] - 50)
			{
				this.curMax[j] = cur + 100;
			}
			if (cur < this.curMin[j] + 50)
			{
				this.curMin[j] = cur - 100;
			}
			this.Cur_yUnit[j] = (float)(this.curMax[j] - this.curMin[j]) / (float)(this.Label_Heigh[j] - 30);
			if (t > this.temMax[j] - 30)
			{
				this.temMax[j] = t + 30;
			}
			if (t < this.temMin[j] + 30)
			{
				this.temMin[j] = t - 30;
			}
			this.Tem_yUnit[j] = (float)(this.temMax[j] - this.temMin[j]) / (float)(this.Label_Heigh[j] - 30);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000BC94 File Offset: 0x00009E94
		private void Update_xUnit(int j)
		{
			int num = this.Label_Width[j] - 100 - 32;
			if (this.Pool_Index[j] <= num)
			{
				this.index_scale[j] = 1f;
				this.Pool_Index[j]++;
				for (int i = 0; i < this.Data_Index[j]; i++)
				{
					this.Voltage_Pool[j][i] = this.Voltage_Data[j][i];
					this.Cur_Pool[j][i] = this.Cur_Data[j][i];
					this.Caps_Pool[j][i] = this.Caps_Data[j][i] / 10;
					this.Batt_Tem_Pool[j][i] = this.Batt_Tem_Data[j][i];
				}
				if ((this.Pool_Index[j] - 1) * this.xUnit[j] > this.Label_Width[j] - 100)
				{
					this.xUnit[j] /= 2;
					this.tMax[j] *= 2;
				}
			}
			else if (this.Pool_Index[j] >= num + 32)
			{
				this.Pool_Index[j] = num + 1;
				this.index_scale[j] = (float)this.Data_Index[j] / (float)this.Pool_Index[j];
				for (int i = 0; i < this.Pool_Index[j]; i++)
				{
					int num2 = (int)((float)i * this.index_scale[j]);
					if (i > 0 && i < this.Pool_Index[j] - 1)
					{
						int num3 = (int)((float)(i + 1) * this.index_scale[j]);
						for (int k = num2; k < num3; k++)
						{
							if (this.Cur_Data[j][k] < 50)
							{
								num2 = k;
							}
						}
					}
					this.Voltage_Pool[j][i] = this.Voltage_Data[j][num2];
					this.Cur_Pool[j][i] = this.Cur_Data[j][num2];
					this.Caps_Pool[j][i] = this.Caps_Data[j][num2] / 10;
					this.Batt_Tem_Pool[j][i] = this.Batt_Tem_Data[j][num2];
				}
				this.tMax[j] += 32;
			}
			else
			{
				int i = this.Pool_Index[j];
				int num2 = this.Data_Index[j] - 1;
				this.Voltage_Pool[j][i] = this.Voltage_Data[j][num2];
				this.Cur_Pool[j][i] = this.Cur_Data[j][num2];
				this.Caps_Pool[j][i] = this.Caps_Data[j][num2] / 10;
				this.Batt_Tem_Pool[j][i] = this.Batt_Tem_Data[j][num2];
				this.Pool_Index[j]++;
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000BF80 File Offset: 0x0000A180
		private void timer2_Tick(object sender, EventArgs e)
		{
			byte b = 0;
			if (this.dataReceived)
			{
				this.dataReceived = false;
				if (this.inPacket[1] == 240)
				{
					if (!this.bwrite_chrager_data)
					{
						MessageBox.Show("OK!");
					}
				}
				else if (this.inPacket[1] == 95)
				{
					int num = (int)this.inPacket[2];
					this.Get_Charge_Data(num);
				}
				else if (this.inPacket[1] == 90)
				{
					int num = (int)this.inPacket[3];
					this.Get_System_Data(num);
				}
				else if (this.inPacket[1] == 85)
				{
					for (int i = 1; i < 64; i++)
					{
						b += this.inPacket[i];
					}
					if (b == this.inPacket[64])
					{
						int num = (int)this.inPacket[2];
						int num2 = (int)this.inPacket[6];
						if (num2 > 0)
						{
							this.bstop[num] = false;
							if (num2 == 4)
							{
								this.bfinish[num] = true;
							}
							else
							{
								this.bfinish[num] = false;
							}
						}
						else
						{
							this.bstop[num] = true;
							this.bfinish[num] = false;
						}
						if (this.bstop[0] && this.bstop[1] && this.bstop[2] && this.bstop[3])
						{
							if (++this.stop_count > 16)
							{
								this.stop_count = 0;
								this.bcharge = false;
								this.StartMenuItem.Text = "Start(&S)";
								this.button_start.Text = "Start";
								this.button_system.Enabled = true;
								this.button_update.Enabled = true;
								this.groupBox_solt1.Enabled = true;
								this.groupBox_solt2.Enabled = true;
								this.groupBox_solt3.Enabled = true;
								this.groupBox_solt4.Enabled = true;
								this.button_load_all.Enabled = true;
								this.button_save_all.Enabled = true;
							}
						}
						int num3 = (int)this.inPacket[3];
						int num4 = (int)this.inPacket[4];
						int num5 = (int)this.inPacket[5];
						int num6 = 0;
						if (num2 >= 128)
						{
							num6 = num2 - 128 + 1;
						}
						this.work_time[num] = (int)this.inPacket[7] * 256 + (int)this.inPacket[8];
						this.Voltage[num] = (int)this.inPacket[9] * 256 + (int)this.inPacket[10];
						if (this.work_time[num] > 0)
						{
							this.work_time[num]--;
						}
						this.Current[num] = (int)this.inPacket[11] * 256 + (int)this.inPacket[12];
						this.Caps[num] = (int)this.inPacket[13] * 256 + (int)this.inPacket[14];
						this.Caps_Decimal[num] = (int)this.inPacket[25];
						if (num2 == 2)
						{
							this.dCaps[num] = this.Caps[num];
						}
						this.Batt_Tem[num] = (int)this.inPacket[15] * 256 + (int)this.inPacket[16];
						this.Batt_Tem[num] &= 32767;
						int num7 = (int)this.inPacket[17] * 256 + (int)this.inPacket[18];
						if (num3 < 7)
						{
							this.BatInfo[num] = FormLoader.bat_type[num3];
						}
						if (num4 < 5)
						{
							if (num6 > 0)
							{
								string[] batInfo;
								IntPtr intPtr;
								(batInfo = this.BatInfo)[(int)(intPtr = (IntPtr)num)] = batInfo[(int)intPtr] + " Error:" + FormLoader.error_str[num6 - 1];
							}
							else
							{
								if (num3 < 3)
								{
									string[] batInfo;
									IntPtr intPtr;
									(batInfo = this.BatInfo)[(int)(intPtr = (IntPtr)num)] = batInfo[(int)intPtr] + "  " + this.li_mode[num4];
								}
								else
								{
									string[] batInfo;
									IntPtr intPtr;
									(batInfo = this.BatInfo)[(int)(intPtr = (IntPtr)num)] = batInfo[(int)intPtr] + "  " + this.ni_mode[num4];
								}
								if (num4 == 1 || num4 == 2 || num4 == 4)
								{
									if (num2 == 1)
									{
										string[] batInfo;
										IntPtr intPtr;
										(batInfo = this.BatInfo)[(int)(intPtr = (IntPtr)num)] = batInfo[(int)intPtr] + ">Charge";
									}
									else if (num2 == 2)
									{
										string[] batInfo;
										IntPtr intPtr;
										(batInfo = this.BatInfo)[(int)(intPtr = (IntPtr)num)] = batInfo[(int)intPtr] + ">DisCharge";
									}
									else if (num2 == 3)
									{
										string[] batInfo;
										IntPtr intPtr;
										(batInfo = this.BatInfo)[(int)(intPtr = (IntPtr)num)] = batInfo[(int)intPtr] + ">Resting";
									}
									else if (num2 == 4)
									{
										string[] batInfo;
										IntPtr intPtr;
										(batInfo = this.BatInfo)[(int)(intPtr = (IntPtr)num)] = (batInfo[(int)intPtr] ?? "");
									}
								}
								if (num2 == 4)
								{
									string[] batInfo;
									IntPtr intPtr;
									(batInfo = this.BatInfo)[(int)(intPtr = (IntPtr)num)] = batInfo[(int)intPtr] + " FINISH";
								}
							}
						}
						if (num2 < 4 && num2 > 0)
						{
							if (++this.tick2[num] >= this.Update_Unit[num])
							{
								this.tick2[num] = 0;
								this.Voltage_Data[num][this.Data_Index[num]] = this.Voltage[num];
								this.Cur_Data[num][this.Data_Index[num]] = this.Current[num];
								this.Caps_Data[num][this.Data_Index[num]] = this.Caps[num] * 10 + this.Caps_Decimal[num];
								this.Batt_Tem_Data[num][this.Data_Index[num]] = this.Batt_Tem[num];
								if ((long)this.Data_Index[num] < 864000L)
								{
									this.Data_Index[num]++;
								}
								this.Update_xUnit(num);
								this.Update_yUnit(this.Voltage_Pool[num][this.Pool_Index[num] - 1], this.Caps_Pool[num][this.Pool_Index[num] - 1], this.Cur_Pool[num][this.Pool_Index[num] - 1], this.Batt_Tem_Pool[num][this.Pool_Index[num] - 1], num);
								this.DownLoad.Text = this.in_count.ToString();
							}
						}
						if (num == 0)
						{
							this.label_SOLT1.Refresh();
							this.label1.Refresh();
						}
						else if (num == 1)
						{
							this.label_SOLT2.Refresh();
							this.label2.Refresh();
						}
						else if (num == 2)
						{
							this.label_SOLT3.Refresh();
							this.label3.Refresh();
						}
						else
						{
							this.label_SOLT4.Refresh();
							this.label4.Refresh();
						}
					}
				}
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000C70B File Offset: 0x0000A90B
		private void FormLoader_Shown(object sender, EventArgs e)
		{
			this.loadApp();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000C718 File Offset: 0x0000A918
		private void Draw_Curves_On_Label(Graphics gp, int solt)
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			int num5 = (this.label_SOLT1.Height - 30) / 5;
			int num6 = (this.label_SOLT1.Width - 100) / 10;
			string str = "";
			this.pen.Color = Color.Black;
			this.pen.DashStyle = DashStyle.Solid;
			gp.FillRectangle(Brushes.WhiteSmoke, 0, 0, this.label_SOLT1.Width - 1, this.label_SOLT1.Height - 1);
			this.pen.Width = 1f;
			gp.DrawRectangle(this.pen, 0, 0, this.label_SOLT1.Width - 1, this.label_SOLT1.Height - 1);
			this.pen.Width = 2f;
			gp.FillRectangle(Brushes.Gainsboro, 40, 10, this.label_SOLT1.Width - 100, this.label_SOLT1.Height - 30);
			gp.DrawRectangle(this.pen, 40, 10, this.label_SOLT1.Width - 100, this.label_SOLT1.Height - 30);
			int i = 40;
			int j = this.label_SOLT1.Height - 20;
			int num7 = 0;
			while (j >= 10)
			{
				this.pen.Width = 1f;
				this.pen.Color = Color.Gray;
				if (num7 > 0 && num7 < 5)
				{
					this.pen.DashStyle = DashStyle.Dot;
				}
				gp.DrawLine(this.pen, i, j, this.label_SOLT1.Width - 60, j);
				this.pen.Color = Color.Black;
				this.pen.DashStyle = DashStyle.Solid;
				gp.DrawLine(this.pen, i, j, i - 4, j);
				gp.DrawLine(this.pen, this.label_SOLT1.Width - 60, j, this.label_SOLT1.Width - 60 + 3, j);
				if (this.Pool_Index[solt] < 2)
				{
					gp.DrawString((5f * (float)num7 / 5f).ToString("f3"), this.font, Brushes.Blue, 5f, (float)(j - 8));
					if (num7 > 0)
					{
						gp.DrawString((5000 * num7 / 5).ToString() + "mAh", this.font, Brushes.DarkOrange, (float)(this.label_SOLT1.Width - 60), (float)j);
					}
					gp.DrawString((5000f * (float)num7 / 5000f).ToString("f1") + "A", this.font, Brushes.Green, (float)(this.label_SOLT1.Width - 60), (float)(j - 10));
					if (this.BatParam[0].Tem_Unit == 0)
					{
						gp.DrawString((800 * num7 / 50).ToString() + "C", this.font, Brushes.Red, (float)(this.label_SOLT1.Width - 60 + 5 + 30), (float)(j - 10));
					}
					else
					{
						gp.DrawString((800 * num7 / 50).ToString() + "F", this.font, Brushes.Red, (float)(this.label_SOLT1.Width - 60 + 5 + 30), (float)(j - 10));
					}
				}
				else
				{
					if (this.Curve_Volt[solt])
					{
						float num8 = (float)this.vMin[solt] + (float)num7 * (float)(this.vMax[solt] - this.vMin[solt]) / 5f;
						gp.DrawString((num8 / 1000f).ToString("f3"), this.font, Brushes.Blue, 5f, (float)(j - 8));
					}
					if (this.Curve_Caps[solt])
					{
						float num8 = (float)this.cMin[solt] + (float)num7 * (float)(this.cMax[solt] - this.cMin[solt]) / 5f;
						if (num7 > 0)
						{
							gp.DrawString(num8.ToString("f0") + "mAh", this.font, Brushes.DarkOrange, (float)(this.label_SOLT1.Width - 60), (float)j);
						}
					}
					if (this.Curve_Cur[solt])
					{
						float num8 = (float)this.curMin[solt] + (float)num7 * (float)(this.curMax[solt] - this.curMin[solt]) / 5f;
						gp.DrawString((num8 / 1000f).ToString("f2") + "A", this.font, Brushes.Green, (float)(this.label_SOLT1.Width - 60), (float)(j - 10));
					}
					if (this.Curve_Tem[solt])
					{
						float num8 = (float)this.temMin[solt] + (float)num7 * (float)(this.temMax[solt] - this.temMin[solt]) / 5f;
						if (this.BatParam[0].Tem_Unit == 0)
						{
							gp.DrawString((num8 / 10f).ToString("f0") + "C", this.font, Brushes.Red, (float)(this.label_SOLT1.Width - 60 + 5 + 30), (float)(j - 10));
						}
						else
						{
							gp.DrawString((num8 / 10f).ToString("f0") + "F", this.font, Brushes.Red, (float)(this.label_SOLT1.Width - 60 + 5 + 30), (float)(j - 10));
						}
					}
				}
				j -= num5;
				num7++;
			}
			j = this.label_SOLT1.Height - 20;
			i = 40;
			num7 = 0;
			while (i <= this.label_SOLT1.Width - 60)
			{
				this.pen.Width = 1f;
				this.pen.Color = Color.Gray;
				this.pen.DashStyle = DashStyle.Dot;
				gp.DrawLine(this.pen, i, j, i, 10);
				this.pen.Color = Color.Black;
				this.pen.DashStyle = DashStyle.Solid;
				gp.DrawLine(this.pen, i, j, i, j + 4);
				int num9 = num7 * this.tMax[solt] / 10;
				string text = string.Concat(new string[]
				{
					(num9 / 3600).ToString(),
					":",
					(num9 % 3600 / 60).ToString("d2"),
					":",
					(num9 % 60).ToString("d2")
				});
				gp.DrawString(text, this.font, Brushes.Black, (float)(i - 20), (float)(j + 3));
				i += num6;
				num7++;
			}
			if (this.Pool_Index[solt] >= 2)
			{
				this.pen.Width = 1f;
				this.pen.DashStyle = DashStyle.Solid;
				if (this.Curve_Volt[solt])
				{
					this.pen.Color = Color.Blue;
					i = 0;
					num7 = 40;
					while (i < this.Pool_Index[solt] - 1)
					{
						int num10 = num7;
						gp.DrawLine(this.pen, (float)num10, (float)(this.vMax[solt] - this.Voltage_Pool[solt][i]) / this.yUnit[solt] + 10f, (float)(num7 + this.xUnit[solt]), (float)(this.vMax[solt] - this.Voltage_Pool[solt][i + 1]) / this.yUnit[solt] + 10f);
						i++;
						num7 += this.xUnit[solt];
					}
				}
				if (this.Curve_Cur[solt])
				{
					this.pen.Color = Color.Green;
					i = 0;
					num7 = 40;
					while (i < this.Pool_Index[solt] - 1)
					{
						int num10 = num7;
						gp.DrawLine(this.pen, (float)num10, (float)(this.curMax[solt] - this.Cur_Pool[solt][i]) / this.Cur_yUnit[solt] + 10f, (float)(num7 + this.xUnit[solt]), (float)(this.curMax[solt] - this.Cur_Pool[solt][i + 1]) / this.Cur_yUnit[solt] + 10f);
						i++;
						num7 += this.xUnit[solt];
					}
				}
				if (this.Curve_Caps[solt])
				{
					this.pen.Color = Color.DarkOrange;
					i = 0;
					num7 = 40;
					while (i < this.Pool_Index[solt] - 1)
					{
						int num10 = num7;
						gp.DrawLine(this.pen, (float)num10, (float)(this.cMax[solt] - this.Caps_Pool[solt][i]) / this.Cap_yUnit[solt] + 10f, (float)(num7 + this.xUnit[solt]), (float)(this.cMax[solt] - this.Caps_Pool[solt][i + 1]) / this.Cap_yUnit[solt] + 10f);
						i++;
						num7 += this.xUnit[solt];
					}
				}
				if (this.Curve_Tem[solt])
				{
					this.pen.Color = Color.Red;
					i = 0;
					num7 = 40;
					while (i < this.Pool_Index[solt] - 1)
					{
						int num10 = num7;
						gp.DrawLine(this.pen, (float)num10, (float)(this.temMax[solt] - this.Batt_Tem_Pool[solt][i]) / this.Tem_yUnit[solt] + 10f, (float)(num7 + this.xUnit[solt]), (float)(this.temMax[solt] - this.Batt_Tem_Pool[solt][i + 1]) / this.Tem_yUnit[solt] + 10f);
						i++;
						num7 += this.xUnit[solt];
					}
				}
				this.pen.Color = Color.Black;
				this.pen.Width = 1f;
				if (this.bMeasure[solt])
				{
					i = (this.mouse_x - 40) / this.xUnit[solt];
					gp.DrawLine(this.pen, 40, this.mouse_y, this.label_SOLT1.Width - 60, this.mouse_y);
					gp.DrawLine(this.pen, this.mouse_x, 10, this.mouse_x, this.label_SOLT1.Height - 20);
					int num9;
					if (this.Pool_Index[solt] < this.label_SOLT1.Width - 100 - 32)
					{
						num9 = (int)((float)this.tMax[solt] * (float)(this.mouse_x - 40) / (float)(this.label_SOLT1.Width - 100));
					}
					else if (this.mouse_x - 40 < this.label_SOLT1.Width - 100 - 32)
					{
						num9 = (int)((float)this.tMax[solt] * (float)(this.mouse_x - 40) / (float)(this.label_SOLT1.Width - 100));
					}
					else
					{
						num9 = this.tMax[solt] + this.mouse_x - this.label_SOLT1.Width + 60;
					}
					string text = string.Concat(new string[]
					{
						(num9 / 3600).ToString(),
						":",
						(num9 % 3600 / 60).ToString("d2"),
						":",
						(num9 % 60).ToString("d2")
					});
					j = (int)((float)(this.vMax[solt] - this.Voltage_Pool[solt][i]) / this.yUnit[solt] + 10f);
					if (this.mouse_y >= j - 1 && this.mouse_y <= j + 1)
					{
						num = this.Voltage_Pool[solt][i];
					}
					j = (int)((float)(this.curMax[solt] - this.Cur_Pool[solt][i]) / this.Cur_yUnit[solt] + 10f);
					if (this.mouse_y >= j - 1 && this.mouse_y <= j + 1)
					{
						num2 = this.Cur_Pool[solt][i];
					}
					j = (int)((float)(this.cMax[solt] - this.Caps_Pool[solt][i]) / this.Cap_yUnit[solt] + 10f);
					if (this.mouse_y >= j - 1 && this.mouse_y <= j + 1)
					{
						num3 = this.Caps_Pool[solt][i];
					}
					j = (int)((float)(this.temMax[solt] - this.Batt_Tem_Pool[solt][i]) / this.Tem_yUnit[solt] + 10f);
					if (this.mouse_y >= j - 1 && this.mouse_y <= j + 1)
					{
						num4 = this.Batt_Tem_Pool[solt][i];
					}
					if (num >= 0)
					{
						str = "(" + ((float)num / 1000f).ToString("f3") + "V)";
					}
					else if (num2 >= 0)
					{
						str = "(" + ((float)num2 / 1000f).ToString("f2") + "A)";
					}
					else if (num3 >= 0)
					{
						str = "(" + num3.ToString() + "mAh)";
					}
					else if (num4 >= 0)
					{
						if (this.BatParam[0].Tem_Unit > 0)
						{
							str = "(" + ((float)num4 / 10f).ToString("f1") + "℉)";
						}
						else
						{
							str = "(" + ((float)num4 / 10f).ToString("f1") + "℃)";
						}
					}
					if (num >= 0 || num2 >= 0 || num3 >= 0 || num4 >= 0)
					{
						text += str;
					}
					gp.DrawString(text, this.font, Brushes.SeaGreen, (float)this.mouse_x, (float)(this.mouse_y - 12));
				}
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000D66C File Offset: 0x0000B86C
		private void Draw_Info_On_Label(Graphics gp, int solt)
		{
			string text = "Mode: " + this.BatInfo[solt];
			string s = this.BatInfo[solt];
			string s2 = "Current：" + ((float)this.Current[solt] / 1000f).ToString("f2") + "A";
			string s3 = "Voltage：" + ((float)this.Voltage[solt] / 1000f).ToString("f3") + "V";
			string s4;
			if (text.Contains("REFRESH") && text.Contains("FINISH"))
			{
				s4 = string.Concat(new object[]
				{
					"Capacity：",
					this.dCaps[solt].ToString(),
					".",
					this.Caps_Decimal[solt],
					"mAh(Discharge)"
				});
			}
			else
			{
				s4 = string.Concat(new object[]
				{
					"Capacity：",
					this.Caps[solt].ToString(),
					".",
					this.Caps_Decimal[solt],
					"mAh"
				});
			}
			string s5;
			if (this.BatParam[0].Tem_Unit > 0)
			{
				s5 = "Temperature:" + ((float)this.Batt_Tem[solt] / 10f).ToString("f1") + "℉";
			}
			else
			{
				s5 = "Temperature:" + ((float)this.Batt_Tem[solt] / 10f).ToString("f1") + "℃";
			}
			string s6 = string.Concat(new string[]
			{
				"Time: ",
				(this.work_time[solt] / 3600).ToString("d2"),
				":",
				(this.work_time[solt] % 3600 / 60).ToString("d2"),
				":",
				(this.work_time[solt] % 60).ToString("d2")
			});
			this.pen.Color = Color.Black;
			this.pen.Width = 1f;
			gp.DrawRectangle(this.pen, 0, 0, this.label1.Width - 1, this.label1.Height - 1);
			gp.DrawString("Slot" + (solt + 1).ToString(), this.font2, Brushes.Black, 100f, 2f);
			if (text.Contains("FINISH"))
			{
				gp.DrawString(text, this.font, Brushes.Blue, 5f, 12f);
			}
			else if (text.Contains("Error"))
			{
				gp.DrawString(s, this.font, Brushes.Red, 5f, 120f);
			}
			else
			{
				gp.DrawString(text, this.font, Brushes.Black, 5f, 15f);
			}
			gp.DrawString(s3, this.font, Brushes.DarkBlue, 5f, 30f);
			gp.DrawString(s2, this.font, Brushes.DarkGreen, 5f, 48f);
			gp.DrawString(s4, this.font, Brushes.DarkOrange, 5f, 68f);
			gp.DrawString(s5, this.font, Brushes.Red, 5f, 88f);
			gp.DrawString(s6, this.font, Brushes.Black, 5f, 106f);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000DA77 File Offset: 0x0000BC77
		private void label_SOLT1_Paint(object sender, PaintEventArgs e)
		{
			this.Draw_Curves_On_Label(e.Graphics, 0);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000DA88 File Offset: 0x0000BC88
		private void label_SOLT2_Paint(object sender, PaintEventArgs e)
		{
			this.Draw_Curves_On_Label(e.Graphics, 1);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000DA99 File Offset: 0x0000BC99
		private void label_SOLT3_Paint(object sender, PaintEventArgs e)
		{
			this.Draw_Curves_On_Label(e.Graphics, 2);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000DAAA File Offset: 0x0000BCAA
		private void label_SOLT4_Paint(object sender, PaintEventArgs e)
		{
			this.Draw_Curves_On_Label(e.Graphics, 3);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000DABB File Offset: 0x0000BCBB
		private void ExitMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000DAC4 File Offset: 0x0000BCC4
		private void SaveMenuItem_Click(object sender, EventArgs e)
		{
			if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					string path = Path.GetFileNameWithoutExtension(this.saveFileDialog1.FileName) + ".CSV";
					StreamWriter streamWriter = new StreamWriter(path);
					Image image = new Bitmap(base.Width, base.Height);
					Image image2 = new Bitmap(this.label_SOLT1.Width, this.label_SOLT1.Height);
					Image image3 = new Bitmap(this.label_SOLT2.Width, this.label_SOLT2.Height);
					Image image4 = new Bitmap(this.label_SOLT3.Width, this.label_SOLT3.Height);
					Image image5 = new Bitmap(this.label_SOLT4.Width, this.label_SOLT4.Height);
					Image image6 = new Bitmap(this.label1.Width, this.label1.Height);
					Image image7 = new Bitmap(this.label2.Width, this.label2.Height);
					Image image8 = new Bitmap(this.label3.Width, this.label3.Height);
					Image image9 = new Bitmap(this.label4.Width, this.label4.Height);
					Graphics graphics = Graphics.FromImage(image);
					Graphics gp = Graphics.FromImage(image2);
					Graphics gp2 = Graphics.FromImage(image3);
					Graphics gp3 = Graphics.FromImage(image4);
					Graphics gp4 = Graphics.FromImage(image5);
					Graphics gp5 = Graphics.FromImage(image6);
					Graphics gp6 = Graphics.FromImage(image7);
					Graphics gp7 = Graphics.FromImage(image8);
					Graphics gp8 = Graphics.FromImage(image9);
					this.Draw_Curves_On_Label(gp, 0);
					this.Draw_Curves_On_Label(gp2, 1);
					this.Draw_Curves_On_Label(gp3, 2);
					this.Draw_Curves_On_Label(gp4, 3);
					this.Draw_Info_On_Label(gp5, 0);
					this.Draw_Info_On_Label(gp6, 1);
					this.Draw_Info_On_Label(gp7, 2);
					this.Draw_Info_On_Label(gp8, 3);
					graphics.DrawImage(image2, this.label_SOLT1.Left, this.label_SOLT1.Top);
					graphics.DrawImage(image6, this.label1.Left, this.label1.Top);
					graphics.DrawImage(image3, this.label_SOLT2.Left, this.label_SOLT2.Top);
					graphics.DrawImage(image7, this.label2.Left, this.label2.Top);
					graphics.DrawImage(image4, this.label_SOLT3.Left, this.label_SOLT3.Top);
					graphics.DrawImage(image8, this.label3.Left, this.label3.Top);
					graphics.DrawImage(image5, this.label_SOLT4.Left, this.label_SOLT4.Top);
					graphics.DrawImage(image9, this.label4.Left, this.label4.Top);
					image.Save(this.saveFileDialog1.FileName);
					string text = "#1;Time;Voltage(V);Curent(A);Capacity(mAh);Batt.Temp(C);#2;Time;Voltage(V);Curent(A);Capacity(mAh);Batt.Temp(C);#3;Time;Voltage(V);Curent(A);Capacity(mAh);Batt.Temp(C);#4;Time;Voltage(V);Curent(A);Capacity(mAh);Batt.Temp(C)";
					streamWriter.WriteLine(text);
					text = "";
					int num = 0;
					int i;
					for (i = 0; i < 4; i++)
					{
						if (num < this.Data_Index[i])
						{
							num = this.Data_Index[i];
						}
					}
					i = 0;
					while (i + 2 < num)
					{
						for (int j = 0; j < 4; j++)
						{
							if (!this.bstop[j] && i < this.Data_Index[j])
							{
								string str = (i / 86400).ToString() + "d";
								string text2 = (i % 86400 / 3600).ToString("d2") + ":";
								string text3 = (i % 3600 / 60).ToString("d2") + ":";
								string text4 = (i % 60).ToString("d2");
								string text5;
								if (i >= 86400)
								{
									text5 = str + text2 + text3 + text4;
								}
								else
								{
									text5 = text2 + text3 + text4;
								}
								string text6 = text;
								text = string.Concat(new string[]
								{
									text6,
									" ;",
									text5,
									";",
									((float)this.Voltage_Data[j][i] / 1000f).ToString("f3"),
									";",
									((float)this.Cur_Data[j][i] / 1000f).ToString("f3"),
									";",
									((float)this.Caps_Data[j][i] / 10f).ToString("f1"),
									";",
									((float)this.Batt_Tem_Data[j][i] / 10f).ToString("f1")
								});
							}
							else
							{
								text += ";;;;;";
							}
							if (j < 3)
							{
								text += ";";
							}
							else if (i % 10 != 0 || i == 0)
							{
								text += "\r\n";
							}
						}
						if (i > 0 && i % 10 == 0)
						{
							streamWriter.WriteLine(text);
							text = "";
						}
						i++;
					}
					streamWriter.WriteLine(text);
					streamWriter.Close();
					MessageBox.Show("Save Charge Data Ok!");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000E0D0 File Offset: 0x0000C2D0
		private void LoadMenuItem_Click(object sender, EventArgs e)
		{
			int num = 0;
			int i = 0;
			try
			{
				if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					StreamReader streamReader = new StreamReader(this.openFileDialog1.FileName);
					for (i = 0; i < 4; i++)
					{
						string text = streamReader.ReadLine();
						if (text == null)
						{
							break;
						}
						if (!text.Contains("<SOLT"))
						{
							break;
						}
						text = streamReader.ReadLine();
						this.BatInfo[i] = text;
						text = streamReader.ReadLine();
						string[] array = text.Split(new char[]
						{
							','
						});
						num++;
						if (array.Length == 15)
						{
							this.work_time[i] = Convert.ToInt32(array[0]);
							this.Voltage[i] = Convert.ToInt32(array[1]);
							this.Current[i] = Convert.ToInt32(array[2]);
							this.Caps[i] = Convert.ToInt32(array[3]);
							this.Batt_Tem[i] = Convert.ToInt32(array[4]);
							this.vMax[i] = Convert.ToInt32(array[5]);
							this.vMin[i] = Convert.ToInt32(array[6]);
							this.cMax[i] = Convert.ToInt32(array[7]);
							this.cMin[i] = Convert.ToInt32(array[8]);
							this.curMax[i] = Convert.ToInt32(array[9]);
							this.curMin[i] = Convert.ToInt32(array[10]);
							this.temMax[i] = Convert.ToInt32(array[11]);
							this.temMin[i] = Convert.ToInt32(array[12]);
							this.xUnit[i] = Convert.ToInt32(array[13]);
							this.tMax[i] = Convert.ToInt32(array[14]);
						}
						this.Pool_Index[i] = 0;
						this.Data_Index[i] = 0;
						int num2 = this.Voltage_Pool[i].Length + 2;
						while (--num2 > 0)
						{
							text = streamReader.ReadLine();
							num++;
							if (text.Contains("</SOLT"))
							{
								break;
							}
							array = text.Split(new char[]
							{
								','
							});
							if (array.Length != 4)
							{
								num2 = 0;
								break;
							}
							for (int j = 0; j < 4; j++)
							{
								this.Voltage_Pool[i][this.Pool_Index[i]] = Convert.ToInt32(array[0]);
								this.Cur_Pool[i][this.Pool_Index[i]] = Convert.ToInt32(array[1]);
								this.Caps_Pool[i][this.Pool_Index[i]] = Convert.ToInt32(array[2]);
								this.Batt_Tem_Pool[i][this.Pool_Index[i]] = Convert.ToInt32(array[3]);
							}
							this.Pool_Index[i]++;
						}
						if (num2 == 0)
						{
							streamReader.Close();
							this.timer2.Stop();
							MessageBox.Show("error:" + num);
							this.Pool_Index[i] = 0;
							this.Data_Index[i] = 0;
							return;
						}
						this.Update_yUnit(this.Voltage_Pool[i][this.Pool_Index[i] - 1], this.Caps_Pool[i][this.Pool_Index[i] - 1], this.Cur_Pool[i][this.Pool_Index[i] - 1], this.Batt_Tem_Pool[i][this.Pool_Index[i] - 1], i);
					}
					this.timer2.Stop();
					this.label_SOLT1.Refresh();
					this.label_SOLT2.Refresh();
					this.label_SOLT3.Refresh();
					this.label_SOLT4.Refresh();
					this.label1.Refresh();
					this.label2.Refresh();
					this.label3.Refresh();
					this.label4.Refresh();
					streamReader.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " line:" + num);
				this.timer2.Stop();
				this.Pool_Index[i] = 0;
				this.Data_Index[i] = 0;
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000E550 File Offset: 0x0000C750
		private bool Send_USB_CMD(int Solt, byte CMD)
		{
			int num = 0;
			bool result;
			if (!this.DeviceFounded)
			{
				result = false;
			}
			else
			{
				this.outPacket[num++] = 0;
				this.outPacket[num++] = 15;
				this.outPacket[num++] = 0;
				this.outPacket[num++] = CMD;
				this.outPacket[num++] = 0;
				this.outPacket[num++] = (byte)Solt;
				if (CMD != 17)
				{
					if (CMD != 85)
					{
					}
				}
				else
				{
					this.outPacket[num++] = (byte)this.BatParam[Solt].Type;
					this.outPacket[num++] = (byte)(this.BatParam[Solt].Caps / 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].Caps % 256);
					this.outPacket[num++] = (byte)this.BatParam[Solt].Mode;
					this.outPacket[num++] = (byte)(this.BatParam[Solt].Cur / 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].Cur % 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].dCur / 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].dCur % 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].Cut_Volt / 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].Cut_Volt % 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].End_Volt / 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].End_Volt % 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].End_Cur / 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].End_Cur % 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].End_dCur / 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].End_dCur % 256);
					this.outPacket[num++] = (byte)this.BatParam[Solt].Cycle_Count;
					this.outPacket[num++] = (byte)this.BatParam[Solt].Cycle_Delay;
					this.outPacket[num++] = (byte)this.BatParam[Solt].Cycle_Delay;
					this.outPacket[num++] = (byte)this.BatParam[Solt].Cycle_Mode;
					this.outPacket[num++] = (byte)this.BatParam[Solt].Peak_Sense;
					this.outPacket[num++] = (byte)(this.BatParam[Solt].Trickle / 10);
					this.outPacket[num++] = 0;
					this.outPacket[num++] = (byte)(this.BatParam[Solt].CutTemp / 10);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].CutTime / 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].CutTime % 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].Hold_Volt / 256);
					this.outPacket[num++] = (byte)(this.BatParam[Solt].Hold_Volt % 256);
				}
				int num2 = num;
				byte b = 0;
				for (int i = 3; i < num2; i++)
				{
					b += this.outPacket[i];
				}
				this.outPacket[2] = (byte)(num - 2);
				this.outPacket[num++] = b;
				this.outPacket[num++] = byte.MaxValue;
				this.outPacket[num] = byte.MaxValue;
				this.dataReceived = false;
				this.usb.SpecifiedDevice.SendData(this.outPacket);
				result = true;
			}
			return result;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000E9A0 File Offset: 0x0000CBA0
		private void ParamMenuItem_Click(object sender, EventArgs e)
		{
			this.label_SOLT1.Visible = false;
			this.label_SOLT2.Visible = false;
			this.label_SOLT3.Visible = false;
			this.label_SOLT4.Visible = false;
			this.label1.Visible = false;
			this.label2.Visible = false;
			this.label3.Visible = false;
			this.label4.Visible = false;
			this.button_save.Visible = false;
			this.button_start.Visible = false;
			this.groupBox_solt1.Visible = true;
			this.groupBox_solt2.Visible = true;
			this.groupBox_solt3.Visible = true;
			this.groupBox_solt4.Visible = true;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000EA68 File Offset: 0x0000CC68
		private void StartMenuItem_Click(object sender, EventArgs e)
		{
			if (!this.DeviceFounded)
			{
				MessageBox.Show("Not Found a Device！");
				this.usbSendConnectData();
			}
			else
			{
				this.bcharge = !this.bcharge;
				if (this.bcharge)
				{
					this.outPacket[0] = 0;
					this.outPacket[1] = 15;
					this.outPacket[2] = 3;
					this.outPacket[3] = 5;
					this.outPacket[4] = 0;
					this.outPacket[5] = 5;
					this.outPacket[6] = byte.MaxValue;
					this.outPacket[7] = byte.MaxValue;
					this.StartMenuItem.Text = "Stop(&S)";
					this.button_start.Text = "Stop";
					for (int i = 0; i < 4; i++)
					{
						this.Pool_Index[i] = 0;
						this.Data_Index[i] = 0;
						this.index_scale[i] = 1f;
						this.vMax[i] = 0;
						this.vMin[i] = 50000;
						this.cMax[i] = 0;
						this.cMin[i] = 50000;
						this.curMax[i] = 0;
						this.curMin[i] = 50000;
						this.temMax[i] = 0;
						this.temMin[i] = 50000;
						this.xUnit[i] = (this.label_SOLT1.Width - 100) / 20;
						this.tMax[i] = 20;
						this.Update_Unit[i] = 1;
						this.bfinish[i] = false;
					}
					this.timer3.Start();
					this.timer2.Start();
					this.button_system.Enabled = false;
					this.button_update.Enabled = false;
					this.groupBox_solt1.Enabled = false;
					this.groupBox_solt2.Enabled = false;
					this.groupBox_solt3.Enabled = false;
					this.groupBox_solt4.Enabled = false;
					this.button_load_all.Enabled = false;
					this.button_save_all.Enabled = false;
				}
				else
				{
					this.outPacket[0] = 0;
					this.outPacket[1] = 15;
					this.outPacket[2] = 3;
					this.outPacket[3] = 254;
					this.outPacket[4] = 0;
					this.outPacket[5] = 254;
					this.outPacket[6] = byte.MaxValue;
					this.outPacket[7] = byte.MaxValue;
					this.StartMenuItem.Text = "Start(&S)";
					this.button_start.Text = "Start";
					this.timer3.Stop();
					this.button_system.Enabled = true;
					this.button_update.Enabled = false;
					this.groupBox_solt1.Enabled = true;
					this.groupBox_solt2.Enabled = true;
					this.groupBox_solt3.Enabled = true;
					this.groupBox_solt4.Enabled = true;
					this.button_load_all.Enabled = true;
					this.button_save_all.Enabled = true;
				}
				this.usb.SpecifiedDevice.SendData(this.outPacket);
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000ED80 File Offset: 0x0000CF80
		private void label_SOLT1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.bmousedown)
			{
				this.new_p = base.Location;
				if (e.X >= this.old_p.X + 2 || e.X < this.old_p.X - 2)
				{
					this.new_p.X = this.new_p.X + (e.X - this.old_p.X);
				}
				if (e.Y >= this.old_p.Y + 2 || e.Y < this.old_p.Y - 2)
				{
					this.new_p.Y = this.new_p.Y + (e.Y - this.old_p.Y);
				}
				base.Location = new Point(this.new_p.X, this.new_p.Y);
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000EE84 File Offset: 0x0000D084
		private void label_SOLT1_MouseDown(object sender, MouseEventArgs e)
		{
			this.bmousedown = true;
			this.old_p.X = e.X;
			this.old_p.Y = e.Y;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000EEB2 File Offset: 0x0000D0B2
		private void label_SOLT1_MouseUp(object sender, MouseEventArgs e)
		{
			this.bmousedown = false;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000EEBC File Offset: 0x0000D0BC
		private void label1_Paint(object sender, PaintEventArgs e)
		{
			this.Draw_Info_On_Label(e.Graphics, 0);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000EECD File Offset: 0x0000D0CD
		private void label2_Paint(object sender, PaintEventArgs e)
		{
			this.Draw_Info_On_Label(e.Graphics, 1);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000EEDE File Offset: 0x0000D0DE
		private void label3_Paint(object sender, PaintEventArgs e)
		{
			this.Draw_Info_On_Label(e.Graphics, 2);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000EEEF File Offset: 0x0000D0EF
		private void label4_Paint(object sender, PaintEventArgs e)
		{
			this.Draw_Info_On_Label(e.Graphics, 3);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000EF00 File Offset: 0x0000D100
		private void btn_min_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000EF0C File Offset: 0x0000D10C
		private void btn_system_Click(object sender, EventArgs e)
		{
			WebClient webClient = new WebClient();
			if (this.machine_info == null)
			{
				MessageBox.Show("Invalid machine ID!");
			}
			else if ((double)this.machine_info.software_version >= 1.0)
			{
				Uri address = new Uri("http://upgrade.skyrc.com/?SN=" + this.machine_info.machine_id);
				string text = null;
				int num = 0;
				this.text_fm_info.Text = "";
				this.label_firmware.Text = "Firmware list:download......";
				this.list_firmware.Items.Clear();
				this.label_firmware.Refresh();
				this.list_firmware.Refresh();
				this.text_fm_info.Refresh();
				try
				{
					webClient.Encoding = Encoding.UTF8;
					text = webClient.DownloadString(address);
				}
				catch (WebException)
				{
					webClient.Dispose();
					this.label_firmware.Text = "Firmware list:can't get firmware from internet";
					return;
				}
				try
				{
					if (text != null)
					{
						string[] array = text.Split(new char[]
						{
							','
						});
						if (array.Length % 8 == 0)
						{
							num = array.Length / 8;
							this.fs = new Firmware_Struct[num];
							for (int i = 0; i < num; i++)
							{
								this.fs[i] = new Firmware_Struct();
								string[] array2 = array[i * 8].Split(new char[]
								{
									':'
								});
								string id = array2[1].Trim(new char[]
								{
									'"'
								});
								array2 = array[i * 8 + 1].Split(new char[]
								{
									':'
								});
								string version = array2[1].Trim(new char[]
								{
									'"'
								});
								array2 = array[i * 8 + 2].Split(new char[]
								{
									':'
								});
								string memo_cn = array2[2].Trim(new char[]
								{
									'"'
								});
								array2 = array[i * 8 + 3].Split(new char[]
								{
									':'
								});
								string memo_en = array2[1].Trim(new char[]
								{
									'"'
								});
								array2 = array[i * 8 + 4].Split(new char[]
								{
									':'
								});
								string memo_tw = array2[1].Trim(new char[]
								{
									'"'
								});
								array2 = array[i * 8 + 5].Split(new char[]
								{
									':'
								});
								string text2 = array2[1].Trim(new char[]
								{
									'"'
								});
								array2 = array[i * 8 + 6].Split(new char[]
								{
									':'
								});
								string checksum = array2[1].Trim(new char[]
								{
									'"'
								});
								array2 = array[i * 8 + 7].Split(new char[]
								{
									':'
								});
								string[] array3 = array2[2].Split(new char[]
								{
									'"'
								});
								string download_url = array2[1].Trim(new char[]
								{
									'"'
								}) + ":" + array3[0];
								this.fs[i].id = id;
								this.fs[i].version = version;
								this.fs[i].memo_cn = memo_cn;
								this.fs[i].memo_en = memo_en;
								this.fs[i].memo_tw = memo_tw;
								this.fs[i].memo_jp = text2.Trim(new char[]
								{
									'}'
								});
								this.fs[i].checksum = checksum;
								this.fs[i].download_url = download_url;
								this.fs[i].hex_file = webClient.DownloadString(this.fs[i].download_url);
								if (this.fs[i].hex_file.Length < 512)
								{
									num = 0;
								}
								text = "Update firmware version " + this.fs[i].version;
								this.list_firmware.Items.Add(text);
							}
						}
					}
				}
				catch (Exception)
				{
					num = 0;
				}
				if (num > 0)
				{
					this.list_firmware.SelectedIndex = 0;
					this.label_firmware.Text = "Firmware list:";
					this.button_update.Enabled = true;
				}
				else
				{
					this.label_firmware.Text = "Firmware list:can't get firmware from internet";
				}
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000F42C File Offset: 0x0000D62C
		private void btn_home_Click(object sender, EventArgs e)
		{
			this.label_SOLT1.Visible = true;
			this.label_SOLT2.Visible = true;
			this.label_SOLT3.Visible = true;
			this.label_SOLT4.Visible = true;
			this.button_save.Visible = true;
			this.button_start.Visible = true;
			this.label1.Visible = true;
			this.label2.Visible = true;
			this.label3.Visible = true;
			this.label4.Visible = true;
			this.groupBox_solt1.Visible = false;
			this.groupBox_solt2.Visible = false;
			this.groupBox_solt3.Visible = false;
			this.groupBox_solt4.Visible = false;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000F4F0 File Offset: 0x0000D6F0
		private void enable_all_button()
		{
			this.button_save.Enabled = true;
			this.button_start.Enabled = true;
			this.button_save_all.Enabled = true;
			this.button_load_all.Enabled = true;
			this.button_system.Enabled = true;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000F540 File Offset: 0x0000D740
		private void disable_all_button()
		{
			this.button_save.Enabled = false;
			this.button_start.Enabled = false;
			this.button_update.Enabled = false;
			this.button_save_all.Enabled = false;
			this.button_load_all.Enabled = false;
			this.button_system.Enabled = false;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000F59C File Offset: 0x0000D79C
		private void btn_setdevice1_Click(object sender, EventArgs e)
		{
			int num = 0;
			Button button = (Button)sender;
			if (button.Name.Contains("device1"))
			{
				num = 0;
			}
			else if (button.Name.Contains("device2"))
			{
				num = 1;
			}
			else if (button.Name.Contains("device3"))
			{
				num = 2;
			}
			else if (button.Name.Contains("device4"))
			{
				num = 3;
			}
			string arg = "type:" + this.BatParam[num].Type;
			arg = arg + "\r\nmode:" + this.BatParam[num].Mode;
			arg = arg + "\r\ncaps:" + this.BatParam[num].Caps;
			arg = arg + "\r\ncur:" + this.BatParam[num].Cur;
			arg = arg + "\r\ndcur:" + this.BatParam[num].dCur;
			arg = arg + "\r\ncut time:" + this.BatParam[num].CutTime;
			arg = arg + "\r\ncut tem:" + this.BatParam[num].CutTemp;
			arg = arg + "\r\nfull voltage:" + this.BatParam[num].End_Volt;
			arg = arg + "\r\ncut voltage:" + this.BatParam[num].Cut_Volt;
			arg = arg + "\r\ntrickle:" + this.BatParam[num].Trickle;
			arg = arg + "\r\npeak:" + this.BatParam[num].Peak_Sense;
			arg = arg + "\r\ncycles:" + this.BatParam[num].Cycle_Count;
			arg = arg + "\r\ncyclemode:" + this.BatParam[num].Cycle_Mode;
			arg = arg + "\r\nrest:" + this.BatParam[num].Cycle_Delay;
			this.timer2.Start();
			if (!this.Send_USB_CMD(num, 17))
			{
				MessageBox.Show("error, check USB connector!");
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000F7F4 File Offset: 0x0000D9F4
		private void timer3_Tick(object sender, EventArgs e)
		{
			if (this.bread_chrager_data)
			{
				this.timer2.Start();
				bool flag;
				if (this.solt_id < 4)
				{
					flag = this.Send_USB_CMD(this.solt_id++, 95);
				}
				else
				{
					flag = this.Send_USB_CMD(this.solt_id++, 90);
				}
				if (this.solt_id >= 5 || !flag)
				{
					this.bread_chrager_data = false;
					this.timer3.Stop();
					if (!flag)
					{
						MessageBox.Show("error, check USB connector!");
					}
				}
			}
			else if (this.bwrite_chrager_data)
			{
				this.timer2.Start();
				bool flag = this.Send_USB_CMD(this.solt_id++ % 4, 17);
				if (this.solt_id >= 4 || !flag)
				{
					this.bwrite_chrager_data = false;
					this.timer3.Stop();
					if (!flag)
					{
						MessageBox.Show("error, check USB connector!");
					}
				}
			}
			else if (this.bcharge)
			{
				if (!this.Send_USB_CMD(this.solt_id++ % 4, 85))
				{
					this.timer3.Stop();
				}
				else
				{
					this.dataReceived = false;
				}
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000F954 File Offset: 0x0000DB54
		private void Get_System_Data(int i)
		{
			byte b = 0;
			string text = "";
			int num = 4;
			this.BatParam[i].Sys_Mem1 = (int)this.inPacket[num++];
			this.BatParam[i].Sys_Mem2 = (int)this.inPacket[num++];
			this.BatParam[i].Sys_Mem3 = (int)this.inPacket[num++];
			this.BatParam[i].Sys_Mem4 = (int)this.inPacket[num++];
			this.BatParam[i].Sys_Advance = (int)this.inPacket[num++];
			this.BatParam[i].Sys_tUnit = (int)this.inPacket[num++];
			this.BatParam[i].Sys_Buzzer_Tone = (int)this.inPacket[num++];
			this.BatParam[i].Sys_Life_Hide = (int)this.inPacket[num++];
			this.BatParam[i].Sys_LiHv_Hide = (int)this.inPacket[num++];
			this.BatParam[i].Sys_Eneloop_Hide = (int)this.inPacket[num++];
			this.BatParam[i].Sys_NiZn_Hide = (int)this.inPacket[num++];
			this.BatParam[i].Sys_Lcd_Time = (int)this.inPacket[num++];
			this.BatParam[i].Sys_Min_Input = (int)this.inPacket[num++];
			for (int j = 0; j < 16; j++)
			{
				if (j < 15)
				{
					b += this.inPacket[17 + j];
				}
				string text2 = this.inPacket[17 + j].ToString("X");
				text += text2.PadLeft(2, '0');
			}
			b = ~b;
			b += 1;
			if (b == this.inPacket[32])
			{
				float num2 = 1f;
				this.machine_info = new Machine_info();
				this.machine_info.core_type = Encoding.ASCII.GetString(this.inPacket, 17, 23);
				this.machine_info.upgrade_type = (int)this.inPacket[23];
				this.machine_info.is_encrypt = (this.inPacket[24] == 1);
				this.machine_info.customer_id = (int)this.inPacket[25] * 256 + (int)this.inPacket[26];
				this.machine_info.language_id = (int)this.inPacket[27];
				this.machine_info.software_version = (float)this.inPacket[28] * num2 + (float)this.inPacket[29] * num2 / 100f;
				this.machine_info.hardware_version = (float)this.inPacket[30];
				this.machine_info.reserved = (float)this.inPacket[31];
				this.machine_info.checksum = this.inPacket[32];
				this.machine_info.machine_id = text;
				this.label_version.Text = "Current Version:" + this.machine_info.software_version.ToString("0.00");
				if (!this.machine_info.core_type.Contains("100083"))
				{
					this.disable_all_button();
				}
				else
				{
					this.enable_all_button();
				}
			}
			else
			{
				this.disable_all_button();
				this.label_version.Text = "Current Version:";
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000FCCC File Offset: 0x0000DECC
		private void Get_Charge_Data(int i)
		{
			int num = 3;
			this.BatParam[i].bWork = (int)this.inPacket[num++];
			this.BatParam[i].Type = (int)this.inPacket[num++];
			this.BatParam[i].Mode = (int)this.inPacket[num++];
			this.BatParam[i].Caps = (int)this.inPacket[num] * 256 + (int)this.inPacket[num + 1];
			num += 2;
			this.BatParam[i].Cur = (int)this.inPacket[num] * 256 + (int)this.inPacket[num + 1];
			num += 2;
			this.BatParam[i].dCur = (int)this.inPacket[num] * 256 + (int)this.inPacket[num + 1];
			num += 2;
			this.BatParam[i].Cut_Volt = (int)this.inPacket[num] * 256 + (int)this.inPacket[num + 1];
			num += 2;
			this.BatParam[i].End_Volt = (int)this.inPacket[num] * 256 + (int)this.inPacket[num + 1];
			num += 2;
			this.BatParam[i].End_Cur = (int)this.inPacket[num] * 256 + (int)this.inPacket[num + 1];
			num += 2;
			this.BatParam[i].End_dCur = (int)this.inPacket[num] * 256 + (int)this.inPacket[num + 1];
			num += 2;
			this.BatParam[i].Cycle_Count = (int)this.inPacket[num++];
			this.BatParam[i].Cycle_Delay = (int)this.inPacket[num++];
			this.BatParam[i].Cycle_Mode = (int)this.inPacket[num++];
			this.BatParam[i].Peak_Sense = (int)this.inPacket[num];
			num++;
			this.BatParam[i].Trickle = (int)(this.inPacket[num] * 10);
			num++;
			this.BatParam[i].Hold_Volt = (int)this.inPacket[num] * 256 + (int)this.inPacket[num + 1];
			num += 2;
			this.BatParam[i].CutTemp = (int)(this.inPacket[num] * 10);
			num++;
			this.BatParam[i].CutTime = (int)this.inPacket[num] * 256 + (int)this.inPacket[num + 1];
			num += 2;
			this.BatParam[0].Tem_Unit = (int)this.inPacket[num];
			this.BatParam[1].Tem_Unit = (int)this.inPacket[num];
			this.BatParam[2].Tem_Unit = (int)this.inPacket[num];
			this.BatParam[3].Tem_Unit = (int)this.inPacket[num];
			if (this.BatParam[0].Tem_Unit == 0)
			{
			}
			string text;
			if (this.BatParam[i].Type < 3)
			{
				text = this.li_mode[this.BatParam[i].Mode];
			}
			else
			{
				text = this.ni_mode[this.BatParam[i].Mode];
			}
			string text2 = string.Concat(new string[]
			{
				FormLoader.bat_type[this.BatParam[i].Type],
				"  ",
				text,
				"  ",
				((float)this.BatParam[i].Cur / 1000f).ToString("f2"),
				"A/-",
				((float)this.BatParam[i].dCur / 1000f).ToString("f2")
			});
			if (i == 0)
			{
				this.button1.Text = text2;
			}
			if (i == 1)
			{
				this.button2.Text = text2;
			}
			if (i == 2)
			{
				this.button3.Text = text2;
			}
			if (i == 3)
			{
				this.button4.Text = text2;
			}
			string arg = "type:" + this.BatParam[i].Type;
			arg = arg + "\r\nmode:" + this.BatParam[i].Mode;
			arg = arg + "\r\ncaps:" + this.BatParam[i].Caps;
			arg = arg + "\r\ncur:" + this.BatParam[i].Cur;
			arg = arg + "\r\ndcur:" + this.BatParam[i].dCur;
			arg = arg + "\r\ncut time:" + this.BatParam[i].CutTime;
			arg = arg + "\r\ncut tem:" + this.BatParam[i].CutTemp;
			arg = arg + "\r\nfull voltage:" + this.BatParam[i].End_Volt;
			arg = arg + "\r\ncut voltage:" + this.BatParam[i].Cut_Volt;
			arg = arg + "\r\ntrickle:" + this.BatParam[i].Trickle;
			arg = arg + "\r\npeak:" + this.BatParam[i].Peak_Sense;
			arg = arg + "\r\ncycles:" + this.BatParam[i].Cycle_Count;
			arg = arg + "\r\ncyclemode:" + this.BatParam[i].Cycle_Mode;
			arg = arg + "\r\nrest:" + this.BatParam[i].Cycle_Delay;
			if (this.BatParam[i].bWork > 0)
			{
				this.button_system.Enabled = false;
				this.button_update.Enabled = false;
				this.groupBox_solt1.Enabled = false;
				this.groupBox_solt2.Enabled = false;
				this.groupBox_solt3.Enabled = false;
				this.groupBox_solt4.Enabled = false;
				this.button_load_all.Enabled = false;
				this.button_save_all.Enabled = false;
				this.bcharge = true;
				this.StartMenuItem.Text = "Stop(&S)";
				this.button_start.Text = "Stop";
			}
			if (this.bcharge && i == 3)
			{
				this.timer3.Start();
				this.timer2.Start();
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0001037C File Offset: 0x0000E57C
		private void btn_loaddevice1_Click(object sender, EventArgs e)
		{
			this.timer2.Start();
			if (!this.Send_USB_CMD(0, 95))
			{
				MessageBox.Show("error, check USB connector!");
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000103B0 File Offset: 0x0000E5B0
		private void btn_loaddevice2_Click(object sender, EventArgs e)
		{
			this.timer2.Start();
			if (!this.Send_USB_CMD(1, 95))
			{
				MessageBox.Show("error, check USB connector!");
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000103E4 File Offset: 0x0000E5E4
		private void btn_loaddevice3_Click(object sender, EventArgs e)
		{
			this.timer2.Start();
			if (!this.Send_USB_CMD(2, 95))
			{
				MessageBox.Show("error, check USB connector!");
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00010418 File Offset: 0x0000E618
		private void btn_loaddevice4_Click(object sender, EventArgs e)
		{
			this.timer2.Start();
			if (!this.Send_USB_CMD(3, 95))
			{
				MessageBox.Show("error, check USB connector!");
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0001044C File Offset: 0x0000E64C
		private void check_volt1_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			string name = checkBox.Name;
			if (name.Contains("volt1"))
			{
				this.Curve_Volt[0] = this.check_volt1.Checked;
			}
			else if (name.Contains("volt2"))
			{
				this.Curve_Volt[1] = this.check_volt2.Checked;
			}
			else if (name.Contains("volt3"))
			{
				this.Curve_Volt[2] = this.check_volt3.Checked;
			}
			else if (name.Contains("volt4"))
			{
				this.Curve_Volt[3] = this.check_volt4.Checked;
			}
			else if (name.Contains("current1"))
			{
				this.Curve_Cur[0] = this.check_current1.Checked;
			}
			else if (name.Contains("current2"))
			{
				this.Curve_Cur[1] = this.check_current2.Checked;
			}
			else if (name.Contains("current3"))
			{
				this.Curve_Cur[2] = this.check_current3.Checked;
			}
			else if (name.Contains("current4"))
			{
				this.Curve_Cur[3] = this.check_current4.Checked;
			}
			else if (name.Contains("caps1"))
			{
				this.Curve_Caps[0] = this.check_caps1.Checked;
			}
			else if (name.Contains("caps2"))
			{
				this.Curve_Caps[1] = this.check_caps2.Checked;
			}
			else if (name.Contains("caps3"))
			{
				this.Curve_Caps[2] = this.check_caps3.Checked;
			}
			else if (name.Contains("caps4"))
			{
				this.Curve_Caps[3] = this.check_caps4.Checked;
			}
			else if (name.Contains("tem1"))
			{
				this.Curve_Tem[0] = this.check_tem1.Checked;
			}
			else if (name.Contains("tem2"))
			{
				this.Curve_Tem[1] = this.check_tem2.Checked;
			}
			else if (name.Contains("tem3"))
			{
				this.Curve_Tem[2] = this.check_tem3.Checked;
			}
			else if (name.Contains("tem4"))
			{
				this.Curve_Tem[3] = this.check_tem4.Checked;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000106FC File Offset: 0x0000E8FC
		private void button1_Click(object sender, EventArgs e)
		{
			if (!this.bread_chrager_data && !this.bwrite_chrager_data)
			{
				if (MessageBox.Show("Read all solts data from device!\r\nContinue?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					this.solt_id = 0;
					this.bread_chrager_data = true;
					this.timer3.Start();
				}
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0001075C File Offset: 0x0000E95C
		private void button2_Click(object sender, EventArgs e)
		{
			if (!this.bread_chrager_data && !this.bwrite_chrager_data)
			{
				if (MessageBox.Show("Set all solts data to device!\r\nContinue?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					int i;
					for (i = 0; i < 4; i++)
					{
					}
					if (i >= 4)
					{
						this.solt_id = 0;
						this.bwrite_chrager_data = true;
						this.timer3.Start();
					}
				}
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000107DC File Offset: 0x0000E9DC
		private void Set_Measure_Line(int solt, MouseEventArgs e)
		{
			this.mouse_x = e.X;
			this.mouse_y = e.Y;
			Label label = this.label_SOLT1;
			if (solt == 0)
			{
				label = this.label_SOLT1;
			}
			else if (solt == 1)
			{
				label = this.label_SOLT2;
			}
			else if (solt == 2)
			{
				label = this.label_SOLT3;
			}
			else if (solt == 3)
			{
				label = this.label_SOLT4;
			}
			if (e.X >= 40 && e.X <= this.label_SOLT1.Width - 60 && e.Y >= 10 && e.Y <= this.label_SOLT1.Height - 20)
			{
				this.bMeasure[solt] = true;
				label.Refresh();
			}
			else if (this.bMeasure[solt])
			{
				this.bMeasure[solt] = false;
				label.Refresh();
			}
			for (int i = 0; i < 4; i++)
			{
				if (solt != i)
				{
					if (this.bMeasure[i])
					{
						this.bMeasure[i] = false;
						label.Refresh();
					}
				}
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00010912 File Offset: 0x0000EB12
		private void label_SOLT1_MouseMove_1(object sender, MouseEventArgs e)
		{
			this.Set_Measure_Line(0, e);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0001091E File Offset: 0x0000EB1E
		private void label_SOLT2_MouseMove(object sender, MouseEventArgs e)
		{
			this.Set_Measure_Line(1, e);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0001092A File Offset: 0x0000EB2A
		private void label_SOLT3_MouseMove(object sender, MouseEventArgs e)
		{
			this.Set_Measure_Line(2, e);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00010936 File Offset: 0x0000EB36
		private void label_SOLT4_MouseMove(object sender, MouseEventArgs e)
		{
			this.Set_Measure_Line(3, e);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00010944 File Offset: 0x0000EB44
		private void button_update_Click(object sender, EventArgs e)
		{
			if (!this.timer1.Enabled)
			{
				if (this.machine_info == null)
				{
					MessageBox.Show("Invalid machine ID!");
				}
				else if ((double)this.machine_info.software_version >= 1.0)
				{
					if (this.list_firmware.Items.Count > 0)
					{
						if (this.list_firmware.SelectedIndex >= 0 && this.list_firmware.SelectedIndex < this.list_firmware.Items.Count && this.fs != null)
						{
							if (this.fs[this.list_firmware.SelectedIndex].hex_file.Length < 1024)
							{
								MessageBox.Show("Bad hex file!");
							}
							else
							{
								this.update_ok_version = this.fs[this.list_firmware.SelectedIndex].version;
								this.timer2.Stop();
								this.BinBuffer = this.ConvertToBin(this.fs[this.list_firmware.SelectedIndex].hex_file);
								this.button_update.Enabled = false;
								this.groupBox_solt1.Enabled = false;
								this.groupBox_solt2.Enabled = false;
								this.groupBox_solt3.Enabled = false;
								this.groupBox_solt4.Enabled = false;
								this.button_start.Enabled = false;
								this.button_system.Enabled = false;
								this.button_save_all.Enabled = false;
								this.button_load_all.Enabled = false;
								this.UFirmware();
							}
						}
					}
				}
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00010B10 File Offset: 0x0000ED10
		private void list_firmware_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.list_firmware.SelectedIndex;
			string[] separator = new string[]
			{
				"\\r\\n"
			};
			if (selectedIndex >= 0 && selectedIndex < this.list_firmware.Items.Count)
			{
				string[] array = this.fs[selectedIndex].memo_en.Split(separator, StringSplitOptions.None);
				this.text_fm_info.Text = "";
				for (int i = 0; i < array.Length; i++)
				{
					TextBox textBox = this.text_fm_info;
					textBox.Text = textBox.Text + array[i] + "\r\n";
				}
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00010BBC File Offset: 0x0000EDBC
		private void button1_Click_1(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			int num = 0;
			if (button.Name.Contains("1"))
			{
				num = 0;
			}
			if (button.Name.Contains("2"))
			{
				num = 1;
			}
			if (button.Name.Contains("3"))
			{
				num = 2;
			}
			if (button.Name.Contains("4"))
			{
				num = 3;
			}
			this.Batt_Type.Set_Battery_Type_Caps(this.BatParam, num);
			string text;
			if (this.BatParam[num].Type < 3)
			{
				text = this.li_mode[this.BatParam[num].Mode];
			}
			else
			{
				text = this.ni_mode[this.BatParam[num].Mode];
			}
			button.Text = string.Concat(new string[]
			{
				FormLoader.bat_type[this.BatParam[num].Type],
				"  ",
				text,
				"  ",
				((float)this.BatParam[num].Cur / 1000f).ToString("f2"),
				"A/-",
				((float)this.BatParam[num].dCur / 1000f).ToString("f2"),
				"A"
			});
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00010D2F File Offset: 0x0000EF2F
		private void FormLoader_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00010D34 File Offset: 0x0000EF34
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00010D6C File Offset: 0x0000EF6C
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormLoader));
			this.DownLoad = new Button();
			this.btn_app = new Button();
			this.timer1 = new Timer(this.components);
			this.btn_boot = new Button();
			this.lb_verson = new Label();
			this.timer2 = new Timer(this.components);
			this.label_SOLT1 = new Label();
			this.label_SOLT2 = new Label();
			this.label_SOLT3 = new Label();
			this.label_SOLT4 = new Label();
			this.menuStrip1 = new MenuStrip();
			this.FileMenuItem = new ToolStripMenuItem();
			this.LoadMenuItem = new ToolStripMenuItem();
			this.SaveMenuItem = new ToolStripMenuItem();
			this.ExitMenuItem = new ToolStripMenuItem();
			this.ToolsMenuItem = new ToolStripMenuItem();
			this.ParamMenuItem = new ToolStripMenuItem();
			this.StartMenuItem = new ToolStripMenuItem();
			this.SystemMenuItem = new ToolStripMenuItem();
			this.AboutMenuItem = new ToolStripMenuItem();
			this.VersionMenuItem = new ToolStripMenuItem();
			this.HelpMenuItem = new ToolStripMenuItem();
			this.saveFileDialog1 = new SaveFileDialog();
			this.openFileDialog1 = new OpenFileDialog();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.btn_exit = new Button();
			this.btn_mini = new Button();
			this.groupBox_solt1 = new GroupBox();
			this.label5 = new Label();
			this.button1 = new Button();
			this.btn_loaddevice1 = new Button();
			this.btn_setdevice1 = new Button();
			this.check_tem1 = new CheckBox();
			this.check_caps1 = new CheckBox();
			this.check_current1 = new CheckBox();
			this.check_volt1 = new CheckBox();
			this.check_tem2 = new CheckBox();
			this.check_caps2 = new CheckBox();
			this.check_current2 = new CheckBox();
			this.check_volt2 = new CheckBox();
			this.check_tem3 = new CheckBox();
			this.check_caps3 = new CheckBox();
			this.check_current3 = new CheckBox();
			this.check_volt3 = new CheckBox();
			this.check_tem4 = new CheckBox();
			this.check_caps4 = new CheckBox();
			this.check_current4 = new CheckBox();
			this.check_volt4 = new CheckBox();
			this.groupBox_solt2 = new GroupBox();
			this.button2 = new Button();
			this.label6 = new Label();
			this.btn_loaddevice2 = new Button();
			this.btn_setdevice2 = new Button();
			this.groupBox_solt3 = new GroupBox();
			this.button3 = new Button();
			this.label7 = new Label();
			this.btn_loaddevice3 = new Button();
			this.btn_setdevice3 = new Button();
			this.groupBox_solt4 = new GroupBox();
			this.button4 = new Button();
			this.label8 = new Label();
			this.btn_loaddevice4 = new Button();
			this.btn_setdevice4 = new Button();
			this.button_update = new Button();
			this.timer3 = new Timer(this.components);
			this.button_system = new Button();
			this.label_usb_status = new Label();
			this.tabControl1 = new TabControl();
			this.tabPage1 = new TabPage();
			this.button_start = new Button();
			this.button_save = new Button();
			this.tabPage2 = new TabPage();
			this.groupBox_system = new GroupBox();
			this.progressBar1 = new ProgressBar();
			this.label44 = new Label();
			this.list_firmware = new ListBox();
			this.label_firmware = new Label();
			this.label_version = new Label();
			this.text_fm_info = new TextBox();
			this.button_save_all = new Button();
			this.button_load_all = new Button();
			this.button_setting = new Button();
			this.button_home = new Button();
			this.label_logo = new Label();
			this.label_sver = new Label();
			this.menuStrip1.SuspendLayout();
			this.groupBox_solt1.SuspendLayout();
			this.groupBox_solt2.SuspendLayout();
			this.groupBox_solt3.SuspendLayout();
			this.groupBox_solt4.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox_system.SuspendLayout();
			base.SuspendLayout();
			this.DownLoad.FlatAppearance.BorderColor = SystemColors.Control;
			this.DownLoad.FlatAppearance.BorderSize = 2;
			this.DownLoad.FlatAppearance.MouseDownBackColor = SystemColors.Control;
			this.DownLoad.Location = new Point(710, 782);
			this.DownLoad.Margin = new Padding(2);
			this.DownLoad.Name = "DownLoad";
			this.DownLoad.Size = new Size(43, 21);
			this.DownLoad.TabIndex = 2;
			this.DownLoad.Text = "Update";
			this.DownLoad.UseVisualStyleBackColor = false;
			this.DownLoad.Visible = false;
			this.DownLoad.Click += this.DownLoad_Click;
			this.btn_app.Location = new Point(776, 782);
			this.btn_app.Margin = new Padding(2);
			this.btn_app.Name = "btn_app";
			this.btn_app.Size = new Size(71, 23);
			this.btn_app.TabIndex = 6;
			this.btn_app.Text = "Load App File";
			this.btn_app.UseVisualStyleBackColor = true;
			this.btn_app.Visible = false;
			this.btn_app.Click += this.buttonCheckDevice_Click;
			this.timer1.Interval = 10;
			this.timer1.Tick += this.timer1_Tick;
			this.btn_boot.FlatAppearance.BorderSize = 2;
			this.btn_boot.FlatStyle = FlatStyle.Flat;
			this.btn_boot.Location = new Point(587, 784);
			this.btn_boot.Margin = new Padding(2);
			this.btn_boot.Name = "btn_boot";
			this.btn_boot.Size = new Size(57, 21);
			this.btn_boot.TabIndex = 8;
			this.btn_boot.Text = "Boot";
			this.btn_boot.UseVisualStyleBackColor = true;
			this.btn_boot.Visible = false;
			this.btn_boot.Click += this.btn_boot_Click;
			this.lb_verson.AutoSize = true;
			this.lb_verson.Location = new Point(22, 95);
			this.lb_verson.Name = "lb_verson";
			this.lb_verson.Size = new Size(0, 12);
			this.lb_verson.TabIndex = 9;
			this.timer2.Interval = 50;
			this.timer2.Tick += this.timer2_Tick;
			this.label_SOLT1.BackColor = Color.WhiteSmoke;
			this.label_SOLT1.Location = new Point(0, 0);
			this.label_SOLT1.Name = "label_SOLT1";
			this.label_SOLT1.Size = new Size(650, 140);
			this.label_SOLT1.TabIndex = 10;
			this.label_SOLT1.Paint += this.label_SOLT1_Paint;
			this.label_SOLT1.MouseMove += this.label_SOLT1_MouseMove_1;
			this.label_SOLT2.BackColor = Color.WhiteSmoke;
			this.label_SOLT2.Location = new Point(0, 140);
			this.label_SOLT2.Name = "label_SOLT2";
			this.label_SOLT2.Size = new Size(650, 140);
			this.label_SOLT2.TabIndex = 20;
			this.label_SOLT2.Paint += this.label_SOLT2_Paint;
			this.label_SOLT2.MouseMove += this.label_SOLT2_MouseMove;
			this.label_SOLT3.BackColor = Color.WhiteSmoke;
			this.label_SOLT3.Location = new Point(0, 280);
			this.label_SOLT3.Name = "label_SOLT3";
			this.label_SOLT3.Size = new Size(650, 140);
			this.label_SOLT3.TabIndex = 21;
			this.label_SOLT3.Paint += this.label_SOLT3_Paint;
			this.label_SOLT3.MouseMove += this.label_SOLT3_MouseMove;
			this.label_SOLT4.BackColor = Color.WhiteSmoke;
			this.label_SOLT4.Location = new Point(0, 420);
			this.label_SOLT4.Name = "label_SOLT4";
			this.label_SOLT4.Size = new Size(650, 140);
			this.label_SOLT4.TabIndex = 22;
			this.label_SOLT4.Paint += this.label_SOLT4_Paint;
			this.label_SOLT4.MouseMove += this.label_SOLT4_MouseMove;
			this.menuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.FileMenuItem,
				this.ToolsMenuItem,
				this.AboutMenuItem
			});
			this.menuStrip1.Location = new Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new Size(1184, 24);
			this.menuStrip1.TabIndex = 23;
			this.menuStrip1.Text = "File&F";
			this.menuStrip1.Visible = false;
			this.FileMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.LoadMenuItem,
				this.SaveMenuItem,
				this.ExitMenuItem
			});
			this.FileMenuItem.Name = "FileMenuItem";
			this.FileMenuItem.Size = new Size(59, 20);
			this.FileMenuItem.Text = "File(&F)";
			this.LoadMenuItem.Name = "LoadMenuItem";
			this.LoadMenuItem.Size = new Size(142, 22);
			this.LoadMenuItem.Text = "Load File(&L)";
			this.LoadMenuItem.Click += this.LoadMenuItem_Click;
			this.SaveMenuItem.Name = "SaveMenuItem";
			this.SaveMenuItem.Size = new Size(142, 22);
			this.SaveMenuItem.Text = "Save File(&S)";
			this.SaveMenuItem.Click += this.SaveMenuItem_Click;
			this.ExitMenuItem.Name = "ExitMenuItem";
			this.ExitMenuItem.Size = new Size(142, 22);
			this.ExitMenuItem.Text = "Exit(&E)";
			this.ExitMenuItem.Click += this.ExitMenuItem_Click;
			this.ToolsMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.ParamMenuItem,
				this.StartMenuItem,
				this.SystemMenuItem
			});
			this.ToolsMenuItem.Name = "ToolsMenuItem";
			this.ToolsMenuItem.Size = new Size(65, 20);
			this.ToolsMenuItem.Text = "Tools(&T)";
			this.ParamMenuItem.Name = "ParamMenuItem";
			this.ParamMenuItem.Size = new Size(142, 22);
			this.ParamMenuItem.Text = "Parameter(&P)";
			this.ParamMenuItem.Click += this.ParamMenuItem_Click;
			this.StartMenuItem.Name = "StartMenuItem";
			this.StartMenuItem.Size = new Size(142, 22);
			this.StartMenuItem.Text = "Start(&S)";
			this.StartMenuItem.Click += this.StartMenuItem_Click;
			this.SystemMenuItem.Name = "SystemMenuItem";
			this.SystemMenuItem.Size = new Size(142, 22);
			this.SystemMenuItem.Text = "System(&T)";
			this.AboutMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.VersionMenuItem,
				this.HelpMenuItem
			});
			this.AboutMenuItem.Name = "AboutMenuItem";
			this.AboutMenuItem.Size = new Size(65, 20);
			this.AboutMenuItem.Text = "About(&A)";
			this.VersionMenuItem.Name = "VersionMenuItem";
			this.VersionMenuItem.Size = new Size(130, 22);
			this.VersionMenuItem.Text = "Version(&V)";
			this.HelpMenuItem.Name = "HelpMenuItem";
			this.HelpMenuItem.Size = new Size(130, 22);
			this.HelpMenuItem.Text = "Help(&H)";
			this.saveFileDialog1.Filter = "BMP(*.bmp)|*.bmp";
			this.openFileDialog1.Filter = "Charge Data(*.cdata)|*.cdata";
			this.label1.BackColor = Color.Gainsboro;
			this.label1.BorderStyle = BorderStyle.Fixed3D;
			this.label1.Font = new Font("SimSun", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label1.ForeColor = Color.Black;
			this.label1.Location = new Point(650, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(250, 140);
			this.label1.TabIndex = 25;
			this.label1.Paint += this.label1_Paint;
			this.label2.BackColor = Color.Gainsboro;
			this.label2.BorderStyle = BorderStyle.Fixed3D;
			this.label2.Font = new Font("SimSun", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label2.Location = new Point(650, 140);
			this.label2.Name = "label2";
			this.label2.Size = new Size(250, 140);
			this.label2.TabIndex = 26;
			this.label2.Paint += this.label2_Paint;
			this.label3.BackColor = Color.Gainsboro;
			this.label3.BorderStyle = BorderStyle.Fixed3D;
			this.label3.Font = new Font("SimSun", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label3.Location = new Point(650, 280);
			this.label3.Name = "label3";
			this.label3.Size = new Size(250, 140);
			this.label3.TabIndex = 27;
			this.label3.Paint += this.label3_Paint;
			this.label4.BackColor = Color.Gainsboro;
			this.label4.BorderStyle = BorderStyle.Fixed3D;
			this.label4.Font = new Font("SimSun", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label4.Location = new Point(650, 420);
			this.label4.Name = "label4";
			this.label4.Size = new Size(250, 140);
			this.label4.TabIndex = 28;
			this.label4.Paint += this.label4_Paint;
			this.btn_exit.BackColor = Color.SkyBlue;
			this.btn_exit.FlatStyle = FlatStyle.Popup;
			this.btn_exit.Font = new Font("SimSun", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.btn_exit.ForeColor = SystemColors.ActiveCaptionText;
			this.btn_exit.Location = new Point(898, 7);
			this.btn_exit.Name = "btn_exit";
			this.btn_exit.Size = new Size(50, 22);
			this.btn_exit.TabIndex = 30;
			this.btn_exit.Text = "X";
			this.btn_exit.UseVisualStyleBackColor = false;
			this.btn_exit.Click += this.ExitMenuItem_Click;
			this.btn_mini.BackColor = Color.SkyBlue;
			this.btn_mini.FlatStyle = FlatStyle.Popup;
			this.btn_mini.Font = new Font("SimSun", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.btn_mini.ForeColor = SystemColors.ControlLightLight;
			this.btn_mini.Location = new Point(842, 7);
			this.btn_mini.Name = "btn_mini";
			this.btn_mini.Size = new Size(50, 22);
			this.btn_mini.TabIndex = 29;
			this.btn_mini.Text = "-";
			this.btn_mini.UseVisualStyleBackColor = false;
			this.btn_mini.Click += this.btn_min_Click;
			this.groupBox_solt1.BackColor = SystemColors.Control;
			this.groupBox_solt1.Controls.Add(this.label5);
			this.groupBox_solt1.Controls.Add(this.button1);
			this.groupBox_solt1.Location = new Point(0, 0);
			this.groupBox_solt1.Name = "groupBox_solt1";
			this.groupBox_solt1.Size = new Size(500, 120);
			this.groupBox_solt1.TabIndex = 31;
			this.groupBox_solt1.TabStop = false;
			this.label5.Font = new Font("Microsoft YaHei", 42f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 134);
			this.label5.Location = new Point(30, 26);
			this.label5.Name = "label5";
			this.label5.Size = new Size(72, 69);
			this.label5.TabIndex = 50;
			this.label5.Text = "1";
			this.label5.TextAlign = ContentAlignment.MiddleCenter;
			this.button1.FlatStyle = FlatStyle.Popup;
			this.button1.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button1.ImageAlign = ContentAlignment.MiddleLeft;
			this.button1.Location = new Point(164, 16);
			this.button1.Margin = new Padding(1);
			this.button1.Name = "button1";
			this.button1.Size = new Size(320, 80);
			this.button1.TabIndex = 27;
			this.button1.Text = "LiIon  Charge  1.00A/-0.50A";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click_1;
			this.btn_loaddevice1.Location = new Point(625, 517);
			this.btn_loaddevice1.Name = "btn_loaddevice1";
			this.btn_loaddevice1.Size = new Size(99, 25);
			this.btn_loaddevice1.TabIndex = 25;
			this.btn_loaddevice1.Text = "Load form #1";
			this.btn_loaddevice1.UseVisualStyleBackColor = true;
			this.btn_loaddevice1.Visible = false;
			this.btn_loaddevice1.Click += this.btn_loaddevice1_Click;
			this.btn_setdevice1.Location = new Point(518, 517);
			this.btn_setdevice1.Name = "btn_setdevice1";
			this.btn_setdevice1.Size = new Size(100, 25);
			this.btn_setdevice1.TabIndex = 24;
			this.btn_setdevice1.Text = "Send to #1";
			this.btn_setdevice1.UseVisualStyleBackColor = true;
			this.btn_setdevice1.Visible = false;
			this.btn_setdevice1.Click += this.btn_setdevice1_Click;
			this.check_tem1.AutoSize = true;
			this.check_tem1.BackColor = Color.Red;
			this.check_tem1.Location = new Point(832, 84);
			this.check_tem1.Name = "check_tem1";
			this.check_tem1.Size = new Size(54, 16);
			this.check_tem1.TabIndex = 3;
			this.check_tem1.Text = "     ";
			this.check_tem1.UseVisualStyleBackColor = false;
			this.check_tem1.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_caps1.AutoSize = true;
			this.check_caps1.BackColor = Color.DarkOrange;
			this.check_caps1.Location = new Point(832, 62);
			this.check_caps1.Name = "check_caps1";
			this.check_caps1.Size = new Size(54, 16);
			this.check_caps1.TabIndex = 2;
			this.check_caps1.Text = "     ";
			this.check_caps1.UseVisualStyleBackColor = false;
			this.check_caps1.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_current1.AutoSize = true;
			this.check_current1.BackColor = Color.Green;
			this.check_current1.Checked = true;
			this.check_current1.CheckState = CheckState.Checked;
			this.check_current1.Location = new Point(832, 37);
			this.check_current1.Name = "check_current1";
			this.check_current1.Size = new Size(54, 16);
			this.check_current1.TabIndex = 1;
			this.check_current1.Text = "     ";
			this.check_current1.UseVisualStyleBackColor = false;
			this.check_current1.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_volt1.AutoSize = true;
			this.check_volt1.BackColor = Color.Blue;
			this.check_volt1.Checked = true;
			this.check_volt1.CheckState = CheckState.Checked;
			this.check_volt1.ForeColor = Color.Black;
			this.check_volt1.Location = new Point(832, 15);
			this.check_volt1.Name = "check_volt1";
			this.check_volt1.Size = new Size(54, 16);
			this.check_volt1.TabIndex = 0;
			this.check_volt1.Text = "     ";
			this.check_volt1.UseVisualStyleBackColor = false;
			this.check_volt1.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_tem2.AutoSize = true;
			this.check_tem2.BackColor = Color.Red;
			this.check_tem2.Location = new Point(832, 228);
			this.check_tem2.Name = "check_tem2";
			this.check_tem2.Size = new Size(54, 16);
			this.check_tem2.TabIndex = 3;
			this.check_tem2.Text = "     ";
			this.check_tem2.UseVisualStyleBackColor = false;
			this.check_tem2.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_caps2.AutoSize = true;
			this.check_caps2.BackColor = Color.DarkOrange;
			this.check_caps2.Location = new Point(832, 206);
			this.check_caps2.Name = "check_caps2";
			this.check_caps2.Size = new Size(54, 16);
			this.check_caps2.TabIndex = 2;
			this.check_caps2.Text = "     ";
			this.check_caps2.UseVisualStyleBackColor = false;
			this.check_caps2.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_current2.AutoSize = true;
			this.check_current2.BackColor = Color.Green;
			this.check_current2.Checked = true;
			this.check_current2.CheckState = CheckState.Checked;
			this.check_current2.Location = new Point(832, 184);
			this.check_current2.Name = "check_current2";
			this.check_current2.Size = new Size(54, 16);
			this.check_current2.TabIndex = 1;
			this.check_current2.Text = "     ";
			this.check_current2.UseVisualStyleBackColor = false;
			this.check_current2.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_volt2.AutoSize = true;
			this.check_volt2.BackColor = Color.Blue;
			this.check_volt2.Checked = true;
			this.check_volt2.CheckState = CheckState.Checked;
			this.check_volt2.Location = new Point(832, 162);
			this.check_volt2.Name = "check_volt2";
			this.check_volt2.Size = new Size(54, 16);
			this.check_volt2.TabIndex = 0;
			this.check_volt2.Text = "     ";
			this.check_volt2.UseVisualStyleBackColor = false;
			this.check_volt2.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_tem3.AutoSize = true;
			this.check_tem3.BackColor = Color.Red;
			this.check_tem3.Location = new Point(836, 364);
			this.check_tem3.Name = "check_tem3";
			this.check_tem3.Size = new Size(54, 16);
			this.check_tem3.TabIndex = 3;
			this.check_tem3.Text = "     ";
			this.check_tem3.UseVisualStyleBackColor = false;
			this.check_tem3.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_caps3.AutoSize = true;
			this.check_caps3.BackColor = Color.DarkOrange;
			this.check_caps3.Location = new Point(836, 342);
			this.check_caps3.Name = "check_caps3";
			this.check_caps3.Size = new Size(54, 16);
			this.check_caps3.TabIndex = 2;
			this.check_caps3.Text = "     ";
			this.check_caps3.UseVisualStyleBackColor = false;
			this.check_caps3.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_current3.AutoSize = true;
			this.check_current3.BackColor = Color.Green;
			this.check_current3.Checked = true;
			this.check_current3.CheckState = CheckState.Checked;
			this.check_current3.Location = new Point(836, 320);
			this.check_current3.Name = "check_current3";
			this.check_current3.Size = new Size(54, 16);
			this.check_current3.TabIndex = 1;
			this.check_current3.Text = "     ";
			this.check_current3.UseVisualStyleBackColor = false;
			this.check_current3.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_volt3.AutoSize = true;
			this.check_volt3.BackColor = Color.Blue;
			this.check_volt3.Checked = true;
			this.check_volt3.CheckState = CheckState.Checked;
			this.check_volt3.Location = new Point(836, 298);
			this.check_volt3.Name = "check_volt3";
			this.check_volt3.Size = new Size(54, 16);
			this.check_volt3.TabIndex = 0;
			this.check_volt3.Text = "     ";
			this.check_volt3.UseVisualStyleBackColor = false;
			this.check_volt3.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_tem4.AutoSize = true;
			this.check_tem4.BackColor = Color.Red;
			this.check_tem4.Location = new Point(836, 500);
			this.check_tem4.Name = "check_tem4";
			this.check_tem4.Size = new Size(54, 16);
			this.check_tem4.TabIndex = 3;
			this.check_tem4.Text = "     ";
			this.check_tem4.UseVisualStyleBackColor = false;
			this.check_tem4.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_caps4.AutoSize = true;
			this.check_caps4.BackColor = Color.DarkOrange;
			this.check_caps4.Location = new Point(836, 478);
			this.check_caps4.Name = "check_caps4";
			this.check_caps4.Size = new Size(54, 16);
			this.check_caps4.TabIndex = 2;
			this.check_caps4.Text = "     ";
			this.check_caps4.UseVisualStyleBackColor = false;
			this.check_caps4.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_current4.AutoSize = true;
			this.check_current4.BackColor = Color.Green;
			this.check_current4.Checked = true;
			this.check_current4.CheckState = CheckState.Checked;
			this.check_current4.Location = new Point(836, 456);
			this.check_current4.Name = "check_current4";
			this.check_current4.Size = new Size(54, 16);
			this.check_current4.TabIndex = 1;
			this.check_current4.Text = "     ";
			this.check_current4.UseVisualStyleBackColor = false;
			this.check_current4.CheckedChanged += this.check_volt1_CheckedChanged;
			this.check_volt4.AutoSize = true;
			this.check_volt4.BackColor = Color.Blue;
			this.check_volt4.Checked = true;
			this.check_volt4.CheckState = CheckState.Checked;
			this.check_volt4.Location = new Point(836, 434);
			this.check_volt4.Name = "check_volt4";
			this.check_volt4.Size = new Size(54, 16);
			this.check_volt4.TabIndex = 0;
			this.check_volt4.Text = "     ";
			this.check_volt4.UseVisualStyleBackColor = false;
			this.check_volt4.CheckedChanged += this.check_volt1_CheckedChanged;
			this.groupBox_solt2.BackColor = SystemColors.Control;
			this.groupBox_solt2.Controls.Add(this.button2);
			this.groupBox_solt2.Controls.Add(this.label6);
			this.groupBox_solt2.Location = new Point(0, 120);
			this.groupBox_solt2.Name = "groupBox_solt2";
			this.groupBox_solt2.Size = new Size(500, 120);
			this.groupBox_solt2.TabIndex = 35;
			this.groupBox_solt2.TabStop = false;
			this.button2.FlatStyle = FlatStyle.Popup;
			this.button2.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button2.ImageAlign = ContentAlignment.MiddleLeft;
			this.button2.Location = new Point(164, 18);
			this.button2.Margin = new Padding(1);
			this.button2.Name = "button2";
			this.button2.Size = new Size(320, 80);
			this.button2.TabIndex = 51;
			this.button2.Text = "LiIon  Charge  1.00A/-0.50A\r\n";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += this.button1_Click_1;
			this.label6.Font = new Font("Microsoft YaHei", 42f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 134);
			this.label6.Location = new Point(18, 35);
			this.label6.Name = "label6";
			this.label6.Size = new Size(84, 75);
			this.label6.TabIndex = 51;
			this.label6.Text = "2";
			this.label6.TextAlign = ContentAlignment.MiddleCenter;
			this.btn_loaddevice2.Location = new Point(730, 517);
			this.btn_loaddevice2.Name = "btn_loaddevice2";
			this.btn_loaddevice2.Size = new Size(96, 25);
			this.btn_loaddevice2.TabIndex = 25;
			this.btn_loaddevice2.Text = "Load from #2";
			this.btn_loaddevice2.UseVisualStyleBackColor = true;
			this.btn_loaddevice2.Visible = false;
			this.btn_loaddevice2.Click += this.btn_loaddevice2_Click;
			this.btn_setdevice2.Location = new Point(836, 517);
			this.btn_setdevice2.Name = "btn_setdevice2";
			this.btn_setdevice2.Size = new Size(86, 25);
			this.btn_setdevice2.TabIndex = 24;
			this.btn_setdevice2.Text = "Send to #2";
			this.btn_setdevice2.UseVisualStyleBackColor = true;
			this.btn_setdevice2.Visible = false;
			this.btn_setdevice2.Click += this.btn_setdevice1_Click;
			this.groupBox_solt3.BackColor = SystemColors.Control;
			this.groupBox_solt3.Controls.Add(this.button3);
			this.groupBox_solt3.Controls.Add(this.label7);
			this.groupBox_solt3.Location = new Point(0, 240);
			this.groupBox_solt3.Name = "groupBox_solt3";
			this.groupBox_solt3.Size = new Size(500, 120);
			this.groupBox_solt3.TabIndex = 36;
			this.groupBox_solt3.TabStop = false;
			this.button3.FlatStyle = FlatStyle.Popup;
			this.button3.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button3.ImageAlign = ContentAlignment.MiddleLeft;
			this.button3.Location = new Point(164, 28);
			this.button3.Margin = new Padding(1);
			this.button3.Name = "button3";
			this.button3.Size = new Size(320, 80);
			this.button3.TabIndex = 53;
			this.button3.Text = "LiIon  Charge  1.00A/-0.50A\r\n\r\n";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += this.button1_Click_1;
			this.label7.Font = new Font("Microsoft YaHei", 42f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 134);
			this.label7.Location = new Point(18, 28);
			this.label7.Name = "label7";
			this.label7.Size = new Size(84, 66);
			this.label7.TabIndex = 52;
			this.label7.Text = "3";
			this.label7.TextAlign = ContentAlignment.MiddleCenter;
			this.btn_loaddevice3.Location = new Point(730, 475);
			this.btn_loaddevice3.Name = "btn_loaddevice3";
			this.btn_loaddevice3.Size = new Size(96, 25);
			this.btn_loaddevice3.TabIndex = 25;
			this.btn_loaddevice3.Text = "Load from #3";
			this.btn_loaddevice3.UseVisualStyleBackColor = true;
			this.btn_loaddevice3.Visible = false;
			this.btn_loaddevice3.Click += this.btn_loaddevice3_Click;
			this.btn_setdevice3.Location = new Point(836, 475);
			this.btn_setdevice3.Name = "btn_setdevice3";
			this.btn_setdevice3.Size = new Size(86, 25);
			this.btn_setdevice3.TabIndex = 24;
			this.btn_setdevice3.Text = "Send to #3";
			this.btn_setdevice3.UseVisualStyleBackColor = true;
			this.btn_setdevice3.Visible = false;
			this.btn_setdevice3.Click += this.btn_setdevice1_Click;
			this.groupBox_solt4.BackColor = SystemColors.Control;
			this.groupBox_solt4.Controls.Add(this.button4);
			this.groupBox_solt4.Controls.Add(this.label8);
			this.groupBox_solt4.Location = new Point(0, 360);
			this.groupBox_solt4.Name = "groupBox_solt4";
			this.groupBox_solt4.Size = new Size(500, 120);
			this.groupBox_solt4.TabIndex = 37;
			this.groupBox_solt4.TabStop = false;
			this.button4.FlatStyle = FlatStyle.Popup;
			this.button4.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button4.ImageAlign = ContentAlignment.MiddleLeft;
			this.button4.Location = new Point(164, 18);
			this.button4.Margin = new Padding(1);
			this.button4.Name = "button4";
			this.button4.Size = new Size(320, 80);
			this.button4.TabIndex = 54;
			this.button4.Text = "LiIon  Charge  1.00A/-0.50A\r\n";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += this.button1_Click_1;
			this.label8.Font = new Font("Microsoft YaHei", 42f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 134);
			this.label8.Location = new Point(18, 23);
			this.label8.Name = "label8";
			this.label8.Size = new Size(84, 75);
			this.label8.TabIndex = 53;
			this.label8.Text = "4";
			this.label8.TextAlign = ContentAlignment.MiddleCenter;
			this.btn_loaddevice4.Location = new Point(518, 475);
			this.btn_loaddevice4.Name = "btn_loaddevice4";
			this.btn_loaddevice4.Size = new Size(100, 25);
			this.btn_loaddevice4.TabIndex = 25;
			this.btn_loaddevice4.Text = "Load from #4";
			this.btn_loaddevice4.UseVisualStyleBackColor = true;
			this.btn_loaddevice4.Visible = false;
			this.btn_loaddevice4.Click += this.btn_loaddevice4_Click;
			this.btn_setdevice4.Location = new Point(624, 475);
			this.btn_setdevice4.Name = "btn_setdevice4";
			this.btn_setdevice4.Size = new Size(100, 25);
			this.btn_setdevice4.TabIndex = 24;
			this.btn_setdevice4.Text = "Send to #4";
			this.btn_setdevice4.UseVisualStyleBackColor = true;
			this.btn_setdevice4.Visible = false;
			this.btn_setdevice4.Click += this.btn_setdevice1_Click;
			this.button_update.Enabled = false;
			this.button_update.FlatStyle = FlatStyle.Popup;
			this.button_update.Location = new Point(6, 359);
			this.button_update.Name = "button_update";
			this.button_update.Size = new Size(65, 25);
			this.button_update.TabIndex = 39;
			this.button_update.Text = "Update";
			this.button_update.UseVisualStyleBackColor = true;
			this.button_update.Click += this.button_update_Click;
			this.timer3.Interval = 250;
			this.timer3.Tick += this.timer3_Tick;
			this.button_system.Enabled = false;
			this.button_system.FlatStyle = FlatStyle.Popup;
			this.button_system.Location = new Point(257, 17);
			this.button_system.Name = "button_system";
			this.button_system.Size = new Size(161, 25);
			this.button_system.TabIndex = 43;
			this.button_system.Text = "Checking for new version";
			this.button_system.TextImageRelation = TextImageRelation.ImageAboveText;
			this.button_system.UseVisualStyleBackColor = true;
			this.button_system.Click += this.btn_system_Click;
			this.label_usb_status.BackColor = Color.White;
			this.label_usb_status.BorderStyle = BorderStyle.Fixed3D;
			this.label_usb_status.Font = new Font("SimSun", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label_usb_status.ForeColor = Color.Green;
			this.label_usb_status.Location = new Point(910, 546);
			this.label_usb_status.Name = "label_usb_status";
			this.label_usb_status.Size = new Size(55, 14);
			this.label_usb_status.TabIndex = 44;
			this.label_usb_status.Text = "USB ON";
			this.tabControl1.Appearance = TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.ItemSize = new Size(50, 25);
			this.tabControl1.Location = new Point(2, 35);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new Size(985, 791);
			this.tabControl1.TabIndex = 45;
			this.tabPage1.Controls.Add(this.label_usb_status);
			this.tabPage1.Controls.Add(this.check_tem4);
			this.tabPage1.Controls.Add(this.label_SOLT2);
			this.tabPage1.Controls.Add(this.check_caps4);
			this.tabPage1.Controls.Add(this.check_tem3);
			this.tabPage1.Controls.Add(this.button_start);
			this.tabPage1.Controls.Add(this.check_current4);
			this.tabPage1.Controls.Add(this.label_SOLT3);
			this.tabPage1.Controls.Add(this.button_save);
			this.tabPage1.Controls.Add(this.check_volt4);
			this.tabPage1.Controls.Add(this.label_SOLT4);
			this.tabPage1.Controls.Add(this.check_tem2);
			this.tabPage1.Controls.Add(this.check_caps3);
			this.tabPage1.Controls.Add(this.check_volt3);
			this.tabPage1.Controls.Add(this.check_caps2);
			this.tabPage1.Controls.Add(this.check_current2);
			this.tabPage1.Controls.Add(this.check_volt2);
			this.tabPage1.Controls.Add(this.check_tem1);
			this.tabPage1.Controls.Add(this.check_caps1);
			this.tabPage1.Controls.Add(this.check_current1);
			this.tabPage1.Controls.Add(this.check_volt1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.check_current3);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.label_SOLT1);
			this.tabPage1.Font = new Font("SimSun", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.tabPage1.Location = new Point(4, 29);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new Padding(3);
			this.tabPage1.Size = new Size(977, 758);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "HOME";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.button_start.Enabled = false;
			this.button_start.FlatStyle = FlatStyle.Popup;
			this.button_start.Image = Resources.icon_operation;
			this.button_start.Location = new Point(915, 62);
			this.button_start.Name = "button_start";
			this.button_start.Size = new Size(50, 50);
			this.button_start.TabIndex = 40;
			this.button_start.Text = "Star";
			this.button_start.TextAlign = ContentAlignment.BottomCenter;
			this.button_start.TextImageRelation = TextImageRelation.ImageAboveText;
			this.button_start.UseVisualStyleBackColor = true;
			this.button_start.Click += this.StartMenuItem_Click;
			this.button_save.Enabled = false;
			this.button_save.FlatStyle = FlatStyle.Popup;
			this.button_save.Image = Resources.save_bmp;
			this.button_save.Location = new Point(915, 3);
			this.button_save.Name = "button_save";
			this.button_save.Size = new Size(50, 50);
			this.button_save.TabIndex = 38;
			this.button_save.Text = "&Save";
			this.button_save.TextImageRelation = TextImageRelation.ImageAboveText;
			this.button_save.UseVisualStyleBackColor = true;
			this.button_save.Click += this.SaveMenuItem_Click;
			this.tabPage2.Controls.Add(this.groupBox_system);
			this.tabPage2.Controls.Add(this.button_save_all);
			this.tabPage2.Controls.Add(this.btn_loaddevice1);
			this.tabPage2.Controls.Add(this.btn_setdevice1);
			this.tabPage2.Controls.Add(this.button_load_all);
			this.tabPage2.Controls.Add(this.groupBox_solt1);
			this.tabPage2.Controls.Add(this.btn_setdevice2);
			this.tabPage2.Controls.Add(this.btn_loaddevice2);
			this.tabPage2.Controls.Add(this.btn_setdevice3);
			this.tabPage2.Controls.Add(this.btn_loaddevice3);
			this.tabPage2.Controls.Add(this.btn_setdevice4);
			this.tabPage2.Controls.Add(this.btn_loaddevice4);
			this.tabPage2.Controls.Add(this.groupBox_solt2);
			this.tabPage2.Controls.Add(this.groupBox_solt3);
			this.tabPage2.Controls.Add(this.groupBox_solt4);
			this.tabPage2.Location = new Point(4, 29);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new Padding(3);
			this.tabPage2.Size = new Size(977, 758);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "SETTING";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.groupBox_system.BackColor = SystemColors.Control;
			this.groupBox_system.Controls.Add(this.progressBar1);
			this.groupBox_system.Controls.Add(this.label44);
			this.groupBox_system.Controls.Add(this.button_update);
			this.groupBox_system.Controls.Add(this.list_firmware);
			this.groupBox_system.Controls.Add(this.label_firmware);
			this.groupBox_system.Controls.Add(this.label_version);
			this.groupBox_system.Controls.Add(this.text_fm_info);
			this.groupBox_system.Controls.Add(this.button_system);
			this.groupBox_system.Font = new Font("SimSun", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.groupBox_system.Location = new Point(518, 9);
			this.groupBox_system.Name = "groupBox_system";
			this.groupBox_system.Size = new Size(424, 449);
			this.groupBox_system.TabIndex = 50;
			this.groupBox_system.TabStop = false;
			this.groupBox_system.Text = "Firmware";
			this.progressBar1.Location = new Point(77, 361);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new Size(321, 23);
			this.progressBar1.TabIndex = 46;
			this.label44.AutoSize = true;
			this.label44.Location = new Point(4, 231);
			this.label44.Name = "label44";
			this.label44.Size = new Size(131, 12);
			this.label44.TabIndex = 49;
			this.label44.Text = "Firmware information:";
			this.list_firmware.FormattingEnabled = true;
			this.list_firmware.ItemHeight = 12;
			this.list_firmware.Location = new Point(6, 58);
			this.list_firmware.Name = "list_firmware";
			this.list_firmware.Size = new Size(411, 160);
			this.list_firmware.TabIndex = 44;
			this.list_firmware.SelectedIndexChanged += this.list_firmware_SelectedIndexChanged;
			this.label_firmware.AutoSize = true;
			this.label_firmware.Location = new Point(5, 43);
			this.label_firmware.Name = "label_firmware";
			this.label_firmware.Size = new Size(89, 12);
			this.label_firmware.TabIndex = 45;
			this.label_firmware.Text = "Firmware list:";
			this.label_version.AutoSize = true;
			this.label_version.Location = new Point(6, 22);
			this.label_version.Name = "label_version";
			this.label_version.Size = new Size(53, 12);
			this.label_version.TabIndex = 47;
			this.label_version.Text = "Version:";
			this.text_fm_info.BackColor = SystemColors.HighlightText;
			this.text_fm_info.Location = new Point(7, 246);
			this.text_fm_info.Multiline = true;
			this.text_fm_info.Name = "text_fm_info";
			this.text_fm_info.ReadOnly = true;
			this.text_fm_info.Size = new Size(410, 107);
			this.text_fm_info.TabIndex = 48;
			this.button_save_all.Enabled = false;
			this.button_save_all.FlatStyle = FlatStyle.Popup;
			this.button_save_all.Location = new Point(6, 502);
			this.button_save_all.Name = "button_save_all";
			this.button_save_all.Size = new Size(115, 40);
			this.button_save_all.TabIndex = 35;
			this.button_save_all.Text = "Send to device";
			this.button_save_all.UseVisualStyleBackColor = true;
			this.button_save_all.Click += this.button2_Click;
			this.button_load_all.Enabled = false;
			this.button_load_all.FlatStyle = FlatStyle.Popup;
			this.button_load_all.Location = new Point(325, 502);
			this.button_load_all.Name = "button_load_all";
			this.button_load_all.Size = new Size(110, 40);
			this.button_load_all.TabIndex = 35;
			this.button_load_all.Text = "Load from device";
			this.button_load_all.UseVisualStyleBackColor = true;
			this.button_load_all.Click += this.button1_Click;
			this.button_setting.FlatStyle = FlatStyle.Popup;
			this.button_setting.Image = Resources.icon_operation;
			this.button_setting.Location = new Point(564, 0);
			this.button_setting.Name = "button_setting";
			this.button_setting.Size = new Size(80, 50);
			this.button_setting.TabIndex = 42;
			this.button_setting.Text = "Setting";
			this.button_setting.TextAlign = ContentAlignment.BottomCenter;
			this.button_setting.TextImageRelation = TextImageRelation.ImageAboveText;
			this.button_setting.UseVisualStyleBackColor = true;
			this.button_setting.Visible = false;
			this.button_setting.Click += this.ParamMenuItem_Click;
			this.button_home.FlatStyle = FlatStyle.Popup;
			this.button_home.Image = Resources.icon_operation;
			this.button_home.Location = new Point(478, 0);
			this.button_home.Name = "button_home";
			this.button_home.Size = new Size(80, 50);
			this.button_home.TabIndex = 41;
			this.button_home.Text = "Home";
			this.button_home.TextAlign = ContentAlignment.BottomCenter;
			this.button_home.TextImageRelation = TextImageRelation.ImageAboveText;
			this.button_home.UseVisualStyleBackColor = true;
			this.button_home.Visible = false;
			this.button_home.Click += this.btn_home_Click;
			this.label_logo.Image = (Image)componentResourceManager.GetObject("label_logo.Image");
			this.label_logo.Location = new Point(0, 0);
			this.label_logo.Name = "label_logo";
			this.label_logo.Size = new Size(32, 32);
			this.label_logo.TabIndex = 46;
			this.label_sver.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label_sver.Location = new Point(48, 8);
			this.label_sver.Name = "label_sver";
			this.label_sver.Size = new Size(180, 23);
			this.label_sver.TabIndex = 47;
			this.label_sver.Text = "MC3000 Monitor V1.04";
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.AliceBlue;
			base.ClientSize = new Size(983, 632);
			base.Controls.Add(this.label_sver);
			base.Controls.Add(this.label_logo);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.button_setting);
			base.Controls.Add(this.button_home);
			base.Controls.Add(this.btn_exit);
			base.Controls.Add(this.btn_mini);
			base.Controls.Add(this.lb_verson);
			base.Controls.Add(this.btn_boot);
			base.Controls.Add(this.btn_app);
			base.Controls.Add(this.DownLoad);
			base.Controls.Add(this.menuStrip1);
			this.ForeColor = Color.Black;
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip1;
			base.Margin = new Padding(2);
			base.MaximizeBox = false;
			this.MaximumSize = new Size(1280, 860);
			this.MinimumSize = new Size(392, 149);
			base.Name = "FormLoader";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ChargeMonitor V2";
			base.Shown += this.FormLoader_Shown;
			base.MouseDown += this.label_SOLT1_MouseDown;
			base.MouseMove += this.label_SOLT1_MouseMove;
			base.MouseUp += this.label_SOLT1_MouseUp;
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox_solt1.ResumeLayout(false);
			this.groupBox_solt2.ResumeLayout(false);
			this.groupBox_solt3.ResumeLayout(false);
			this.groupBox_solt4.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox_system.ResumeLayout(false);
			this.groupBox_system.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000B9 RID: 185
		protected const uint MAX_DATA_RECORD = 864000u;

		// Token: 0x040000BA RID: 186
		public const byte DATA_END1 = 255;

		// Token: 0x040000BB RID: 187
		public const byte DATA_END2 = 255;

		// Token: 0x040000BC RID: 188
		public const byte CMD_PHONE_TO_MCU_START_CHARGER = 5;

		// Token: 0x040000BD RID: 189
		public const byte CMD_PHONE_TO_MCU_STOP_CHARGER = 254;

		// Token: 0x040000BE RID: 190
		public const byte CMD_PHONE_TO_MCU_SYSTEM_SET_SAVE = 17;

		// Token: 0x040000BF RID: 191
		public const byte CMD_PHONE_TO_MCU_TAKE_DATA = 85;

		// Token: 0x040000C0 RID: 192
		public const byte CMD_PHONE_TO_MCU_SYSTEM_FEED = 90;

		// Token: 0x040000C1 RID: 193
		public const byte CMD_PHONE_TO_MCU_STATUS_FEED = 95;

		// Token: 0x040000C2 RID: 194
		public const byte CMD_PHONE_TO_MCU_EN_BUZZ = 128;

		// Token: 0x040000C3 RID: 195
		public const byte product_ID = 0;

		// Token: 0x040000C4 RID: 196
		public const byte CHAGE_MOVDATA_ST = 4;

		// Token: 0x040000C5 RID: 197
		public const byte CHAGE_MOVCMD_ST = 2;

		// Token: 0x040000C6 RID: 198
		public const byte CHAGE_MOVSYS_ST = 5;

		// Token: 0x040000C7 RID: 199
		public const byte UART_DATA_START = 15;

		// Token: 0x040000C8 RID: 200
		public const byte SEND_DATA_ST = 4;

		// Token: 0x040000C9 RID: 201
		public const byte CMD_USB_UPDATE = 136;

		// Token: 0x040000CA RID: 202
		public const byte CMD_PHONE_TO_MCU_MACHINE_ID = 87;

		// Token: 0x040000CB RID: 203
		private bool FileLoaded = false;

		// Token: 0x040000CC RID: 204
		private bool DeviceFounded = false;

		// Token: 0x040000CD RID: 205
		private bool dataReceived = false;

		// Token: 0x040000CE RID: 206
		private UsbHidPort usb;

		// Token: 0x040000CF RID: 207
		private byte[] BinBuffer = new byte[65536];

		// Token: 0x040000D0 RID: 208
		private byte[] outPacket = new byte[65];

		// Token: 0x040000D1 RID: 209
		private byte[] inPacket = new byte[65];

		// Token: 0x040000D2 RID: 210
		private byte[] head = new byte[3];

		// Token: 0x040000D3 RID: 211
		private byte[] loadHead = new byte[3];

		// Token: 0x040000D4 RID: 212
		private ChargerData[] BatParam;

		// Token: 0x040000D5 RID: 213
		private Firmware_Struct[] fs;

		// Token: 0x040000D6 RID: 214
		private Machine_info machine_info;

		// Token: 0x040000D7 RID: 215
		private Battery Batt_Type;

		// Token: 0x040000D8 RID: 216
		private int[] DCHG_VOL_H = new int[]
		{
			3300,
			3000,
			3400,
			1000,
			1000,
			1300,
			1000
		};

		// Token: 0x040000D9 RID: 217
		private int[] DCHG_VOL_DEFAULT = new int[]
		{
			3000,
			2900,
			3300,
			800,
			800,
			1200,
			800
		};

		// Token: 0x040000DA RID: 218
		private int[] DCHG_VOL_L = new int[]
		{
			2500,
			2750,
			3100,
			500,
			500,
			1000,
			500
		};

		// Token: 0x040000DB RID: 219
		private int[] CHG_VOL_H = new int[]
		{
			4250,
			3650,
			4350,
			1800,
			1800,
			1950,
			1800
		};

		// Token: 0x040000DC RID: 220
		private int[] CHG_VOL_DEFAULT = new int[]
		{
			4200,
			3600,
			4350,
			1650,
			1650,
			1900,
			1650
		};

		// Token: 0x040000DD RID: 221
		private int[] CHG_VOL_L = new int[]
		{
			4180,
			3580,
			4300,
			1500,
			1500,
			1850,
			1500
		};

		// Token: 0x040000DE RID: 222
		private int[] CHG_VOL_STORGE = new int[]
		{
			3800,
			3300,
			3900
		};

		// Token: 0x040000DF RID: 223
		private bool bcharge = false;

		// Token: 0x040000E0 RID: 224
		private bool[] Curve_Volt;

		// Token: 0x040000E1 RID: 225
		private bool[] Curve_Cur;

		// Token: 0x040000E2 RID: 226
		private bool[] Curve_Caps;

		// Token: 0x040000E3 RID: 227
		private bool[] Curve_Tem;

		// Token: 0x040000E4 RID: 228
		private bool[] bstop;

		// Token: 0x040000E5 RID: 229
		private bool[] bfinish;

		// Token: 0x040000E6 RID: 230
		private int[] Voltage;

		// Token: 0x040000E7 RID: 231
		private int[] Current;

		// Token: 0x040000E8 RID: 232
		private int[] Caps;

		// Token: 0x040000E9 RID: 233
		private int[] Caps_Decimal;

		// Token: 0x040000EA RID: 234
		private int[] dCaps;

		// Token: 0x040000EB RID: 235
		private int[] Batt_Tem;

		// Token: 0x040000EC RID: 236
		private int[][] Voltage_Pool;

		// Token: 0x040000ED RID: 237
		private int[][] Cur_Pool;

		// Token: 0x040000EE RID: 238
		private int[][] Caps_Pool;

		// Token: 0x040000EF RID: 239
		private int[][] Batt_Tem_Pool;

		// Token: 0x040000F0 RID: 240
		private int[][] Voltage_Data;

		// Token: 0x040000F1 RID: 241
		private int[][] Cur_Data;

		// Token: 0x040000F2 RID: 242
		private int[][] Caps_Data;

		// Token: 0x040000F3 RID: 243
		private int[][] Batt_Tem_Data;

		// Token: 0x040000F4 RID: 244
		private Font font;

		// Token: 0x040000F5 RID: 245
		private Font font2;

		// Token: 0x040000F6 RID: 246
		private Pen pen;

		// Token: 0x040000F7 RID: 247
		private bool[] bMeasure;

		// Token: 0x040000F8 RID: 248
		private float[] index_scale;

		// Token: 0x040000F9 RID: 249
		private int[] Pool_Index;

		// Token: 0x040000FA RID: 250
		private int[] Data_Index;

		// Token: 0x040000FB RID: 251
		private int[] vMax;

		// Token: 0x040000FC RID: 252
		private int[] vMin;

		// Token: 0x040000FD RID: 253
		private int[] cMax;

		// Token: 0x040000FE RID: 254
		private int[] cMin;

		// Token: 0x040000FF RID: 255
		private int[] curMax;

		// Token: 0x04000100 RID: 256
		private int[] curMin;

		// Token: 0x04000101 RID: 257
		private int[] temMax;

		// Token: 0x04000102 RID: 258
		private int[] temMin;

		// Token: 0x04000103 RID: 259
		private float[] yUnit;

		// Token: 0x04000104 RID: 260
		private float[] Cap_yUnit;

		// Token: 0x04000105 RID: 261
		private float[] Cur_yUnit;

		// Token: 0x04000106 RID: 262
		private float[] Tem_yUnit;

		// Token: 0x04000107 RID: 263
		private int[] xUnit;

		// Token: 0x04000108 RID: 264
		private int[] Label_Width;

		// Token: 0x04000109 RID: 265
		private int[] Label_Heigh;

		// Token: 0x0400010A RID: 266
		private int[] work_time;

		// Token: 0x0400010B RID: 267
		private int[] tMax;

		// Token: 0x0400010C RID: 268
		private int[] tick2;

		// Token: 0x0400010D RID: 269
		private int[] Update_Unit;

		// Token: 0x0400010E RID: 270
		private string[] BatInfo;

		// Token: 0x0400010F RID: 271
		private Param param;

		// Token: 0x04000110 RID: 272
		private string[] li_mode;

		// Token: 0x04000111 RID: 273
		private string[] ni_mode;

		// Token: 0x04000112 RID: 274
		private int max_add;

		// Token: 0x04000113 RID: 275
		private int addSend;

		// Token: 0x04000114 RID: 276
		private int packet_counter;

		// Token: 0x04000115 RID: 277
		private uint checkSum;

		// Token: 0x04000116 RID: 278
		private FormLoader.REQENUM request;

		// Token: 0x04000117 RID: 279
		private FormLoader.UPDATAENUM updataStep;

		// Token: 0x04000118 RID: 280
		private bool waitAck;

		// Token: 0x04000119 RID: 281
		private bool downLoadFail;

		// Token: 0x0400011A RID: 282
		private int timerCounter;

		// Token: 0x0400011B RID: 283
		private int start_update;

		// Token: 0x0400011C RID: 284
		private int wait_count;

		// Token: 0x0400011D RID: 285
		private bool vectorStart;

		// Token: 0x0400011E RID: 286
		private int vector;

		// Token: 0x0400011F RID: 287
		private int vectorBytes;

		// Token: 0x04000120 RID: 288
		private int vectorBytesSended;

		// Token: 0x04000121 RID: 289
		private int vectorDelay;

		// Token: 0x04000122 RID: 290
		private StringBuilder BinText;

		// Token: 0x04000123 RID: 291
		private char[] hexchar;

		// Token: 0x04000124 RID: 292
		private int in_count;

		// Token: 0x04000125 RID: 293
		private static string[] bat_type = new string[]
		{
			"LiIon",
			"LiFe",
			"LiHV",
			"NiMH",
			"NiCd",
			"NiZn",
			"ENELOOP"
		};

		// Token: 0x04000126 RID: 294
		private static string[] error_str = new string[]
		{
			" Input Low!    ",
			"Input High!    ",
			" MCP3424-1 Err ",
			" MCP3424-2 Err ",
			"Battery Break! ",
			"Check Battery! ",
			"Capacity Cut!  ",
			"Time Cut!      ",
			"Int.Temp High! ",
			"Batt.Temp High!",
			" Over Load!    ",
			"Batt. Reverse! ",
			"AnKnow Error!  "
		};

		// Token: 0x04000127 RID: 295
		private int solt_id;

		// Token: 0x04000128 RID: 296
		private int stop_count;

		// Token: 0x04000129 RID: 297
		private bool bmousedown;

		// Token: 0x0400012A RID: 298
		private Point new_p;

		// Token: 0x0400012B RID: 299
		private Point old_p;

		// Token: 0x0400012C RID: 300
		private bool bread_chrager_data;

		// Token: 0x0400012D RID: 301
		private bool bwrite_chrager_data;

		// Token: 0x0400012E RID: 302
		private int mouse_x;

		// Token: 0x0400012F RID: 303
		private int mouse_y;

		// Token: 0x04000130 RID: 304
		private string update_ok_version;

		// Token: 0x04000131 RID: 305
		private IContainer components;

		// Token: 0x04000132 RID: 306
		private Button DownLoad;

		// Token: 0x04000133 RID: 307
		private Button btn_app;

		// Token: 0x04000134 RID: 308
		private Timer timer1;

		// Token: 0x04000135 RID: 309
		private Button btn_boot;

		// Token: 0x04000136 RID: 310
		private Label lb_verson;

		// Token: 0x04000137 RID: 311
		private Timer timer2;

		// Token: 0x04000138 RID: 312
		private Label label_SOLT1;

		// Token: 0x04000139 RID: 313
		private Label label_SOLT2;

		// Token: 0x0400013A RID: 314
		private Label label_SOLT3;

		// Token: 0x0400013B RID: 315
		private Label label_SOLT4;

		// Token: 0x0400013C RID: 316
		private MenuStrip menuStrip1;

		// Token: 0x0400013D RID: 317
		private ToolStripMenuItem FileMenuItem;

		// Token: 0x0400013E RID: 318
		private ToolStripMenuItem LoadMenuItem;

		// Token: 0x0400013F RID: 319
		private ToolStripMenuItem SaveMenuItem;

		// Token: 0x04000140 RID: 320
		private ToolStripMenuItem ExitMenuItem;

		// Token: 0x04000141 RID: 321
		private ToolStripMenuItem ToolsMenuItem;

		// Token: 0x04000142 RID: 322
		private ToolStripMenuItem AboutMenuItem;

		// Token: 0x04000143 RID: 323
		private SaveFileDialog saveFileDialog1;

		// Token: 0x04000144 RID: 324
		private OpenFileDialog openFileDialog1;

		// Token: 0x04000145 RID: 325
		private ToolStripMenuItem ParamMenuItem;

		// Token: 0x04000146 RID: 326
		private ToolStripMenuItem StartMenuItem;

		// Token: 0x04000147 RID: 327
		private ToolStripMenuItem SystemMenuItem;

		// Token: 0x04000148 RID: 328
		private ToolStripMenuItem VersionMenuItem;

		// Token: 0x04000149 RID: 329
		private ToolStripMenuItem HelpMenuItem;

		// Token: 0x0400014A RID: 330
		private Label label1;

		// Token: 0x0400014B RID: 331
		private Label label2;

		// Token: 0x0400014C RID: 332
		private Label label3;

		// Token: 0x0400014D RID: 333
		private Label label4;

		// Token: 0x0400014E RID: 334
		private Button btn_mini;

		// Token: 0x0400014F RID: 335
		private Button btn_exit;

		// Token: 0x04000150 RID: 336
		private GroupBox groupBox_solt1;

		// Token: 0x04000151 RID: 337
		private Button btn_setdevice1;

		// Token: 0x04000152 RID: 338
		private Button btn_loaddevice1;

		// Token: 0x04000153 RID: 339
		private CheckBox check_tem1;

		// Token: 0x04000154 RID: 340
		private CheckBox check_caps1;

		// Token: 0x04000155 RID: 341
		private CheckBox check_current1;

		// Token: 0x04000156 RID: 342
		private CheckBox check_volt1;

		// Token: 0x04000157 RID: 343
		private CheckBox check_tem2;

		// Token: 0x04000158 RID: 344
		private CheckBox check_caps2;

		// Token: 0x04000159 RID: 345
		private CheckBox check_current2;

		// Token: 0x0400015A RID: 346
		private CheckBox check_volt2;

		// Token: 0x0400015B RID: 347
		private CheckBox check_tem3;

		// Token: 0x0400015C RID: 348
		private CheckBox check_caps3;

		// Token: 0x0400015D RID: 349
		private CheckBox check_current3;

		// Token: 0x0400015E RID: 350
		private CheckBox check_volt3;

		// Token: 0x0400015F RID: 351
		private CheckBox check_tem4;

		// Token: 0x04000160 RID: 352
		private CheckBox check_caps4;

		// Token: 0x04000161 RID: 353
		private CheckBox check_current4;

		// Token: 0x04000162 RID: 354
		private CheckBox check_volt4;

		// Token: 0x04000163 RID: 355
		private GroupBox groupBox_solt2;

		// Token: 0x04000164 RID: 356
		private Button btn_loaddevice2;

		// Token: 0x04000165 RID: 357
		private Button btn_setdevice2;

		// Token: 0x04000166 RID: 358
		private GroupBox groupBox_solt3;

		// Token: 0x04000167 RID: 359
		private Button btn_loaddevice3;

		// Token: 0x04000168 RID: 360
		private Button btn_setdevice3;

		// Token: 0x04000169 RID: 361
		private GroupBox groupBox_solt4;

		// Token: 0x0400016A RID: 362
		private Button btn_loaddevice4;

		// Token: 0x0400016B RID: 363
		private Button btn_setdevice4;

		// Token: 0x0400016C RID: 364
		private Button button_save;

		// Token: 0x0400016D RID: 365
		private Button button_update;

		// Token: 0x0400016E RID: 366
		private Button button_start;

		// Token: 0x0400016F RID: 367
		private Timer timer3;

		// Token: 0x04000170 RID: 368
		private Button button_home;

		// Token: 0x04000171 RID: 369
		private Button button_setting;

		// Token: 0x04000172 RID: 370
		private Button button_system;

		// Token: 0x04000173 RID: 371
		private Label label_usb_status;

		// Token: 0x04000174 RID: 372
		private TabControl tabControl1;

		// Token: 0x04000175 RID: 373
		private TabPage tabPage2;

		// Token: 0x04000176 RID: 374
		private Button button_save_all;

		// Token: 0x04000177 RID: 375
		private Button button_load_all;

		// Token: 0x04000178 RID: 376
		private ListBox list_firmware;

		// Token: 0x04000179 RID: 377
		private Label label_firmware;

		// Token: 0x0400017A RID: 378
		private ProgressBar progressBar1;

		// Token: 0x0400017B RID: 379
		private Label label_version;

		// Token: 0x0400017C RID: 380
		private Label label44;

		// Token: 0x0400017D RID: 381
		private TextBox text_fm_info;

		// Token: 0x0400017E RID: 382
		private Button button1;

		// Token: 0x0400017F RID: 383
		private GroupBox groupBox_system;

		// Token: 0x04000180 RID: 384
		private Label label5;

		// Token: 0x04000181 RID: 385
		private Label label6;

		// Token: 0x04000182 RID: 386
		private Label label7;

		// Token: 0x04000183 RID: 387
		private Label label8;

		// Token: 0x04000184 RID: 388
		private Button button2;

		// Token: 0x04000185 RID: 389
		private Button button3;

		// Token: 0x04000186 RID: 390
		private Button button4;

		// Token: 0x04000187 RID: 391
		private Label label_logo;

		// Token: 0x04000188 RID: 392
		private Label label_sver;

		// Token: 0x04000189 RID: 393
		private TabPage tabPage1;

		// Token: 0x02000013 RID: 19
		private enum REQENUM
		{
			// Token: 0x0400018B RID: 395
			get_information,
			// Token: 0x0400018C RID: 396
			start_updata,
			// Token: 0x0400018D RID: 397
			start_vector,
			// Token: 0x0400018E RID: 398
			send_code,
			// Token: 0x0400018F RID: 399
			get_result,
			// Token: 0x04000190 RID: 400
			execute_application
		}

		// Token: 0x02000014 RID: 20
		private enum UPDATAENUM
		{
			// Token: 0x04000192 RID: 402
			get_device_infomation,
			// Token: 0x04000193 RID: 403
			start_updata,
			// Token: 0x04000194 RID: 404
			send_code,
			// Token: 0x04000195 RID: 405
			check_result,
			// Token: 0x04000196 RID: 406
			finsh
		}
	}
}
