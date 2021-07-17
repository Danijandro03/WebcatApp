using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebcatApp.ViewModel.Base;
using Windows.Storage;

namespace WebcatApp.ViewModel
{
    public class PdfPageModel : BasePageModel
    {
        private string texto1;
        public string texto { get { return texto1; } set { texto1 = value; RaisePropertyChanged(); } }
        private ICommand _returnText;
        public ICommand ReturnText => _returnText ?? (_returnText = new RelayCommand(metod));

        public PdfPageModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public void metod()
        {
            texto = "You fired the custom command";
        }
    }
}

// AsStreamForRead().CopyTo(dst); } catch (Exception ex) {}
// Create sample file; replace if exists. StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
// StorageFile sampleFile = await storageFolder.CreateFileAsync("Prajesh.pdf", CreationCollisionOption.ReplaceExisting);
//var sampleFile = await DownloadsFolder.CreateFileAsync("ManualFile.pdf", CreationCollisionOption.ReplaceExisting); var
//cli = new HttpClient(); var str = await cli.GetStreamAsync(uriBing); var dst = await sampleFile.OpenStreamForWriteAsync();
//await str.AsInputStream().AsStreamForRead().CopyToAsync(dst);// AsStreamForRead().CopyTo(dst); } catch (Exception ex) {}