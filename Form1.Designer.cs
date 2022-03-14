
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
            this.BtnSQL = new System.Windows.Forms.Button();
            this.BtnHbase = new System.Windows.Forms.Button();
            this.BtnDynamic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnSQL
            // 
            this.BtnSQL.Location = new System.Drawing.Point(43, 35);
            this.BtnSQL.Name = "BtnSQL";
            this.BtnSQL.Size = new System.Drawing.Size(76, 38);
            this.BtnSQL.TabIndex = 0;
            this.BtnSQL.Text = "SQL";
            this.BtnSQL.UseVisualStyleBackColor = true;
            this.BtnSQL.Click += new System.EventHandler(this.BtnSQL_Click);
            // 
            // BtnHbase
            // 
            this.BtnHbase.Location = new System.Drawing.Point(47, 84);
            this.BtnHbase.Name = "BtnHbase";
            this.BtnHbase.Size = new System.Drawing.Size(71, 36);
            this.BtnHbase.TabIndex = 1;
            this.BtnHbase.Text = "Hbase";
            this.BtnHbase.UseVisualStyleBackColor = true;
            this.BtnHbase.Click += new System.EventHandler(this.BtnHbase_Click);
            // 
            // BtnDynamic
            // 
            this.BtnDynamic.Location = new System.Drawing.Point(48, 140);
            this.BtnDynamic.Name = "BtnDynamic";
            this.BtnDynamic.Size = new System.Drawing.Size(69, 35);
            this.BtnDynamic.TabIndex = 2;
            this.BtnDynamic.Text = "Dynamic";
            this.BtnDynamic.UseVisualStyleBackColor = true;
            this.BtnDynamic.Click += new System.EventHandler(this.BtnDynamic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnDynamic);
            this.Controls.Add(this.BtnHbase);
            this.Controls.Add(this.BtnSQL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSQL;
        private System.Windows.Forms.Button BtnHbase;
        private System.Windows.Forms.Button BtnDynamic;
    }
}

