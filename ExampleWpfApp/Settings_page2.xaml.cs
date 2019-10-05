using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleWpfApp
{
    /// <summary>
    /// Interaction logic for Settings_page2.xaml
    /// </summary>
    public partial class Settings_page2 : UserControl, ISettingsPage
    {
        public Settings_page2()
        {
            InitializeComponent();
        }

        public string Header => "Page 2";
    }
}
