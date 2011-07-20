using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace BetterWriter.EditorModule {
    public class EditorModule : IModule {

        private readonly IUnityContainer container;

        public EditorModule(IUnityContainer container) {
            this.container = container;
        }

        public void Initialize() {
            
        }
    }
}
