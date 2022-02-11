
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
            this.BtnXMLFile = new System.Windows.Forms.Button();
            this.TxtXMLFile = new System.Windows.Forms.TextBox();
            this.BtnXMLParse = new System.Windows.Forms.Button();
            this.TxtXML = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnXMLFile
            // 
            this.BtnXMLFile.Location = new System.Drawing.Point(33, 78);
            this.BtnXMLFile.Name = "BtnXMLFile";
            this.BtnXMLFile.Size = new System.Drawing.Size(117, 33);
            this.BtnXMLFile.TabIndex = 0;
            this.BtnXMLFile.Text = "Select XML File";
            this.BtnXMLFile.UseVisualStyleBackColor = true;
            this.BtnXMLFile.Click += new System.EventHandler(this.BtnXMLFile_Click);
            // 
            // TxtXMLFile
            // 
            this.TxtXMLFile.Location = new System.Drawing.Point(33, 47);
            this.TxtXMLFile.Name = "TxtXMLFile";
            this.TxtXMLFile.Size = new System.Drawing.Size(444, 25);
            this.TxtXMLFile.TabIndex = 1;
            // 
            // BtnXMLParse
            // 
            this.BtnXMLParse.Location = new System.Drawing.Point(33, 397);
            this.BtnXMLParse.Name = "BtnXMLParse";
            this.BtnXMLParse.Size = new System.Drawing.Size(114, 32);
            this.BtnXMLParse.TabIndex = 2;
            this.BtnXMLParse.Text = "XML Parse";
            this.BtnXMLParse.UseVisualStyleBackColor = true;
            // 
            // TxtXML
            // 
            this.TxtXML.Location = new System.Drawing.Point(32, 121);
            this.TxtXML.Multiline = true;
            this.TxtXML.Name = "TxtXML";
            this.TxtXML.Size = new System.Drawing.Size(677, 270);
            this.TxtXML.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtXML);
            this.Controls.Add(this.BtnXMLParse);
            this.Controls.Add(this.TxtXMLFile);
            this.Controls.Add(this.BtnXMLFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnXMLFile;
        private System.Windows.Forms.TextBox TxtXMLFile;
        private System.Windows.Forms.Button BtnXMLParse;
        private System.Windows.Forms.TextBox TxtXML;
    }
}

