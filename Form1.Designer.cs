
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
            this.BtnTXT = new System.Windows.Forms.Button();
            this.BtnXML = new System.Windows.Forms.Button();
            this.BtnXLS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnTXT
            // 
            this.BtnTXT.Location = new System.Drawing.Point(33, 38);
            this.BtnTXT.Name = "BtnTXT";
            this.BtnTXT.Size = new System.Drawing.Size(69, 35);
            this.BtnTXT.TabIndex = 0;
            this.BtnTXT.Text = "TXT";
            this.BtnTXT.UseVisualStyleBackColor = true;
            this.BtnTXT.Click += new System.EventHandler(this.BtnTXT_Click);
            // 
            // BtnXML
            // 
            this.BtnXML.Location = new System.Drawing.Point(33, 79);
            this.BtnXML.Name = "BtnXML";
            this.BtnXML.Size = new System.Drawing.Size(69, 35);
            this.BtnXML.TabIndex = 1;
            this.BtnXML.Text = "XML";
            this.BtnXML.UseVisualStyleBackColor = true;
            this.BtnXML.Click += new System.EventHandler(this.BtnXML_Click);
            // 
            // BtnXLS
            // 
            this.BtnXLS.Location = new System.Drawing.Point(33, 120);
            this.BtnXLS.Name = "BtnXLS";
            this.BtnXLS.Size = new System.Drawing.Size(69, 35);
            this.BtnXLS.TabIndex = 2;
            this.BtnXLS.Text = "XLS";
            this.BtnXLS.UseVisualStyleBackColor = true;
            this.BtnXLS.Click += new System.EventHandler(this.BtnXLS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnXLS);
            this.Controls.Add(this.BtnXML);
            this.Controls.Add(this.BtnTXT);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnTXT;
        private System.Windows.Forms.Button BtnXML;
        private System.Windows.Forms.Button BtnXLS;
    }
}

