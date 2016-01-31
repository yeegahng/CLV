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
		
		public void CreateAssortedLogLineItems(String[] aRawLogLine, List<String> rawLogItemConfigList)
		{
			if(AssortedLogLine.Count != 0)
			{
				Debug.Warning("AssortedLogLine is not empty and is being cleared before reallocation.");
				AssortedLogLine.Clear();
			}
			int rawLogLineDataNum = aRawLogLine.Length;
			AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf("CAN ID")]);
			if(rawLogItemConfigList.IndexOf("CANdata1") >= rawLogLineDataNum) return;
			AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf("CANdata1")]);
			if(rawLogItemConfigList.IndexOf("CANdata2") >= rawLogLineDataNum) return;
			AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf("CANdata2")]);
			if(rawLogItemConfigList.IndexOf("CANdata3") >= rawLogLineDataNum) return;
			AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf("CANdata3")]);
			if(rawLogItemConfigList.IndexOf("CANdata4") >= rawLogLineDataNum) return;
			AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf("CANdata4")]);
			if(rawLogItemConfigList.IndexOf("CANdata5") >= rawLogLineDataNum) return;
			AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf("CANdata5")]);
			if(rawLogItemConfigList.IndexOf("CANdata6") >= rawLogLineDataNum) return;
			AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf("CANdata6")]);
			if(rawLogItemConfigList.IndexOf("CANdata7") >= rawLogLineDataNum) return;
			AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf("CANdata7")]);
			if(rawLogItemConfigList.IndexOf("CANdata8") >= rawLogLineDataNum) return;
			AssortedLogLine.Add(aRawLogLine[rawLogItemConfigList.IndexOf("CANdata8")]);			
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
