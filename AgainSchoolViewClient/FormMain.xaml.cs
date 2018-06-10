using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity.Attributes;
using Unity;
using AgainSchoolService.Interfaces;
using AgainSchoolService.ViewModel;
using AgainSchoolService.BindingModel;
using Microsoft.Win32;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace AgainSchoolViewClient
{

    public partial class FormMain : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
      
        private readonly IMain service;

        private readonly IReport reportService;

        public int Id { set { id = value; } }

        private int? id;

        public FormMain(IMain service, IReport reportService)
        {
            InitializeComponent();
            this.service = service;
            this.reportService = reportService;
       
        }

        private void LoadData()
        {
            try
            {
                List<OrderViewModel> list = service.GetList(App.id);
                if (list != null)
                {
                    dataGridViewMain.ItemsSource = list;
                    dataGridViewMain.Columns[0].Visibility = Visibility.Hidden;
                    dataGridViewMain.Columns[1].Visibility = Visibility.Hidden;                 
                    dataGridViewMain.Columns[3].Visibility = Visibility.Hidden;
                    dataGridViewMain.Columns[6].Visibility = Visibility.Hidden;
                    dataGridViewMain.Columns[5].Visibility = Visibility.Hidden;
                    dataGridViewMain.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
     
        private void кружкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEntrys>();
            form.ShowDialog();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var form = Container.Resolve<FormCreateOrder>();
                form.ShowDialog();
                LoadData();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());

            }
        }
      
        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedItem != null)
            {                
                var form = Container.Resolve<FormPayment>();
                form.Id = ((OrderViewModel)dataGridViewMain.SelectedItem).Id;
                form.ShowDialog();
                LoadData();
            }
        }       
        private void buttonRef_Click(object sender, EventArgs e)
        {
           
                LoadData();           
        }

        private void списокКружковToolStripMenuItem_Click(object sender, EventArgs e)
        {           
                try
                {
                    reportService.SaveSectionPriceW(new ReportBindingModel
                    {});
                    reportService.SaveSectionPriceE(new ReportBindingModel
                    {});

                var form = Container.Resolve<FormLetter>();
                form.ShowDialog();
            }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
        }        
        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClientOrders>();
            form.ShowDialog();
        }

        private void buttonBonusFine_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedItem != null)
            {
                OrderViewModel view = service.GetElement(((OrderViewModel)dataGridViewMain.SelectedItem).Id);
                if (view != null)
                {
                    decimal x = view.Summa;
                    decimal y = view.BonusFine;
                   service.UpdateOrder(new OrderBindingModel
                {
                    Id = ((OrderViewModel)dataGridViewMain.SelectedItem).Id,
                    Summa = x - y                   
                });
                }
                
                LoadData();
            }
        }
    }
}

