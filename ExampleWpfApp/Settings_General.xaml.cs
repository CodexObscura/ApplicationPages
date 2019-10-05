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
    /// Interaction logic for Settings_General.xaml
    /// </summary>
    public partial class Settings_General : UserControl,ISettingsPage
    {
        public Settings_General()
        {
            InitializeComponent();
        }

        public string Header => "General";
    }
}
