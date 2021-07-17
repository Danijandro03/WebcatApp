﻿using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebcatApp.ViewModel.Base;
using Windows.Data.Pdf;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace WebcatApp.ViewModel
{
    public class PdfPageModel : BasePageModel
    {
        private Collection<BitmapImage> pdfPages = new ObservableCollection<BitmapImage>();
        public Collection<BitmapImage> PdfPages { get { return pdfPages; } set { pdfPages = value; RaisePropertyChanged(); } }
        private string pdf;
        public string Pdf { get { return pdf; } set { pdf = value; RaisePropertyChanged(); } }
        //private string texto;
        //public string Texto { get { return texto; } set { texto = value; RaisePropertyChanged(); } }
        private ICommand _returnText;
        public ICommand ReturnText => _returnText ?? (_returnText = new RelayCommand(metod));

        public PdfPageModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public async void metod()
        {

            try
            {
                Uri source = new Uri("https://gotocon.com/dl/goto-aar-2014/slides/JamesMontemagno_XamarinFormsNativeIOSAndroidAndWindowsPhoneAppsFromONECCodebase.pdf");
                StorageFile destinationFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("Architecting Mobile Apps.pdf", CreationCollisionOption.ReplaceExisting);
                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(source, destinationFile);
                var Pdf = await download.StartAsync();
                Debug.WriteLine("Download successfull");
                string pth = ApplicationData.Current.LocalFolder.Path;
                StorageFile f = await StorageFile.GetFileFromPathAsync(pth + "Architecting Mobile Apps.pdf");
                PdfDocument doc = await PdfDocument.LoadFromFileAsync(f);
                Load(doc);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Download error. Exception: " + ex);
            }
        }

        async void Load(PdfDocument doc)
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