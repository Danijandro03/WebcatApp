using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
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
                SimpleIoc.Default.Register<TreePageModel>();
                nav.Configure("TreePage", typeof(TreePage));
                SimpleIoc.Default.Register<PdfPageModel>();
                nav.Configure("PdfPage", typeof(PdfPage));
                SimpleIoc.Default.Register<UxPageModel>();
                nav.Configure("UxPage", typeof(UxPage));

            }
        }
        public InitPageModel InitPage => ServiceLocator.Current.GetInstance<InitPageModel>();
        public TreePageModel TreePage => ServiceLocator.Current.GetInstance<TreePageModel>();
        public PdfPageModel PdfPage => ServiceLocator.Current.GetInstance<PdfPageModel>();
        public UxPageModel UxPage => ServiceLocator.Current.GetInstance<UxPageModel>();
    }
}
