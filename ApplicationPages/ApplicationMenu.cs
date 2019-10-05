using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationPages
{
    public class ApplicationMenu : TabControl
    {
        static ApplicationMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ApplicationMenu), new FrameworkPropertyMetadata(typeof(ApplicationMenu)));
        }
    }

  public class ApplicationSubMenu : TabControl
    {
        static ApplicationSubMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ApplicationSubMenu), new FrameworkPropertyMetadata(typeof(ApplicationSubMenu)));
        }
    }
}
