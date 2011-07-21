using Microsoft.Practices.Prism.Events;
using BetterWriter.Common.Events;
using BetterWriter.Common.BaseClasses;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace BetterWriter.ViewModels {
    public class ShellViewModel : ViewModelBase {

        #region Fields

        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Properties

        private string _fileName;
        public string FileName {
            get {
                if(_fileName == null) {
                    return "Untitled";
                }
                return _fileName;
            }
            set {
                if(_fileName != value) {
                    _fileName = value;
                    RaisePropertyChanged("FileName");
                }
            }
        }

        #endregion

        #region Constructor

        public ShellViewModel(IEventAggregator eventAggregator) {
            this.eventAggregator = eventAggregator;

            var evt = this.eventAggregator.GetEvent<NewFileOpenedEvent>();
            evt.Subscribe(OnNewFileOpened);
        }

        #endregion

        #region Commands with actions

        private ICommand _controlOShortcutCommand;

        public ICommand ControlOShortcutCommand {
            get {
                if(_controlOShortcutCommand == null) {
                    _controlOShortcutCommand = new DelegateCommand(PublishControlOShortcut);
                }
                return _controlOShortcutCommand;
            }
        }

        private void PublishControlOShortcut() {
            var evt = this.eventAggregator.GetEvent<ShortcutPressedEvent>();
            evt.Publish(Shortcut.CTRL_O);
        }

        #endregion

        #region Methods

        private void OnNewFileOpened(string fileName) {
            FileName = fileName;
        }

        #endregion
    }
}
