﻿
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuFont = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFont,
            this.MnuSize,
            this.MnuStyle,
            this.MnuSet});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuFont
            // 
            this.MnuFont.Name = "MnuFont";
            this.MnuFont.Size = new System.Drawing.Size(53, 23);
            this.MnuFont.Text = "字型";
            // 
            // MnuSize
            // 
            this.MnuSize.Name = "MnuSize";
            this.MnuSize.Size = new System.Drawing.Size(53, 23);
            this.MnuSize.Text = "大小";
            // 
            // MnuStyle
            // 
            this.MnuStyle.Name = "MnuStyle";
            this.MnuStyle.Size = new System.Drawing.Size(53, 23);
            this.MnuStyle.Text = "樣式";
            // 
            // MnuSet
            // 
            this.MnuSet.Name = "MnuSet";
            this.MnuSet.Size = new System.Drawing.Size(53, 23);
            this.MnuSet.Text = "設定";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuFont;
        private System.Windows.Forms.ToolStripMenuItem MnuSize;
        private System.Windows.Forms.ToolStripMenuItem MnuStyle;
        private System.Windows.Forms.ToolStripMenuItem MnuSet;
    }
}

