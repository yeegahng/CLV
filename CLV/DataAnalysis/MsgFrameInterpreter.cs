/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2015-12-28
 * Time: 오후 3:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CLV
{
	/// <summary>
	/// Description of MsgFrameInterpreter.
	/// </summary>
	public class MsgFrameInterpreter
	{
		enum CANDBType
		{
			CO,
			CNI,
			AES
		}
		
		/// CAN_MSG_TABLE is supposed to be in following map.
		/// 
		/// [0]: MSG name
		/// [1]: Frame length(0~8, byte)
		/// [even]: Field name
		/// [even+1]: Field lendth
		///
		private readonly int INDEX_MSG = 0;
		private readonly int INDEX_LENGTH = 1;
		private readonly int INDEX_DATAFIELD_START = 2;
		
		//for MSG_FRAME_MAP, DataField is used as (FieldName, FieldDataLength)
		private Object[][] MSG_FRAME_MAP =
		{
			new Object[] {"BS", 0},
			new Object[] {"IDC1", 2,	new DataField("BankId",	1),	new DataField("CmdClass", 1)},
			new Object[] {"IDC2", 2,	new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"BIR", 2,		new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"BST", 2,		new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"RPM", 1,		new DataField("BankId", 1)},
			new Object[] {"CCRQ", 4,	new DataField("BankId", 1),	new DataField("RackId", 1),	new DataField("RackPcCmd", 1),	new DataField("RackMcCmd", 1)},
			new Object[] {"BSRQ", 2,	new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"BOMS", 3,	new DataField("BankId", 1),	new DataField("CmdClass", 1),	new DataField("BankState", 1)},
			new Object[] {"SHR", 2,		new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"ESTP", 2,	new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"RSR", 2,		new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"FCR", 2,		new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"IDC1A", 2,	new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"IDC2A", 2,	new DataField("BankId", 1),	new DataField("CmdClass", 1)},
			new Object[] {"BIRA", 6,	new DataField("BankSerialNum", 4),	new DataField("PrjCode", 2)},
			new Object[] {"BSTA", 0},
			new Object[] {"BIRT", 8,	new DataField("CmdClass", 1),	new DataField("BankState", 1),	new DataField("BankInitResult", 1),	new DataField("BankHWVer", 1),	new DataField("BankSWVer", 4)},
			new Object[] {"BSTT", 8,	new DataField("RelayType", 1),	new DataField("BankState", 1),	new DataField("BatteryStartResult", 1),	new DataField("OnlineRackNum", 1),	new DataField("RelayStatusBit", 4)},
			new Object[] {"RIRT", 8,	new DataField("CmdClass", 1),	new DataField("BankState", 1),	new DataField("RackInitResult", 1),	new DataField("CurrentRackNum", 1),	new DataField("ActivatedRackIndexBit", 4)},
			new Object[] {"MIRT", 8,	new DataField("CmdClass", 1),	new DataField("BankState", 1),	new DataField("ModuleInitResult", 1),	new DataField("CurrentRackNum", 1),	new DataField("ActivatedRackIndexBit", 4)},
			new Object[] {"BICT", 8,	new DataField("CmdClass", 1),	new DataField("BankState", 1),	new DataField("RackInitDiagResult", 1),	new DataField("UsableRackNum", 1),	new DataField("UsableRackIndexBit", 4)},
			new Object[] {"OND1", 8,	new DataField("BankSOC", 1),	new DataField("BankRelayStatus", 1),	new DataField("OnlineChrgPowerLimit", 2),	new DataField("OnlineDchrgPowerLimit", 2),	new DataField("BankSOH", 1),	new DataField("UpdateCounter", 1)},
			new Object[] {"OND2", 8,	new DataField("MaxSOC", 1),	new DataField("MinSOC", 1),	new DataField("AvgOnlineRackVoltage", 2),	new DataField("MaxOnlineRackVoltage", 2),	new DataField("MinOnlineRackVoltage", 2)},
			new Object[] {"OND3", 8,	new DataField("MaxSOH", 1),	new DataField("MinSOH", 1),	new DataField("BankCurrent", 2),	new DataField("MaxOnlineRackCurrent", 2),	new DataField("MinOnlineRackCurrent", 2)},
			new Object[] {"OND4", 5,	new DataField("OnlineRackCapacitySum", 2),	new DataField("AvgModuleTemp", 1),	new DataField("MaxModuleTemp", 1),	new DataField("MinModuleTemp", 1)},
			new Object[] {"OND5", 6,	new DataField("AvgCellVoltage", 2),	new DataField("MaxCellVoltage", 2),	new DataField("MinCellVoltage", 2)},
			new Object[] {"OND6", 8,	new DataField("BankDiagnosisFlagBit", 7),	new DataField("BankState", 1)},
			new Object[] {"OND7", 8,	new DataField("MaxCellVoltageRackId", 1),	new DataField("MinCellVoltageRackId", 1),	new DataField("MaxModuleTempRackId", 1),	new DataField("MinModuleTempRackId", 1),	new DataField("MaxVoltageRackId", 1),	new DataField("MinVoltageRackId", 1),	new DataField("MaxCurrentRackId", 1),	new DataField("MinCurrentRackId", 1)},
			new Object[] {"OND8", 6,	new DataField("MinDchrgPowerOnlineRackId", 1),	new DataField("MaxChrgPowerOnlineRackId", 1),	new DataField("MaxSOCRackId", 1),	new DataField("MinSOCRackId", 1),	new DataField("MaxSOHRackId", 1),	new DataField("MinSOHRackId", 1)},
			new Object[] {"OND9", 8,	new DataField("RelayStatusMcBit", 4),	new DataField("RelayStatusPcBit", 4)},
			new Object[] {"OND10", 0},
			new Object[] {"ARD1", 8,	new DataField("RackId", 1),	new DataField("RackRelayStatus", 1),	new DataField("RackVoltage", 2),	new DataField("ChargingStatus", 1),	new DataField("SOC", 1),	new DataField("SOH", 1),	new DataField("UpdateCounter", 1)},
			new Object[] {"ARD2", 8,	new DataField("RackId", 1),	new DataField("RackState", 1),	new DataField("AvgCellVoltage", 2),	new DataField("MaxCellVoltage", 2),	new DataField("MinCellVoltage", 2)},
			new Object[] {"ARD3", 8,	new DataField("RackId", 1),	new DataField("AvgModuleTemp", 1),	new DataField("MaxModuleTemp", 1),	new DataField("MinModuleTemp", 1),	new DataField("RackCurrent", 2),	new DataField("RackCapacity", 2)},
			new Object[] {"ARD4", 8,	new DataField("RackId", 1),	new DataField("RackDiagnosisFlagBit", 7)},
			new Object[] {"ARD5", 6,	new DataField("RackId", 1),	new DataField("CellBalancingFlag", 1),	new DataField("ChrgPowerLimit", 2),	new DataField("DchrgPowerLimit", 2)},
			new Object[] {"ARD6", 5,	new DataField("RackId", 1),	new DataField("MaxVoltageCellId", 1),	new DataField("MinVoltageCellId", 1),	new DataField("MaxTempModuleId", 1),	new DataField("MinTempModuleId", 1)},
			new Object[] {"ARD7", 0},
			new Object[] {"CCRQA", 3,	new DataField("Null", 1),	new DataField("RackId", 1),	new DataField("RackRelayStatus", 1)},
			new Object[] {"CCRQT", 4,	new DataField("Null", 1),	new DataField("RackId", 1),	new DataField("RackRelayStatus", 1),	new DataField("RequestResult", 1)},
			new Object[] {"BSRQT", 3,	new DataField("CmdClass", 1),	new DataField("BankState", 1),	new DataField("BankRelayStatus", 1)},
			new Object[] {"BOMST", 3,	new DataField("CmdClass", 1),	new DataField("BankState", 1),	new DataField("BankModeSetResult", 1)},
			new Object[] {"SHRA", 0},
			new Object[] {"RSRA", 0},
			new Object[] {"FCRA", 0},
			new Object[] {"SHRT", 8,	new DataField("CmdClass", 1),	new DataField("BankState", 1),	new DataField("ShutdownResult", 1),	new DataField("Null", 3),	new DataField("Current", 2)},
			new Object[] {"RSRT", 8,	new DataField("CmdClass", 1),	new DataField("BankState", 1),	new DataField("ShutdownResult", 1),	new DataField("Null", 3),	new DataField("Current", 2)},
			new Object[] {"BRD", 0},
			//new Object[] {"ESTPA", 0}, // ID not determined
		};
		
		public MsgFrameInterpreter()
		{
		}
		
		public bool InterpreteRawDataToReadable(LogLinePair currentLogLinePair)
		{
			//here we need a big, big table to translate all the data in CAN DB...
			
			bool gotTheMsgTranslated = false;
			
			foreach(Object[] msgMapItem in MSG_FRAME_MAP)
			{				
				String canMsgName = (String)msgMapItem[INDEX_MSG];
				if(canMsgName.Equals(currentLogLinePair.CanMessageName))
				{
					int frameByteLength = (int)msgMapItem[INDEX_LENGTH]; //TODO: delete this field, it's not used. (redundant information)
					int dataIndex = 1; //TODO: ugly hard-coded: assortedLogLine contains its raw data from [1] to [8].
					currentLogLinePair.InitializeTransalatedLogLine();
					for(int mapIndex = INDEX_DATAFIELD_START; mapIndex < msgMapItem.Length; mapIndex += 1)
					{
						DataField dataField = (DataField)msgMapItem[mapIndex];
						String fieldName = dataField.FieldName;
						int fieldLength = dataField.FieldDataLength;
						
						String hexStr = String.Join("", currentLogLinePair.AssortedLogLine.ToArray(), dataIndex, fieldLength);
						dataIndex += fieldLength;
						
						String fieldData;
						if(fieldName.EndsWith("Bit"))
						{
							fieldData = HexConverter.HexStrToBinStr(hexStr);
						}
						else
						{
							fieldData = HexConverter.HexStrToDecInt(hexStr).ToString();
						}
						currentLogLinePair.ComposeTranslatedLogLine(new DataField(fieldName, fieldData));
					}
					gotTheMsgTranslated = true;
					break;
				}
				else
				{
					//Try next map item.
				}
			}
			
			return gotTheMsgTranslated;
		}
		
		
	}
}
