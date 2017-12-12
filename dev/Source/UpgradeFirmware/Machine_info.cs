using System;

namespace UpgradeFirmware
{
	// Token: 0x0200001D RID: 29
	public class Machine_info
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00014E00 File Offset: 0x00013000
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00014DF4 File Offset: 0x00012FF4
		public string core_type { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00014E20 File Offset: 0x00013020
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00014E17 File Offset: 0x00013017
		public int upgrade_type { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00014E40 File Offset: 0x00013040
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00014E37 File Offset: 0x00013037
		public bool is_encrypt { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00014E60 File Offset: 0x00013060
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00014E57 File Offset: 0x00013057
		public int customer_id { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00014E80 File Offset: 0x00013080
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00014E77 File Offset: 0x00013077
		public int language_id { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00014EA0 File Offset: 0x000130A0
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00014E97 File Offset: 0x00013097
		public float software_version { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00014EC0 File Offset: 0x000130C0
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00014EB7 File Offset: 0x000130B7
		public float hardware_version { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00014EE0 File Offset: 0x000130E0
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00014ED7 File Offset: 0x000130D7
		public float reserved { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00014F00 File Offset: 0x00013100
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00014EF7 File Offset: 0x000130F7
		public byte checksum { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00014F20 File Offset: 0x00013120
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00014F17 File Offset: 0x00013117
		public string machine_id { get; set; }
	}
}
