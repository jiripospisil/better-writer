using System.Windows;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace BetterWriter {
    public class Bootstrapper : UnityBootstrapper {
        protected override DependencyObject CreateShell() {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell() {
            base.InitializeShell();

            App.Current.MainWindow = this.Shell as Window;
            App.Current.MainWindow.Show();
        }

    }
}
