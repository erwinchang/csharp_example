
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
            this.MnuFont1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFont2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSize4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStyle1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStyle2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSet = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSet1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSet2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSet3 = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtW = new System.Windows.Forms.TextBox();
            this.MnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEdit1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEdit2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEdit3 = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.MnuSet,
            this.MnuEdit,
            this.設定ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuFont
            // 
            this.MnuFont.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFont1,
            this.MnuFont2});
            this.MnuFont.Name = "MnuFont";
            this.MnuFont.Size = new System.Drawing.Size(43, 20);
            this.MnuFont.Text = "字型";
            // 
            // MnuFont1
            // 
            this.MnuFont1.Name = "MnuFont1";
            this.MnuFont1.Size = new System.Drawing.Size(122, 22);
            this.MnuFont1.Text = "新細明體";
            this.MnuFont1.Click += new System.EventHandler(this.MnuFont1_Click);
            // 
            // MnuFont2
            // 
            this.MnuFont2.Name = "MnuFont2";
            this.MnuFont2.Size = new System.Drawing.Size(122, 22);
            this.MnuFont2.Text = "標楷體";
            this.MnuFont2.Click += new System.EventHandler(this.MnuFont2_Click);
            // 
            // MnuSize
            // 
            this.MnuSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSize1,
            this.MnuSize2,
            this.MnuSize3,
            this.MnuSize4});
            this.MnuSize.Name = "MnuSize";
            this.MnuSize.Size = new System.Drawing.Size(43, 20);
            this.MnuSize.Text = "大小";
            // 
            // MnuSize1
            // 
            this.MnuSize1.Name = "MnuSize1";
            this.MnuSize1.Size = new System.Drawing.Size(88, 22);
            this.MnuSize1.Text = "9";
            this.MnuSize1.Click += new System.EventHandler(this.MnuSize1_Click);
            // 
            // MnuSize2
            // 
            this.MnuSize2.Name = "MnuSize2";
            this.MnuSize2.Size = new System.Drawing.Size(88, 22);
            this.MnuSize2.Text = "12";
            this.MnuSize2.Click += new System.EventHandler(this.MnuSize2_Click);
            // 
            // MnuSize3
            // 
            this.MnuSize3.Name = "MnuSize3";
            this.MnuSize3.Size = new System.Drawing.Size(88, 22);
            this.MnuSize3.Text = "20";
            this.MnuSize3.Click += new System.EventHandler(this.MnuSize3_Click);
            // 
            // MnuSize4
            // 
            this.MnuSize4.Name = "MnuSize4";
            this.MnuSize4.Size = new System.Drawing.Size(88, 22);
            this.MnuSize4.Text = "24";
            this.MnuSize4.Click += new System.EventHandler(this.MnuSize4_Click);
            // 
            // MnuStyle
            // 
            this.MnuStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuStyle1,
            this.MnuStyle2});
            this.MnuStyle.Name = "MnuStyle";
            this.MnuStyle.Size = new System.Drawing.Size(43, 20);
            this.MnuStyle.Text = "樣式";
            this.MnuStyle.Click += new System.EventHandler(this.MnuStyle_Click);
            // 
            // MnuStyle1
            // 
            this.MnuStyle1.Name = "MnuStyle1";
            this.MnuStyle1.Size = new System.Drawing.Size(98, 22);
            this.MnuStyle1.Text = "粗體";
            this.MnuStyle1.Click += new System.EventHandler(this.MnuStyle1_Click);
            // 
            // MnuStyle2
            // 
            this.MnuStyle2.Name = "MnuStyle2";
            this.MnuStyle2.Size = new System.Drawing.Size(98, 22);
            this.MnuStyle2.Text = "斜體";
            this.MnuStyle2.Click += new System.EventHandler(this.MnuStyle2_Click);
            // 
            // MnuSet
            // 
            this.MnuSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSet1,
            this.MnuSet2,
            this.MnuSet3});
            this.MnuSet.Name = "MnuSet";
            this.MnuSet.Size = new System.Drawing.Size(43, 20);
            this.MnuSet.Text = "設定";
            // 
            // MnuSet1
            // 
            this.MnuSet1.Name = "MnuSet1";
            this.MnuSet1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.MnuSet1.Size = new System.Drawing.Size(159, 22);
            this.MnuSet1.Text = "預設(&U)";
            this.MnuSet1.Click += new System.EventHandler(this.MnuSet1_Click);
            // 
            // MnuSet2
            // 
            this.MnuSet2.Name = "MnuSet2";
            this.MnuSet2.Size = new System.Drawing.Size(159, 22);
            this.MnuSet2.Text = "較大字型";
            this.MnuSet2.Click += new System.EventHandler(this.MnuSet2_Click);
            // 
            // MnuSet3
            // 
            this.MnuSet3.Name = "MnuSet3";
            this.MnuSet3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MnuSet3.Size = new System.Drawing.Size(159, 22);
            this.MnuSet3.Text = "結束(&X)";
            this.MnuSet3.Click += new System.EventHandler(this.MnuSet3_Click);
            // 
            // TxtW
            // 
            this.TxtW.Location = new System.Drawing.Point(25, 63);
            this.TxtW.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtW.Name = "TxtW";
            this.TxtW.Size = new System.Drawing.Size(346, 22);
            this.TxtW.TabIndex = 1;
            // 
            // MnuEdit
            // 
            this.MnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuEdit1,
            this.MnuEdit2,
            this.MnuEdit3});
            this.MnuEdit.Name = "MnuEdit";
            this.MnuEdit.Size = new System.Drawing.Size(43, 20);
            this.MnuEdit.Text = "編輯";
            // 
            // MnuEdit1
            // 
            this.MnuEdit1.Name = "MnuEdit1";
            this.MnuEdit1.Size = new System.Drawing.Size(180, 22);
            this.MnuEdit1.Text = "複製";
            // 
            // MnuEdit2
            // 
            this.MnuEdit2.Name = "MnuEdit2";
            this.MnuEdit2.Size = new System.Drawing.Size(180, 22);
            this.MnuEdit2.Text = "貼上";
            // 
            // MnuEdit3
            // 
            this.MnuEdit3.Name = "MnuEdit3";
            this.MnuEdit3.Size = new System.Drawing.Size(180, 22);
            this.MnuEdit3.Text = "剪下";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.TxtW);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.ToolStripMenuItem MnuEdit;
        private System.Windows.Forms.ToolStripMenuItem MnuEdit1;
        private System.Windows.Forms.ToolStripMenuItem MnuEdit2;
        private System.Windows.Forms.ToolStripMenuItem MnuEdit3;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
    }
}

