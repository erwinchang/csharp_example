
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
            this.loggingView = new Utilities.Controls.LoggingView();
            this.SuspendLayout();
            // 
            // loggingView
            // 
            this.loggingView.FormattingEnabled = true;
            this.loggingView.ItemHeight = 15;
            this.loggingView.Location = new System.Drawing.Point(12, 12);
            this.loggingView.MaxEntriesInListBox = 3000;
            this.loggingView.Name = "loggingView";
            this.loggingView.Size = new System.Drawing.Size(776, 409);
            this.loggingView.TabIndex = 0;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loggingView);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Utilities.Controls.LoggingView loggingView;
    }
}