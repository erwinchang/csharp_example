
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnNewRow = new System.Windows.Forms.Button();
            this.BtnDataRow1 = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(98, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(650, 287);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnNewRow
            // 
            this.BtnNewRow.Location = new System.Drawing.Point(216, 22);
            this.BtnNewRow.Name = "BtnNewRow";
            this.BtnNewRow.Size = new System.Drawing.Size(120, 41);
            this.BtnNewRow.TabIndex = 1;
            this.BtnNewRow.Text = "NewRow";
            this.BtnNewRow.UseVisualStyleBackColor = true;
            this.BtnNewRow.Click += new System.EventHandler(this.BtnNewRow_Click);
            // 
            // BtnDataRow1
            // 
            this.BtnDataRow1.Location = new System.Drawing.Point(342, 22);
            this.BtnDataRow1.Name = "BtnDataRow1";
            this.BtnDataRow1.Size = new System.Drawing.Size(136, 41);
            this.BtnDataRow1.TabIndex = 2;
            this.BtnDataRow1.Text = "DataRow1";
            this.BtnDataRow1.UseVisualStyleBackColor = true;
            this.BtnDataRow1.Click += new System.EventHandler(this.BtnDataRow1_Click);
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(98, 21);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(114, 42);
            this.BtnCreate.TabIndex = 3;
            this.BtnCreate.Text = "Create Table";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.BtnDataRow1);
            this.Controls.Add(this.BtnNewRow);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnNewRow;
        private System.Windows.Forms.Button BtnDataRow1;
        private System.Windows.Forms.Button BtnCreate;
    }
}

