
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsBtnStart = new System.Windows.Forms.ToolStripButton();
            this.TsBtnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TsCboPic = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TsTxtMsg = new System.Windows.Forms.ToolStripTextBox();
            this.TmrMove = new System.Windows.Forms.Timer(this.components);
            this.LblMsg = new System.Windows.Forms.Label();
            this.PicPicture = new System.Windows.Forms.PictureBox();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.PicPicture);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.LblMsg);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(801, 425);
            this.toolStripContainer1.Location = new System.Drawing.Point(1, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(801, 452);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsBtnStart,
            this.TsBtnStop,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.TsCboPic,
            this.toolStripLabel2,
            this.TsTxtMsg});
            this.toolStrip1.Location = new System.Drawing.Point(21, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(532, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TsBtnStart
            // 
            this.TsBtnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsBtnStart.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnStart.Image")));
            this.TsBtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnStart.Name = "TsBtnStart";
            this.TsBtnStart.Size = new System.Drawing.Size(29, 24);
            this.TsBtnStart.Text = "toolStripButton1";
            // 
            // TsBtnStop
            // 
            this.TsBtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsBtnStop.Image = ((System.Drawing.Image)(resources.GetObject("TsBtnStop.Image")));
            this.TsBtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtnStop.Name = "TsBtnStop";
            this.TsBtnStop.Size = new System.Drawing.Size(29, 24);
            this.TsBtnStop.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(115, 24);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // TsCboPic
            // 
            this.TsCboPic.Name = "TsCboPic";
            this.TsCboPic.Size = new System.Drawing.Size(121, 27);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(115, 24);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // TsTxtMsg
            // 
            this.TsTxtMsg.Name = "TsTxtMsg";
            this.TsTxtMsg.Size = new System.Drawing.Size(100, 27);
            // 
            // LblMsg
            // 
            this.LblMsg.AutoSize = true;
            this.LblMsg.Font = new System.Drawing.Font("標楷體", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LblMsg.Location = new System.Drawing.Point(38, 317);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(213, 60);
            this.LblMsg.TabIndex = 0;
            this.LblMsg.Text = "label1";
            // 
            // PicPicture
            // 
            this.PicPicture.Location = new System.Drawing.Point(42, 22);
            this.PicPicture.Name = "PicPicture";
            this.PicPicture.Size = new System.Drawing.Size(562, 248);
            this.PicPicture.TabIndex = 1;
            this.PicPicture.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsBtnStart;
        private System.Windows.Forms.ToolStripButton TsBtnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox TsCboPic;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox TsTxtMsg;
        private System.Windows.Forms.Timer TmrMove;
        private System.Windows.Forms.Label LblMsg;
        private System.Windows.Forms.PictureBox PicPicture;
    }
}

