using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace WebcatApp.Model
{
    public class FilePdf
    {
        public string Name
        {
            get;
            set;
        }

        public List<BitmapImage> PdfPages;
    }
}
