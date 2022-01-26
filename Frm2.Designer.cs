
namespace csharp_example
{
    partial class Frm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Rdb1 = new System.Windows.Forms.RadioButton();
            this.Rdb2 = new System.Windows.Forms.RadioButton();
            this.Rdb3 = new System.Windows.Forms.RadioButton();
            this.Rdb4 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtInput = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "學歷:";
            // 
            // Rdb1
            // 
            this.Rdb1.AutoSize = true;
            this.Rdb1.Location = new System.Drawing.Point(29, 54);
            this.Rdb1.Name = "Rdb1";
            this.Rdb1.Size = new System.Drawing.Size(58, 19);
            this.Rdb1.TabIndex = 1;
            this.Rdb1.TabStop = true;
            this.Rdb1.Text = "高中";
            this.Rdb1.UseVisualStyleBackColor = true;
            // 
            // Rdb2
            // 
            this.Rdb2.AutoSize = true;
            this.Rdb2.Location = new System.Drawing.Point(106, 54);
            this.Rdb2.Name = "Rdb2";
            this.Rdb2.Size = new System.Drawing.Size(58, 19);
            this.Rdb2.TabIndex = 2;
            this.Rdb2.TabStop = true;
            this.Rdb2.Text = "高職";
            this.Rdb2.UseVisualStyleBackColor = true;
            // 
            // Rdb3
            // 
            this.Rdb3.AutoSize = true;
            this.Rdb3.Location = new System.Drawing.Point(179, 54);
            this.Rdb3.Name = "Rdb3";
            this.Rdb3.Size = new System.Drawing.Size(58, 19);
            this.Rdb3.TabIndex = 3;
            this.Rdb3.TabStop = true;
            this.Rdb3.Text = "專科";
            this.Rdb3.UseVisualStyleBackColor = true;
            // 
            // Rdb4
            // 
            this.Rdb4.AutoSize = true;
            this.Rdb4.Location = new System.Drawing.Point(243, 54);
            this.Rdb4.Name = "Rdb4";
            this.Rdb4.Size = new System.Drawing.Size(58, 19);
            this.Rdb4.TabIndex = 4;
            this.Rdb4.TabStop = true;
            this.Rdb4.Text = "大學";
            this.Rdb4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "專長";
            // 
            // TxtInput
            // 
            this.TxtInput.Location = new System.Drawing.Point(26, 130);
            this.TxtInput.Name = "TxtInput";
            this.TxtInput.Size = new System.Drawing.Size(275, 25);
            this.TxtInput.TabIndex = 6;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(194, 173);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(107, 28);
            this.BtnOK.TabIndex = 7;
            this.BtnOK.Text = "完成";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // Frm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TxtInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Rdb4);
            this.Controls.Add(this.Rdb3);
            this.Controls.Add(this.Rdb2);
            this.Controls.Add(this.Rdb1);
            this.Controls.Add(this.label1);
            this.Name = "Frm2";
            this.Text = "個人專長";
            this.Load += new System.EventHandler(this.Frm2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Rdb1;
        private System.Windows.Forms.RadioButton Rdb2;
        private System.Windows.Forms.RadioButton Rdb3;
        private System.Windows.Forms.RadioButton Rdb4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtInput;
        private System.Windows.Forms.Button BtnOK;
    }
}