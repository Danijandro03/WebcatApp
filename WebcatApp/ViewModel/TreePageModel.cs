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
            for (int x = 1; x < 4; x++)
            {
                CreaFath(x);
            }

            foreach (FatherModel fa in Fath)
            {
                fa.Sons = new List<FatherModel>();
                for (int y = 1; y < 3; y++)
                {
                    fa.Sons.Add(new FatherModel { Id = y, Name = "Son " + y.ToString()});
                }
                foreach (FatherModel f in fa.Sons)
                {
                    f.Sons = new List<FatherModel>();
                    for (int z = 1; z < 4; z++)
                    {
                        f.Sons.Add(new FatherModel { Id = z, Name = "SubSon " + z.ToString() });
                    }
                    
                }
                
            }

        }

        private void CreaFath(int x)
        {
            Fath.Add(new FatherModel { Id = x, Name = "Father " + x.ToString() });
        }
    }
}
