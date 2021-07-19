using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcatApp.View;
using WebcatApp.ViewModel.Base;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WebcatApp.ViewModel
{
    public class InitPageModel: BasePageModel
    {
        private Frame frame;
        public Frame Frame { get { return frame; } set { frame = value; RaisePropertyChanged(); } }
        public InitPageModel(INavigationService navigationService) : base(navigationService)
        {
         
        }
        public void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender,
                                           Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var names = args.InvokedItemContainer;
            if (names.Tag.ToString() == "Tree")
            {
                Frame.Navigate(typeof(TreePage), null);
            }
            else if (names.Tag.ToString() == "Pdf")
            {
                Frame.Navigate(typeof(PdfPage), null);
            }
            else if (names.Tag.ToString() == "Ux")
            {
                Frame.Navigate(typeof(UxPage), null);
            }


        }
        public void FrameLoaded(object sender, RoutedEventArgs e)
        {
            Frame = (Frame)sender;
          
        }
      
    }
}
