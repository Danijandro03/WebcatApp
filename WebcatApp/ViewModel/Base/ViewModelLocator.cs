using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using WebcatApp.View;

namespace WebcatApp.ViewModel.Base
{
    public class ViewModelLocator : SimpleIoc
    {
        public static ViewModelLocator Locator => locator ?? (locator = new ViewModelLocator());
        private static ViewModelLocator locator;
        public ViewModelLocator()
        {
            var nav = new NavigationService();
            ServiceLocator.SetLocatorProvider(() => Default);
            if (!Default.IsRegistered<INavigationService>())
            {
                Default.Register<INavigationService, NavigationService>();
                Default.Register<InitPageModel>();
                nav.Configure("InitPage", typeof(InitPage));
                Default.Register<TreePageModel>();
                nav.Configure("TreePage", typeof(TreePage));
                Default.Register<PdfPageModel>();
                nav.Configure("PdfPage", typeof(PdfPage));
                Default.Register<UxPageModel>();
                nav.Configure("UxPage", typeof(UxPage));

            }
        }
        public InitPageModel InitPage => ServiceLocator.Current.GetInstance<InitPageModel>();
        public TreePageModel TreePage => ServiceLocator.Current.GetInstance<TreePageModel>();
        public PdfPageModel PdfPage => ServiceLocator.Current.GetInstance<PdfPageModel>();
        public UxPageModel UxPage => ServiceLocator.Current.GetInstance<UxPageModel>();
    }
}
