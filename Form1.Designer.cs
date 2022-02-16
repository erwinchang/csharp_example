
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
            this.BtnTurnOn = new System.Windows.Forms.Button();
            this.BtnTurnOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnTurnOn
            // 
            this.BtnTurnOn.Location = new System.Drawing.Point(48, 36);
            this.BtnTurnOn.Name = "BtnTurnOn";
            this.BtnTurnOn.Size = new System.Drawing.Size(108, 35);
            this.BtnTurnOn.TabIndex = 0;
            this.BtnTurnOn.Text = "Turn On";
            this.BtnTurnOn.UseVisualStyleBackColor = true;
            this.BtnTurnOn.Click += new System.EventHandler(this.BtnTurnOn_Click);
            // 
            // BtnTurnOff
            // 
            this.BtnTurnOff.Location = new System.Drawing.Point(52, 82);
            this.BtnTurnOff.Name = "BtnTurnOff";
            this.BtnTurnOff.Size = new System.Drawing.Size(103, 32);
            this.BtnTurnOff.TabIndex = 1;
            this.BtnTurnOff.Text = "Turn Off";
            this.BtnTurnOff.UseVisualStyleBackColor = true;
            this.BtnTurnOff.Click += new System.EventHandler(this.BtnTurnOff_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnTurnOff);
            this.Controls.Add(this.BtnTurnOn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnTurnOn;
        private System.Windows.Forms.Button BtnTurnOff;
    }
}

