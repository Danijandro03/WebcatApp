using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcatApp.Model;
using WebcatApp.ViewModel.Base;

namespace WebcatApp.ViewModel
{
    public class TreePageModel : BasePageModel
    {
        private List<FatherModel> _fath;
        public List<FatherModel> Fath { get { return _fath; } set { _fath = value; RaisePropertyChanged(); } }
        public TreePageModel(INavigationService navigationService) : base(navigationService)
        {
            LoadFather();
            FatherLoad();
        }

        private void LoadFather()
        {
            Fath = new List<FatherModel>();
        }

        private void FatherLoad()
        {
            for (int x = 0; x < 2; x++)
            {
                CreaFath(x);
            }

        }

        private void CreaFath(int x)
        {
            Fath.Add(new FatherModel { Id = x, Name = "Nombre" + x.ToString() });
        }
    }
}
