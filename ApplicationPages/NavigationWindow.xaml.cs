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
    /// Interaction logic for NavigationWindow.xaml
    /// </summary>
    public partial class NavigationWindow : Window
    {
        public NavigationWindow()
        {
           
            InitializeComponent();
            this.DataContext=this;
            BuildMenu();

        }

            private void BuildMenu()
            {
            }

        public void AddOpenWindow()
        {
        }


        public ObservableCollection<NavigationCommand> Windows
        {
            get { return (ObservableCollection<NavigationCommand>)GetValue(WindowsProperty); }
            set { SetValue(WindowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Windows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowsProperty =
            DependencyProperty.Register("Windows", typeof(ObservableCollection<NavigationCommand>), typeof(NavigationWindow), new PropertyMetadata(null));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        /// <summary>
        /// CloseButton_Clicked
        /// </summary>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// MaximizedButton_Clicked
        /// </summary>
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
           AdjustWindowSize();
        }

        /// <summary>
        /// Minimized Button_Clicked
        /// </summary>
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        
        private Control max = new MahApps.Metro.IconPacks.PackIconMaterial() { Kind= MahApps.Metro.IconPacks.PackIconMaterialKind.WindowMaximize,Width = 20, Height = 20, };
        private Control restore = new MahApps.Metro.IconPacks.PackIconMaterial()  {  Kind= PackIconMaterialKind.ContentCopy, Width=20,Height=20,Flip= PackIconFlipOrientation.Horizontal};
        /// <summary>
        /// Adjusts the WindowSize to correct parameters when Maximize button is clicked
        /// </summary>
        private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.None;
                
                MaximizeButton.Content = max;
                this.BorderThickness = new System.Windows.Thickness(0);
            }
            else
            {
                //     this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.MaxHeight = SystemParameters.WorkArea.Height +12;
                this.MaxWidth = SystemParameters.WorkArea.Width +12;

                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                MaximizeButton.Content = restore;
                this.BorderThickness = new System.Windows.Thickness(8);
            }

        }


       


      
    }

    public class NavigationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Blah");
        }

        public Control mycontent { get;set;}

        public string _Dock { get;set;}
        public PackIconMaterialKind _Kind { get;set;}

        public string DockLocation => _Dock;
         public PackIconMaterialKind Kind => _Kind;
        public string _Description { get;set;}
        public string Description => _Description;
    }

    public class MainMenu : TabControl
    {
        static MainMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainMenu), new FrameworkPropertyMetadata(typeof(MainMenu)));
        }
    }

    public class MenuTab : TabItem
    {
        static MenuTab()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuTab), new FrameworkPropertyMetadata(typeof(MenuTab)));
        }
    }
}
