
namespace csharp_example
{
    partial class Frm1
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
            this.Txt1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt3 = new System.Windows.Forms.TextBox();
            this.BtnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名:";
            // 
            // Txt1
            // 
            this.Txt1.Location = new System.Drawing.Point(108, 39);
            this.Txt1.Name = "Txt1";
            this.Txt1.Size = new System.Drawing.Size(179, 25);
            this.Txt1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "電話:";
            // 
            // Txt2
            // 
            this.Txt2.Location = new System.Drawing.Point(108, 77);
            this.Txt2.Name = "Txt2";
            this.Txt2.Size = new System.Drawing.Size(179, 25);
            this.Txt2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "電子信箱:";
            // 
            // Txt3
            // 
            this.Txt3.Location = new System.Drawing.Point(108, 116);
            this.Txt3.Name = "Txt3";
            this.Txt3.Size = new System.Drawing.Size(179, 25);
            this.Txt3.TabIndex = 5;
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(195, 158);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(92, 36);
            this.BtnNext.TabIndex = 6;
            this.BtnNext.Text = "下一步";
            this.BtnNext.UseVisualStyleBackColor = true;
            // 
            // Frm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.Txt3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt1);
            this.Controls.Add(this.label1);
            this.Name = "Frm1";
            this.Text = "個人資料";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt3;
        private System.Windows.Forms.Button BtnNext;
    }
}