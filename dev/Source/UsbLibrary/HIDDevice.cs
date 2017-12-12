using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace UsbLibrary
{
	// Token: 0x0200000A RID: 10
	public abstract class HIDDevice : Win32Usb, IDisposable
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00003C16 File Offset: 0x00001E16
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003C28 File Offset: 0x00001E28
		protected virtual void Dispose(bool bDisposing)
		{
			try
			{
				if (bDisposing)
				{
					if (this.m_oFile != null)
					{
						this.m_oFile.Close();
						this.m_oFile = null;
					}
				}
				if (this.m_hHandle != IntPtr.Zero)
				{
					Win32Usb.CloseHandle(this.m_hHandle);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003CB0 File Offset: 0x00001EB0
		private void Initialise(string strPath)
		{
			this.m_hHandle = Win32Usb.CreateFile(strPath, 3221225472u, 0u, IntPtr.Zero, 3u, 1073741824u, IntPtr.Zero);
			if (!(this.m_hHandle != Win32Usb.InvalidHandleValue))
			{
				this.m_hHandle = IntPtr.Zero;
				throw HIDDeviceException.GenerateWithWinError("Failed to create device file");
			}
			IntPtr lpData;
			if (Win32Usb.HidD_GetPreparsedData(this.m_hHandle, out lpData))
			{
				try
				{
					Win32Usb.HidCaps hidCaps;
					Win32Usb.HidP_GetCaps(lpData, out hidCaps);
					this.m_nInputReportLength = (int)hidCaps.InputReportByteLength;
					this.m_nOutputReportLength = (int)hidCaps.OutputReportByteLength;
					HIDDevice.OutputLength = this.m_nOutputReportLength;
					HIDDevice.InputLength = this.m_nInputReportLength;
					this.m_oFile = new FileStream(new SafeFileHandle(this.m_hHandle, false), FileAccess.ReadWrite, this.m_nInputReportLength, true);
					this.BeginAsyncRead();
				}
				catch (Exception ex)
				{
					throw HIDDeviceException.GenerateWithWinError("Failed to get the detailed data from the hid." + ex.ToString());
				}
				finally
				{
					Win32Usb.HidD_FreePreparsedData(ref lpData);
				}
				return;
			}
			throw HIDDeviceException.GenerateWithWinError("GetPreparsedData failed");
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003DE4 File Offset: 0x00001FE4
		private void BeginAsyncRead()
		{
			byte[] array = new byte[this.m_nInputReportLength];
			this.m_oFile.BeginRead(array, 0, this.m_nInputReportLength, new AsyncCallback(this.ReadCompleted), array);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003E20 File Offset: 0x00002020
		protected void ReadCompleted(IAsyncResult iResult)
		{
			byte[] data = (byte[])iResult.AsyncState;
			try
			{
				this.m_oFile.EndRead(iResult);
				try
				{
					InputReport inputReport = this.CreateInputReport();
					inputReport.SetData(data);
					this.HandleDataReceived(inputReport);
				}
				finally
				{
					this.BeginAsyncRead();
				}
			}
			catch (IOException)
			{
				this.HandleDeviceRemoved();
				if (this.OnDeviceRemoved != null)
				{
					this.OnDeviceRemoved(this, new EventArgs());
				}
				this.Dispose();
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003EC4 File Offset: 0x000020C4
		protected void Write(OutputReport oOutRep)
		{
			try
			{
				this.m_oFile.Write(oOutRep.Buffer, 0, oOutRep.BufferLength);
			}
			catch (IOException ex)
			{
				throw new HIDDeviceException("Probbaly the device was removed" + ex.ToString());
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003F38 File Offset: 0x00002138
		protected virtual void HandleDataReceived(InputReport oInRep)
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003F3B File Offset: 0x0000213B
		protected virtual void HandleDeviceRemoved()
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003F40 File Offset: 0x00002140
		private static string GetDevicePath(IntPtr hInfoSet, ref Win32Usb.DeviceInterfaceData oInterface)
		{
			uint nDeviceInterfaceDetailDataSize = 0u;
			if (!Win32Usb.SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, IntPtr.Zero, 0u, ref nDeviceInterfaceDetailDataSize, IntPtr.Zero))
			{
				Win32Usb.DeviceInterfaceDetailData deviceInterfaceDetailData = default(Win32Usb.DeviceInterfaceDetailData);
				deviceInterfaceDetailData.Size = 5;
				if (Win32Usb.SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, ref deviceInterfaceDetailData, nDeviceInterfaceDetailDataSize, ref nDeviceInterfaceDetailDataSize, IntPtr.Zero))
				{
					return deviceInterfaceDetailData.DevicePath;
				}
			}
			return null;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003FA4 File Offset: 0x000021A4
		public static HIDDevice FindDevice(int nVid, int nPid, Type oType)
		{
			string empty = string.Empty;
			string value = string.Format("vid_{0:x4}&pid_{1:x4}", nVid, nPid);
			Guid hidguid = Win32Usb.HIDGuid;
			IntPtr intPtr = Win32Usb.SetupDiGetClassDevs(ref hidguid, null, IntPtr.Zero, 18u);
			try
			{
				Win32Usb.DeviceInterfaceData deviceInterfaceData = default(Win32Usb.DeviceInterfaceData);
				deviceInterfaceData.Size = Marshal.SizeOf(deviceInterfaceData);
				int num = 0;
				while (Win32Usb.SetupDiEnumDeviceInterfaces(intPtr, 0u, ref hidguid, (uint)num, ref deviceInterfaceData))
				{
					string devicePath = HIDDevice.GetDevicePath(intPtr, ref deviceInterfaceData);
					if (devicePath.IndexOf(value) >= 0)
					{
						HIDDevice hiddevice = (HIDDevice)Activator.CreateInstance(oType);
						hiddevice.Initialise(devicePath);
						return hiddevice;
					}
					num++;
				}
			}
			catch (Exception ex)
			{
				throw HIDDeviceException.GenerateError(ex.ToString());
			}
			finally
			{
				Win32Usb.SetupDiDestroyDeviceInfoList(intPtr);
			}
			return null;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600002C RID: 44 RVA: 0x000040A0 File Offset: 0x000022A0
		// (remove) Token: 0x0600002D RID: 45 RVA: 0x000040DC File Offset: 0x000022DC
		public event EventHandler OnDeviceRemoved;

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00004118 File Offset: 0x00002318
		public int OutputReportLength
		{
			get
			{
				return this.m_nOutputReportLength;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00004130 File Offset: 0x00002330
		public int InputReportLength
		{
			get
			{
				return this.m_nInputReportLength;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004148 File Offset: 0x00002348
		public virtual InputReport CreateInputReport()
		{
			return null;
		}

		// Token: 0x04000054 RID: 84
		private FileStream m_oFile;

		// Token: 0x04000055 RID: 85
		private int m_nInputReportLength;

		// Token: 0x04000056 RID: 86
		private int m_nOutputReportLength;

		// Token: 0x04000057 RID: 87
		private IntPtr m_hHandle;

		// Token: 0x04000058 RID: 88
		public static int OutputLength;

		// Token: 0x04000059 RID: 89
		public static int InputLength;
	}
}
