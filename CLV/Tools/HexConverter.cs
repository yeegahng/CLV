/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2015-12-29
 * Time: 오후 2:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CLV
{
	/// <summary>
	/// Description of HexConverter.
	/// </summary>
	public class HexConverter
	{
		private HexConverter()
		{
		}
		
		public static int HexStrToDecInt(String hexStr)
		{
			int hexInt = 0;
			for(int i = 0; i < hexStr.Length; i += 1)
			{
				int hexIntDigit = HexCharToHexInt(hexStr[i]) << ((hexStr.Length - 1 - i)<<2);
				if(hexIntDigit < 0)
				{
					return -1; //this means error.
				}
				//Debug.Log(hexStr[i] + " --> " + hexIntDigit);
				hexInt += hexIntDigit;
			}
			//Debug.Log("Hex Data " + hexStr + "(" + (hexStr.Length>>1) + "-byte) value is decimal " + hexInt);
			return hexInt;
		}
		
		private static int HexCharToHexInt(char hexChar)
		{
			int offset = 0;
			if(hexChar >= 'A' && hexChar <='F')
			{
				offset = 'A' - 10;
			}
			else if(hexChar >= '0' && hexChar <= '9')
			{
				offset = '0';
			}
			else
			{
				Debug.ErrorBox("Illegal value in data field: " + hexChar);
				return -1; //this means error.
			}
			
			return (int)hexChar - offset;
		}
		
		public static String HexStrToBinStr(String hexStr)
		{
			String binStr = "";
			int hexInt = HexStrToDecInt(hexStr);
			
			if(hexInt < 1)
			{
				//this case occurs only when hexInt is 0.
				//make it 4-times longer : 0x00(hex) -> 0x00000000(bin)
				//return hexStr + hexStr + hexStr + hexStr;
				return "ALL 0";
			}
			
			while(hexInt >= 1)
			{
				if((hexInt % 2) == 0)
				{
					binStr = "0" + binStr;
				}
				else
				{
					binStr = "1" + binStr;
				}
				hexInt /= 2;
			}
			int binStrZeroPaddingLength = (4 - (binStr.Length % 4)) % 4;
			while(binStrZeroPaddingLength > 0)
			{
				binStr = "0" + binStr;
				binStrZeroPaddingLength -= 1;
			}
			
			//Debug.Log("Hex Data " + hexStr + "(" + (hexStr.Length>>1) + "-byte) value is binary " + binStr);
			return binStr;
		}
	}
}
