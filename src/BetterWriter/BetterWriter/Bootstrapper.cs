using System.Windows;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using BetterWriter.Views;

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

        protected override void ConfigureModuleCatalog() {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = this.ModuleCatalog as ModuleCatalog;

            moduleCatalog.AddModule(new ModuleInfo() {
                ModuleName = "EditorModule",
                ModuleType = "BetterWriter.EditorModule.EditorModule, BetterWriter.EditorModule, Version=1.0.0.0, Culture=neutral"
            });
        }

    }
}
