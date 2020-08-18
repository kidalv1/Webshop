[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Webshop.SL.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Webshop.SL.App_Start.NinjectWebCommon), "Stop")]

namespace Webshop.SL.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Webshop.BL;
    using Webshop.DAL;
    using Webshop.DAL.Entit;
    using Webshop.DAL.Repositories;
    using Webshop.DAL.UnitOfWork;
    using Webshop.Domain;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepository<Course>>().To<CourseRepo>();
            kernel.Bind<IRepository<InvoiceDetail>>().To<InvoiceDetailRepo>();
            kernel.Bind<IRepository<Invoice>>().To<InvoiceRepo>();
            kernel.Bind<IRepository<Product>>().To<ProductRepo>();
            kernel.Bind<IRepository<ProductPrice>>().To<ProductPriceRepo>();
            kernel.Bind<IRepository<Vat>>().To<VatRepo>();

            kernel.Bind<ILogic<CourseDTO>>().To<CourseLogic>();
            kernel.Bind<ILogic<InvoiceDTO>>().To<InvoiceLogic>();
            kernel.Bind<ILogic<InvoiceDetailDTO>>().To<InvoiceDetailLogic>();
            kernel.Bind<ILogic<ProductDTO>>().To<ProductLogic>();
            kernel.Bind<ILogic<ProductPriceDTO>>().To<ProductPriceLogic>();
            kernel.Bind<ILogic<VatDTO>>().To<VatLogic>();

            kernel.Bind<UnitOfWork>().To<UnitOfWork>();
            kernel.Bind<WebshopContext>().To<WebshopContext>();
        }        
    }
}