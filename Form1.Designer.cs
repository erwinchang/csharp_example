
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
            this.LblDiv = new System.Windows.Forms.Label();
            this.LblMsg = new System.Windows.Forms.Label();
            this.ClstTest = new System.Windows.Forms.CheckedListBox();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnCheck = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblDiv
            // 
            this.LblDiv.AutoSize = true;
            this.LblDiv.Location = new System.Drawing.Point(37, 42);
            this.LblDiv.Name = "LblDiv";
            this.LblDiv.Size = new System.Drawing.Size(52, 15);
            this.LblDiv.TabIndex = 0;
            this.LblDiv.Text = "未出題";
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.Location = new System.Drawing.Point(264, 42);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(51, 19);
            this.LblMsg.TabIndex = 1;
            this.LblMsg.Text = "label2";
            // 
            // ClstTest
            // 
            this.ClstTest.FormattingEnabled = true;
            this.ClstTest.Location = new System.Drawing.Point(40, 74);
            this.ClstTest.Name = "ClstTest";
            this.ClstTest.Size = new System.Drawing.Size(210, 184);
            this.ClstTest.TabIndex = 2;
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(278, 74);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 3;
            this.BtnNew.Text = "出題";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnCheck
            // 
            this.BtnCheck.Location = new System.Drawing.Point(278, 120);
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(75, 23);
            this.BtnCheck.TabIndex = 4;
            this.BtnCheck.Text = "核對";
            this.BtnCheck.UseVisualStyleBackColor = true;
            this.BtnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(278, 162);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 5;
            this.BtnClear.Text = "重答";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 315);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.BtnCheck);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.ClstTest);
            this.Controls.Add(this.LblMsg);
            this.Controls.Add(this.LblDiv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblDiv;
        private System.Windows.Forms.Label LblMsg;
        private System.Windows.Forms.CheckedListBox ClstTest;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnCheck;
        private System.Windows.Forms.Button BtnClear;
    }
}

