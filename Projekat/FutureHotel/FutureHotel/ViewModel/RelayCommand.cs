using System;
using System.Windows.Input;

namespace FutureHotel.ViewModel
{
    internal class RelayCommand<T> : ICommand
    {
        private object dOpdajJelo;
        private Action<object> _executeMethod;
        private Func<object, bool> _canExecuteMethod;

        public RelayCommand(Action<Object> executeMethod)
            : this(executeMethod, null)
        {
        }

        public RelayCommand(object dOpdajJelo)
        {
            this.dOpdajJelo = dOpdajJelo;
        }

        public RelayCommand(Action<object> dodajJelo, Func<object, bool> moze)
        {
            this._executeMethod = dodajJelo;
            this._canExecuteMethod = moze;
        }
        //#endregion Constructors

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter)
        {
            try
            {
                return CanExecute((T)parameter);
            }
            catch { return false; }
        }
        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        public bool CanExecute(T parameter)
        {
            return ((_canExecuteMethod == null) || _canExecuteMethod(parameter));
        }

        public void Execute(T parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Protected Methods
    }
}
