using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ApplicationPages;
using MahApps.Metro.IconPacks;

namespace ExampleWpfApp
{
    public class Settings : SubMenuPage<ISettingsPage>
    {
        private readonly ObservableCollection<ISettingsPage> _pages;

        public Settings(IEnumerable<ISettingsPage> pages)
        {
            _pages = new ObservableCollection<ISettingsPage>();
            _pages.AddRange(pages);
            DataContext = this;
        }


        public override ObservableCollection<ISettingsPage> Tabs => _pages;

        public override string DockLocation => "Bottom";

        public override string Description => "Settings";

        public override PackIconMaterialKind Icon { get => PackIconMaterialKind.SettingsOutline; protected set => throw new NotImplementedException(); }
    }
}
