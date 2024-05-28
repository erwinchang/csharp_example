using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfOfficeInterop
{
    public class cpMessageBox
    {
        public MessageBoxResult Show(
            string messageBoxText,
            string caption,
            string button = null,
            string icon = null,
            string defaultResult = null,
            string options = null)
        {
            MessageBoxButton button1 = MessageBoxButton.OK;
            MessageBoxImage icon1 = MessageBoxImage.None;
            MessageBoxResult defaultResult1 = MessageBoxResult.None;
            MessageBoxOptions options1 = MessageBoxOptions.None;
            switch (button)
            {
                case "OK":
                    button1 = MessageBoxButton.OK;
                    break;
                case "OKCancel":
                    button1 = MessageBoxButton.OKCancel;
                    break;
                case "YesNo":
                    button1 = MessageBoxButton.YesNo;
                    break;
                case "YesNoCancel":
                    button1 = MessageBoxButton.YesNoCancel;
                    break;
            }
            switch (icon)
            {
                case "None":
                    icon1 = MessageBoxImage.None;
                    break;
                case "Hand":
                    icon1 = MessageBoxImage.Hand;
                    break;
                case "Stop":
                    icon1 = MessageBoxImage.Hand;
                    break;
                case "Error":
                    icon1 = MessageBoxImage.Hand;
                    break;
                case "Question":
                    icon1 = MessageBoxImage.Question;
                    break;
                case "Exclamation":
                    icon1 = MessageBoxImage.Exclamation;
                    break;
                case "Warning":
                    icon1 = MessageBoxImage.Exclamation;
                    break;
                case "Asterisk":
                    icon1 = MessageBoxImage.Asterisk;
                    break;
                case "Information":
                    icon1 = MessageBoxImage.Asterisk;
                    break;
            }
            switch (defaultResult)
            {
                case "None":
                    defaultResult1 = MessageBoxResult.None;
                    break;
                case "OK":
                    defaultResult1 = MessageBoxResult.OK;
                    break;
                case "Cancel":
                    defaultResult1 = MessageBoxResult.Cancel;
                    break;
                case "Yes":
                    defaultResult1 = MessageBoxResult.Yes;
                    break;
                case "No":
                    defaultResult1 = MessageBoxResult.No;
                    break;
            }
            switch (options)
            {
                case "None":
                    options1 = MessageBoxOptions.None;
                    break;
                case "DefaultDesktopOnly":
                    options1 = MessageBoxOptions.DefaultDesktopOnly;
                    break;
                case "RightAlign":
                    options1 = MessageBoxOptions.RightAlign;
                    break;
                case "RtlReading":
                    options1 = MessageBoxOptions.RtlReading;
                    break;
                case "ServiceNotification":
                    options1 = MessageBoxOptions.ServiceNotification;
                    break;
            }
            return MessageBox.Show(messageBoxText, caption, button1, icon1, defaultResult1, options1);
        }
    }
}
