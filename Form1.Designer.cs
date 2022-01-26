
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
            this.McdDate = new System.Windows.Forms.MonthCalendar();
            this.LblMoney = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // McdDate
            // 
            this.McdDate.Location = new System.Drawing.Point(86, 83);
            this.McdDate.Name = "McdDate";
            this.McdDate.TabIndex = 0;
            this.McdDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.McdDate_DateChanged);
            this.McdDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.McdDate_DateSelected);
            // 
            // LblMoney
            // 
            this.LblMoney.Location = new System.Drawing.Point(89, 288);
            this.LblMoney.Name = "LblMoney";
            this.LblMoney.Size = new System.Drawing.Size(323, 46);
            this.LblMoney.TabIndex = 1;
            this.LblMoney.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 350);
            this.Controls.Add(this.LblMoney);
            this.Controls.Add(this.McdDate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar McdDate;
        private System.Windows.Forms.Label LblMoney;
    }
}

