using System;
using System.Reflection;
using log4net;
using log4net.Config;
using Shopping_Online.Services;

namespace Shopping_Online.Presentation
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main()
        {
            try
            {
                XmlConfigurator.Configure();

                Logger.Info("Main START");
                ServiceFactory serviceFactory = new ServiceFactory();
                IViewMainMenu viewMainMenu = new ViewMainMenu();
                IControllerMainMenu controllerMainMenu = new ControllerMainMenu(viewMainMenu, serviceFactory);
                controllerMainMenu.BeginSession();

            }
            catch (Exception exception)
            {
                Logger.Error($"An error occurred: {exception.Message}", exception);
            }

            Logger.Info("Main STOP");
        }
    }
}
