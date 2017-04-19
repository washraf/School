using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infrastructure.Utils.MVC.MEF
{
    //public static class MefMvcConfig
    //{

    //    public static void RegisterSolver()
    //    {
    //        //var catalog = new AggregateCatalog();
    //        //catalog.Catalogs.Add(new DirectoryCatalog(@".\bin", "*.dll")); //Extensions
    //        //catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
    //        //catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath));
    //        var catalog = new AggregateCatalog();

    //        catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin")));

    //        //foreach (var plugin in pluginFolders)
    //        //{
    //        //    var directoryCatalog = new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules", plugin));
    //        //    catalog.Catalogs.Add(directoryCatalog);

    //        //}
    //        var composition = new CompositionContainer(catalog, true);
    //        IControllerFactory mefControllerFactory = new MefControllerFactory(composition); //Get Factory to be used
    //        ControllerBuilder.Current.SetControllerFactory(mefControllerFactory); //Set Factory to be used
    //    }

    //}
    public class MefControllerFactory : DefaultControllerFactory
    {
        private readonly CompositionContainer _container; // This container will work like an IOC container
        public MefControllerFactory(CompositionContainer container)
        {
            _container = container;

        }

        //public override IController CreateController(RequestContext requestContext, string controllerName)
        //{
        //    return base.CreateController(requestContext, controllerName);
        //}

        //protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        //{

        //    if (controllerType != null)
        //    {
        //        ImportDefinition importDefinition = new ImportDefinition(i => i.ContractName.Equals(controllerType.FullName), controllerType.FullName, ImportCardinality.ZeroOrMore, false, false);
        //        AtomicComposition atomicComposition = new AtomicComposition();
        //        IEnumerable<Export> extensions = null;

        //        bool exportDiscovery = _container.TryGetExports(importDefinition, atomicComposition, out extensions);

        //        if (extensions != null && extensions.Count<Export>() > 0)
        //        {
        //            return extensions.First().Value as IController;
        //        }
        //    }

        //    return null;
        //    //Lazy<object, object> export = _container.GetExports(controllerType, null, null).FirstOrDefault();

        //    ////here if the controller object is not found (resulted as null) we can go ahead and get the default controller.
        //    ////This means that in order to get the Controller we have to Export it first which will be shown later in this post
        //    //return null == export ? base.GetControllerInstance(requestContext, controllerType) : (IController)export.Value;
        //}
        public override void ReleaseController(IController controller)
        {
            //this is were the controller gets disposed
            ((IDisposable)controller).Dispose();
        }
    }
}