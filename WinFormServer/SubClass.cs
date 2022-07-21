using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormServer
{
    partial class Form1 : Form
    {
        private delegate void UIToolStripLabelCallBack(string strText, ToolStripStatusLabel ctl);
        private delegate void UIToolStripProgressBarCallBack(int progress, ToolStripProgressBar ctl);
        private delegate void UIRrichTextBoxCallBack(string strText, RichTextBox ctl);
        private delegate void UITextBoxCallBack(string strText, TextBox ctl);

        //https://cloud.tencent.com/developer/ask/sof/145529
        public void PrintTextToToolStripLabel(string strText, ToolStripStatusLabel ctlobj)
        {
            string arg = string.Empty;
            try
            {
                //https://stackoverflow.com/questions/10084691/close-a-form-from-an-external-thread-using-the-invoke-method
                if (ctlobj.IsDisposed)
                {
                    return;
                }
                if (ctlobj.GetCurrentParent().InvokeRequired)
                {
                    UIToolStripLabelCallBack method = new UIToolStripLabelCallBack(PrintTextToToolStripLabel);
                    ctlobj.GetCurrentParent().Invoke(method, new object[]
                    {
                        strText,
                        ctlobj
                    });
                }
                else if (ctlobj.GetType() == typeof(ToolStripStatusLabel))
                {
                    arg = ctlobj.Name;
                    ctlobj.Text = strText;
                }
            }
            catch (Exception ex)
            {
                string strContent = string.Format("[PrintTextToToolStripLabel] {0} {1} {2} ", arg, strText,ex.Message);
                Debug.WriteLine(strContent);
            }
        }

        public void PrintTextToToolStripProgressBar(int progress, ToolStripProgressBar ctlobj)
        {
            string arg = string.Empty;
            try
            {
                if (ctlobj.IsDisposed)
                {
                    return;
                }
                if (ctlobj.GetCurrentParent().InvokeRequired)
                {
                    UIToolStripProgressBarCallBack method = new UIToolStripProgressBarCallBack(PrintTextToToolStripProgressBar);
                    ctlobj.GetCurrentParent().Invoke(method, new object[]
                    {
                        progress,
                        ctlobj
                    });
                }
                else if (ctlobj.GetType() == typeof(ToolStripProgressBar))
                {
                    arg = ctlobj.Name;
                    ctlobj.Value = progress;
                }
            }
            catch (Exception ex)
            {
                string strContent = string.Format("[PrintTextToToolStripProgressBar] {0} {1} {2}", arg, progress.ToString(),ex.Message);
                Debug.WriteLine(strContent);
            }
        }

        public void PrintTextToRichTextBox(string strText, RichTextBox ctlobj)
        {
            string arg = string.Empty;
            try
            {
                if (ctlobj.IsDisposed)
                {
                    return;
                }
                if (ctlobj.InvokeRequired)
                {
                    UIRrichTextBoxCallBack method = new UIRrichTextBoxCallBack(PrintTextToRichTextBox);
                    ctlobj.Invoke(method, new object[]
                    {
                        strText,
                        ctlobj
                    });
                }
                else if (ctlobj.GetType() == typeof(RichTextBox))
                {
                    arg = ctlobj.Name;
                    ctlobj.AppendText(strText);
                    ctlobj.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                string strContent = string.Format("[PrintTextToRichTextBox] {0} {1} {2} ", arg, strText,ex.Message);
                Debug.WriteLine(strContent);
            }
        }

        public void PrintTextToTextBox(string strText, TextBox ctlobj)
        {
            string arg = string.Empty;
            try
            {
                if (ctlobj.IsDisposed)
                {
                    return;
                }
                if (ctlobj.InvokeRequired)
                {
                    UITextBoxCallBack method = new UITextBoxCallBack(PrintTextToTextBox);
                    ctlobj.Invoke(method, new object[]
                    {
                        strText,
                        ctlobj
                    });
                }
                else if (ctlobj.GetType() == typeof(TextBox))
                {
                    arg = ctlobj.Name;
                    ctlobj.Text = strText;
                }
            }
            catch (Exception ex)
            {
                string strContent = string.Format("[PrintTextToTextBox] {0} {1} {2} ", arg, strText, ex.Message);
                Debug.WriteLine(strContent);
            }
        }
    }
}
