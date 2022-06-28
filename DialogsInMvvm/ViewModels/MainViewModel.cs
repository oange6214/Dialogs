using DialogsInMvvm.Bases;
using DialogsInMvvm.Services;

namespace DialogsInMvvm.ViewModels
{
    public class MainViewModel
    {

        #region Fields

        IDialogService _dialogService = new DialogService();

        #endregion


        #region Commands

        /// <summary>
        /// Property Lambda Method Command
        /// </summary>
        private RelayCommand? _showDialog;
        public RelayCommand ShowDialog => _showDialog ?? (_showDialog = new RelayCommand(ExecuteShowDialog));

        private void ExecuteShowDialog()
        {
            _dialogService.ShowDialog();
        }

        /// <summary>
        /// Property Method Command
        /// </summary>
        public RelayCommand ShowDialogParameter
        {
            get
            {
                return new RelayCommand(ExecuteShowParameterDialog);
            }
        }
        private void ExecuteShowParameterDialog() 
        {
            _dialogService.ShowDialog("Notification");
        }

        /// <summary>
        /// Property Anonymous Command
        /// </summary>
        public RelayCommand ShowDialogParameterAnonymous
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _dialogService.ShowDialog("Notification", result =>
                    {
                        var test = result;
                    });
                });
            }
        }

        /// <summary>
        /// Property Anonymous Command Base on Register
        /// </summary>
        public RelayCommand ShowDialogParameterAnonymousRegister
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _dialogService.ShowDialog<NotificationViewModel>(result =>
                    {
                        var test = result;
                    });
                });
            }
        }

        /// <summary>
        /// Property Anonymous Command Base on Register，綁定 ViewModel
        /// </summary>
        public RelayCommand ShowDialogParameterAnonymousRegisterVMType
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _dialogService.ShowDialogVMType<NotificationViewModel>(result =>
                    {
                        var test = result;
                    });
                });
            }
        }

        #endregion

    }
}
