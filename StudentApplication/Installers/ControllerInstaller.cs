using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(
            Castle.Windsor.IWindsorContainer container, 
            Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            /**
             * instance is provided every time it is needed by IoC container.  
             * Caller is responsible to tell IoC container 
             * when instance is no longer needed (ReleaseController)
             * WindsorControllerFactory is responsible for resolving and 
             * releasing controller components
             */
            container.Register(Classes.FromThisAssembly()
                            .BasedOn<IController>()
                            .LifestyleTransient());
        }
    }
}