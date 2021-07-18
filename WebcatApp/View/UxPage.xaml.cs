using WebcatApp.ViewModel;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WebcatApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UxPage : Page
    {
        public UxPage()
        {
            this.InitializeComponent();
        }
        UxPageModel Vm => (UxPageModel)DataContext;

        private void ImageGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
