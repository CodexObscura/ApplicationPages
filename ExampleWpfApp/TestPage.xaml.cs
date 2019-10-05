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
using ApplicationPages;
using MahApps.Metro.IconPacks;

namespace ExampleWpfApp
{
    /// <summary>
    /// Interaction logic for DefaultPage.xaml
    /// </summary>
    public partial class TestPage : MenuPage
    {

        public TestPage()
        {
            
            InitializeComponent();
        }

        public override string DockLocation =>"Top";

        public override string Description => "Test page";

        public override PackIconMaterialKind Icon { get =>  PackIconMaterialKind.TestTube; protected set => throw new NotImplementedException(); }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           App.Host.GetApplicationWindow().ChangeTheme();
        }
    }
}
