
namespace Utilities.Controls
{
    partial class LoggingView
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

        #region 元件設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.eagerTimer1 = new Utilities.EagerTimer();
            ((System.ComponentModel.ISupportInitialize)(this.eagerTimer1)).BeginInit();
            this.SuspendLayout();
            // 
            // eagerTimer1
            // 
            this.eagerTimer1.AutoStart = false;
            this.eagerTimer1.Enabled = true;
            this.eagerTimer1.SynchronizingObject = this;
            ((System.ComponentModel.ISupportInitialize)(this.eagerTimer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EagerTimer eagerTimer1;
    }
}
