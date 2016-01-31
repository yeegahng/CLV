/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2015-12-28
 * Time: 오전 11:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace CLV
{
	/// <summary>
	/// Description of Debug.
	/// </summary>
	/// 
	public sealed class Debug
	{
		private const bool FLAG_TO_SHOW_LOG = true;	//toggle this flag to turn on/off the log spewing.
		private const bool FLAG_TO_SHOW_WARNING = true;
		private const bool FLAG_TO_SHOW_ERROR = true;
		
		private const bool FLAG_TO_SHOW_MSGBOX = false;
		
		private Debug()
		{
		}
		
		public static void Log(String text)
		{
			if(FLAG_TO_SHOW_LOG)
			{
				System.Diagnostics.Debug.WriteLine(text);
			}
		}
		public static void Warning(String text)
		{
			if(FLAG_TO_SHOW_WARNING)
			{
				System.Diagnostics.Debug.WriteLine("[WARNING] " + text);
			}
		}
		public static void Error(String text)
		{
			if(FLAG_TO_SHOW_ERROR)
			{
				System.Diagnostics.Debug.WriteLine("[ERROR] " + text);
			}
		}		
		public static void LogBox(String text)
		{
			if(FLAG_TO_SHOW_LOG & FLAG_TO_SHOW_MSGBOX)
			{
				MessageBox.Show(text);
			}
		}
		public static void WarningBox(String text)
		{
			if(FLAG_TO_SHOW_WARNING & FLAG_TO_SHOW_MSGBOX)
			{
				MessageBox.Show("[WARNING] " + text);
			}
		}
		public static void ErrorBox(String text)
		{
			if(FLAG_TO_SHOW_ERROR & FLAG_TO_SHOW_MSGBOX)
			{
				MessageBox.Show("[ERROR] " + text);
			}
		}
	}
}
