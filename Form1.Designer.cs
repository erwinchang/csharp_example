
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
            this.LstvBooks = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.CboView = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LstBorrow = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LstvBooks
            // 
            this.LstvBooks.HideSelection = false;
            this.LstvBooks.Location = new System.Drawing.Point(58, 38);
            this.LstvBooks.Name = "LstvBooks";
            this.LstvBooks.Size = new System.Drawing.Size(276, 378);
            this.LstvBooks.TabIndex = 0;
            this.LstvBooks.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "檢視方式";
            // 
            // CboView
            // 
            this.CboView.FormattingEnabled = true;
            this.CboView.Location = new System.Drawing.Point(378, 56);
            this.CboView.Name = "CboView";
            this.CboView.Size = new System.Drawing.Size(153, 23);
            this.CboView.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "借書清單";
            // 
            // LstBorrow
            // 
            this.LstBorrow.FormattingEnabled = true;
            this.LstBorrow.ItemHeight = 15;
            this.LstBorrow.Location = new System.Drawing.Point(379, 207);
            this.LstBorrow.Name = "LstBorrow";
            this.LstBorrow.Size = new System.Drawing.Size(152, 199);
            this.LstBorrow.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 436);
            this.Controls.Add(this.LstBorrow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CboView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstvBooks);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LstvBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LstBorrow;
    }
}

