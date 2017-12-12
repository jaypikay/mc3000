using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UpgradeFirmware
{
	// Token: 0x02000002 RID: 2
	public class Param : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002088 File Offset: 0x00000288
		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			this.dataGridView1 = new DataGridView();
			this.num = new DataGridViewTextBoxColumn();
			this.Type = new DataGridViewComboBoxColumn();
			this.Caps = new DataGridViewComboBoxColumn();
			this.Mode = new DataGridViewComboBoxColumn();
			this.Cur = new DataGridViewComboBoxColumn();
			this.dCur = new DataGridViewComboBoxColumn();
			this.CutTime = new DataGridViewComboBoxColumn();
			this.CutTemp = new DataGridViewComboBoxColumn();
			this.btn_ok = new Button();
			this.btn_exit = new Button();
			this.label_Set = new Label();
			this.label_display = new Label();
			this.dataGridView2 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column_Volt = new DataGridViewCheckBoxColumn();
			this.Column_Cur = new DataGridViewCheckBoxColumn();
			this.Column_Caps = new DataGridViewCheckBoxColumn();
			this.Column_Tem = new DataGridViewCheckBoxColumn();
			this.colorDialog1 = new ColorDialog();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			((ISupportInitialize)this.dataGridView2).BeginInit();
			base.SuspendLayout();
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.BackgroundColor = SystemColors.ActiveCaptionText;
			this.dataGridView1.ColumnHeadersHeight = 30;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.num,
				this.Type,
				this.Caps,
				this.Mode,
				this.Cur,
				this.dCur,
				this.CutTime,
				this.CutTemp
			});
			this.dataGridView1.Location = new Point(12, 31);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidth = 5;
			this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridView1.RowTemplate.Height = 25;
			this.dataGridView1.Size = new Size(545, 135);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellEndEdit += this.dataGridView1_CellValueChanged;
			this.num.HeaderText = "Slot";
			this.num.Name = "num";
			this.num.ReadOnly = true;
			this.num.Width = 40;
			this.Type.HeaderText = "Type";
			this.Type.Items.AddRange(new object[]
			{
				"LiIo",
				"LiFe",
				"LiIo435",
				"NiMH",
				"NiCd",
				"NiZn",
				"Eneloop"
			});
			this.Type.Name = "Type";
			this.Type.Resizable = DataGridViewTriState.False;
			this.Type.Width = 70;
			this.Caps.HeaderText = "Capacity";
			this.Caps.Name = "Caps";
			this.Caps.Resizable = DataGridViewTriState.False;
			this.Caps.Width = 80;
			this.Mode.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
			this.Mode.HeaderText = "Mode";
			this.Mode.Items.AddRange(new object[]
			{
				"Charge",
				"DisCharge",
				"Storge",
				"Cycle",
				"Refresh",
				"BreakIn"
			});
			this.Mode.Name = "Mode";
			this.Mode.Resizable = DataGridViewTriState.True;
			this.Mode.Width = 80;
			this.Cur.HeaderText = "C.Current";
			this.Cur.Name = "Cur";
			this.Cur.Resizable = DataGridViewTriState.False;
			this.Cur.Width = 70;
			this.dCur.HeaderText = "D.Current";
			this.dCur.Name = "dCur";
			this.dCur.Resizable = DataGridViewTriState.False;
			this.dCur.Width = 70;
			this.CutTime.HeaderText = "Max.Time";
			this.CutTime.Name = "CutTime";
			this.CutTime.Resizable = DataGridViewTriState.False;
			this.CutTime.Width = 70;
			this.CutTemp.HeaderText = "Max.Tem.";
			this.CutTemp.Name = "CutTemp";
			this.CutTemp.Resizable = DataGridViewTriState.False;
			this.CutTemp.Width = 60;
			this.btn_ok.Location = new Point(418, 380);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new Size(113, 31);
			this.btn_ok.TabIndex = 2;
			this.btn_ok.Text = "Confirm";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += this.btn_ok_Click;
			this.btn_exit.DialogResult = DialogResult.Cancel;
			this.btn_exit.Location = new Point(15, 380);
			this.btn_exit.Name = "btn_exit";
			this.btn_exit.Size = new Size(114, 31);
			this.btn_exit.TabIndex = 3;
			this.btn_exit.Text = "Cancel";
			this.btn_exit.UseVisualStyleBackColor = true;
			this.btn_exit.Click += this.btn_exit_Click;
			this.label_Set.AutoSize = true;
			this.label_Set.Location = new Point(10, 16);
			this.label_Set.Name = "label_Set";
			this.label_Set.Size = new Size(119, 12);
			this.label_Set.TabIndex = 4;
			this.label_Set.Text = "Charge Config Data:";
			this.label_display.AutoSize = true;
			this.label_display.Location = new Point(10, 197);
			this.label_display.Name = "label_display";
			this.label_display.Size = new Size(89, 12);
			this.label_display.TabIndex = 5;
			this.label_display.Text = "Curve Display:";
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.AllowUserToResizeColumns = false;
			this.dataGridView2.AllowUserToResizeRows = false;
			this.dataGridView2.BackgroundColor = SystemColors.ActiveCaptionText;
			this.dataGridView2.ColumnHeadersHeight = 30;
			this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView2.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column1,
				this.Column_Volt,
				this.Column_Cur,
				this.Column_Caps,
				this.Column_Tem
			});
			this.dataGridView2.Location = new Point(12, 212);
			this.dataGridView2.Name = "dataGridView2";
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("SimSun", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.ControlLightLight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowHeadersWidth = 5;
			this.dataGridView2.RowTemplate.Height = 25;
			this.dataGridView2.Size = new Size(515, 135);
			this.dataGridView2.TabIndex = 6;
			this.dataGridView2.CellDoubleClick += this.dataGridView2_CellDoubleClick;
			this.Column1.HeaderText = "Slot";
			this.Column1.Name = "Column1";
			this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column1.Width = 50;
			this.Column_Volt.HeaderText = "Voltage";
			this.Column_Volt.Name = "Column_Volt";
			this.Column_Volt.Resizable = DataGridViewTriState.True;
			this.Column_Volt.Width = 120;
			this.Column_Cur.HeaderText = "Current";
			this.Column_Cur.Name = "Column_Cur";
			this.Column_Cur.Resizable = DataGridViewTriState.True;
			this.Column_Cur.Width = 120;
			this.Column_Caps.HeaderText = "Capacity";
			this.Column_Caps.Name = "Column_Caps";
			this.Column_Caps.Resizable = DataGridViewTriState.True;
			this.Column_Caps.Width = 120;
			this.Column_Tem.HeaderText = "Temperature";
			this.Column_Tem.Name = "Column_Tem";
			this.Column_Tem.Resizable = DataGridViewTriState.True;
			this.colorDialog1.Color = Color.Blue;
			base.AcceptButton = this.btn_ok;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.AliceBlue;
			base.CancelButton = this.btn_exit;
			base.ClientSize = new Size(575, 423);
			base.Controls.Add(this.dataGridView2);
			base.Controls.Add(this.label_display);
			base.Controls.Add(this.label_Set);
			base.Controls.Add(this.btn_exit);
			base.Controls.Add(this.btn_ok);
			base.Controls.Add(this.dataGridView1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Param";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Param";
			base.Load += this.Param_Load;
			base.Shown += this.Param_Shown;
			((ISupportInitialize)this.dataGridView1).EndInit();
			((ISupportInitialize)this.dataGridView2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002BBC File Offset: 0x00000DBC
		public Param()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002C0E File Offset: 0x00000E0E
		private void Param_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002C14 File Offset: 0x00000E14
		public void Init_datagridview()
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				this.dataGridView1.Rows.Add(4);
				for (int i = 100; i <= 10000; i += 100)
				{
					this.Caps.Items.Add(i.ToString() + "mAh");
				}
				for (int i = 100; i <= 3000; i += 100)
				{
					this.Cur.Items.Add(((float)i / 1000f).ToString("f1") + "A");
				}
				for (int i = 50; i <= 1000; i += 50)
				{
					this.dCur.Items.Add(((float)i / 1000f).ToString("f2") + "A");
				}
				for (int i = 0; i <= 720; i += 10)
				{
					if (i == 0)
					{
						this.CutTime.Items.Add("OFF");
					}
					else
					{
						this.CutTime.Items.Add(i.ToString() + "Min");
					}
				}
				for (int i = 20; i <= 80; i++)
				{
					this.CutTemp.Items.Add(i.ToString() + "℃");
				}
				this.dataGridView2.Rows.Clear();
				this.dataGridView2.Rows.Add(4);
				for (int j = 0; j < 4; j++)
				{
					this.dataGridView2.Rows[j].Cells[0].Value = (j + 1).ToString();
					this.dataGridView2.Rows[j].Cells[1].Style.BackColor = Color.Blue;
					this.dataGridView2.Rows[j].Cells[2].Style.BackColor = Color.DarkGreen;
					this.dataGridView2.Rows[j].Cells[3].Style.BackColor = Color.DarkOrange;
					this.dataGridView2.Rows[j].Cells[4].Style.BackColor = Color.Red;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002F04 File Offset: 0x00001104
		private void Param_Shown(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < 4; i++)
				{
					this.dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
					this.dataGridView1.Rows[i].Cells[1].Value = this.Type.Items[this.BatParam[i].Type].ToString();
					this.dataGridView1.Rows[i].Cells[2].Value = this.Caps.Items[(this.BatParam[i].Caps - 100) / 100].ToString();
					int index;
					if (this.BatParam[i].Type < 3)
					{
						index = this.li_mode_load[this.BatParam[i].Mode];
					}
					else
					{
						index = this.ni_mode_load[this.BatParam[i].Mode];
					}
					this.dataGridView1.Rows[i].Cells[3].Value = this.Mode.Items[index].ToString();
					this.dataGridView1.Rows[i].Cells[4].Value = this.Cur.Items[(this.BatParam[i].Cur - 100) / 100].ToString();
					this.dataGridView1.Rows[i].Cells[5].Value = this.dCur.Items[(this.BatParam[i].dCur - 50) / 50].ToString();
					this.dataGridView1.Rows[i].Cells[6].Value = this.CutTime.Items[this.BatParam[i].CutTime / 10].ToString();
					this.dataGridView1.Rows[i].Cells[7].Value = this.CutTemp.Items[(this.BatParam[i].CutTemp - 200) / 10].ToString();
				}
				for (int i = 0; i < 4; i++)
				{
					if (this.bVolt[i])
					{
						this.dataGridView2.Rows[i].Cells[1].Value = 1;
					}
					else
					{
						this.dataGridView2.Rows[i].Cells[1].Value = 0;
					}
					if (this.bCur[i])
					{
						this.dataGridView2.Rows[i].Cells[2].Value = 1;
					}
					else
					{
						this.dataGridView2.Rows[i].Cells[2].Value = 0;
					}
					if (this.bCaps[i])
					{
						this.dataGridView2.Rows[i].Cells[3].Value = 1;
					}
					else
					{
						this.dataGridView2.Rows[i].Cells[3].Value = 0;
					}
					if (this.bTem[i])
					{
						this.dataGridView2.Rows[i].Cells[4].Value = 1;
					}
					else
					{
						this.dataGridView2.Rows[i].Cells[4].Value = 0;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00003364 File Offset: 0x00001564
		private void btn_exit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000336E File Offset: 0x0000156E
		private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00003374 File Offset: 0x00001574
		public void set_param(ChargerData[] data, bool[] volt, bool[] cur, bool[] caps, bool[] tem)
		{
			this.bVolt = volt;
			this.bCur = cur;
			this.bCaps = caps;
			this.bTem = tem;
			this.BatParam = data;
			this.bConfirm = false;
			base.ShowDialog();
			if (this.bConfirm)
			{
				for (int i = 0; i < 4; i++)
				{
					if (Convert.ToInt32(this.dataGridView2.Rows[i].Cells[1].Value) > 0)
					{
						volt[i] = true;
					}
					else
					{
						volt[i] = false;
					}
					if (Convert.ToInt32(this.dataGridView2.Rows[i].Cells[2].Value) > 0)
					{
						cur[i] = true;
					}
					else
					{
						cur[i] = false;
					}
					if (Convert.ToInt32(this.dataGridView2.Rows[i].Cells[3].Value) > 0)
					{
						caps[i] = true;
					}
					else
					{
						caps[i] = false;
					}
					if (Convert.ToInt32(this.dataGridView2.Rows[i].Cells[4].Value) > 0)
					{
						tem[i] = true;
					}
					else
					{
						tem[i] = false;
					}
				}
				for (int i = 0; i < 4; i++)
				{
					this.BatParam[i].Type = this.Type.Items.IndexOf(this.dataGridView1.Rows[i].Cells[1].Value);
					this.BatParam[i].Caps = this.Caps.Items.IndexOf(this.dataGridView1.Rows[i].Cells[2].Value) * 100 + 100;
					int num = this.Mode.Items.IndexOf(this.dataGridView1.Rows[i].Cells[3].Value);
					if (this.BatParam[i].Type < 3 && num == 4)
					{
						num = 3;
					}
					if (this.BatParam[i].Type >= 3 && num >= 3)
					{
						num--;
					}
					this.BatParam[i].Mode = num;
					this.BatParam[i].Cur = this.Cur.Items.IndexOf(this.dataGridView1.Rows[i].Cells[4].Value) * 100 + 100;
					this.BatParam[i].dCur = this.dCur.Items.IndexOf(this.dataGridView1.Rows[i].Cells[5].Value) * 50 + 50;
					this.BatParam[i].CutTime = this.CutTime.Items.IndexOf(this.dataGridView1.Rows[i].Cells[6].Value) * 10;
					this.BatParam[i].CutTemp = this.CutTemp.Items.IndexOf(this.dataGridView1.Rows[i].Cells[7].Value) * 10 + 200;
				}
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000036F1 File Offset: 0x000018F1
		private void btn_ok_Click(object sender, EventArgs e)
		{
			this.bConfirm = true;
			base.Close();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00003704 File Offset: 0x00001904
		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			if (rowIndex >= 0 && rowIndex < 4)
			{
				if (e.ColumnIndex == 1)
				{
					int num = this.Type.Items.IndexOf(this.dataGridView1.Rows[rowIndex].Cells[1].Value);
					int num2 = this.Cur.Items.IndexOf(this.dataGridView1.Rows[rowIndex].Cells[4].Value) * 100 + 100;
					if (num >= 3 && num2 > 2000)
					{
						this.dataGridView1.Rows[rowIndex].Cells[4].Value = this.Cur.Items[19];
					}
					this.dataGridView1.Rows[rowIndex].Cells[3].Value = this.Mode.Items[0];
				}
				else if (e.ColumnIndex == 3)
				{
					string text = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
					int num = this.Type.Items.IndexOf(this.dataGridView1.Rows[rowIndex].Cells[1].Value);
					if (num < 3 && (text.Contains("Cycle") || text.Contains("BreakIn")))
					{
						MessageBox.Show("Error Charge Mode!");
						this.dataGridView1.Rows[rowIndex].Cells[3].Value = this.Mode.Items[0];
					}
					if (num >= 3 && text.Contains("Storge"))
					{
						MessageBox.Show("Error Charge Mode!");
						this.dataGridView1.Rows[rowIndex].Cells[3].Value = this.Mode.Items[0];
					}
					if (text.Contains("BreakIn"))
					{
						this.dataGridView1.Rows[rowIndex].Cells[4].Value = this.Cur.Items[0];
					}
				}
				else if (e.ColumnIndex == 4)
				{
					string text = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
					int num = this.Type.Items.IndexOf(this.dataGridView1.Rows[rowIndex].Cells[1].Value);
					int num2 = this.Cur.Items.IndexOf(this.dataGridView1.Rows[rowIndex].Cells[4].Value) * 100 + 100;
					if (num >= 3 && num2 > 2000)
					{
						MessageBox.Show("Sorry!NiXX battery must less than 2.0A!");
						this.dataGridView1.Rows[rowIndex].Cells[4].Value = this.Cur.Items[19];
					}
					if (text.Contains("BreakIn") && num2 > 200)
					{
						MessageBox.Show("Sorry!BreakIn Current must less than 0.2A!");
						this.dataGridView1.Rows[rowIndex].Cells[4].Value = this.Cur.Items[1];
					}
				}
			}
		}

		// Token: 0x04000001 RID: 1
		private IContainer components = null;

		// Token: 0x04000002 RID: 2
		private DataGridView dataGridView1;

		// Token: 0x04000003 RID: 3
		private Button btn_ok;

		// Token: 0x04000004 RID: 4
		private Button btn_exit;

		// Token: 0x04000005 RID: 5
		private Label label_Set;

		// Token: 0x04000006 RID: 6
		private Label label_display;

		// Token: 0x04000007 RID: 7
		private DataGridView dataGridView2;

		// Token: 0x04000008 RID: 8
		private ColorDialog colorDialog1;

		// Token: 0x04000009 RID: 9
		private DataGridViewTextBoxColumn Column1;

		// Token: 0x0400000A RID: 10
		private DataGridViewCheckBoxColumn Column_Volt;

		// Token: 0x0400000B RID: 11
		private DataGridViewCheckBoxColumn Column_Cur;

		// Token: 0x0400000C RID: 12
		private DataGridViewCheckBoxColumn Column_Caps;

		// Token: 0x0400000D RID: 13
		private DataGridViewCheckBoxColumn Column_Tem;

		// Token: 0x0400000E RID: 14
		private DataGridViewTextBoxColumn num;

		// Token: 0x0400000F RID: 15
		private DataGridViewComboBoxColumn Type;

		// Token: 0x04000010 RID: 16
		private DataGridViewComboBoxColumn Caps;

		// Token: 0x04000011 RID: 17
		private DataGridViewComboBoxColumn Mode;

		// Token: 0x04000012 RID: 18
		private DataGridViewComboBoxColumn Cur;

		// Token: 0x04000013 RID: 19
		private DataGridViewComboBoxColumn dCur;

		// Token: 0x04000014 RID: 20
		private DataGridViewComboBoxColumn CutTime;

		// Token: 0x04000015 RID: 21
		private DataGridViewComboBoxColumn CutTemp;

		// Token: 0x04000016 RID: 22
		private ChargerData[] BatParam;

		// Token: 0x04000017 RID: 23
		private bool[] bVolt;

		// Token: 0x04000018 RID: 24
		private bool[] bCur;

		// Token: 0x04000019 RID: 25
		private bool[] bCaps;

		// Token: 0x0400001A RID: 26
		private bool[] bTem;

		// Token: 0x0400001B RID: 27
		private int[] li_mode_load = new int[]
		{
			0,
			1,
			2,
			4,
			5
		};

		// Token: 0x0400001C RID: 28
		private int[] ni_mode_load = new int[]
		{
			0,
			1,
			3,
			4,
			5
		};

		// Token: 0x0400001D RID: 29
		private bool bConfirm;
	}
}
