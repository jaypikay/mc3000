using System;
using System.Windows.Forms;

namespace usb_loader_host
{
	// Token: 0x02000015 RID: 21
	internal static class Program
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x00014B48 File Offset: 0x00012D48
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormLoader());
		}
	}
}
