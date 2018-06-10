using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AgainSchoolService;
using AgainSchoolService.ImplementationBD;
using AgainSchoolService.Interfaces;
using Unity;
using Unity.Lifetime;

namespace AgainSchoolViewClient
{
    public partial class App : Application
    {
        public static int id;


        /*App()
                   {
                       InitializeComponent();
                     */

        [STAThread]
        public static void Main()
        {



            var container = BuildUnityContainer();

            var application = new App();
            //application.InitializeComponent();
            application.Run(container.Resolve<FormLogin>());
            //App app = new App();
            //app.Run(container.Resolve<FormMain>());

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