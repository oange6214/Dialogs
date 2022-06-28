using DialogsInMvvm.Bases;

namespace DialogsInMvvm.ViewModels
{
    public class NotificationViewModel
    {
        private string _message = "I'm Notification View Model TextBox";
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
