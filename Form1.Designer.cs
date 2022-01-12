
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.TxtPW = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.TxtM1 = new System.Windows.Forms.TextBox();
            this.TxtM2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtR1 = new System.Windows.Forms.TextBox();
            this.TxtR2 = new System.Windows.Forms.TextBox();
            this.LblTotal = new System.Windows.Forms.Label();
            this.LblMsg = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(40, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(381, 240);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TxtPW);
            this.tabPage1.Controls.Add(this.TxtID);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(373, 211);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "登錄";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.TxtM2);
            this.tabPage2.Controls.Add(this.TxtM1);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(373, 211);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "主餐";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TxtR2);
            this.tabPage3.Controls.Add(this.TxtR1);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.checkBox4);
            this.tabPage3.Controls.Add(this.checkBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(373, 211);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "飲料";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.LblTotal);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(373, 211);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "結帳";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "使用者";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  碼:";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(117, 41);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(66, 25);
            this.TxtID.TabIndex = 2;
            // 
            // TxtPW
            // 
            this.TxtPW.Location = new System.Drawing.Point(118, 77);
            this.TxtPW.Name = "TxtPW";
            this.TxtPW.Size = new System.Drawing.Size(66, 25);
            this.TxtPW.TabIndex = 3;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(33, 86);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(113, 19);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "三明治(30元)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(34, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "蛋餅(20元)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // TxtM1
            // 
            this.TxtM1.Location = new System.Drawing.Point(134, 46);
            this.TxtM1.Name = "TxtM1";
            this.TxtM1.Size = new System.Drawing.Size(66, 25);
            this.TxtM1.TabIndex = 4;
            // 
            // TxtM2
            // 
            this.TxtM2.Location = new System.Drawing.Point(135, 83);
            this.TxtM2.Name = "TxtM2";
            this.TxtM2.Size = new System.Drawing.Size(66, 25);
            this.TxtM2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "數量";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(71, 61);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(98, 19);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "豆漿(15元)";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(73, 96);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(98, 19);
            this.checkBox4.TabIndex = 1;
            this.checkBox4.Text = "奶茶(20元)";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "數量";
            // 
            // TxtR1
            // 
            this.TxtR1.Location = new System.Drawing.Point(200, 60);
            this.TxtR1.Name = "TxtR1";
            this.TxtR1.Size = new System.Drawing.Size(44, 25);
            this.TxtR1.TabIndex = 3;
            this.TxtR1.TextChanged += new System.EventHandler(this.TxtR1_TextChanged);
            // 
            // TxtR2
            // 
            this.TxtR2.Location = new System.Drawing.Point(200, 93);
            this.TxtR2.Name = "TxtR2";
            this.TxtR2.Size = new System.Drawing.Size(44, 25);
            this.TxtR2.TabIndex = 4;
            // 
            // LblTotal
            // 
            this.LblTotal.Location = new System.Drawing.Point(19, 28);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(265, 94);
            this.LblTotal.TabIndex = 0;
            this.LblTotal.Text = "label5";
            // 
            // LblMsg
            // 
            this.LblMsg.Location = new System.Drawing.Point(41, 276);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.Size = new System.Drawing.Size(376, 52);
            this.LblMsg.TabIndex = 1;
            this.LblMsg.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 359);
            this.Controls.Add(this.LblMsg);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "活力早餐店";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox TxtPW;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtM2;
        private System.Windows.Forms.TextBox TxtM1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox TxtR2;
        private System.Windows.Forms.TextBox TxtR1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label LblMsg;
    }
}

