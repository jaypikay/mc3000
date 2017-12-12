using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace UpgradeFirmware.Properties
{
	// Token: 0x0200000C RID: 12
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00008DE8 File Offset: 0x00006FE8
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000B3 RID: 179
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
