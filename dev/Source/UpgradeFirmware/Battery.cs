using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UpgradeFirmware
{
	// Token: 0x0200000B RID: 11
	public class Battery : Form
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00004164 File Offset: 0x00002364
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000419C File Offset: 0x0000239C
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Battery));
			this.trackBar1 = new TrackBar();
			this.label1 = new Label();
			this.button1 = new Button();
			this.button2 = new Button();
			this.button3 = new Button();
			this.button4 = new Button();
			this.button5 = new Button();
			this.button7 = new Button();
			this.button6 = new Button();
			this.label2 = new Label();
			this.label3 = new Label();
			this.button8 = new Button();
			this.button9 = new Button();
			this.button10 = new Button();
			this.button11 = new Button();
			this.button12 = new Button();
			this.button13 = new Button();
			this.label4 = new Label();
			this.trackBar2 = new TrackBar();
			this.label5 = new Label();
			this.trackBar3 = new TrackBar();
			this.btn_cancel = new Button();
			this.btn_Ok = new Button();
			this.button1_advance = new Button();
			this.label_solt = new Label();
			this.label_split = new Label();
			this.label6 = new Label();
			this.trackBar4 = new TrackBar();
			this.label7 = new Label();
			this.trackBar5 = new TrackBar();
			this.label8 = new Label();
			this.trackBar6 = new TrackBar();
			this.label9 = new Label();
			this.trackBar7 = new TrackBar();
			this.label10 = new Label();
			this.trackBar8 = new TrackBar();
			this.label11 = new Label();
			this.trackBar9 = new TrackBar();
			this.label12 = new Label();
			this.button15 = new Button();
			this.button16 = new Button();
			this.label13 = new Label();
			this.trackBar10 = new TrackBar();
			this.label14 = new Label();
			this.trackBar11 = new TrackBar();
			this.label15 = new Label();
			this.trackBar12 = new TrackBar();
			this.label16 = new Label();
			this.trackBar13 = new TrackBar();
			this.label17 = new Label();
			this.trackBar14 = new TrackBar();
			this.button14 = new Button();
			this.button17 = new Button();
			((ISupportInitialize)this.trackBar1).BeginInit();
			((ISupportInitialize)this.trackBar2).BeginInit();
			((ISupportInitialize)this.trackBar3).BeginInit();
			((ISupportInitialize)this.trackBar4).BeginInit();
			((ISupportInitialize)this.trackBar5).BeginInit();
			((ISupportInitialize)this.trackBar6).BeginInit();
			((ISupportInitialize)this.trackBar7).BeginInit();
			((ISupportInitialize)this.trackBar8).BeginInit();
			((ISupportInitialize)this.trackBar9).BeginInit();
			((ISupportInitialize)this.trackBar10).BeginInit();
			((ISupportInitialize)this.trackBar11).BeginInit();
			((ISupportInitialize)this.trackBar12).BeginInit();
			((ISupportInitialize)this.trackBar13).BeginInit();
			((ISupportInitialize)this.trackBar14).BeginInit();
			base.SuspendLayout();
			this.trackBar1.AutoSize = false;
			this.trackBar1.Location = new Point(12, 188);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new Size(400, 25);
			this.trackBar1.TabIndex = 0;
			this.trackBar1.TickStyle = TickStyle.None;
			this.trackBar1.Value = 100;
			this.trackBar1.ValueChanged += this.trackBar1_ValueChanged;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Microsoft YaHei", 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label1.ForeColor = Color.Navy;
			this.label1.Location = new Point(25, 69);
			this.label1.Name = "label1";
			this.label1.Size = new Size(54, 22);
			this.label1.TabIndex = 1;
			this.label1.Text = "Type:";
			this.button1.BackColor = Color.LavenderBlush;
			this.button1.FlatStyle = FlatStyle.Flat;
			this.button1.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button1.ForeColor = Color.Silver;
			this.button1.Location = new Point(21, 94);
			this.button1.Name = "button1";
			this.button1.Size = new Size(80, 30);
			this.button1.TabIndex = 2;
			this.button1.Text = "LiIon";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += this.button_Type_Click;
			this.button2.BackColor = Color.LavenderBlush;
			this.button2.FlatStyle = FlatStyle.Flat;
			this.button2.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button2.ForeColor = Color.Silver;
			this.button2.Location = new Point(107, 94);
			this.button2.Name = "button2";
			this.button2.Size = new Size(80, 30);
			this.button2.TabIndex = 3;
			this.button2.Text = "LiFe";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += this.button_Type_Click;
			this.button3.BackColor = Color.LavenderBlush;
			this.button3.FlatStyle = FlatStyle.Flat;
			this.button3.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button3.ForeColor = Color.Silver;
			this.button3.Location = new Point(193, 94);
			this.button3.Name = "button3";
			this.button3.Size = new Size(80, 30);
			this.button3.TabIndex = 4;
			this.button3.Text = "LiHV";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += this.button_Type_Click;
			this.button4.BackColor = Color.LavenderBlush;
			this.button4.FlatStyle = FlatStyle.Flat;
			this.button4.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button4.ForeColor = Color.Silver;
			this.button4.Location = new Point(279, 94);
			this.button4.Name = "button4";
			this.button4.Size = new Size(80, 30);
			this.button4.TabIndex = 5;
			this.button4.Text = "NiMH";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += this.button_Type_Click;
			this.button5.BackColor = Color.LavenderBlush;
			this.button5.FlatStyle = FlatStyle.Flat;
			this.button5.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button5.ForeColor = Color.Silver;
			this.button5.Location = new Point(21, 130);
			this.button5.Name = "button5";
			this.button5.Size = new Size(80, 30);
			this.button5.TabIndex = 6;
			this.button5.Text = "NiCd";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += this.button_Type_Click;
			this.button7.BackColor = Color.LavenderBlush;
			this.button7.FlatStyle = FlatStyle.Flat;
			this.button7.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button7.ForeColor = Color.Silver;
			this.button7.Location = new Point(193, 130);
			this.button7.Name = "button7";
			this.button7.Size = new Size(91, 30);
			this.button7.TabIndex = 7;
			this.button7.Text = "ENELOOP";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += this.button_Type_Click;
			this.button6.BackColor = Color.LavenderBlush;
			this.button6.FlatStyle = FlatStyle.Flat;
			this.button6.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button6.ForeColor = Color.Silver;
			this.button6.Location = new Point(107, 130);
			this.button6.Name = "button6";
			this.button6.Size = new Size(80, 30);
			this.button6.TabIndex = 8;
			this.button6.Text = "NiZn";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += this.button_Type_Click;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Microsoft YaHei", 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label2.ForeColor = Color.Navy;
			this.label2.Location = new Point(17, 163);
			this.label2.Name = "label2";
			this.label2.Size = new Size(84, 22);
			this.label2.TabIndex = 9;
			this.label2.Text = "Capacity:";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Microsoft YaHei", 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label3.ForeColor = Color.Navy;
			this.label3.Location = new Point(17, 211);
			this.label3.Name = "label3";
			this.label3.Size = new Size(62, 22);
			this.label3.TabIndex = 10;
			this.label3.Text = "Mode:";
			this.button8.BackColor = Color.LavenderBlush;
			this.button8.FlatStyle = FlatStyle.Flat;
			this.button8.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button8.ForeColor = Color.Silver;
			this.button8.Location = new Point(21, 239);
			this.button8.Name = "button8";
			this.button8.Size = new Size(80, 30);
			this.button8.TabIndex = 11;
			this.button8.Text = "Charge";
			this.button8.UseVisualStyleBackColor = false;
			this.button8.Click += this.button_Mode_Click;
			this.button9.BackColor = Color.LavenderBlush;
			this.button9.FlatStyle = FlatStyle.Flat;
			this.button9.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button9.ForeColor = Color.Silver;
			this.button9.Location = new Point(107, 239);
			this.button9.Name = "button9";
			this.button9.Size = new Size(80, 30);
			this.button9.TabIndex = 12;
			this.button9.Text = "Refresh";
			this.button9.UseVisualStyleBackColor = false;
			this.button9.Click += this.button_Mode_Click;
			this.button10.BackColor = Color.LavenderBlush;
			this.button10.FlatStyle = FlatStyle.Flat;
			this.button10.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button10.ForeColor = Color.Silver;
			this.button10.Location = new Point(193, 239);
			this.button10.Name = "button10";
			this.button10.Size = new Size(80, 30);
			this.button10.TabIndex = 13;
			this.button10.Text = "Storage";
			this.button10.UseVisualStyleBackColor = false;
			this.button10.Click += this.button_Mode_Click;
			this.button11.BackColor = Color.LavenderBlush;
			this.button11.FlatStyle = FlatStyle.Flat;
			this.button11.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button11.ForeColor = Color.Silver;
			this.button11.Location = new Point(279, 239);
			this.button11.Name = "button11";
			this.button11.Size = new Size(92, 30);
			this.button11.TabIndex = 14;
			this.button11.Text = "Discharge";
			this.button11.UseVisualStyleBackColor = false;
			this.button11.Click += this.button_Mode_Click;
			this.button12.BackColor = Color.LavenderBlush;
			this.button12.FlatStyle = FlatStyle.Flat;
			this.button12.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button12.ForeColor = Color.Silver;
			this.button12.Location = new Point(21, 275);
			this.button12.Name = "button12";
			this.button12.Size = new Size(80, 30);
			this.button12.TabIndex = 15;
			this.button12.Text = "Cycle";
			this.button12.UseVisualStyleBackColor = false;
			this.button12.Click += this.button_Mode_Click;
			this.button13.BackColor = Color.LavenderBlush;
			this.button13.FlatStyle = FlatStyle.Flat;
			this.button13.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button13.ForeColor = Color.Silver;
			this.button13.Location = new Point(107, 275);
			this.button13.Name = "button13";
			this.button13.Size = new Size(80, 30);
			this.button13.TabIndex = 16;
			this.button13.Text = "BreakIn";
			this.button13.UseVisualStyleBackColor = false;
			this.button13.Click += this.button_Mode_Click;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Microsoft YaHei", 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label4.ForeColor = Color.Navy;
			this.label4.Location = new Point(17, 319);
			this.label4.Name = "label4";
			this.label4.Size = new Size(138, 22);
			this.label4.TabIndex = 17;
			this.label4.Text = "Charge Current:";
			this.trackBar2.AutoSize = false;
			this.trackBar2.Location = new Point(21, 344);
			this.trackBar2.Maximum = 300;
			this.trackBar2.Minimum = 5;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new Size(400, 25);
			this.trackBar2.TabIndex = 18;
			this.trackBar2.TickStyle = TickStyle.None;
			this.trackBar2.Value = 50;
			this.trackBar2.ValueChanged += this.trackBar2_ValueChanged;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Microsoft YaHei", 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label5.ForeColor = Color.Navy;
			this.label5.Location = new Point(17, 367);
			this.label5.Name = "label5";
			this.label5.Size = new Size(161, 22);
			this.label5.TabIndex = 19;
			this.label5.Text = "Discharge Current:";
			this.trackBar3.AutoSize = false;
			this.trackBar3.Location = new Point(21, 392);
			this.trackBar3.Maximum = 100;
			this.trackBar3.Minimum = 5;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new Size(400, 25);
			this.trackBar3.TabIndex = 20;
			this.trackBar3.TickStyle = TickStyle.None;
			this.trackBar3.Value = 50;
			this.trackBar3.ValueChanged += this.trackBar3_ValueChanged;
			this.btn_cancel.BackColor = Color.LavenderBlush;
			this.btn_cancel.DialogResult = DialogResult.Cancel;
			this.btn_cancel.FlatStyle = FlatStyle.Flat;
			this.btn_cancel.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.btn_cancel.ForeColor = Color.Black;
			this.btn_cancel.Location = new Point(29, 472);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new Size(80, 30);
			this.btn_cancel.TabIndex = 21;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += this.button14_Click;
			this.btn_Ok.BackColor = Color.LavenderBlush;
			this.btn_Ok.FlatStyle = FlatStyle.Flat;
			this.btn_Ok.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.btn_Ok.ForeColor = Color.Black;
			this.btn_Ok.Location = new Point(182, 472);
			this.btn_Ok.Name = "btn_Ok";
			this.btn_Ok.Size = new Size(80, 30);
			this.btn_Ok.TabIndex = 22;
			this.btn_Ok.Text = "Ok";
			this.btn_Ok.UseVisualStyleBackColor = false;
			this.btn_Ok.Click += this.button15_Click;
			this.button1_advance.BackColor = Color.LavenderBlush;
			this.button1_advance.FlatStyle = FlatStyle.Flat;
			this.button1_advance.Font = new Font("Microsoft YaHei", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button1_advance.ForeColor = Color.Black;
			this.button1_advance.Location = new Point(322, 472);
			this.button1_advance.Name = "button1_advance";
			this.button1_advance.Size = new Size(80, 30);
			this.button1_advance.TabIndex = 23;
			this.button1_advance.Text = ">>";
			this.button1_advance.UseVisualStyleBackColor = false;
			this.button1_advance.Click += this.button1_advance_Click;
			this.label_solt.AutoSize = true;
			this.label_solt.Font = new Font("Microsoft YaHei", 42f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label_solt.ForeColor = Color.Navy;
			this.label_solt.Location = new Point(157, 5);
			this.label_solt.Name = "label_solt";
			this.label_solt.Size = new Size(103, 75);
			this.label_solt.TabIndex = 24;
			this.label_solt.Text = "#1";
			this.label_split.BackColor = Color.Silver;
			this.label_split.Location = new Point(438, 5);
			this.label_split.Name = "label_split";
			this.label_split.Size = new Size(2, 500);
			this.label_split.TabIndex = 25;
			this.label_split.Text = "1";
			this.label6.AutoSize = true;
			this.label6.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label6.ForeColor = Color.Navy;
			this.label6.Location = new Point(456, 9);
			this.label6.Name = "label6";
			this.label6.Size = new Size(133, 17);
			this.label6.TabIndex = 26;
			this.label6.Text = "Charge End Voltage:";
			this.trackBar4.AutoSize = false;
			this.trackBar4.Location = new Point(459, 29);
			this.trackBar4.Maximum = 100;
			this.trackBar4.Minimum = 5;
			this.trackBar4.Name = "trackBar4";
			this.trackBar4.Size = new Size(300, 24);
			this.trackBar4.SmallChange = 10;
			this.trackBar4.TabIndex = 27;
			this.trackBar4.TickStyle = TickStyle.None;
			this.trackBar4.Value = 5;
			this.trackBar4.ValueChanged += this.trackBar4_ValueChanged;
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label7.ForeColor = Color.Navy;
			this.label7.Location = new Point(456, 56);
			this.label7.Name = "label7";
			this.label7.Size = new Size(151, 17);
			this.label7.TabIndex = 28;
			this.label7.Text = "Discharge End Voltage:";
			this.trackBar5.AutoSize = false;
			this.trackBar5.Location = new Point(459, 76);
			this.trackBar5.Maximum = 100;
			this.trackBar5.Minimum = 5;
			this.trackBar5.Name = "trackBar5";
			this.trackBar5.Size = new Size(300, 24);
			this.trackBar5.SmallChange = 10;
			this.trackBar5.TabIndex = 29;
			this.trackBar5.TickStyle = TickStyle.None;
			this.trackBar5.Value = 5;
			this.trackBar5.ValueChanged += this.trackBar5_ValueChanged;
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label8.ForeColor = Color.Navy;
			this.label8.Location = new Point(456, 107);
			this.label8.Name = "label8";
			this.label8.Size = new Size(131, 17);
			this.label8.TabIndex = 30;
			this.label8.Text = "Charge End Current:";
			this.trackBar6.AutoSize = false;
			this.trackBar6.Location = new Point(459, 127);
			this.trackBar6.Maximum = 100;
			this.trackBar6.Minimum = 5;
			this.trackBar6.Name = "trackBar6";
			this.trackBar6.Size = new Size(300, 24);
			this.trackBar6.SmallChange = 10;
			this.trackBar6.TabIndex = 31;
			this.trackBar6.TickStyle = TickStyle.None;
			this.trackBar6.Value = 5;
			this.trackBar6.ValueChanged += this.trackBar6_ValueChanged;
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label9.ForeColor = Color.Navy;
			this.label9.Location = new Point(458, 154);
			this.label9.Name = "label9";
			this.label9.Size = new Size(149, 17);
			this.label9.TabIndex = 32;
			this.label9.Text = "Discharge End Current:";
			this.trackBar7.AutoSize = false;
			this.trackBar7.Location = new Point(459, 174);
			this.trackBar7.Maximum = 100;
			this.trackBar7.Minimum = 5;
			this.trackBar7.Name = "trackBar7";
			this.trackBar7.Size = new Size(300, 24);
			this.trackBar7.SmallChange = 10;
			this.trackBar7.TabIndex = 33;
			this.trackBar7.TickStyle = TickStyle.None;
			this.trackBar7.Value = 5;
			this.trackBar7.ValueChanged += this.trackBar7_ValueChanged;
			this.label10.AutoSize = true;
			this.label10.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label10.ForeColor = Color.Navy;
			this.label10.Location = new Point(456, 201);
			this.label10.Name = "label10";
			this.label10.Size = new Size(92, 17);
			this.label10.TabIndex = 34;
			this.label10.Text = "Resting Time:";
			this.trackBar8.AutoSize = false;
			this.trackBar8.Location = new Point(461, 221);
			this.trackBar8.Maximum = 240;
			this.trackBar8.Name = "trackBar8";
			this.trackBar8.Size = new Size(300, 26);
			this.trackBar8.TabIndex = 35;
			this.trackBar8.TickStyle = TickStyle.None;
			this.trackBar8.Value = 5;
			this.trackBar8.ValueChanged += this.trackBar8_ValueChanged;
			this.label11.AutoSize = true;
			this.label11.Font = new Font("Microsoft YaHei", 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label11.ForeColor = Color.Navy;
			this.label11.Location = new Point(17, 420);
			this.label11.Name = "label11";
			this.label11.Size = new Size(111, 22);
			this.label11.TabIndex = 36;
			this.label11.Text = "Cycle Count:";
			this.trackBar9.AutoSize = false;
			this.trackBar9.Location = new Point(21, 440);
			this.trackBar9.Maximum = 99;
			this.trackBar9.Minimum = 1;
			this.trackBar9.Name = "trackBar9";
			this.trackBar9.Size = new Size(400, 24);
			this.trackBar9.TabIndex = 37;
			this.trackBar9.TickStyle = TickStyle.None;
			this.trackBar9.Value = 5;
			this.trackBar9.ValueChanged += this.trackBar9_ValueChanged;
			this.label12.AutoSize = true;
			this.label12.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label12.ForeColor = Color.Navy;
			this.label12.Location = new Point(458, 250);
			this.label12.Name = "label12";
			this.label12.Size = new Size(82, 17);
			this.label12.TabIndex = 38;
			this.label12.Text = "Cycle Mode:";
			this.button15.BackColor = Color.LavenderBlush;
			this.button15.FlatStyle = FlatStyle.Flat;
			this.button15.Font = new Font("Microsoft YaHei", 7.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button15.ForeColor = Color.Silver;
			this.button15.Location = new Point(593, 242);
			this.button15.Name = "button15";
			this.button15.Size = new Size(59, 25);
			this.button15.TabIndex = 39;
			this.button15.Text = "C>D>C";
			this.button15.UseVisualStyleBackColor = false;
			this.button15.Click += this.button15_Click_1;
			this.button16.BackColor = Color.LavenderBlush;
			this.button16.FlatStyle = FlatStyle.Flat;
			this.button16.Font = new Font("Microsoft YaHei", 7.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button16.ForeColor = Color.Silver;
			this.button16.Location = new Point(658, 242);
			this.button16.Name = "button16";
			this.button16.Size = new Size(44, 25);
			this.button16.TabIndex = 40;
			this.button16.Text = "D>C";
			this.button16.UseVisualStyleBackColor = false;
			this.button16.Click += this.button16_Click;
			this.label13.AutoSize = true;
			this.label13.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label13.ForeColor = Color.Navy;
			this.label13.Location = new Point(458, 286);
			this.label13.Name = "label13";
			this.label13.Size = new Size(80, 17);
			this.label13.TabIndex = 41;
			this.label13.Text = "Ni -Detal V:";
			this.trackBar10.AutoSize = false;
			this.trackBar10.Location = new Point(609, 287);
			this.trackBar10.Maximum = 20;
			this.trackBar10.Minimum = 3;
			this.trackBar10.Name = "trackBar10";
			this.trackBar10.Size = new Size(150, 24);
			this.trackBar10.TabIndex = 42;
			this.trackBar10.TickStyle = TickStyle.None;
			this.trackBar10.Value = 5;
			this.trackBar10.ValueChanged += this.trackBar10_ValueChanged;
			this.label14.AutoSize = true;
			this.label14.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label14.ForeColor = Color.Navy;
			this.label14.Location = new Point(458, 319);
			this.label14.Name = "label14";
			this.label14.Size = new Size(52, 17);
			this.label14.TabIndex = 43;
			this.label14.Text = "Trickle:";
			this.trackBar11.AutoSize = false;
			this.trackBar11.Location = new Point(609, 317);
			this.trackBar11.Maximum = 30;
			this.trackBar11.Name = "trackBar11";
			this.trackBar11.Size = new Size(150, 24);
			this.trackBar11.TabIndex = 44;
			this.trackBar11.TickFrequency = 10;
			this.trackBar11.TickStyle = TickStyle.None;
			this.trackBar11.Value = 5;
			this.trackBar11.ValueChanged += this.trackBar11_ValueChanged;
			this.label15.AutoSize = true;
			this.label15.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label15.ForeColor = Color.Navy;
			this.label15.Location = new Point(458, 353);
			this.label15.Name = "label15";
			this.label15.Size = new Size(93, 17);
			this.label15.TabIndex = 45;
			this.label15.Text = "Hold Voltage:";
			this.trackBar12.AutoSize = false;
			this.trackBar12.Location = new Point(609, 353);
			this.trackBar12.Maximum = 300;
			this.trackBar12.Name = "trackBar12";
			this.trackBar12.Size = new Size(150, 24);
			this.trackBar12.SmallChange = 10;
			this.trackBar12.TabIndex = 46;
			this.trackBar12.TickStyle = TickStyle.None;
			this.trackBar12.Value = 5;
			this.trackBar12.ValueChanged += this.trackBar12_ValueChanged;
			this.label16.AutoSize = true;
			this.label16.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label16.ForeColor = Color.Navy;
			this.label16.Location = new Point(458, 392);
			this.label16.Name = "label16";
			this.label16.Size = new Size(115, 17);
			this.label16.TabIndex = 47;
			this.label16.Text = "Cut Temperature:";
			this.trackBar13.AutoSize = false;
			this.trackBar13.Location = new Point(609, 392);
			this.trackBar13.Maximum = 800;
			this.trackBar13.Minimum = 200;
			this.trackBar13.Name = "trackBar13";
			this.trackBar13.Size = new Size(150, 24);
			this.trackBar13.SmallChange = 10;
			this.trackBar13.TabIndex = 48;
			this.trackBar13.TickStyle = TickStyle.None;
			this.trackBar13.Value = 200;
			this.trackBar13.ValueChanged += this.trackBar13_ValueChanged;
			this.label17.AutoSize = true;
			this.label17.Font = new Font("Microsoft YaHei", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label17.ForeColor = Color.Navy;
			this.label17.Location = new Point(458, 425);
			this.label17.Name = "label17";
			this.label17.Size = new Size(67, 17);
			this.label17.TabIndex = 49;
			this.label17.Text = "Cut Time:";
			this.trackBar14.AutoSize = false;
			this.trackBar14.Location = new Point(461, 445);
			this.trackBar14.Maximum = 144;
			this.trackBar14.Name = "trackBar14";
			this.trackBar14.Size = new Size(300, 24);
			this.trackBar14.TabIndex = 50;
			this.trackBar14.TickStyle = TickStyle.None;
			this.trackBar14.Value = 5;
			this.trackBar14.ValueChanged += this.trackBar14_ValueChanged;
			this.button14.BackColor = Color.LavenderBlush;
			this.button14.FlatStyle = FlatStyle.Flat;
			this.button14.Font = new Font("Microsoft YaHei", 7.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button14.ForeColor = Color.Black;
			this.button14.Location = new Point(544, 242);
			this.button14.Name = "button14";
			this.button14.Size = new Size(43, 25);
			this.button14.TabIndex = 51;
			this.button14.Text = "C>D";
			this.button14.UseVisualStyleBackColor = false;
			this.button14.Click += this.button14_Click_1;
			this.button17.BackColor = Color.LavenderBlush;
			this.button17.FlatStyle = FlatStyle.Flat;
			this.button17.Font = new Font("Microsoft YaHei", 7.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.button17.ForeColor = Color.Silver;
			this.button17.Location = new Point(708, 242);
			this.button17.Name = "button17";
			this.button17.Size = new Size(62, 25);
			this.button17.TabIndex = 52;
			this.button17.Text = "D>C>D";
			this.button17.UseVisualStyleBackColor = false;
			this.button17.Click += this.button17_Click;
			base.AcceptButton = this.btn_Ok;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Control;
			base.CancelButton = this.btn_cancel;
			base.ClientSize = new Size(782, 514);
			base.Controls.Add(this.button17);
			base.Controls.Add(this.button14);
			base.Controls.Add(this.trackBar14);
			base.Controls.Add(this.label17);
			base.Controls.Add(this.trackBar13);
			base.Controls.Add(this.label16);
			base.Controls.Add(this.trackBar12);
			base.Controls.Add(this.label15);
			base.Controls.Add(this.trackBar11);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.trackBar10);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.button16);
			base.Controls.Add(this.button15);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.trackBar9);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.trackBar8);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.trackBar7);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.trackBar6);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.trackBar5);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.trackBar4);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label_split);
			base.Controls.Add(this.label_solt);
			base.Controls.Add(this.button1_advance);
			base.Controls.Add(this.btn_Ok);
			base.Controls.Add(this.btn_cancel);
			base.Controls.Add(this.trackBar3);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.trackBar2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.button13);
			base.Controls.Add(this.button12);
			base.Controls.Add(this.button11);
			base.Controls.Add(this.button10);
			base.Controls.Add(this.button9);
			base.Controls.Add(this.button8);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.button6);
			base.Controls.Add(this.button7);
			base.Controls.Add(this.button5);
			base.Controls.Add(this.button4);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.trackBar1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Battery";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Setting";
			((ISupportInitialize)this.trackBar1).EndInit();
			((ISupportInitialize)this.trackBar2).EndInit();
			((ISupportInitialize)this.trackBar3).EndInit();
			((ISupportInitialize)this.trackBar4).EndInit();
			((ISupportInitialize)this.trackBar5).EndInit();
			((ISupportInitialize)this.trackBar6).EndInit();
			((ISupportInitialize)this.trackBar7).EndInit();
			((ISupportInitialize)this.trackBar8).EndInit();
			((ISupportInitialize)this.trackBar9).EndInit();
			((ISupportInitialize)this.trackBar10).EndInit();
			((ISupportInitialize)this.trackBar11).EndInit();
			((ISupportInitialize)this.trackBar12).EndInit();
			((ISupportInitialize)this.trackBar13).EndInit();
			((ISupportInitialize)this.trackBar14).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00006F94 File Offset: 0x00005194
		public Battery()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00006FB0 File Offset: 0x000051B0
		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			this.batt_caps = this.trackBar1.Value * 100;
			this.label2.Text = "Capacity:  " + this.batt_caps + "mAh";
			if (this.batt_caps <= this.trackBar2.Maximum * 10 && this.batt_caps >= 50)
			{
				this.trackBar2.Value = this.batt_caps / 10;
			}
			if (this.batt_caps <= this.trackBar3.Maximum * 20 && this.batt_caps >= 100)
			{
				this.trackBar3.Value = this.batt_caps / 20;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00007070 File Offset: 0x00005270
		private void trackBar2_ValueChanged(object sender, EventArgs e)
		{
			this.current = this.trackBar2.Value * 10;
			this.label4.Text = "Charge Current:  " + ((float)this.current / 1000f).ToString("f2") + "A";
			if (this.current > this.end_cur)
			{
				if (this.current >= 200)
				{
					this.trackBar6.Maximum = this.current / 10;
					this.end_cur = this.current / 10;
				}
				else
				{
					this.end_cur = 20;
				}
				this.trackBar6.Value = this.end_cur / 10;
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00007134 File Offset: 0x00005334
		private void trackBar3_ValueChanged(object sender, EventArgs e)
		{
			this.dcurrent = this.trackBar3.Value * 10;
			this.label5.Text = "Discharge Current:  " + ((float)this.dcurrent / 1000f).ToString("f2") + "A";
			if (this.dcurrent > this.end_dcur)
			{
				if (this.dcurrent >= 40)
				{
					this.trackBar7.Maximum = this.dcurrent / 10;
					this.end_dcur = this.dcurrent / 2;
				}
				else
				{
					this.end_dcur = 20;
				}
				this.trackBar7.Value = this.end_dcur / 10;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000071F4 File Offset: 0x000053F4
		private void trackBar4_ValueChanged(object sender, EventArgs e)
		{
			this.end_volt = this.trackBar4.Value * 10;
			this.label6.Text = "Charge End Voltage:  " + ((float)this.end_volt / 1000f).ToString("f2") + "V";
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000724C File Offset: 0x0000544C
		private void trackBar5_ValueChanged(object sender, EventArgs e)
		{
			this.end_dvolt = this.trackBar5.Value * 10;
			this.label7.Text = "Discharge End Voltage:  " + ((float)this.end_dvolt / 1000f).ToString("f2") + "V";
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000072A3 File Offset: 0x000054A3
		private void trackBar6_ValueChanged(object sender, EventArgs e)
		{
			this.end_cur = this.trackBar6.Value * 10;
			this.label8.Text = "Charge End Current:  " + this.end_cur + "mA";
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000072E0 File Offset: 0x000054E0
		private void trackBar7_ValueChanged(object sender, EventArgs e)
		{
			this.end_dcur = this.trackBar7.Value * 10;
			this.label9.Text = "Discharge End Current:  " + this.end_dcur + "mA";
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000731D File Offset: 0x0000551D
		private void trackBar8_ValueChanged(object sender, EventArgs e)
		{
			this.rest_time = this.trackBar8.Value;
			this.label10.Text = "Resting Time:  " + this.rest_time + "min";
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00007357 File Offset: 0x00005557
		private void trackBar9_ValueChanged(object sender, EventArgs e)
		{
			this.cycle_count = this.trackBar9.Value;
			this.label11.Text = "Cycle Count:  " + this.cycle_count;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000738C File Offset: 0x0000558C
		private void trackBar10_ValueChanged(object sender, EventArgs e)
		{
			this.peak_sense = this.trackBar10.Value;
			this.label13.Text = "Ni -DetalV:  " + this.peak_sense + "mV";
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000073C8 File Offset: 0x000055C8
		private void trackBar11_ValueChanged(object sender, EventArgs e)
		{
			this.trickle = this.trackBar11.Value * 10;
			if (this.trickle == 0)
			{
				this.label14.Text = "Trickle: OFF";
			}
			else
			{
				this.label14.Text = "Trickle:" + this.trickle + "mA";
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00007434 File Offset: 0x00005634
		private void trackBar12_ValueChanged(object sender, EventArgs e)
		{
			this.hold_volt = this.trackBar12.Value * 10;
			this.label15.Text = "Hold Voltage:  " + ((float)this.hold_volt / 1000f).ToString("f2") + "V";
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000748B File Offset: 0x0000568B
		private void trackBar13_ValueChanged(object sender, EventArgs e)
		{
			this.cuttemp = this.trackBar13.Value;
			this.label16.Text = "Cut Temperature:  " + this.cuttemp / 10 + "C";
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000074C8 File Offset: 0x000056C8
		private void trackBar14_ValueChanged(object sender, EventArgs e)
		{
			this.cuttime = this.trackBar14.Value * 10;
			this.label17.Text = "Cut Time:  " + this.cuttime + "min";
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00007508 File Offset: 0x00005708
		private void button14_Click_1(object sender, EventArgs e)
		{
			this.cycle_mode = 0;
			this.button14.ForeColor = Color.Black;
			this.button15.ForeColor = Color.Silver;
			this.button16.ForeColor = Color.Silver;
			this.button17.ForeColor = Color.Silver;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00007564 File Offset: 0x00005764
		private void button15_Click_1(object sender, EventArgs e)
		{
			this.cycle_mode = 1;
			this.button14.ForeColor = Color.Silver;
			this.button15.ForeColor = Color.Black;
			this.button16.ForeColor = Color.Silver;
			this.button17.ForeColor = Color.Silver;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000075C0 File Offset: 0x000057C0
		private void button16_Click(object sender, EventArgs e)
		{
			this.cycle_mode = 2;
			this.button14.ForeColor = Color.Silver;
			this.button15.ForeColor = Color.Silver;
			this.button16.ForeColor = Color.Black;
			this.button17.ForeColor = Color.Silver;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000761C File Offset: 0x0000581C
		private void button17_Click(object sender, EventArgs e)
		{
			this.cycle_mode = 3;
			this.button14.ForeColor = Color.Silver;
			this.button15.ForeColor = Color.Silver;
			this.button16.ForeColor = Color.Silver;
			this.button17.ForeColor = Color.Black;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00007678 File Offset: 0x00005878
		public void Set_Battery_Type_Caps(ChargerData[] data, int index)
		{
			this.bSave = false;
			this.bAdvance = false;
			try
			{
				base.Width = 446;
				this.button1_advance.Text = ">>";
				this.label_solt.Text = "#" + (index + 1).ToString();
				this.batt_type = data[index].Type;
				this.label1.Text = "Type:  " + Battery.bat_type_str[this.batt_type];
				this.Reset_Type_Button_ForeColor();
				if (this.batt_type == 0)
				{
					this.button1.ForeColor = Color.Black;
				}
				else if (this.batt_type == 1)
				{
					this.button2.ForeColor = Color.Black;
				}
				else if (this.batt_type == 2)
				{
					this.button3.ForeColor = Color.Black;
				}
				else if (this.batt_type == 3)
				{
					this.button4.ForeColor = Color.Black;
				}
				else if (this.batt_type == 4)
				{
					this.button5.ForeColor = Color.Black;
				}
				else if (this.batt_type == 5)
				{
					this.button6.ForeColor = Color.Black;
				}
				else if (this.batt_type == 6)
				{
					this.button7.ForeColor = Color.Black;
				}
				this.batt_caps = data[index].Caps;
				this.trackBar1.Value = this.batt_caps / 100;
				this.label2.Text = "Capacity:  " + this.batt_caps + "mAh";
				this.mode = data[index].Mode;
				this.Reset_Mode_Button_ForeColor();
				if (this.batt_type < 3)
				{
					this.trackBar2.Maximum = 300;
					this.label3.Text = "Mode:  " + Battery.li_mode_str[this.mode];
					if (this.mode == 0)
					{
						this.button8.ForeColor = Color.Black;
					}
					else if (this.mode == 1)
					{
						this.button9.ForeColor = Color.Black;
					}
					else if (this.mode == 2)
					{
						this.button10.ForeColor = Color.Black;
					}
					else if (this.mode == 3)
					{
						this.button11.ForeColor = Color.Black;
					}
					else if (this.mode == 4)
					{
						this.button12.ForeColor = Color.Black;
					}
				}
				else
				{
					this.trackBar2.Maximum = 200;
					this.label3.Text = "Mode:  " + Battery.ni_mode_str[this.mode];
					if (this.mode == 0)
					{
						this.button8.ForeColor = Color.Black;
					}
					else if (this.mode == 1)
					{
						this.button9.ForeColor = Color.Black;
					}
					else if (this.mode == 2)
					{
						this.button13.ForeColor = Color.Black;
					}
					else if (this.mode == 3)
					{
						this.button11.ForeColor = Color.Black;
					}
					else if (this.mode == 4)
					{
						this.button12.ForeColor = Color.Black;
					}
				}
				this.current = data[index].Cur;
				this.trackBar2.Value = this.current / 10;
				this.label4.Text = "Charge Current:  " + ((float)this.current / 1000f).ToString("f2") + "A";
				this.dcurrent = data[index].dCur;
				this.trackBar3.Value = this.dcurrent / 10;
				this.label5.Text = "Discharge Current:  " + ((float)this.dcurrent / 1000f).ToString("f2") + "A";
				this.cycle_count = data[index].Cycle_Count;
				this.trackBar9.Value = this.cycle_count;
				this.label11.Text = "Cycle Count:  " + this.cycle_count;
				this.end_volt = data[index].End_Volt;
				if (this.batt_type < 3 && this.mode == 2)
				{
					this.trackBar4.Maximum = Battery.STORGE_VOL_H[this.batt_type] / 10;
					this.trackBar4.Minimum = Battery.STORGE_VOL_L[this.batt_type] / 10;
					this.label15.Text = "Hold Voltage:  OFF";
					this.trackBar12.Enabled = false;
				}
				else
				{
					this.trackBar4.Maximum = Battery.CHG_VOL_H[this.batt_type] / 10;
					this.trackBar4.Minimum = Battery.CHG_VOL_L[this.batt_type] / 10;
				}
				this.trackBar4.Value = this.end_volt / 10;
				this.label6.Text = "Charge End Voltage:  " + ((float)this.end_volt / 1000f).ToString("f2") + "V";
				this.end_dvolt = data[index].Cut_Volt;
				this.trackBar5.Maximum = Battery.DCHG_VOL_H[this.batt_type] / 10;
				this.trackBar5.Minimum = Battery.DCHG_VOL_L[this.batt_type] / 10;
				if (this.end_dvolt / 10 < this.trackBar5.Minimum)
				{
					this.trackBar5.Value = this.trackBar5.Minimum;
				}
				else if (this.end_dvolt / 10 > this.trackBar5.Maximum)
				{
					this.trackBar5.Value = this.trackBar5.Maximum;
				}
				else
				{
					this.trackBar5.Value = this.end_dvolt / 10;
				}
				this.label7.Text = "Discharge End Voltage:  " + ((float)this.end_dvolt / 1000f).ToString("f2") + "V";
				this.end_cur = data[index].End_Cur;
				this.trackBar6.Maximum = this.current / 10;
				this.trackBar6.Minimum = 0;
				this.trackBar6.Value = this.end_cur / 10;
				this.label8.Text = "Charge End Current:  " + this.end_cur + "mA";
				this.end_dcur = data[index].End_dCur;
				this.trackBar7.Maximum = this.dcurrent / 10;
				this.trackBar7.Minimum = 0;
				this.trackBar7.Value = this.end_dcur / 10;
				this.label9.Text = "Discharge End Current:  " + this.end_dcur + "mA";
				this.rest_time = data[index].Cycle_Delay;
				this.trackBar8.Value = this.rest_time;
				this.label10.Text = "Resting Time:  " + this.rest_time + "min";
				this.button14.ForeColor = Color.Silver;
				this.button15.ForeColor = Color.Silver;
				this.button16.ForeColor = Color.Silver;
				this.button17.ForeColor = Color.Silver;
				this.cycle_mode = data[index].Cycle_Mode;
				if (this.cycle_mode == 0)
				{
					this.button14.ForeColor = Color.Black;
				}
				else if (this.cycle_mode == 1)
				{
					this.button15.ForeColor = Color.Black;
				}
				else if (this.cycle_mode == 2)
				{
					this.button16.ForeColor = Color.Black;
				}
				else if (this.cycle_mode == 3)
				{
					this.button17.ForeColor = Color.Black;
				}
				this.peak_sense = data[index].Peak_Sense;
				this.trackBar10.Value = this.peak_sense;
				this.label13.Text = "Ni -DetalV:  " + this.peak_sense + "mV";
				this.trickle = data[index].Trickle;
				this.trackBar11.Value = this.trickle / 10;
				if (this.trickle == 0)
				{
					this.label14.Text = "Trickle: OFF";
				}
				else
				{
					this.label14.Text = "Trickle:  " + this.trickle + "mA";
				}
				if (this.batt_type >= 3 || this.mode != 2)
				{
					this.hold_volt = data[index].Hold_Volt;
					this.trackBar12.Maximum = Battery.RST_VOL_H[this.batt_type] / 10;
					this.trackBar12.Minimum = Battery.RST_VOL_L[this.batt_type] / 10;
					if (this.hold_volt / 10 < this.trackBar12.Minimum)
					{
						this.trackBar12.Value = this.trackBar12.Minimum;
					}
					else if (this.hold_volt / 10 > this.trackBar12.Maximum)
					{
						this.trackBar12.Value = this.trackBar12.Maximum;
					}
					else
					{
						this.trackBar12.Value = this.hold_volt / 10;
					}
					this.label15.Text = "Hold Voltage:  " + ((float)this.hold_volt / 1000f).ToString("f2") + "V";
				}
				this.cuttemp = data[index].CutTemp;
				this.trackBar13.Value = this.cuttemp;
				this.label16.Text = "Cut Temperature:  " + this.cuttemp / 10 + "C";
				this.cuttime = data[index].CutTime;
				this.trackBar14.Value = this.cuttime / 10;
				this.label17.Text = "Cut Time:  " + this.cuttime + "min";
			}
			catch (Exception)
			{
				data[index].Type = 0;
				data[index].Caps = 2000;
				data[index].Mode = 0;
				data[index].Cur = 1000;
				data[index].dCur = 500;
				data[index].End_Volt = 4200;
				data[index].Cut_Volt = 3300;
				data[index].End_Cur = 100;
				data[index].End_dCur = 400;
				data[index].Cycle_Mode = 0;
				data[index].Cycle_Count = 1;
				data[index].Cycle_Delay = 10;
				data[index].Peak_Sense = 3;
				data[index].Trickle = 50;
				data[index].Hold_Volt = 4180;
				data[index].CutTemp = 450;
				data[index].CutTime = 180;
				return;
			}
			base.ShowDialog();
			if (this.bSave)
			{
				data[index].Type = this.batt_type;
				data[index].Caps = this.batt_caps;
				data[index].Mode = this.mode;
				data[index].Cur = this.current;
				data[index].dCur = this.dcurrent;
				data[index].End_Volt = this.end_volt;
				data[index].Cut_Volt = this.end_dvolt;
				data[index].End_Cur = this.end_cur;
				data[index].End_dCur = this.end_dcur;
				data[index].Cycle_Mode = this.cycle_mode;
				data[index].Cycle_Count = this.cycle_count;
				data[index].Cycle_Delay = this.rest_time;
				data[index].Peak_Sense = this.peak_sense;
				data[index].Trickle = this.trickle;
				data[index].Hold_Volt = this.hold_volt;
				data[index].CutTemp = this.cuttemp;
				data[index].CutTime = this.cuttime;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00008378 File Offset: 0x00006578
		private void Reset_Type_Button_ForeColor()
		{
			this.button1.ForeColor = Color.Silver;
			this.button2.ForeColor = Color.Silver;
			this.button3.ForeColor = Color.Silver;
			this.button4.ForeColor = Color.Silver;
			this.button5.ForeColor = Color.Silver;
			this.button7.ForeColor = Color.Silver;
			this.button6.ForeColor = Color.Silver;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00008400 File Offset: 0x00006600
		private void button_Type_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			int num;
			if (button.Text.Contains("LiIon"))
			{
				num = 0;
			}
			else if (button.Text.Contains("LiFe"))
			{
				num = 1;
			}
			else if (button.Text.Contains("LiHV"))
			{
				num = 2;
			}
			else if (button.Text.Contains("NiMH"))
			{
				num = 3;
			}
			else if (button.Text.Contains("NiCd"))
			{
				num = 4;
			}
			else if (button.Text.Contains("NiZn"))
			{
				num = 5;
			}
			else
			{
				num = 6;
			}
			if (num != this.batt_type)
			{
				this.batt_type = num;
				this.Reset_Type_Button_ForeColor();
				button.ForeColor = Color.Black;
				this.label1.Text = "Type:  " + Battery.bat_type_str[this.batt_type];
				if (this.batt_type < 3)
				{
					this.trackBar2.Maximum = 300;
				}
				else
				{
					if (this.trackBar2.Value > 200)
					{
						this.trackBar2.Value = 100;
					}
					this.trackBar2.Maximum = 200;
				}
				if (this.mode == 2)
				{
					this.mode = 0;
					this.label3.Text = "Mode:  " + Battery.li_mode_str[this.mode];
					this.Reset_Mode_Button_ForeColor();
					this.button8.ForeColor = Color.Black;
				}
				this.trackBar4.Maximum = Battery.CHG_VOL_H[this.batt_type] / 10;
				this.trackBar4.Minimum = Battery.CHG_VOL_L[this.batt_type] / 10;
				this.trackBar4.Value = Battery.CHG_VOL_DEFAULT[this.batt_type] / 10;
				this.trackBar5.Maximum = Battery.DCHG_VOL_H[this.batt_type] / 10;
				this.trackBar5.Minimum = Battery.DCHG_VOL_L[this.batt_type] / 10;
				this.trackBar5.Value = Battery.DCHG_VOL_DEFAULT[this.batt_type] / 10;
				this.trackBar12.Maximum = Battery.RST_VOL_H[this.batt_type] / 10;
				this.trackBar12.Minimum = Battery.RST_VOL_L[this.batt_type] / 10;
				this.trackBar12.Value = Battery.RST_VOL_DEFAULT[this.batt_type] / 10;
				this.trackBar12.Enabled = true;
				this.label15.Text = "Hold Voltage:  " + ((float)this.hold_volt / 1000f).ToString("f2") + "V";
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000086F8 File Offset: 0x000068F8
		private void Reset_Mode_Button_ForeColor()
		{
			this.button8.ForeColor = Color.Silver;
			this.button9.ForeColor = Color.Silver;
			this.button10.ForeColor = Color.Silver;
			this.button11.ForeColor = Color.Silver;
			this.button12.ForeColor = Color.Silver;
			this.button13.ForeColor = Color.Silver;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000876C File Offset: 0x0000696C
		private void button_Mode_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			int num;
			if (button.Text.Contains("Charge"))
			{
				num = 0;
			}
			else if (button.Text.Contains("Refresh"))
			{
				num = 1;
			}
			else if (button.Text.Contains("Storage"))
			{
				if (this.batt_type >= 3)
				{
					return;
				}
				num = 2;
			}
			else if (button.Text.Contains("Discharge"))
			{
				num = 3;
			}
			else if (button.Text.Contains("Cycle"))
			{
				num = 4;
			}
			else
			{
				if (this.batt_type < 3)
				{
					return;
				}
				num = 2;
				this.cycle_mode = 0;
			}
			if (num != this.mode)
			{
				this.mode = num;
				if (this.batt_type < 3)
				{
					this.label3.Text = "Mode:  " + Battery.li_mode_str[this.mode];
				}
				else
				{
					this.label3.Text = "Mode:  " + Battery.ni_mode_str[this.mode];
				}
				this.Reset_Mode_Button_ForeColor();
				button.ForeColor = Color.Black;
				if (this.batt_type < 3 && this.mode == 2)
				{
					this.trackBar4.Maximum = Battery.STORGE_VOL_H[this.batt_type] / 10;
					this.trackBar4.Minimum = Battery.STORGE_VOL_L[this.batt_type] / 10;
					this.trackBar4.Value = Battery.STORGE_VOL_DEFAULT[this.batt_type] / 10;
					this.trackBar12.Enabled = false;
					this.label15.Text = "Hold Voltage:  OFF";
				}
				else
				{
					this.trackBar4.Maximum = Battery.CHG_VOL_H[this.batt_type] / 10;
					this.trackBar4.Minimum = Battery.CHG_VOL_L[this.batt_type] / 10;
					this.trackBar4.Value = Battery.CHG_VOL_DEFAULT[this.batt_type] / 10;
					this.trackBar12.Maximum = Battery.RST_VOL_H[this.batt_type] / 10;
					this.trackBar12.Minimum = Battery.RST_VOL_L[this.batt_type] / 10;
					this.trackBar12.Value = Battery.RST_VOL_DEFAULT[this.batt_type] / 10;
					this.trackBar12.Enabled = true;
					this.label15.Text = "Hold Voltage:  " + ((float)this.hold_volt / 1000f).ToString("f2") + "V";
				}
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00008A45 File Offset: 0x00006C45
		private void button14_Click(object sender, EventArgs e)
		{
			this.bSave = false;
			base.Close();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00008A56 File Offset: 0x00006C56
		private void button15_Click(object sender, EventArgs e)
		{
			this.bSave = true;
			base.Close();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00008A68 File Offset: 0x00006C68
		private void button1_advance_Click(object sender, EventArgs e)
		{
			this.bAdvance = !this.bAdvance;
			if (this.bAdvance)
			{
				base.Width = 788;
				this.button1_advance.Text = "<<";
			}
			else
			{
				base.Width = 446;
				this.button1_advance.Text = ">>";
			}
		}

		// Token: 0x0400005B RID: 91
		private IContainer components = null;

		// Token: 0x0400005C RID: 92
		private TrackBar trackBar1;

		// Token: 0x0400005D RID: 93
		private Label label1;

		// Token: 0x0400005E RID: 94
		private Button button1;

		// Token: 0x0400005F RID: 95
		private Button button2;

		// Token: 0x04000060 RID: 96
		private Button button3;

		// Token: 0x04000061 RID: 97
		private Button button4;

		// Token: 0x04000062 RID: 98
		private Button button5;

		// Token: 0x04000063 RID: 99
		private Button button7;

		// Token: 0x04000064 RID: 100
		private Button button6;

		// Token: 0x04000065 RID: 101
		private Label label2;

		// Token: 0x04000066 RID: 102
		private Label label3;

		// Token: 0x04000067 RID: 103
		private Button button8;

		// Token: 0x04000068 RID: 104
		private Button button9;

		// Token: 0x04000069 RID: 105
		private Button button10;

		// Token: 0x0400006A RID: 106
		private Button button11;

		// Token: 0x0400006B RID: 107
		private Button button12;

		// Token: 0x0400006C RID: 108
		private Button button13;

		// Token: 0x0400006D RID: 109
		private Label label4;

		// Token: 0x0400006E RID: 110
		private TrackBar trackBar2;

		// Token: 0x0400006F RID: 111
		private Label label5;

		// Token: 0x04000070 RID: 112
		private TrackBar trackBar3;

		// Token: 0x04000071 RID: 113
		private Button btn_cancel;

		// Token: 0x04000072 RID: 114
		private Button btn_Ok;

		// Token: 0x04000073 RID: 115
		private Button button1_advance;

		// Token: 0x04000074 RID: 116
		private Label label_solt;

		// Token: 0x04000075 RID: 117
		private Label label_split;

		// Token: 0x04000076 RID: 118
		private Label label6;

		// Token: 0x04000077 RID: 119
		private TrackBar trackBar4;

		// Token: 0x04000078 RID: 120
		private Label label7;

		// Token: 0x04000079 RID: 121
		private TrackBar trackBar5;

		// Token: 0x0400007A RID: 122
		private Label label8;

		// Token: 0x0400007B RID: 123
		private TrackBar trackBar6;

		// Token: 0x0400007C RID: 124
		private Label label9;

		// Token: 0x0400007D RID: 125
		private TrackBar trackBar7;

		// Token: 0x0400007E RID: 126
		private Label label10;

		// Token: 0x0400007F RID: 127
		private TrackBar trackBar8;

		// Token: 0x04000080 RID: 128
		private Label label11;

		// Token: 0x04000081 RID: 129
		private TrackBar trackBar9;

		// Token: 0x04000082 RID: 130
		private Label label12;

		// Token: 0x04000083 RID: 131
		private Button button15;

		// Token: 0x04000084 RID: 132
		private Button button16;

		// Token: 0x04000085 RID: 133
		private Label label13;

		// Token: 0x04000086 RID: 134
		private TrackBar trackBar10;

		// Token: 0x04000087 RID: 135
		private Label label14;

		// Token: 0x04000088 RID: 136
		private TrackBar trackBar11;

		// Token: 0x04000089 RID: 137
		private Label label15;

		// Token: 0x0400008A RID: 138
		private TrackBar trackBar12;

		// Token: 0x0400008B RID: 139
		private Label label16;

		// Token: 0x0400008C RID: 140
		private TrackBar trackBar13;

		// Token: 0x0400008D RID: 141
		private Label label17;

		// Token: 0x0400008E RID: 142
		private TrackBar trackBar14;

		// Token: 0x0400008F RID: 143
		private Button button14;

		// Token: 0x04000090 RID: 144
		private Button button17;

		// Token: 0x04000091 RID: 145
		private static string[] bat_type_str = new string[]
		{
			"LiIon",
			"LiFe",
			"LiHV",
			"NiMH",
			"NiCd",
			"NiZn",
			"ENELOOP"
		};

		// Token: 0x04000092 RID: 146
		private static string[] ni_mode_str = new string[]
		{
			"Charge",
			"Refresh",
			"BreakIn",
			"Discharge",
			"Cycle"
		};

		// Token: 0x04000093 RID: 147
		private static string[] li_mode_str = new string[]
		{
			"Charge",
			"Refresh",
			"Storage",
			"Discharge",
			"Cycle"
		};

		// Token: 0x04000094 RID: 148
		private static int[] DCHG_VOL_H = new int[]
		{
			3650,
			3150,
			3750,
			1100,
			1100,
			1300,
			1000
		};

		// Token: 0x04000095 RID: 149
		private static int[] DCHG_VOL_DEFAULT = new int[]
		{
			3000,
			2900,
			3300,
			1000,
			1000,
			1200,
			900
		};

		// Token: 0x04000096 RID: 150
		private static int[] DCHG_VOL_L = new int[]
		{
			2500,
			2000,
			2650,
			200,
			200,
			1000,
			500
		};

		// Token: 0x04000097 RID: 151
		private static int[] CHG_VOL_H = new int[]
		{
			4250,
			3650,
			4400,
			1800,
			1800,
			1950,
			1800
		};

		// Token: 0x04000098 RID: 152
		private static int[] CHG_VOL_DEFAULT = new int[]
		{
			4200,
			3600,
			4350,
			1650,
			1650,
			1900,
			1650
		};

		// Token: 0x04000099 RID: 153
		private static int[] CHG_VOL_L = new int[]
		{
			4000,
			3400,
			4100,
			1500,
			1500,
			1850,
			1500
		};

		// Token: 0x0400009A RID: 154
		private static int[] STORGE_VOL_H = new int[]
		{
			4000,
			3400,
			4100
		};

		// Token: 0x0400009B RID: 155
		private static int[] STORGE_VOL_DEFAULT = new int[]
		{
			3800,
			3300,
			3900
		};

		// Token: 0x0400009C RID: 156
		private static int[] STORGE_VOL_L = new int[]
		{
			3650,
			3150,
			3750
		};

		// Token: 0x0400009D RID: 157
		private static int[] RST_VOL_H = new int[]
		{
			4180,
			3580,
			4330,
			1450,
			1450,
			1880,
			1450
		};

		// Token: 0x0400009E RID: 158
		private static int[] RST_VOL_DEFAULT = new int[]
		{
			4150,
			3550,
			4250,
			1350,
			1350,
			1600,
			1350
		};

		// Token: 0x0400009F RID: 159
		private static int[] RST_VOL_L = new int[]
		{
			4000,
			3400,
			4150,
			1300,
			1300,
			1500,
			1300
		};

		// Token: 0x040000A0 RID: 160
		private int batt_type;

		// Token: 0x040000A1 RID: 161
		private int batt_caps;

		// Token: 0x040000A2 RID: 162
		private int mode;

		// Token: 0x040000A3 RID: 163
		private int current;

		// Token: 0x040000A4 RID: 164
		private int dcurrent;

		// Token: 0x040000A5 RID: 165
		private int cycle_count;

		// Token: 0x040000A6 RID: 166
		private int cycle_mode;

		// Token: 0x040000A7 RID: 167
		private int rest_time;

		// Token: 0x040000A8 RID: 168
		private int peak_sense;

		// Token: 0x040000A9 RID: 169
		private int trickle;

		// Token: 0x040000AA RID: 170
		private int hold_volt;

		// Token: 0x040000AB RID: 171
		private int end_volt;

		// Token: 0x040000AC RID: 172
		private int end_dvolt;

		// Token: 0x040000AD RID: 173
		private int end_cur;

		// Token: 0x040000AE RID: 174
		private int end_dcur;

		// Token: 0x040000AF RID: 175
		private int cuttemp;

		// Token: 0x040000B0 RID: 176
		private int cuttime;

		// Token: 0x040000B1 RID: 177
		private bool bSave;

		// Token: 0x040000B2 RID: 178
		private bool bAdvance;
	}
}
