﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class MyClass
    {
    }
    public class MyButton: Button
    {
        public Type UserWindowType { get; set; }
        protected override void OnClick()
        {
            base.OnClick();
            Window win = Activator.CreateInstance(this.UserWindowType) as Window;
            if(win != null)
            {
                win.ShowDialog();
            }
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
