using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebcatApp.View;
using WebcatApp.ViewModel.Base;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WebcatApp.ViewModel
{
    public class InitPageModel : BasePageModel
    {
        private string _actpa1;
        public string Actpa { get => _actpa1; set => Set(ref _actpa1, value); } 
        private Frame frame;
        public Frame Frame { get { return frame; } set { frame = value; RaisePropertyChanged(); } }

        private void BackMetod(Microsoft.UI.Xaml.Controls.NavigationView sender,
                                           Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            throw new NotImplementedException();
        }
        private List<string> _bck;
        public List<string> Bck { get => _bck; set => Set(ref _bck, value); }

        public InitPageModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public void NavView_BackItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender,
                                           Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }

        private bool TryGoBack()
        {
            if (!Frame.CanGoBack)
            {
                return false;
            }
            // Don't go back if the nav pane is overlayed.

            Frame.GoBack();
            return true;
        }

        public void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender,
                                           Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            Bck = new List<string>();

            if (sender is null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            var names = args.InvokedItemContainer;
            if (names.Tag.ToString() == "TreeView")
            {
                _ = Frame.Navigate(typeof(TreePage), null);
                Actpa = "    " + (string)names.Tag;
            }
            else if (names.Tag.ToString() == "PDF Downloader")
            {
                _ = Frame.Navigate(typeof(PdfPage), null);
                Actpa = "    " + (string)names.Tag;

            }
            else if (names.Tag.ToString() == "UX Design")
            {
                _ = Frame.Navigate(typeof(UxPage), null);
                Actpa = "    "+(string)names.Tag;
            }

            Bck.Add(names.Tag.ToString());
        }



        public void FrameLoaded(object sender, RoutedEventArgs e)
        {
            Frame = (Frame)sender;
            Bck = new List<string>();
            Actpa = "    Technical Test WebCat";
        }



    }
}
