using Microsoft.Practices.Prism.Events;
using BetterWriter.Common.Events;
using BetterWriter.Common.BaseClasses;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace BetterWriter.ViewModels {
    public class ShellViewModel : ViewModelBase {

        #region Fields

        private const string UNTITLED = "Untitled";
        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Properties

        private string _windowTitle;
        public string WindowTitle {
            get {
                if(_windowTitle == null) {
                    return GetWindowTitle(UNTITLED);
                }
                return _windowTitle;
            }
            set {
                if(_windowTitle != value) {
                    _windowTitle = value;
                    RaisePropertyChanged("WindowTitle");
                }
            }
        }

        #endregion

        #region Constructor

        public ShellViewModel(IEventAggregator eventAggregator) {
            this.eventAggregator = eventAggregator;

            var evt = this.eventAggregator.GetEvent<OpenedFileChangedEvent>();
            evt.Subscribe(OnOpenedFileChanged);
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

        private ICommand _controlSShortcutCommand;

        public ICommand ControlSShortcutCommand {
            get {
                if(_controlSShortcutCommand == null) {
                    _controlSShortcutCommand = new DelegateCommand(PublishControlSShortcut);
                }
                return _controlSShortcutCommand;
            }
        }

        private void PublishControlSShortcut() {
            var evt = this.eventAggregator.GetEvent<ShortcutPressedEvent>();
            evt.Publish(Shortcut.CTRL_S);
        }

        #endregion

        #region Methods

        private void OnOpenedFileChanged(string fileName) {
            WindowTitle = GetWindowTitle(fileName);
        }

        private string GetWindowTitle(string str) {
            return string.Format("{0} - {1}", Info.GetName(), str);
        }

        #endregion
    }
}
