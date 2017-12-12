using System;

namespace UpgradeFirmware
{
	// Token: 0x0200001E RID: 30
	public class ChargerData
	{
		// Token: 0x0600011F RID: 287 RVA: 0x00014F3F File Offset: 0x0001313F
		public void Load_From_Device()
		{
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00014F44 File Offset: 0x00013144
		public void Set_To_Device()
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00014F49 File Offset: 0x00013149
		public void Start_Stop()
		{
		}

		// Token: 0x040001AF RID: 431
		public int Type = 0;

		// Token: 0x040001B0 RID: 432
		public int Caps = 1000;

		// Token: 0x040001B1 RID: 433
		public int Mode = 0;

		// Token: 0x040001B2 RID: 434
		public int Cur = 1000;

		// Token: 0x040001B3 RID: 435
		public int dCur = 500;

		// Token: 0x040001B4 RID: 436
		public int Cycle_Count = 1;

		// Token: 0x040001B5 RID: 437
		public int Cycle_Delay = 5;

		// Token: 0x040001B6 RID: 438
		public int Cycle_Mode = 0;

		// Token: 0x040001B7 RID: 439
		public int Peak_Sense = 3;

		// Token: 0x040001B8 RID: 440
		public int End_Volt = 800;

		// Token: 0x040001B9 RID: 441
		public int Cut_Volt = 100;

		// Token: 0x040001BA RID: 442
		public int End_Cur = 100;

		// Token: 0x040001BB RID: 443
		public int End_dCur = 250;

		// Token: 0x040001BC RID: 444
		public int Hold_Volt = 4180;

		// Token: 0x040001BD RID: 445
		public int Trickle = 30;

		// Token: 0x040001BE RID: 446
		public int CutTime = 180;

		// Token: 0x040001BF RID: 447
		public int CutTemp = 45;

		// Token: 0x040001C0 RID: 448
		public int Tem_Unit = 0;

		// Token: 0x040001C1 RID: 449
		public int bWork = 0;

		// Token: 0x040001C2 RID: 450
		public int Sys_Mem1 = 0;

		// Token: 0x040001C3 RID: 451
		public int Sys_Mem2 = 0;

		// Token: 0x040001C4 RID: 452
		public int Sys_Mem3 = 0;

		// Token: 0x040001C5 RID: 453
		public int Sys_Mem4 = 0;

		// Token: 0x040001C6 RID: 454
		public int Sys_Advance = 0;

		// Token: 0x040001C7 RID: 455
		public int Sys_tUnit = 0;

		// Token: 0x040001C8 RID: 456
		public int Sys_Buzzer_Tone = 0;

		// Token: 0x040001C9 RID: 457
		public int Sys_Life_Hide = 0;

		// Token: 0x040001CA RID: 458
		public int Sys_LiHv_Hide = 0;

		// Token: 0x040001CB RID: 459
		public int Sys_Eneloop_Hide = 0;

		// Token: 0x040001CC RID: 460
		public int Sys_NiZn_Hide = 0;

		// Token: 0x040001CD RID: 461
		public int Sys_Lcd_Time = 0;

		// Token: 0x040001CE RID: 462
		public int Sys_Min_Input = 0;
	}
}
