using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgainSchoolService;
using AgainSchoolService.ImplementationBD;
using AgainSchoolService.Interfaces;
using Unity;
using Unity.Lifetime;

namespace AgainSchoolViewAdmin
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormLoginAdmin>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AgSchoolDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClient, ClientService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISection, SectionService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAdmin, AdminService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntry, EntryService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMain, MainService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReport, ReportService>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
