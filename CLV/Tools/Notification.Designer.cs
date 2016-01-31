/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2016-01-07
 * Time: 오후 10:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CLV.Tools
{
	partial class Notification
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button_YES = new System.Windows.Forms.Button();
			this.button_NO = new System.Windows.Forms.Button();
			this.button_Confirm = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button_YES
			// 
			this.button_YES.Location = new System.Drawing.Point(39, 227);
			this.button_YES.Name = "button_YES";
			this.button_YES.Size = new System.Drawing.Size(75, 23);
			this.button_YES.TabIndex = 0;
			this.button_YES.Text = "YES";
			this.button_YES.UseVisualStyleBackColor = true;
			this.button_YES.Visible = false;
			// 
			// button_NO
			// 
			this.button_NO.Location = new System.Drawing.Point(170, 227);
			this.button_NO.Name = "button_NO";
			this.button_NO.Size = new System.Drawing.Size(75, 23);
			this.button_NO.TabIndex = 0;
			this.button_NO.Text = "NO";
			this.button_NO.UseVisualStyleBackColor = true;
			this.button_NO.Visible = false;
			// 
			// button_Confirm
			// 
			this.button_Confirm.Location = new System.Drawing.Point(102, 227);
			this.button_Confirm.Name = "button_Confirm";
			this.button_Confirm.Size = new System.Drawing.Size(75, 23);
			this.button_Confirm.TabIndex = 0;
			this.button_Confirm.Text = "Confirm";
			this.button_Confirm.UseVisualStyleBackColor = true;
			this.button_Confirm.Visible = false;
			// 
			// Notification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.button_NO);
			this.Controls.Add(this.button_Confirm);
			this.Controls.Add(this.button_YES);
			this.Name = "Notification";
			this.Text = "Notification";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button_Confirm;
		private System.Windows.Forms.Button button_NO;
		private System.Windows.Forms.Button button_YES;
	}
}
