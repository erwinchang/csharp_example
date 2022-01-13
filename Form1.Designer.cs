
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
            this.LstPlace = new System.Windows.Forms.ListBox();
            this.TxtCity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LstPlace
            // 
            this.LstPlace.FormattingEnabled = true;
            this.LstPlace.ItemHeight = 15;
            this.LstPlace.Location = new System.Drawing.Point(184, 22);
            this.LstPlace.Name = "LstPlace";
            this.LstPlace.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstPlace.Size = new System.Drawing.Size(120, 79);
            this.LstPlace.TabIndex = 0;
            this.LstPlace.SelectedIndexChanged += new System.EventHandler(this.LstPlace_SelectedIndexChanged);
            // 
            // TxtCity
            // 
            this.TxtCity.Location = new System.Drawing.Point(44, 124);
            this.TxtCity.Multiline = true;
            this.TxtCity.Name = "TxtCity";
            this.TxtCity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtCity.Size = new System.Drawing.Size(315, 81);
            this.TxtCity.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "風景區代表:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 235);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCity);
            this.Controls.Add(this.LstPlace);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstPlace;
        private System.Windows.Forms.TextBox TxtCity;
        private System.Windows.Forms.Label label1;
    }
}

