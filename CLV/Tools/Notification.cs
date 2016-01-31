/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2016-01-07
 * Time: 오후 8:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CLV.Tools
{
	/// <summary>
	/// Description of Notification.
	/// </summary>
	public partial class Notification : Form
	{
		public Label Description = new Label();
		private Timer PopTimer = new Timer();
		public int TimeSec = 5;
		private TYPE WindowType = TYPE.YESNO;
		private RESULT WindowResult = RESULT.UNKNOWN;
		
		public Notification(String title, TYPE windowType = TYPE.YESNO)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
            this.Text = title;

            //Disable normal window functions
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true; //make it appear on the very top
            
			this.Size = new System.Drawing.Size(400, 400);
			this.AutoSize = true;
			this.Capture = true;
			this.Visible = false;
			this.Controls.Add(Description);
			Description.AutoSize = true;
			this.WindowType = windowType;
			if(this.WindowType == TYPE.YESNO)
			{
				//show yes and no button
				this.button_YES.Click += delegate { WindowResult = RESULT.YES; this.Close();};
				this.button_YES.Visible = true;
				this.button_NO.Click += delegate { WindowResult = RESULT.NO; this.Close();};
				this.button_NO.Visible = true;
			}
			else if(this.WindowType == TYPE.NOTIFY)
			{
				//show confirmed button
				this.button_Confirm.Click += delegate { WindowResult = RESULT.YES; };
				this.button_Confirm.Visible = true;
			}
			else
			{
				 //window type of TYPE.TRANSIENT has no button visible.
			}
		}
		
		public new RESULT ShowDialog()
		{            
            if(this.WindowType == TYPE.TRANSIENT)
            {
            	PopTimer.Interval = Math.Max(this.TimeSec, 1) * 1000; //interval is in milisecond and cannot be under 1.
				PopTimer.Tick += delegate { 
									this.Hide();
									PopTimer.Stop(); };
				PopTimer.Start();
            }
            ((Form)this).ShowDialog();
            Debug.Log("Notification returns " + this.WindowResult);
            return this.WindowResult;
		}
		private new void Show()
		{
			//it's forbidden to invoke modaless notification window.
		}
		
		public enum TYPE
		{
			YESNO = 0,
			NOTIFY = 1,
			TRANSIENT = 2
		}
		public enum RESULT
		{
			UNKNOWN = 0,
			YES = 1,
			NO = 2
		}
	}
}
