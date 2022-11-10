using HouseholdManager.GUI;
using Interfaces;
using log4net.Config;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Unity;

namespace HouseholdManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Config.RegisterEF();
            //Config.RegisterSQLite();

            //Chọn đường dẫn cho thư mục chứa file log
            log4net.GlobalContext.Properties["LogPath"] = Application.StartupPath;
            log4net.GlobalContext.Properties["DataProvider"] = Config.DataProvider;
            //Cấu hình đặt trong App.config
            XmlConfigurator.Configure();
            
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => MessageBox.Show((e.ExceptionObject as Exception).Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.ThreadException += (s, e) => MessageBox.Show(e.Exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fLogin());
        }
    }

    class Config
    {
        public static UnityContainer Container { get; } = new UnityContainer();

        public static string DataProvider { get; private set; }

        public static void RegisterEF()
        {
            Container.RegisterInstance<IAccountDAO>(Activator.CreateInstance(typeof(EntityDataAccess.AccountDAO), true) as EntityDataAccess.AccountDAO, InstanceLifetime.Singleton);
            Container.RegisterInstance<IDonateDAO>(Activator.CreateInstance(typeof(EntityDataAccess.DonateDAO), true) as EntityDataAccess.DonateDAO, InstanceLifetime.Singleton);
            Container.RegisterInstance<IFeeDAO>(Activator.CreateInstance(typeof(EntityDataAccess.FeeDAO), true) as EntityDataAccess.FeeDAO, InstanceLifetime.Singleton);
            Container.RegisterInstance<IHouseholdDAO>(Activator.CreateInstance(typeof(EntityDataAccess.HouseholdDAO), true) as EntityDataAccess.HouseholdDAO, InstanceLifetime.Singleton);
            Container.RegisterInstance<IPersonDAO>(Activator.CreateInstance(typeof(EntityDataAccess.PersonDAO), true) as EntityDataAccess.PersonDAO, InstanceLifetime.Singleton);
            DataProvider = "EF6-SqlServer";
        }

        public static void RegisterSQLite()
        {
            Container.RegisterFactory<IAccountDAO>(uc => Activator.CreateInstance(typeof(HouseholdManager.DAO.AccountDAO), true) as HouseholdManager.DAO.AccountDAO, FactoryLifetime.Singleton);
            Container.RegisterFactory<IDonateDAO>(uc => Activator.CreateInstance(typeof(HouseholdManager.DAO.DonateDAO), true) as HouseholdManager.DAO.DonateDAO, FactoryLifetime.Singleton);
            Container.RegisterFactory<IFeeDAO>(uc => Activator.CreateInstance(typeof(HouseholdManager.DAO.FeeDAO), true) as HouseholdManager.DAO.FeeDAO, FactoryLifetime.Singleton);
            Container.RegisterFactory<IHouseholdDAO>(uc => Activator.CreateInstance(typeof(HouseholdManager.DAO.HouseholdDAO), true) as HouseholdManager.DAO.HouseholdDAO, FactoryLifetime.Singleton);
            Container.RegisterFactory<IPersonDAO>(uc => Activator.CreateInstance(typeof(HouseholdManager.DAO.PersonDAO), true) as HouseholdManager.DAO.PersonDAO, FactoryLifetime.Singleton);
            DataProvider = "ADO.NET-SQLite";
        }
    }
}
