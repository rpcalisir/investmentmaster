using InvestmentMaster.DataAccess.Utilities;
using InvestmentMaster.WPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InvestmentMaster.WPFUI.ViewModels.Concrete
{
    public class MainViewModel: BaseViewModel
    {
        /// <summary>
        /// Controls the navigation between View Models.
        /// </summary>
        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            FundTableDataCreatorUtilities.CreateFundTableData();

            UpdateViewCommand = new UpdateViewCommand(this);
        }


    }
}
