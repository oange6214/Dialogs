using DialogsInMvvm.Services;
using DialogsInMvvm.ViewModels;
using System.Windows;

namespace DialogsInMvvm.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DialogService.RegisterDialog<Notification, NotificationViewModel>();
        }
    }
}
