using System.Windows.Input;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;

namespace BetterWriter.Common.BaseClasses {
    public class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string property) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        protected void RaiseCommandCanChanged(ICommand command) {
            DelegateCommand delegateCommand = command as DelegateCommand;
            if(delegateCommand != null) {
                delegateCommand.RaiseCanExecuteChanged();
            }
        }
    }
}
