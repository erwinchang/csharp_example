
namespace csharp_example
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ltbViewText = new System.Windows.Forms.ListBox();
            this.btnStartThread = new System.Windows.Forms.Button();
            this.btnEndThread = new System.Windows.Forms.Button();
            this.tbText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ltbViewText
            // 
            this.ltbViewText.FormattingEnabled = true;
            this.ltbViewText.ItemHeight = 12;
            this.ltbViewText.Location = new System.Drawing.Point(12, 12);
            this.ltbViewText.Name = "ltbViewText";
            this.ltbViewText.Size = new System.Drawing.Size(388, 232);
            this.ltbViewText.TabIndex = 0;
            // 
            // btnStartThread
            // 
            this.btnStartThread.Location = new System.Drawing.Point(225, 250);
            this.btnStartThread.Name = "btnStartThread";
            this.btnStartThread.Size = new System.Drawing.Size(80, 26);
            this.btnStartThread.TabIndex = 1;
            this.btnStartThread.Text = "Start Thread";
            this.btnStartThread.UseVisualStyleBackColor = true;
            this.btnStartThread.Click += new System.EventHandler(this.btnStartThread_Click);
            // 
            // btnEndThread
            // 
            this.btnEndThread.Location = new System.Drawing.Point(320, 250);
            this.btnEndThread.Name = "btnEndThread";
            this.btnEndThread.Size = new System.Drawing.Size(80, 26);
            this.btnEndThread.TabIndex = 2;
            this.btnEndThread.Text = "End Thread";
            this.btnEndThread.UseVisualStyleBackColor = true;
            this.btnEndThread.Click += new System.EventHandler(this.btnEndThread_Click);
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(13, 252);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(198, 22);
            this.tbText.TabIndex = 3;
            this.tbText.Text = "Test123";
            this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 297);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.btnEndThread);
            this.Controls.Add(this.btnStartThread);
            this.Controls.Add(this.ltbViewText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ltbViewText;
        private System.Windows.Forms.Button btnStartThread;
        private System.Windows.Forms.Button btnEndThread;
        private System.Windows.Forms.TextBox tbText;
    }
}

