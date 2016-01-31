/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2016-01-04
 * Time: 오후 4:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace CLV.Tools
{
	/// <summary>
	/// Description of InfoPopup.
	/// </summary>
	public class InfoPopup : Form
	{
		public Label Description = new Label();
		private Timer PopTimer = new Timer();
		
		public InfoPopup()
		{
			//Remove title bar and set edge-style
            this.Text = string.Empty;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //Disable normal window functions
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true; //make it appear on the very top
            
			this.Size = new System.Drawing.Size(250, 150);
			this.AutoSize = true;
			this.Capture = false;
			this.Visible = false;
			this.Controls.Add(Description);
			Description.AutoSize = true;
		}
		
		public void Show(int timeSec)
		{            
            if(timeSec > 0)
            {
				PopTimer.Interval = timeSec * 1000; //interval is in milisecond
				PopTimer.Tick += delegate { 
									this.Hide();
									PopTimer.Stop(); };
				PopTimer.Start();
            }
			this.Show();
		}
		
		public enum SHOW_POPUP_WHEN
		{
			NEVER = 0,
			CELL_CLICK = 1,
			MOUSE_HOVER = 2,
			MOUSE_HOVER_TIMER = 3
		}
	}
}
