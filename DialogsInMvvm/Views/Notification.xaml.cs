using System.Windows;
using System.Windows.Controls;

namespace DialogsInMvvm.Views
{
    public partial class Notification : UserControl
    {
        public Notification()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Parent as Window).DialogResult = true;
        }
    }
}
