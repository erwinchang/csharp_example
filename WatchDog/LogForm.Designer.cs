
namespace WatchDog
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loggingView1 = new Utilities.Controls.LoggingView();
            this.SuspendLayout();
            // 
            // loggingView1
            // 
            this.loggingView1.FormattingEnabled = true;
            this.loggingView1.ItemHeight = 15;
            this.loggingView1.Location = new System.Drawing.Point(12, 12);
            this.loggingView1.MaxEntriesInListBox = 0;
            this.loggingView1.Name = "loggingView1";
            this.loggingView1.Size = new System.Drawing.Size(776, 409);
            this.loggingView1.TabIndex = 0;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loggingView1);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Utilities.Controls.LoggingView loggingView1;
    }
}