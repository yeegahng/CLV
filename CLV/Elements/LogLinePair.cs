/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2015-12-24
 * Time: 오후 7:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CLV
{
	/// <summary>
	/// Description of LogLinePair.
	/// </summary>
	public class LogLinePair
	{
		public List<String> AssortedLogLine;
		public List<Object> TranslatedLogLine;
		public String CanMessageName;
		public int TargetBankId;
		public String TxRx; //0:Tx, 1:Rx
		public int LineIndex
		{
			get
			{
				return lineIndex;
			}
		}
		public String[] TranslatedLogData
		{
			get
			{
				return translatedLogData.ToArray();
			}
		}
		
		private String[] logItemList = {"CAN ID", "CANdata1", "CANdata2", "CANdata3", "CANdata4", "CANdata5", "CANdata6", "CANdata7", "CANdata8"};
		private int lineIndex;
		private List<String> translatedLogData; //this list contains data value only (not the data field name)
		
		
		public LogLinePair(int lineIndex)
		{
			AssortedLogLine = new List<String>();
			TranslatedLogLine = new List<Object>();
			CanMessageName = "";
			TargetBankId = 0;
			TxRx = "";
			this.lineIndex = lineIndex;
			translatedLogData = new List<String>();
		}
		
		public bool CreateAssortedLogLineItems(String[] aRawLogLine, List<String> rawLogItemConfigList)
		{
			if(AssortedLogLine.Count != 0)
			{
				Debug.Warning("AssortedLogLine is not empty and is being cleared before reallocation.");
				AssortedLogLine.Clear();
			}

			int rawLogLineDataNum = aRawLogLine.Length;
			bool result = true;

			foreach(String logItem in logItemList)
			{
				if(rawLogItemConfigList.IndexOf(logItem) < 0) { result = false; break;}
				if(rawLogItemConfigList.IndexOf(logItem) >= rawLogLineDataNum) { result = false; break;}
				AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf(logItem)]);
			}
			
			if(result == false)
			{
				MessageBox.Show("Finding Log Item was not successful. Please check configuration and try again.");
			}
			return result;
		}
		
		public void InitializeTransalatedLogLine()
		{
			if(TranslatedLogLine.Count != 0)
			{
				Debug.Warning("AssortedLogLine is not empty and is being cleared before reallocation.");
				TranslatedLogLine.Clear();
			}
			TranslatedLogLine.Add(CanMessageName);
			translatedLogData.Add(CanMessageName);
		}
		
		//for TranslatedLogLine, DataField is used as (FieldName, FieldDataValue)
		public void ComposeTranslatedLogLine(DataField dataField)
		{
			TranslatedLogLine.Add(dataField);
			translatedLogData.Add(dataField.FieldData);
		}
	}
}
