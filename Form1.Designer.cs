
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
            this.MnuSet1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSet2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSet3 = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtW = new System.Windows.Forms.TextBox();
            this.MnuStyle1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStyle2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFont1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFont2 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuFont
            // 
            this.MnuFont.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFont1,
            this.MnuFont2});
            this.MnuFont.Name = "MnuFont";
            this.MnuFont.Size = new System.Drawing.Size(53, 24);
            this.MnuFont.Text = "字型";
            // 
            // MnuSize
            // 
            this.MnuSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSize1,
            this.MnuSize2,
            this.MnuSize3,
            this.MnuSize4});
            this.MnuSize.Name = "MnuSize";
            this.MnuSize.Size = new System.Drawing.Size(53, 24);
            this.MnuSize.Text = "大小";
            // 
            // MnuStyle
            // 
            this.MnuStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuStyle1,
            this.MnuStyle2});
            this.MnuStyle.Name = "MnuStyle";
            this.MnuStyle.Size = new System.Drawing.Size(53, 24);
            this.MnuStyle.Text = "樣式";
            this.MnuStyle.Click += new System.EventHandler(this.MnuStyle_Click);
            // 
            // MnuSet
            // 
            this.MnuSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSet1,
            this.MnuSet2,
            this.MnuSet3});
            this.MnuSet.Name = "MnuSet";
            this.MnuSet.Size = new System.Drawing.Size(53, 24);
            this.MnuSet.Text = "設定";
            // 
            // MnuSet1
            // 
            this.MnuSet1.Name = "MnuSet1";
            this.MnuSet1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.MnuSet1.Size = new System.Drawing.Size(224, 26);
            this.MnuSet1.Text = "預設(&U)";
            this.MnuSet1.Click += new System.EventHandler(this.MnuSet1_Click);
            // 
            // MnuSet2
            // 
            this.MnuSet2.Name = "MnuSet2";
            this.MnuSet2.Size = new System.Drawing.Size(224, 26);
            this.MnuSet2.Text = "較大字型";
            this.MnuSet2.Click += new System.EventHandler(this.MnuSet2_Click);
            // 
            // MnuSet3
            // 
            this.MnuSet3.Name = "MnuSet3";
            this.MnuSet3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MnuSet3.Size = new System.Drawing.Size(224, 26);
            this.MnuSet3.Text = "結束(&X)";
            this.MnuSet3.Click += new System.EventHandler(this.MnuSet3_Click);
            // 
            // TxtW
            // 
            this.TxtW.Location = new System.Drawing.Point(33, 79);
            this.TxtW.Name = "TxtW";
            this.TxtW.Size = new System.Drawing.Size(460, 25);
            this.TxtW.TabIndex = 1;
            // 
            // MnuStyle1
            // 
            this.MnuStyle1.Name = "MnuStyle1";
            this.MnuStyle1.Size = new System.Drawing.Size(224, 26);
            this.MnuStyle1.Text = "粗體";
            this.MnuStyle1.Click += new System.EventHandler(this.MnuStyle1_Click);
            // 
            // MnuStyle2
            // 
            this.MnuStyle2.Name = "MnuStyle2";
            this.MnuStyle2.Size = new System.Drawing.Size(224, 26);
            this.MnuStyle2.Text = "斜體";
            this.MnuStyle2.Click += new System.EventHandler(this.MnuStyle2_Click);
            // 
            // MnuSize1
            // 
            this.MnuSize1.Name = "MnuSize1";
            this.MnuSize1.Size = new System.Drawing.Size(224, 26);
            this.MnuSize1.Text = "9";
            this.MnuSize1.Click += new System.EventHandler(this.MnuSize1_Click);
            // 
            // MnuSize2
            // 
            this.MnuSize2.Name = "MnuSize2";
            this.MnuSize2.Size = new System.Drawing.Size(224, 26);
            this.MnuSize2.Text = "12";
            this.MnuSize2.Click += new System.EventHandler(this.MnuSize2_Click);
            // 
            // MnuSize3
            // 
            this.MnuSize3.Name = "MnuSize3";
            this.MnuSize3.Size = new System.Drawing.Size(224, 26);
            this.MnuSize3.Text = "20";
            this.MnuSize3.Click += new System.EventHandler(this.MnuSize3_Click);
            // 
            // MnuSize4
            // 
            this.MnuSize4.Name = "MnuSize4";
            this.MnuSize4.Size = new System.Drawing.Size(224, 26);
            this.MnuSize4.Text = "24";
            this.MnuSize4.Click += new System.EventHandler(this.MnuSize4_Click);
            // 
            // MnuFont1
            // 
            this.MnuFont1.Name = "MnuFont1";
            this.MnuFont1.Size = new System.Drawing.Size(224, 26);
            this.MnuFont1.Text = "新細明體";
            this.MnuFont1.Click += new System.EventHandler(this.MnuFont1_Click);
            // 
            // MnuFont2
            // 
            this.MnuFont2.Name = "MnuFont2";
            this.MnuFont2.Size = new System.Drawing.Size(224, 26);
            this.MnuFont2.Text = "標楷體";
            this.MnuFont2.Click += new System.EventHandler(this.MnuFont2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtW);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.ToolStripMenuItem MnuSet1;
        private System.Windows.Forms.ToolStripMenuItem MnuSet2;
        private System.Windows.Forms.ToolStripMenuItem MnuSet3;
        private System.Windows.Forms.TextBox TxtW;
        private System.Windows.Forms.ToolStripMenuItem MnuFont1;
        private System.Windows.Forms.ToolStripMenuItem MnuFont2;
        private System.Windows.Forms.ToolStripMenuItem MnuSize1;
        private System.Windows.Forms.ToolStripMenuItem MnuSize2;
        private System.Windows.Forms.ToolStripMenuItem MnuSize3;
        private System.Windows.Forms.ToolStripMenuItem MnuSize4;
        private System.Windows.Forms.ToolStripMenuItem MnuStyle1;
        private System.Windows.Forms.ToolStripMenuItem MnuStyle2;
    }
}

