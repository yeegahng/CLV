/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2015-12-14
 * Time: 오전 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CLV.Tools;

namespace CLV
{
	
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private ArrayList LogList = new ArrayList();
		private List<LogLinePair> LogLinePairList = new List<LogLinePair>();
		private int CurrentlySelectedRow = -1;
		private InfoPopup infoPopup = new InfoPopup();
		private String LastLogFileName = null;
		private List<String> RawLogItemConfigList = new List<String>();
	
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.comboBox_PopupMode.SelectedIndex = 1; //#1: Cell Click
		}
		
		private void InitializeElements()
		{
			this.LogLineViewRaw.Rows.Clear();
			this.LogLineViewTranslated.Rows.Clear();
			this.LogLinePairList.Clear();
			this.CurrentlySelectedRow = -1;
		}
		
		void ToolTip_OpenLogFileClick(object sender, EventArgs e)
		{			
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if(openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				InitializeElements();
				
				if(!openFileDialog.FileName.Equals(this.LastLogFileName))
				{
					LastLogFileName = (String)openFileDialog.FileName.Clone();
					this.LogList.Clear();
					
					// Read raw log strings from the file
					System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName);	
					String rawLogLine = null;
					Char[] delimiterChars = {' ', ',', ';', '\t'};
					while((rawLogLine = sr.ReadLine()) != null)
					{
						String[] splitLogLine = new String(rawLogLine.ToCharArray()).Split(delimiterChars);
						LogList.Add(splitLogLine);
					}
					sr.Close();					
					
					this.LogFilePath.Text = openFileDialog.FileName;
					Debug.Log(String.Format("Opening Log File Complete ({0} lines, {1} items)", LogList.Count, ((object[])LogList[0]).Length));
					
					// Configure parsor
					this.RawLogItemConfigList.Clear();
					String[] sampleLogLine = (String[])LogList[0]; // Keep a sample line to let the user configure parsing rule.
					RawLogItemConfiguratorWindow configWindow = new RawLogItemConfiguratorWindow();
					RawLogItemConfigList = configWindow.GenerateConfigurationList(sampleLogLine).GetConfigurationList();
				}
				

				// Determine log line range to translate
				int fromLineNum, toLineNum;
				DetermineLogLineRangeToTranslate(1, LogList.Count, out fromLineNum, out toLineNum);
//				fromLineNum = 21105;
//				toLineNum = 21126;
				
				// Parse raw log strings
				CanMsgFinder canLookupTables = new CanMsgFinder();
				Debug.Log("Start parsing log file: " + openFileDialog.SafeFileName);
				for(int logLineIndex = fromLineNum-1; logLineIndex < toLineNum; logLineIndex += 1)
				{
					String[] aLogLine = (String[])LogList[logLineIndex];
					
					LogLinePair aLogLinePair = new LogLinePair(logLineIndex+1);
					bool logItemSearchResult = aLogLinePair.CreateAssortedLogLineItems(aLogLine, RawLogItemConfigList);
					if(logItemSearchResult == false)
					{
						return;
					}
					canLookupTables.FindMsgNameFrom(aLogLinePair);
					
					Debug.Log("Line#"+(logLineIndex+1) + ": " + aLogLinePair.CanMessageName
					              + ((aLogLinePair.TargetBankId > 0) ? ", TargetBankId="+aLogLinePair.TargetBankId : ""));
					
					//Now we have the unique message name. Go parsing. (we should have parsing rule based on msg frame interpreter)
					MsgFrameInterpreter frameInterpreter = new MsgFrameInterpreter();
					frameInterpreter.InterpreteRawDataToReadable(aLogLinePair);
					
					LogLinePairList.Add(aLogLinePair);
				}
				Debug.Log("Complete parsing log file: " + openFileDialog.SafeFileName);
				Debug.Log("Raw log line count = " + LogList.Count);
				Debug.Log("Translated log line count = " + LogLinePairList.Count);
				
				// Display LogLines in DataGridView
				List<String> rawLineRow = new List<String>();
				List<String> translatedLineRow = new List<String>();
				foreach(LogLinePair aLogLinePair in LogLinePairList)
				{
					rawLineRow.Clear();
					translatedLineRow.Clear();
					int lineIndex = aLogLinePair.LineIndex;
					String timestamp = "";
					rawLineRow.Add(lineIndex.ToString());
					rawLineRow.Add(timestamp);
					rawLineRow.AddRange(aLogLinePair.AssortedLogLine.ToArray());
					LogLineViewRaw.Rows.Add(rawLineRow.ToArray());
					
					translatedLineRow.Add(lineIndex.ToString());
					translatedLineRow.AddRange(aLogLinePair.TranslatedLogData);
					LogLineViewTranslated.Rows.Add(translatedLineRow.ToArray());
				}
				this.LogLineViewRaw.Visible = true;
				this.LogLineViewTranslated.Visible = true;
				this.CurrentlySelectedRow = 0;

			}
		}

		void TextBox_LogLineRangeEditTextClicked(object sender, System.EventArgs e)
		{
			checkBox_LogLineRange.Checked = true;
		}
		
		void LogLineView_CellClicked(object sender, DataGridViewCellEventArgs e)
		{
			if(sender.Equals(this.LogLineViewRaw))
			{
				//this.LogLineViewTranslated.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
				//LogLineViewTranslated.CurrentRow.SetValues(e.RowIndex);
				this.LogLineViewTranslated.CurrentRow.Selected = false;
				this.LogLineViewTranslated.Rows[CurrentlySelectedRow].Selected = false;
				this.LogLineViewTranslated.Rows[e.RowIndex].Selected = true;
			}
			else if(sender.Equals(this.LogLineViewTranslated))
			{
				this.LogLineViewRaw.CurrentRow.Selected = false;
				this.LogLineViewRaw.Rows[CurrentlySelectedRow].Selected = false;
				this.LogLineViewRaw.Rows[e.RowIndex].Selected = true;
			}
			CurrentlySelectedRow = e.RowIndex;
			
			if(this.comboBox_PopupMode.SelectedIndex.Equals((int)InfoPopup.SHOW_POPUP_WHEN.CELL_CLICK))
			{
				ShowCellInfoIfPossible(sender as DataGridView, e.RowIndex, e.ColumnIndex);
			}
		}
		
		void LogLineView_Scrolled(object sender, ScrollEventArgs e)
		{
			//Debug.Log("View Scrolled: ori=" + e.ScrollOrientation + ", old value=" + e.OldValue + ", new value=" + e.NewValue + ", type=" + e.Type +")");
			if(sender.Equals(this.LogLineViewRaw))
			{
				this.LogLineViewTranslated.FirstDisplayedScrollingRowIndex = this.LogLineViewRaw.FirstDisplayedScrollingRowIndex;
			}
			else if(sender.Equals(this.LogLineViewTranslated))
			{
				this.LogLineViewRaw.FirstDisplayedScrollingRowIndex = this.LogLineViewTranslated.FirstDisplayedScrollingRowIndex;
			}
		}
		
		void LogLineView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.Log("Cell Mouse Enter: (" + e.RowIndex + ", " + e.ColumnIndex + ")");
			if(this.comboBox_PopupMode.SelectedIndex.Equals((int)InfoPopup.SHOW_POPUP_WHEN.MOUSE_HOVER))
			{
				ShowCellInfoIfPossible(sender as DataGridView, e.RowIndex, e.ColumnIndex);
			}
			else if(this.comboBox_PopupMode.SelectedIndex.Equals((int)InfoPopup.SHOW_POPUP_WHEN.MOUSE_HOVER_TIMER))
			{
				ShowCellInfoIfPossible(sender as DataGridView, e.RowIndex, e.ColumnIndex, 3); //popup timer expires in 3 sec
			}
		}
		
		private void LogLineView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.Log("Cell Mouse Leave: (" + e.RowIndex + ", " + e.ColumnIndex + ")");
		    HideInfoPopup();
		}
		
		private void ShowCellInfoIfPossible(DataGridView view, int rowIndex, int columnIndex, int popupDuration = 0)
		{
			if(rowIndex >= 0 && columnIndex >= 0)
			{				
				//RowIndex=>LogLinePairIndex, ColumnIndex-2=>DataFieldIndex (due to Line#, MsgName)
				if(LogLinePairList[rowIndex].TranslatedLogLine.Count >= columnIndex
				   && 0 < (columnIndex-1))
				{
					DataField dataField = (DataField)(LogLinePairList[rowIndex].TranslatedLogLine[columnIndex-1]);
					String content = dataField.FieldName;
					Rectangle viewRect = view.GetCellDisplayRectangle(columnIndex, rowIndex, true);
					Point viewLocation = view.Location;					
					Debug.Log("ToolTip: " + content + " at viewRect=" + viewRect);
					ShowInfoPopup(viewRect.Left, viewRect.Top, content, popupDuration);
				}
		    }
		}
		
		private void ShowInfoPopup(int posX, int posY, String content, int timerSec)
		{
			if(infoPopup.Visible)
			{
				infoPopup.Hide();
			}
			infoPopup.Location = this.PointToScreen(new Point(posX, posY));
			//infoPopup.Location = new Point(posX, posY);
			infoPopup.Description.Text = content;
			infoPopup.Show(timerSec);
		}
		
		private void HideInfoPopup()
		{
			if(infoPopup.Visible)
			{
				infoPopup.Hide();
			}
		}
		
		private void DetermineLogLineRangeToTranslate(int minOfFromLineNum, int maxOfToLineNum, out int fromLineNum, out int toLineNum)
		{
			fromLineNum = minOfFromLineNum;
			toLineNum = maxOfToLineNum;
			
			if(this.checkBox_LogLineRange.Checked)
			{
				bool readingResult = Int32.TryParse(this.textBox_LogLineRangeFrom.Text, out fromLineNum);
				if(!readingResult)
				{
					fromLineNum = minOfFromLineNum;
				}
				readingResult = Int32.TryParse(this.textBox_LogLineRangeTo.Text, out toLineNum);
				if(!readingResult)
				{
					toLineNum = maxOfToLineNum;
				}
				
				if(fromLineNum > toLineNum)
				{
					//swap fromLineNum and toLineNum if their order corrupts
					int swapbuffer = fromLineNum;
					fromLineNum = toLineNum;
					toLineNum = swapbuffer;
				}
				
				if(fromLineNum < minOfFromLineNum)
				{
					//default values are applied when abnormal input delivered.
					fromLineNum = minOfFromLineNum;
				}
				
				if(toLineNum > maxOfToLineNum)
				{
					//default values are applied when abnormal input delivered.
					toLineNum = maxOfToLineNum;
				}
			}
		}
	}
}
