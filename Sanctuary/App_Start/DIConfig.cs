using IBusinessLayer;
using BusinessLayer;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.DataAccessLayer.ServiceRepositry;
using Sanctuary.DataAccessLayer.DbContext;
using Unity;
using Unity.AspNet.WebApi;
using System.Web.Http;

namespace Sanctuary.App_Start
{
    /// <summary>
    /// dependency injection configuration file
    /// </summary>
    public static class DIConfig
    {
        /// <summary>
        /// register the components for dependency resolving
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<ILocationManager, LocationManager>();
            container.RegisterType<IAssetsManager, AssetsManager>();
            container.RegisterType<IBookingManager, BookingManager>();
            container.RegisterType<IBookingService, BookingService>();
            container.RegisterType<IAssetsService, AssetsService>();
            container.RegisterType<ILocationService, LocationService>();



            //container.RegisterType<IBookingService, BookingService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}