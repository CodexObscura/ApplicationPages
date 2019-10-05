using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ApplicationPages
{
   
    public abstract class ApplicationPage : UserControl, ApplicationPage.IApplicationPage
    {
        public abstract PackIconMaterialKind Icon {get;protected set; }

        public interface IApplicationPage
        {
            public PackIconMaterialKind Icon {get; }
            
        }
    }
    public abstract class MenuPage : ApplicationPage, IMenuPage
    {
        
        public abstract string DockLocation { get;}
        public abstract string Description { get;}

        public virtual Visibility ShowIndicator => Visibility.Visible;
    }

    public abstract class SubMenuPage<T> : MenuPage 
    {
        public abstract ObservableCollection<T> Tabs {get; }
        public SubMenuPage()
        {

            var tabItemBinding = new Binding("Tabs");
            var subMenuTabControl = new TabControl();
            subMenuTabControl.SetResourceReference(Control.StyleProperty, "appSubMenu");
            subMenuTabControl.SetResourceReference(ItemsControl.ItemContainerStyleProperty, "appSubMenuPage");

            BindingOperations.SetBinding(subMenuTabControl, ItemsControl.ItemsSourceProperty, tabItemBinding);
            this.Content = subMenuTabControl;

        }
        public override Visibility ShowIndicator => Visibility.Hidden;
    }

 

    public abstract class DynamicPage : ApplicationPage, IDynamicPage
    {

    }
    public interface IMenuPage : ApplicationPage.IApplicationPage
    {
        public string DockLocation { get;}
    }
    public interface IDynamicPage : ApplicationPage.IApplicationPage
    {

    }
}
