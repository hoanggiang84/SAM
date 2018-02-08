﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SAM.Library;

namespace SAM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbNumber.MouseWheel += tbNumber_MouseWheel;
        }

        void tbNumber_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var index = tbNumber.SelectionStart;
            var dVal = Math.Sign(e.Delta);
            var newNum = NumberScroll.ScrollUp(tbNumber.Text, index);
            tbNumber.Text = newNum.ToString();
            tbNumber.SelectionStart = index;
            tbIndex.Text = dVal.ToString();
        }

        private void tbNumber_KeyUp(object sender, KeyEventArgs e)
        {
        }
    }
}
