using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcatApp.Model;
using WebcatApp.ViewModel.Base;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace WebcatApp.ViewModel
{

    public class UxPageModel : BasePageModel

    {
        private List<string> _CaroList;
        public List<string> CaroList { get => _CaroList; set => Set(ref _CaroList, value);}
        private Uri uxImage;
        public Uri UxImage { get => uxImage; set => Set(ref uxImage, value); }
        public UxPageModel(INavigationService navigationService) : base(navigationService)
        {
            LoadImage();
        }

        void LoadImage()
        {
            CaroList = new List<string>()
            {
                "ms-appx:///Assets/Samples/Cocinella/1.jpg",
                "ms-appx:///Assets/Samples/Cocinella/2.jpg",
                "ms-appx:///Assets/Samples/Cocinella/3.jpg",
                "ms-appx:///Assets/Samples/Cocinella/4.jpg",
            };
        }
    }
   
}
