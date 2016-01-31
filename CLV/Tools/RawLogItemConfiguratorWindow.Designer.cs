/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2016-01-07
 * Time: 오후 10:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CLV.Tools
{
	partial class RawLogItemConfiguratorWindow
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
			this.button_Apply = new System.Windows.Forms.Button();
			this.groupBox_ItemList = new System.Windows.Forms.GroupBox();
			this.groupBox_ItemList.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_Apply
			// 
			this.button_Apply.Location = new System.Drawing.Point(141, 227);
			this.button_Apply.Name = "button_Apply";
			this.button_Apply.Size = new System.Drawing.Size(75, 23);
			this.button_Apply.TabIndex = 0;
			this.button_Apply.Text = "Apply";
			this.button_Apply.UseVisualStyleBackColor = true;
			this.button_Apply.Click += new System.EventHandler(this.Button_ApplyClick);
			// 
			// groupBox_ItemList
			// 
			this.groupBox_ItemList.Location = new System.Drawing.Point(13, 13);
			this.groupBox_ItemList.Name = "groupBox_ItemList";
			this.groupBox_ItemList.Size = new System.Drawing.Size(336, 208);
			this.groupBox_ItemList.TabIndex = 1;
			this.groupBox_ItemList.TabStop = false;
			this.groupBox_ItemList.Text = "Log Items";
			// 
			// RawLogItemConfiguratorWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(361, 262);
			this.Controls.Add(this.groupBox_ItemList);
			this.Controls.Add(this.button_Apply);
			this.Name = "RawLogItemConfiguratorWindow";
			this.Text = "Raw Log Item Configurator Window";
			this.groupBox_ItemList.ResumeLayout(false);
			this.groupBox_ItemList.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.GroupBox groupBox_ItemList;
		private System.Windows.Forms.Button button_Apply;
	}
}
