using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApplicationPages
{
    /// <summary>
    /// Interaction logic for ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        private readonly IEnumerable<IMenuPage> _menuPages;
        public ApplicationWindow(IEnumerable<IMenuPage> menuPages)
        {
            _menuPages = menuPages;
            this.DataContext = this;
       
            InitializeComponent();
            BuildMenu();
        }
        private ObservableCollection<IMenuPage> _pages = new ObservableCollection<IMenuPage>();
        public ObservableCollection<IMenuPage> Pages
        {
            get
            {
                return _pages;
            }
        }
        


        public void BuildMenu()
        {
            _pages.Clear();
            _pages.AddRange(_menuPages);
            if (_pages.Where((x) => x.DockLocation == "Top").Count() == 1)
            {
                Items.SelectedItem = _pages.Where((x) => x.DockLocation == "Top").First();
            }
            else
            {
                Items.SelectedItem = null;
            }
        }

        private bool _isDefault = true;
        public void ChangeTheme()
        {
            if (_isDefault)
            {
                this.Resources["StatusBar.Background"] = Brushes.Red;
            }
        }
        //  <SolidColorBrush x:Key="Titlebar.Logo.Foreground" Color="White" />
        //<SolidColorBrush x:Key="Titlebar.Background" Color="{StaticResource ResourceKey=MillikenBlue}"/>
        //<SolidColorBrush x:Key="Titlebar.WindowButton.Foreground" Color="{StaticResource ResourceKey=MediumGray}"/>

        //<SolidColorBrush x:Key="StatusBar.Background" Color="{StaticResource ResourceKey=DarkPurple}"/>

        //<SolidColorBrush x:Key="MenuBar.Background" Color="{StaticResource ResourceKey=DarkBlue}"/>
        //<SolidColorBrush x:Key="MenuBar.Foreground" Color="{StaticResource ResourceKey=LightGray}"/>
        //<SolidColorBrush x:Key="MenuBar.Active.Background" Color="{StaticResource ResourceKey=MediumBlue}"/>
        //<SolidColorBrush x:Key="MenuBar.Active.Foreground" Color="White"/>
        //<SolidColorBrush x:Key="MenuBar.Active.Indicator" Color="{StaticResource ResourceKey=LightGreen}"/>

        #region "TitleBar"
        public Control IconControl
        {
            get { return (Control)GetValue(IconControlProperty); }
            set { SetValue(IconControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconControl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconControlProperty =
            DependencyProperty.Register("IconControl", typeof(Control), typeof(ApplicationWindow), new PropertyMetadata(null));

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            return;
        }

        private void ToggleMax_Click(object sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                if (e.ClickCount == 2)
                {
                    AdjustWindowSize();
                }
                else
                {
                    Application.Current.MainWindow.DragMove();
                }
        }

        private Control max = new PackIconMaterial() { Kind = PackIconMaterialKind.WindowMaximize, Width = 20, Height = 20, };
        private Control restore = new PackIconMaterial() { Kind = PackIconMaterialKind.ContentCopy, Width = 20, Height = 20, Flip = PackIconFlipOrientation.Horizontal };

        private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.None;

                toggleMax.Content = max;
                this.BorderThickness = new System.Windows.Thickness(0);
            }
            else
            {
                //     this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.MaxHeight = SystemParameters.WorkArea.Height + 12;
                this.MaxWidth = SystemParameters.WorkArea.Width + 12;

                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                toggleMax.Content = restore;
                this.BorderThickness = new System.Windows.Thickness(8);
            }

        } 
        #endregion
    }
}
