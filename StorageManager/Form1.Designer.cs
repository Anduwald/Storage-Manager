namespace StorageManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			blazorWebView1 = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
			openFileDialog1 = new OpenFileDialog();
			saveFileDialog1 = new SaveFileDialog();
			SuspendLayout();
			// 
			// blazorWebView1
			// 
			blazorWebView1.Dock = DockStyle.Fill;
			blazorWebView1.Location = new Point(0, 0);
			blazorWebView1.Margin = new Padding(3, 2, 3, 2);
			blazorWebView1.Name = "blazorWebView1";
			blazorWebView1.Size = new Size(884, 461);
			blazorWebView1.StartPath = "/";
			blazorWebView1.TabIndex = 0;
			blazorWebView1.Text = "blazorWebView1";
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// saveFileDialog1
			// 
			saveFileDialog1.DefaultExt = "json";
			saveFileDialog1.FileName = "ApplicationData";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(884, 461);
			Controls.Add(blazorWebView1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 2, 3, 2);
			MinimumSize = new Size(700, 500);
			Name = "Form1";
			Text = "Storage manager";
			WindowState = FormWindowState.Maximized;
			FormClosing += Form1_FormClosing;
			ResumeLayout(false);
		}

		#endregion

		private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView blazorWebView1;
		private OpenFileDialog openFileDialog1;
		private SaveFileDialog saveFileDialog1;
	}
}
