using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcatApp.View;

namespace WebcatApp.ViewModel.Base
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Locator => locator ?? (locator = new ViewModelLocator());
        private static ViewModelLocator locator;
        public ViewModelLocator()
        {
            var nav = new NavigationService();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
                SimpleIoc.Default.Register<InitPageModel>();
                nav.Configure("InitPage", typeof(InitPage));

            }
        }
        public InitPageModel InitPage => ServiceLocator.Current.GetInstance<InitPageModel>();
        
        
    }
}
