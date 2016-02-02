/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2015-12-14
 * Time: 오후 5:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CLV
{
	public class CanIdPair
	{
		public CanIdPair(String Id, String Name)
		{
		}
	}

	/// <summary>
	/// Description of CanMsgFinder.
	/// </summary>
	public class CanMsgFinder
	{
		private static String NEED_CONTEXT = "NeedContext";
		private static String PREVIOUS_TX_MESSAGE = "PrevTxMsg";
		private static String COMMAND_CLASS = "CmdClass";

		///
		/// The assorted raw data is supposed to be in following map.
		/// 
		/// [0]: CAN ID
		/// [1]~[8]: 8-byte frame data
		/// 
		private readonly int INDEX_RAW_CANID = 0;
		
		/// CAN_MSG_TABLE is supposed to be in following map.
		/// 
		/// [0]: CAN ID
		/// [1]: Tx or Rx
		/// [2]: CAN Message or identifier(NeedContext or something else)
		/// [3]: Context point (what to check - PrevTxMsg or CmdClass) 
		/// [4]: Index of context data (in byte-wise, 0~7)
		/// [5]: Expected context data (in hexa)
		/// [6]: Final Message
		///
		private readonly int INDEX_CANID = 0;
		private readonly int INDEX_TXRX = 1;
		private readonly int INDEX_PRIMARY_MSG = 2;
		private readonly int INDEX_CONTEXT_IDENTIFIER = 3;
		private readonly int INDEX_POS_OF_CONTEXT_DATA = 4;
		private readonly int INDEX_EXPECTED_CONTEXT_DATA = 5;
		private readonly int INDEX_FINAL_MSG = 6;
		
		private String[][] CAN_MSG_TABLE =
		{
			// EMS -> BBMS
			new String[] {"100", "TX", "BS"},
			new String[] {"101", "TX", "NeedContext", "CmdClass", "2", "20", "IDC1"},
			new String[] {"101", "TX", "NeedContext", "CmdClass", "2", "22", "IDC2"},
			new String[] {"102", "TX", "NeedContext", "CmdClass", "2", "FF", "BIR"},
			new String[] {"102", "TX", "NeedContext", "CmdClass", "2", "55", "BST"},
			new String[] {"103", "TX", "RPM"},
			new String[] {"104", "TX", "CCRQ"},
			new String[] {"105", "TX", "BSRQ"},
			new String[] {"106", "TX", "BOMS"},
			new String[] {"110", "TX", "SHR"},
			new String[] {"10E", "TX", "ESTP"},
			new String[] {"111", "TX", "NeedContext", "CmdClass", "2", "22", "RSR"},
			new String[] {"111", "TX", "NeedContext", "CmdClass", "2", "33", "FCR"},
			
			// BBMS -> EMS
			new String[] {"140", "RX", "NeedContext", "CmdClass", "2", "20", "IDC1A"},
			new String[] {"140", "RX", "NeedContext", "CmdClass", "2", "22", "IDC2A"},
			new String[] {"16", "RX", "NeedContext", "PrevTxMsg", "", "BIR", "BIRA"},
			new String[] {"16", "RX", "NeedContext", "PrevTxMsg", "", "BST", "BSTA"},
			new String[] {"17", "RX", "NeedContext", "PrevTxMsg", "", "BIR", "BIRA"},
			new String[] {"17", "RX", "NeedContext", "PrevTxMsg", "", "BST", "BSTA"},
			new String[] {"18", "RX", "NeedContext", "PrevTxMsg", "", "BIR", "BIRT"},
			new String[] {"18", "RX", "NeedContext", "PrevTxMsg", "", "BST", "BSTT"},
			new String[] {"19", "RX", "NeedContext", "PrevTxMsg", "", "BIR", "BIRT"},
			new String[] {"19", "RX", "NeedContext", "PrevTxMsg", "", "BST", "BSTT"},
			new String[] {"1A", "RX", "RIRT"},
			new String[] {"1B", "RX", "RIRT"},
			new String[] {"1C", "RX", "MIRT"},
			new String[] {"1D", "RX", "MIRT"},
			new String[] {"1E", "RX", "BICT"},
			new String[] {"1F", "RX", "BICT"},
			
			new String[] {"30", "RX", "OND1"},
			new String[] {"32", "RX", "OND2"},
			new String[] {"34", "RX", "OND3"},
			new String[] {"36", "RX", "OND4"},
			new String[] {"38", "RX", "OND5"},
			new String[] {"3A", "RX", "OND6"},
			new String[] {"3C", "RX", "OND7"},
			new String[] {"3E", "RX", "OND8"},
			new String[] {"40", "RX", "OND9"},
			new String[] {"42", "RX", "OND10"}, // Reserved Frame
			new String[] {"46", "RX", "ARD1"},
			new String[] {"48", "RX", "ARD2"},
			new String[] {"4A", "RX", "ARD3"},
			new String[] {"4C", "RX", "ARD4"},
			new String[] {"4E", "RX", "ARD5"},
			new String[] {"50", "RX", "ARD6"},
			new String[] {"52", "RX", "ARD7"}, // Reserved Frame
			
			new String[] {"20", "RX", "CCRQA"},
			new String[] {"22", "RX", "CCRQT"},
			new String[] {"24", "RX", "BSRQT"},
			new String[] {"26", "RX", "BOMST"},
			new String[] {"28", "RX", "NeedContext", "PrevTxMsg", "", "SHR", "SHRA"},
			new String[] {"28", "RX", "NeedContext", "PrevTxMsg", "", "RSR", "RSRA"},
			new String[] {"28", "RX", "NeedContext", "PrevTxMsg", "", "FCR", "FCRA"},
			new String[] {"2A", "RX", "NeedContext", "CmdClass", "1", "11", "SHRT"},
			new String[] {"2A", "RX", "NeedContext", "CmdClass", "1", "22", "RSRT"},
			new String[] {"60", "RX", "BRD"},
			//new String[] {"", "ESTPA"}, // ID not determined
		};
		
		private String LastTxMessage = null;
		
		public CanMsgFinder()
		{
		}
		
		private bool IsContextMatching(String[] canMsgItem, String[] rawMessage, out String canMsgName)
		{
			canMsgName = "";
			bool isContextMatching = false;
			String contextIdentifier = canMsgItem[INDEX_CONTEXT_IDENTIFIER];
			
			if(contextIdentifier.Equals(COMMAND_CLASS))
			{
				int index = 0;
				if(Int32.TryParse(canMsgItem[INDEX_POS_OF_CONTEXT_DATA], out index))
				{
					if(rawMessage[index].Equals(canMsgItem[INDEX_EXPECTED_CONTEXT_DATA]))
					{
						isContextMatching = true;
						canMsgName = canMsgItem[INDEX_FINAL_MSG];
					}
					else
					{
						//Try next one.
					}
				}
				else
				{
					//In case of any invalid index for identifier is detected.
					Debug.ErrorBox(canMsgItem[INDEX_POS_OF_CONTEXT_DATA] + " is not valid Context identifier position.");
				}
			}
			else if(contextIdentifier.Equals(PREVIOUS_TX_MESSAGE))
	        {
				if(LastTxMessage != null)
				{
		        	if(LastTxMessage.Equals(canMsgItem[INDEX_EXPECTED_CONTEXT_DATA]))
					{
						isContextMatching = true;
						canMsgName = canMsgItem[INDEX_FINAL_MSG];
					}
		        	else
		        	{
		        		//Try next one.
		        	}
				}
				else
				{
					//No previous Tx Message exists.
					Debug.ErrorBox("Previous Tx Message is necessary to determine context, but none exists.");
				}
	        }
			else
			{
				//In case of any invalid Context identifier is detected.
				Debug.ErrorBox(canMsgItem[INDEX_CONTEXT_IDENTIFIER] + " is not valid Context identifier.");
			}
			
			return isContextMatching;
		}
		
		private bool GetMsgNameIfPossible(String[] canMsgItem, String[] rawMessageLine, out String canMsgName)
		{
			canMsgName = "";
			
			//check if 'NeedContext' is detected.
			if(canMsgItem[INDEX_PRIMARY_MSG].Equals(NEED_CONTEXT))
			{
				//need to check further conditions.
				if(IsContextMatching(canMsgItem, rawMessageLine, out canMsgName))
				{
					return true;
				}
				else
				{
					//cannot get MsgName with this MsgItem, due to mismatching.
					return false;
				}
			}
			else
			{
				canMsgName = canMsgItem[INDEX_PRIMARY_MSG];
				return true;
			}
		}
		
		private void MakeMessageTidy(String[] rawMessageLine)
		{
			foreach(String message in rawMessageLine)
			{
				message.Trim('[', ']', ')' ,'(', ' ');
				if(message.Contains("0x"))
				{
					message.Substring(2);
				}
			}
		}
		
		//
		// Returns: true if successfully found, false otherwise.
		//
		public bool FindMsgNameFrom(LogLinePair currentLogLinePair)
		{
			String[] assortedRawMessageLine = currentLogLinePair.AssortedLogLine.ToArray();
			
			MakeMessageTidy(assortedRawMessageLine);
			
			foreach(String[] canMsgItem in CAN_MSG_TABLE)
			{
				bool gotTheMsg = false;
				String canMsgName = null;
				
				if(canMsgItem[INDEX_CANID].Equals(assortedRawMessageLine[INDEX_RAW_CANID]))
				{
					gotTheMsg = GetMsgNameIfPossible(canMsgItem, assortedRawMessageLine, out canMsgName);
				}				
				else if(canMsgItem[INDEX_CANID].Equals(assortedRawMessageLine[INDEX_RAW_CANID].Substring(0, 2)))
				{
					gotTheMsg = GetMsgNameIfPossible(canMsgItem, assortedRawMessageLine, out canMsgName);
					
					if(gotTheMsg)
					{
						int targetBankId = 0;
						bool result = Int32.TryParse(assortedRawMessageLine[INDEX_RAW_CANID].Substring(2, 1), out targetBankId);	//TODO: The case with Bank of more than 9(0x09) is not considered yet.
						if(!result)
						{
							Debug.ErrorBox(assortedRawMessageLine[INDEX_RAW_CANID] + " contains invalid Bank ID.");
							return false; //routine stops in case of invalid Bank ID is detected. since msg already matched, no further lookup needed for this log line.
						}
						currentLogLinePair.TargetBankId = targetBankId; //bankID is updated only when msg name matches and id parsing was successful.
					}
				}
				else
				{
					//this msg item doesn't match the input raw data.
				}
				
				if(gotTheMsg)
				{
					currentLogLinePair.TxRx = canMsgItem[INDEX_TXRX];
					if("TX".Equals(canMsgItem[INDEX_TXRX]))
					{
						LastTxMessage = canMsgName; //save last Tx message for subsequent Rx determination.
						//TODO: to be perfect, LastTxMessage should be a List<String> to correspond to multiple banks.
					}
					currentLogLinePair.CanMessageName = canMsgName;
					return true;
				}
				else
				{
					//let's check the next canMsgItem...
				}
			}
			
			Debug.ErrorBox(assortedRawMessageLine[INDEX_RAW_CANID] + " is not valid CAN ID.");
			return false; //routine failed to find matching msg item in the whole list.
		}
	

	}
	
}
