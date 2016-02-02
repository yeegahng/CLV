/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2016-01-07
 * Time: 오후 7:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CLV.Tools
{
	/// <summary>
	/// Description of RawLogItemConfiguratorWindow.
	/// </summary>
	public partial class RawLogItemConfiguratorWindow : Form
	{
		public enum TYPE
		{
			YESNO = 0,
			NOTIFY = 1,
			TRANSIENT = 2
		}
		
		public Label Description = new Label();
		private List<String> RawLogItemConfigList = new List<String>();
		private String[] SampleLogLine = null;
		
		public RawLogItemConfiguratorWindow()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
            this.Text = "Raw Log Item Configurator";
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //Disable normal window functions
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true; //make it appear on the very top
            
			this.Size = new System.Drawing.Size(250, 150);
			this.AutoSize = true;
			this.Capture = true;
			this.Visible = false;
			this.Controls.Add(Description);
			Description.AutoSize = true;
		}
		
		public RawLogItemConfiguratorWindow GenerateConfigurationList(String[] sampleLogLine)
		{
			SampleLogLine = (String[])sampleLogLine.Clone();
			for(int logItemIndex = 0; logItemIndex < sampleLogLine.Length; logItemIndex += 1)
			{
				CreateLogItemCandidate(logItemIndex, sampleLogLine[logItemIndex]);
			}
			
			this.ShowDialog();
			
			return this;
		}
		
		public List<String> GetConfigurationList()
		{
			return RawLogItemConfigList;
		}
		
		private void CreateLogItemCandidate(int logItemIndex, String logItemStr)
		{			
			System.Windows.Forms.Label label_LogItemIndex = new System.Windows.Forms.Label();
			System.Windows.Forms.TextBox textBox_LogItemStr = new System.Windows.Forms.TextBox();
			System.Windows.Forms.ComboBox comboBox_LogItemType = new System.Windows.Forms.ComboBox();
			this.panel_ItemPanel.Controls.Add(comboBox_LogItemType);
			this.panel_ItemPanel.Controls.Add(textBox_LogItemStr);
			this.panel_ItemPanel.Controls.Add(label_LogItemIndex);
			
			int logItemDisplayOffset = 20;
			int logItemHeight = 25;
			int displayOffsetVertical = (logItemIndex * logItemHeight) + logItemDisplayOffset;
			// 
			// label_LogItemIndex
			// 
			label_LogItemIndex.Location = new System.Drawing.Point(17, displayOffsetVertical);
			label_LogItemIndex.Name = "label_LogItemIndex";
			label_LogItemIndex.Size = new System.Drawing.Size(43, 16);
			label_LogItemIndex.TabIndex = 0;
			label_LogItemIndex.Text = "#" + (logItemIndex + 1);
			label_LogItemIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox_LogItemStr
			// 
			textBox_LogItemStr.Location = new System.Drawing.Point(66, displayOffsetVertical);
			textBox_LogItemStr.Name = "textBox_LogItemStr";
			textBox_LogItemStr.ReadOnly = true;
			textBox_LogItemStr.Size = new System.Drawing.Size(137, 21);
			textBox_LogItemStr.TabIndex = 1;
			textBox_LogItemStr.Text = logItemStr;
			// 
			// comboBox_LogItemType
			// 
			comboBox_LogItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox_LogItemType.FormattingEnabled = true;
			comboBox_LogItemType.Location = new System.Drawing.Point(209, displayOffsetVertical);
			comboBox_LogItemType.Name = "comboBox_LogItemType";
			comboBox_LogItemType.Size = new System.Drawing.Size(121, 20);
			comboBox_LogItemType.TabIndex = 2;
			comboBox_LogItemType.Items.AddRange(new object[] {
									"Ignore",
									"Date",
									"Time",
									"CAN ID",
									"MsgSize",
									"CANdata1",
									"CANdata2",
									"CANdata3",
									"CANdata4",
									"CANdata5",
									"CANdata6",
									"CANdata7",
									"CANdata8"});
			if(logItemStr.Length == 0)
			{
				comboBox_LogItemType.SelectedIndex = 0; //empty logItemStr will be 'Ignore'
			}
			
			
		}
		
		private new void Show()
		{
			//it's forbidden to invoke modaless configuration window.
		}

		void Button_ApplyClick(object sender, EventArgs e)
		{
			// For prototyping, I put a static rule. 2015.12.14
//			RawLogItemConfigList.Add("Ignore");
//			RawLogItemConfigList.Add("Date");
//			RawLogItemConfigList.Add("Time");
//			RawLogItemConfigList.Add("Ignore");
//			RawLogItemConfigList.Add("Ignore");
//			RawLogItemConfigList.Add("Ignore");
//			RawLogItemConfigList.Add("CAN ID");
//			RawLogItemConfigList.Add("Ignore");
//			RawLogItemConfigList.Add("Ignore");
//			RawLogItemConfigList.Add("MsgSize");
//			RawLogItemConfigList.Add("Ignore");
//			RawLogItemConfigList.Add("CANdata1");
//			RawLogItemConfigList.Add("CANdata2");
//			RawLogItemConfigList.Add("CANdata3");
//			RawLogItemConfigList.Add("CANdata4");
//			RawLogItemConfigList.Add("CANdata5");
//			RawLogItemConfigList.Add("CANdata6");
//			RawLogItemConfigList.Add("CANdata7");
//			RawLogItemConfigList.Add("CANdata8");
			
			//화면 조작 결과를 읽어서 RawLogItemConfigList를 구성한다.
			foreach(System.Windows.Forms.Control childControl in this.panel_ItemPanel.Controls)
			{
				if(childControl is System.Windows.Forms.ComboBox)
				{
					ComboBox itemTypeSelecter = (ComboBox)childControl;
					if(itemTypeSelecter.SelectedItem != null)
					{
						RawLogItemConfigList.Add(itemTypeSelecter.SelectedItem.ToString());
					}
					else
					{						
						RawLogItemConfigList.Add(itemTypeSelecter.Items[0].ToString()); //default assign to 'Ignore'
					}
				}
			}
			
			StringBuilder parsingRuleMapResult = new StringBuilder();
			int ruleCounter = 0;
			foreach(String item in SampleLogLine)
			{
				parsingRuleMapResult.Append("Rule#" + ruleCounter + ": " + item + "\t --> " + RawLogItemConfigList[ruleCounter].ToString() + "\n");
				ruleCounter++;
			}
			
			//사용자 확인 창
			Notification notiWindow = new Notification("Raw Log Item Configuration Result", Notification.TYPE.YESNO);
			notiWindow.Description.Text = parsingRuleMapResult.ToString();
			if(notiWindow.ShowDialog() == Notification.RESULT.NO)
			{
				//keep config window open (to allow user modification).
			}
			else
			{
				//close config window because user confirmed configuration.
				this.Close();
			}
		}
	}
}
