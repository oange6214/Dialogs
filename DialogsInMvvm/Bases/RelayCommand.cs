using System;
using System.Windows.Input;

namespace DialogsInMvvm.Bases
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (s, e) => { };
        private Action aciton;
        private Action<object> oneParamAction;

        public RelayCommand(Action action)
        {
            this.aciton = action;
        }

        public RelayCommand(Action<object> action)
        {
            oneParamAction = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            aciton?.Invoke();
            oneParamAction?.Invoke(parameter);
        }
    }

    public class RelayCommand<T> : ICommand
    {
        public event EventHandler? CanExecuteChanged = (s, e) => { };
        Action<T> action;

        public RelayCommand(Action<T> action)
        {
            this.action = action;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action?.Invoke((T)parameter);
        }
    }
}
