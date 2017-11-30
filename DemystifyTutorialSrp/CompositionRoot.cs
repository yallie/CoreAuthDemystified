using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DryIoc;

namespace DemystifyTutorialSrp
{
    public class CompositionRoot
    {
        // If you need the whole container then change parameter type from IRegistrator to IContainer
        public CompositionRoot(IRegistrator r)
        {
            // TODO: register services here
            ////r.Register<ISingletonService, SingletonService>(Reuse.Singleton);
            ////r.Register<ITransientService, TransientService>(Reuse.Transient);
            ////r.Register<IScopedService, ScopedService>(Reuse.InCurrentScope);

            ////var assemblies = new[] { typeof(ExportedService).GetAssembly() };
            ////r.RegisterExports(assemblies);
        }
    }
}
