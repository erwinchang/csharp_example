
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TsBtnSpeed = new System.Windows.Forms.ToolStripSplitButton();
            this.MnuFast = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSlow = new System.Windows.Forms.ToolStripMenuItem();
            this.TsLblSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsPrgFly = new System.Windows.Forms.ToolStripProgressBar();
            this.TsLblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.PicBird = new System.Windows.Forms.PictureBox();
            this.TmrFly = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBird)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsBtnSpeed,
            this.TsLblSpeed,
            this.TsPrgFly,
            this.TsLblMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 228);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(640, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Click += new System.EventHandler(this.statusStrip1_Click);
            // 
            // TsBtnSpeed
            // 
            this.TsBtnSpeed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsBtnSpeed.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFast,
            this.MnuSlow});
            this.TsBtnSpeed.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnSpeed.Image")));
            this.TsBtnSpeed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnSpeed.Name = "TsBtnSpeed";
            this.TsBtnSpeed.Size = new System.Drawing.Size(39, 24);
            this.TsBtnSpeed.Text = "toolStripSplitButton1";
            this.TsBtnSpeed.ButtonClick += new System.EventHandler(this.TsBtnSpeed_ButtonClick);
            this.TsBtnSpeed.Click += new System.EventHandler(this.TsBtnSpeed_Click);
            // 
            // MnuFast
            // 
            this.MnuFast.Name = "MnuFast";
            this.MnuFast.Size = new System.Drawing.Size(224, 26);
            this.MnuFast.Text = "快速";
            this.MnuFast.Click += new System.EventHandler(this.MnuFast_Click);
            // 
            // MnuSlow
            // 
            this.MnuSlow.Name = "MnuSlow";
            this.MnuSlow.Size = new System.Drawing.Size(224, 26);
            this.MnuSlow.Text = "慢速";
            this.MnuSlow.Click += new System.EventHandler(this.MnuSlow_Click);
            // 
            // TsLblSpeed
            // 
            this.TsLblSpeed.Name = "TsLblSpeed";
            this.TsLblSpeed.Size = new System.Drawing.Size(39, 20);
            this.TsLblSpeed.Text = "慢速";
            // 
            // TsPrgFly
            // 
            this.TsPrgFly.Name = "TsPrgFly";
            this.TsPrgFly.Size = new System.Drawing.Size(133, 18);
            // 
            // TsLblMsg
            // 
            this.TsLblMsg.Name = "TsLblMsg";
            this.TsLblMsg.Size = new System.Drawing.Size(39, 20);
            this.TsLblMsg.Text = "進度";
            // 
            // PicBird
            // 
            this.PicBird.Image = ((System.Drawing.Image)(resources.GetObject("PicBird.Image")));
            this.PicBird.InitialImage = ((System.Drawing.Image)(resources.GetObject("PicBird.InitialImage")));
            this.PicBird.Location = new System.Drawing.Point(13, 74);
            this.PicBird.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PicBird.Name = "PicBird";
            this.PicBird.Size = new System.Drawing.Size(147, 100);
            this.PicBird.TabIndex = 1;
            this.PicBird.TabStop = false;
            // 
            // TmrFly
            // 
            this.TmrFly.Tick += new System.EventHandler(this.TmrFly_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 254);
            this.Controls.Add(this.PicBird);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBird)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton TsBtnSpeed;
        private System.Windows.Forms.ToolStripStatusLabel TsLblSpeed;
        private System.Windows.Forms.ToolStripProgressBar TsPrgFly;
        private System.Windows.Forms.ToolStripStatusLabel TsLblMsg;
        private System.Windows.Forms.PictureBox PicBird;
        private System.Windows.Forms.ToolStripMenuItem MnuFast;
        private System.Windows.Forms.ToolStripMenuItem MnuSlow;
        private System.Windows.Forms.Timer TmrFly;
    }
}

