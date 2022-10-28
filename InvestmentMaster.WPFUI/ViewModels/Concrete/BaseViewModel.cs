using InvestmentMaster.Entities.Concrete;
using InvestmentMaster.WPFUI.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.WPFUI.ViewModels.Concrete
{
    public class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
