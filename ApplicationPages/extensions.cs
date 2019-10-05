using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApplicationPages
{
    public static class extensions
    {
		public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
		{
			if (assembly == null) throw new ArgumentNullException(nameof(assembly));
			try
			{
				return assembly.GetTypes();
			}
			catch (ReflectionTypeLoadException e)
			{
				return e.Types.Where(t => t != null);
			}
		}

		public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
		{
			foreach (var i in items)
			{
				collection.Add(i);
			}
		}
		public static void UseApplicationPages(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ApplicationWindow));

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany((assemb) => assemb.GetLoadableTypes()).Where((t) => (!t.IsAbstract) && typeof(ApplicationPage.IApplicationPage).IsAssignableFrom(t));
            
            types.ForEach(t=>
            {
                switch(t)
                {
                    case IDynamicPage dynamic:
                        services.AddTransient(typeof(IDynamicPage),t);
                        break;
                    default:
                        services.AddSingleton(typeof(IMenuPage),t);
                        break;
                }
            });

            //services.AddTransient<Lazy<IRepo>>(provider => new Lazy<IRepo>(provider.GetService<IRepo>));
        }

        public static  ApplicationWindow GetApplicationWindow(this IHost host) => (ApplicationWindow)host.Services.GetService(typeof(ApplicationWindow));
        

        internal static void ForEach<T>(this IEnumerable<T> source,Action<T> action)
        {
            foreach( T element in source)
            {
                action(element);
            }
        }
    }
}
