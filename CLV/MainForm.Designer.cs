using System.Windows.Forms;
/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2015-12-14
 * Time: 오전 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CLV
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ToolTip_OpenLogFile = new System.Windows.Forms.ToolStripButton();
			this.LogFilePathLabel = new System.Windows.Forms.TextBox();
			this.LogFilePath = new System.Windows.Forms.TextBox();
			this.LogLineViewRaw = new System.Windows.Forms.DataGridView();
			this.RawLineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawCanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawData1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawData2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawData3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawData4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawData5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawData6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawData7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RawData8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LogLineViewTranslated = new System.Windows.Forms.DataGridView();
			this.TranslatedLineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CanMessageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MsgData1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MsgData2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MsgData3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MsgData4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MsgData5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MsgData6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MsgData7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MsgData8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label_LogLineRangeFrom = new System.Windows.Forms.Label();
			this.checkBox_LogLineRange = new System.Windows.Forms.CheckBox();
			this.textBox_LogLineRangeFrom = new System.Windows.Forms.TextBox();
			this.label_LogLineRangeTo = new System.Windows.Forms.Label();
			this.textBox_LogLineRangeTo = new System.Windows.Forms.TextBox();
			this.toolTip_FieldName = new System.Windows.Forms.ToolTip(this.components);
			this.label_PopupMode = new System.Windows.Forms.Label();
			this.comboBox_PopupMode = new System.Windows.Forms.ComboBox();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LogLineViewRaw)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LogLineViewTranslated)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ToolTip_OpenLogFile});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1219, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// ToolTip_OpenLogFile
			// 
			this.ToolTip_OpenLogFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolTip_OpenLogFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolTip_OpenLogFile.Image")));
			this.ToolTip_OpenLogFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolTip_OpenLogFile.Name = "ToolTip_OpenLogFile";
			this.ToolTip_OpenLogFile.Size = new System.Drawing.Size(23, 22);
			this.ToolTip_OpenLogFile.Text = "Open Log File";
			this.ToolTip_OpenLogFile.Click += new System.EventHandler(this.ToolTip_OpenLogFileClick);
			// 
			// LogFilePathLabel
			// 
			this.LogFilePathLabel.BackColor = System.Drawing.SystemColors.Menu;
			this.LogFilePathLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LogFilePathLabel.Location = new System.Drawing.Point(13, 28);
			this.LogFilePathLabel.Name = "LogFilePathLabel";
			this.LogFilePathLabel.Size = new System.Drawing.Size(100, 14);
			this.LogFilePathLabel.TabIndex = 1;
			this.LogFilePathLabel.TabStop = false;
			this.LogFilePathLabel.Text = "Log File Path:";
			// 
			// LogFilePath
			// 
			this.LogFilePath.BackColor = System.Drawing.SystemColors.Menu;
			this.LogFilePath.Enabled = false;
			this.LogFilePath.Location = new System.Drawing.Point(96, 25);
			this.LogFilePath.Name = "LogFilePath";
			this.LogFilePath.Size = new System.Drawing.Size(389, 21);
			this.LogFilePath.TabIndex = 0;
			this.LogFilePath.TabStop = false;
			// 
			// LogLineViewRaw
			// 
			this.LogLineViewRaw.AllowUserToAddRows = false;
			this.LogLineViewRaw.AllowUserToDeleteRows = false;
			this.LogLineViewRaw.AllowUserToResizeRows = false;
			this.LogLineViewRaw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.LogLineViewRaw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
			this.LogLineViewRaw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.LogLineViewRaw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.RawLineNum,
									this.RawTime,
									this.RawCanId,
									this.RawData1,
									this.RawData2,
									this.RawData3,
									this.RawData4,
									this.RawData5,
									this.RawData6,
									this.RawData7,
									this.RawData8});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.LogLineViewRaw.DefaultCellStyle = dataGridViewCellStyle3;
			this.LogLineViewRaw.Location = new System.Drawing.Point(13, 52);
			this.LogLineViewRaw.Name = "LogLineViewRaw";
			this.LogLineViewRaw.ReadOnly = true;
			this.LogLineViewRaw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.LogLineViewRaw.RowTemplate.Height = 23;
			this.LogLineViewRaw.RowTemplate.ReadOnly = true;
			this.LogLineViewRaw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.LogLineViewRaw.Size = new System.Drawing.Size(532, 557);
			this.LogLineViewRaw.TabIndex = 2;
			this.LogLineViewRaw.Tag = "Raw CAN Data";
			this.LogLineViewRaw.Visible = false;
			this.LogLineViewRaw.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogLineView_CellClicked);
			this.LogLineViewRaw.Scroll += new System.Windows.Forms.ScrollEventHandler(this.LogLineView_Scrolled);
			// 
			// RawLineNum
			// 
			this.RawLineNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.RawLineNum.Frozen = true;
			this.RawLineNum.HeaderText = "Line#";
			this.RawLineNum.Name = "RawLineNum";
			this.RawLineNum.ReadOnly = true;
			this.RawLineNum.Width = 60;
			// 
			// RawTime
			// 
			this.RawTime.HeaderText = "Time";
			this.RawTime.Name = "RawTime";
			this.RawTime.ReadOnly = true;
			this.RawTime.Visible = false;
			this.RawTime.Width = 59;
			// 
			// RawCanId
			// 
			this.RawCanId.HeaderText = "CAN ID";
			this.RawCanId.Name = "RawCanId";
			this.RawCanId.ReadOnly = true;
			this.RawCanId.Width = 71;
			// 
			// RawData1
			// 
			this.RawData1.HeaderText = "D0";
			this.RawData1.Name = "RawData1";
			this.RawData1.ReadOnly = true;
			this.RawData1.Width = 44;
			// 
			// RawData2
			// 
			this.RawData2.HeaderText = "D1";
			this.RawData2.Name = "RawData2";
			this.RawData2.ReadOnly = true;
			this.RawData2.Width = 44;
			// 
			// RawData3
			// 
			this.RawData3.HeaderText = "D2";
			this.RawData3.Name = "RawData3";
			this.RawData3.ReadOnly = true;
			this.RawData3.Width = 44;
			// 
			// RawData4
			// 
			this.RawData4.HeaderText = "D3";
			this.RawData4.Name = "RawData4";
			this.RawData4.ReadOnly = true;
			this.RawData4.Width = 44;
			// 
			// RawData5
			// 
			this.RawData5.HeaderText = "D4";
			this.RawData5.Name = "RawData5";
			this.RawData5.ReadOnly = true;
			this.RawData5.Width = 44;
			// 
			// RawData6
			// 
			this.RawData6.HeaderText = "D5";
			this.RawData6.Name = "RawData6";
			this.RawData6.ReadOnly = true;
			this.RawData6.Width = 44;
			// 
			// RawData7
			// 
			this.RawData7.HeaderText = "D6";
			this.RawData7.Name = "RawData7";
			this.RawData7.ReadOnly = true;
			this.RawData7.Width = 44;
			// 
			// RawData8
			// 
			this.RawData8.HeaderText = "D7";
			this.RawData8.Name = "RawData8";
			this.RawData8.ReadOnly = true;
			this.RawData8.Width = 44;
			// 
			// LogLineViewTranslated
			// 
			this.LogLineViewTranslated.AllowUserToAddRows = false;
			this.LogLineViewTranslated.AllowUserToDeleteRows = false;
			this.LogLineViewTranslated.AllowUserToResizeRows = false;
			this.LogLineViewTranslated.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.LogLineViewTranslated.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
			this.LogLineViewTranslated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.LogLineViewTranslated.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.TranslatedLineNum,
									this.CanMessageName,
									this.MsgData1,
									this.MsgData2,
									this.MsgData3,
									this.MsgData4,
									this.MsgData5,
									this.MsgData6,
									this.MsgData7,
									this.MsgData8});
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.LogLineViewTranslated.DefaultCellStyle = dataGridViewCellStyle4;
			this.LogLineViewTranslated.Location = new System.Drawing.Point(551, 52);
			this.LogLineViewTranslated.Name = "LogLineViewTranslated";
			this.LogLineViewTranslated.ReadOnly = true;
			this.LogLineViewTranslated.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.LogLineViewTranslated.RowTemplate.Height = 23;
			this.LogLineViewTranslated.RowTemplate.ReadOnly = true;
			this.LogLineViewTranslated.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.LogLineViewTranslated.Size = new System.Drawing.Size(664, 557);
			this.LogLineViewTranslated.TabIndex = 3;
			this.LogLineViewTranslated.Tag = "Translated CAN Data";
			this.LogLineViewTranslated.Visible = false;
			this.LogLineViewTranslated.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogLineView_CellClicked);
			this.LogLineViewTranslated.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogLineView_CellMouseEnter);
			this.LogLineViewTranslated.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogLineView_CellMouseLeave);
			this.LogLineViewTranslated.Scroll += new System.Windows.Forms.ScrollEventHandler(this.LogLineView_Scrolled);
			// 
			// TranslatedLineNum
			// 
			this.TranslatedLineNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.TranslatedLineNum.Frozen = true;
			this.TranslatedLineNum.HeaderText = "Line#";
			this.TranslatedLineNum.Name = "TranslatedLineNum";
			this.TranslatedLineNum.ReadOnly = true;
			this.TranslatedLineNum.Width = 60;
			// 
			// CanMessageName
			// 
			this.CanMessageName.HeaderText = "Msg";
			this.CanMessageName.Name = "CanMessageName";
			this.CanMessageName.ReadOnly = true;
			this.CanMessageName.Width = 55;
			// 
			// MsgData1
			// 
			this.MsgData1.HeaderText = "Field1";
			this.MsgData1.Name = "MsgData1";
			this.MsgData1.ReadOnly = true;
			this.MsgData1.Width = 63;
			// 
			// MsgData2
			// 
			this.MsgData2.HeaderText = "Field2";
			this.MsgData2.Name = "MsgData2";
			this.MsgData2.ReadOnly = true;
			this.MsgData2.Width = 63;
			// 
			// MsgData3
			// 
			this.MsgData3.HeaderText = "Field3";
			this.MsgData3.Name = "MsgData3";
			this.MsgData3.ReadOnly = true;
			this.MsgData3.Width = 63;
			// 
			// MsgData4
			// 
			this.MsgData4.HeaderText = "Field4";
			this.MsgData4.Name = "MsgData4";
			this.MsgData4.ReadOnly = true;
			this.MsgData4.Width = 63;
			// 
			// MsgData5
			// 
			this.MsgData5.HeaderText = "Field5";
			this.MsgData5.Name = "MsgData5";
			this.MsgData5.ReadOnly = true;
			this.MsgData5.Width = 63;
			// 
			// MsgData6
			// 
			this.MsgData6.HeaderText = "Field6";
			this.MsgData6.Name = "MsgData6";
			this.MsgData6.ReadOnly = true;
			this.MsgData6.Width = 63;
			// 
			// MsgData7
			// 
			this.MsgData7.HeaderText = "Field7";
			this.MsgData7.Name = "MsgData7";
			this.MsgData7.ReadOnly = true;
			this.MsgData7.Width = 63;
			// 
			// MsgData8
			// 
			this.MsgData8.HeaderText = "Field8";
			this.MsgData8.Name = "MsgData8";
			this.MsgData8.ReadOnly = true;
			this.MsgData8.Width = 63;
			// 
			// label_LogLineRangeFrom
			// 
			this.label_LogLineRangeFrom.Location = new System.Drawing.Point(543, 28);
			this.label_LogLineRangeFrom.Name = "label_LogLineRangeFrom";
			this.label_LogLineRangeFrom.Size = new System.Drawing.Size(92, 14);
			this.label_LogLineRangeFrom.TabIndex = 5;
			this.label_LogLineRangeFrom.Text = "Show line from";
			// 
			// checkBox_LogLineRange
			// 
			this.checkBox_LogLineRange.Location = new System.Drawing.Point(523, 21);
			this.checkBox_LogLineRange.Name = "checkBox_LogLineRange";
			this.checkBox_LogLineRange.Size = new System.Drawing.Size(14, 25);
			this.checkBox_LogLineRange.TabIndex = 4;
			this.checkBox_LogLineRange.UseVisualStyleBackColor = true;
			// 
			// textBox_LogLineRangeFrom
			// 
			this.textBox_LogLineRangeFrom.Location = new System.Drawing.Point(635, 24);
			this.textBox_LogLineRangeFrom.Name = "textBox_LogLineRangeFrom";
			this.textBox_LogLineRangeFrom.Size = new System.Drawing.Size(60, 21);
			this.textBox_LogLineRangeFrom.TabIndex = 6;
			this.textBox_LogLineRangeFrom.Click += new System.EventHandler(this.TextBox_LogLineRangeEditTextClicked);
			// 
			// label_LogLineRangeTo
			// 
			this.label_LogLineRangeTo.Location = new System.Drawing.Point(701, 28);
			this.label_LogLineRangeTo.Name = "label_LogLineRangeTo";
			this.label_LogLineRangeTo.Size = new System.Drawing.Size(18, 13);
			this.label_LogLineRangeTo.TabIndex = 7;
			this.label_LogLineRangeTo.Text = "to";
			// 
			// textBox_LogLineRangeTo
			// 
			this.textBox_LogLineRangeTo.Location = new System.Drawing.Point(716, 25);
			this.textBox_LogLineRangeTo.Name = "textBox_LogLineRangeTo";
			this.textBox_LogLineRangeTo.Size = new System.Drawing.Size(60, 21);
			this.textBox_LogLineRangeTo.TabIndex = 8;
			this.textBox_LogLineRangeTo.Click += new System.EventHandler(this.TextBox_LogLineRangeEditTextClicked);
			// 
			// label_PopupMode
			// 
			this.label_PopupMode.Location = new System.Drawing.Point(802, 28);
			this.label_PopupMode.Name = "label_PopupMode";
			this.label_PopupMode.Size = new System.Drawing.Size(142, 17);
			this.label_PopupMode.TabIndex = 0;
			this.label_PopupMode.Text = "Show InfoPopup when";
			this.label_PopupMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox_PopupMode
			// 
			this.comboBox_PopupMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_PopupMode.FormattingEnabled = true;
			this.comboBox_PopupMode.Items.AddRange(new object[] {
									"Never",
									"Cell Click",
									"Mouse Hover",
									"Mouse Hover w/ Timer"});
			this.comboBox_PopupMode.Location = new System.Drawing.Point(937, 26);
			this.comboBox_PopupMode.Name = "comboBox_PopupMode";
			this.comboBox_PopupMode.Size = new System.Drawing.Size(121, 20);
			this.comboBox_PopupMode.TabIndex = 9;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1219, 621);
			this.Controls.Add(this.comboBox_PopupMode);
			this.Controls.Add(this.label_PopupMode);
			this.Controls.Add(this.textBox_LogLineRangeTo);
			this.Controls.Add(this.textBox_LogLineRangeFrom);
			this.Controls.Add(this.label_LogLineRangeTo);
			this.Controls.Add(this.checkBox_LogLineRange);
			this.Controls.Add(this.label_LogLineRangeFrom);
			this.Controls.Add(this.LogLineViewTranslated);
			this.Controls.Add(this.LogLineViewRaw);
			this.Controls.Add(this.LogFilePath);
			this.Controls.Add(this.LogFilePathLabel);
			this.Controls.Add(this.toolStrip1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "CAN Log Viewer";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LogLineViewRaw)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LogLineViewTranslated)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox comboBox_PopupMode;
		private System.Windows.Forms.Label label_PopupMode;
		private System.Windows.Forms.ToolTip toolTip_FieldName;
		private System.Windows.Forms.TextBox textBox_LogLineRangeTo;
		private System.Windows.Forms.Label label_LogLineRangeTo;
		private System.Windows.Forms.TextBox textBox_LogLineRangeFrom;
		private System.Windows.Forms.CheckBox checkBox_LogLineRange;
		private System.Windows.Forms.Label label_LogLineRangeFrom;
		private System.Windows.Forms.DataGridViewTextBoxColumn MsgData8;
		private System.Windows.Forms.DataGridViewTextBoxColumn MsgData7;
		private System.Windows.Forms.DataGridViewTextBoxColumn MsgData6;
		private System.Windows.Forms.DataGridViewTextBoxColumn MsgData5;
		private System.Windows.Forms.DataGridViewTextBoxColumn MsgData4;
		private System.Windows.Forms.DataGridViewTextBoxColumn MsgData3;
		private System.Windows.Forms.DataGridViewTextBoxColumn MsgData2;
		private System.Windows.Forms.DataGridViewTextBoxColumn MsgData1;
		private System.Windows.Forms.DataGridViewTextBoxColumn CanMessageName;
		private System.Windows.Forms.DataGridViewTextBoxColumn TranslatedLineNum;
		private System.Windows.Forms.DataGridView LogLineViewTranslated;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawData8;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawData7;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawData6;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawData5;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawData4;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawData3;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawData2;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawData1;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawCanId;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn RawLineNum;
		private System.Windows.Forms.DataGridView LogLineViewRaw;
		private System.Windows.Forms.TextBox LogFilePath;
		private System.Windows.Forms.TextBox LogFilePathLabel;
		private System.Windows.Forms.ToolStripButton ToolTip_OpenLogFile;
		private System.Windows.Forms.ToolStrip toolStrip1;
		


	}
}
