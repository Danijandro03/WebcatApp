using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Windows.Input;
using WebcatApp.ViewModel.Base;
using Windows.Data.Pdf;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace WebcatApp.ViewModel
{
    public class PdfPageModel : BasePageModel
    {
        
        private ObservableCollection<BitmapImage> pdfPages = new ObservableCollection<BitmapImage>();
        public ObservableCollection<BitmapImage> PdfPages { get { return pdfPages; } set { pdfPages = value; RaisePropertyChanged(); } }
        private string pdf;
        public string Pdf { get { return pdf; } set { pdf = value; RaisePropertyChanged(); } }
        //private string texto;
        //public string Texto { get { return texto; } set { texto = value; RaisePropertyChanged(); } }
        private ICommand _DownloadPDFFile;
        public ICommand DownloadPDFFile => _DownloadPDFFile ?? (_DownloadPDFFile = new RelayCommand(Metod));

        public PdfPageModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public async void Metod()
        {

            HttpClient client = new HttpClient();
            var stream = await client.GetStreamAsync("https://gotocon.com/dl/goto-aar-2014/slides/JamesMontemagno_XamarinFormsNativeIOSAndroidAndWindowsPhoneAppsFromONECCodebase.pdf");
            var memStream = new MemoryStream();
            await stream.CopyToAsync(memStream);
            memStream.Position = 0;
            PdfDocument doc = await PdfDocument.LoadFromStreamAsync(memStream.AsRandomAccessStream());
            Load(doc);
               
        }

        private async void Load(PdfDocument doc)
        {

            PdfPages.Clear();

            for (uint i = 0; i < doc.PageCount; i++)
            {
                BitmapImage image = new BitmapImage();

                var page = doc.GetPage(i);

                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await page.RenderToStreamAsync(stream);
                    await image.SetSourceAsync(stream);
                }

                PdfPages.Add(image);
            }

        }

    }
    
}