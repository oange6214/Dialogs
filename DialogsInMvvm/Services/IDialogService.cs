using System;

namespace DialogsInMvvm.Services
{
    public interface IDialogService
    {
        void ShowDialog();
        void ShowDialog(string message);
        void ShowDialog(string message, Action<string> callback);
        void ShowDialog<ViewModel>(Action<string> callback);
        void ShowDialogVMType<ViewModel>(Action<string> callback);
    }
}
