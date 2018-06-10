using iTextSharp.text.pdf;
using AgainSchoolService.BindingModel;
using AgainSchoolService.Interfaces;
using Microsoft.Office.Interop.Word;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using Unity;
using Unity.Attributes;
namespace AgainSchoolViewClient
{
    /// <summary>
    /// Логика взаимодействия для FormcClientOrders.xaml
    /// </summary>
    public partial class FormClientOrders : System.Windows.Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IReport service;

        public FormClientOrders(IReport service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.SelectedDate >= dateTimePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                reportViewer.LocalReport.ReportEmbeddedResource = "IvanAgencyViewClient.Report1.rdlc";
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
                                            "c " + Convert.ToDateTime(dateTimePickerFrom.SelectedDate).ToString("dd-MM") +
                                            " по " + Convert.ToDateTime(dateTimePickerTo.SelectedDate).ToString("dd-MM"));
                reportViewer.LocalReport.SetParameters(parameter);
               
              
                var dataSource = service.GetClientOrders(App.id, new ReportBindingModel
                {
                    DateFrom = dateTimePickerFrom.SelectedDate,
                    DateTo = dateTimePickerTo.SelectedDate
                });
                 ReportDataSource source = new ReportDataSource("DataSet", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);                                         
                reportViewer.RefreshReport();
                    
                    service.SaveClientOrders(App.id, new ReportBindingModel
                    {                       
                        DateFrom = dateTimePickerFrom.SelectedDate,
                        DateTo = dateTimePickerTo.SelectedDate
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }      
        private void buttonMail_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLetterPDF>();
            form.ShowDialog();
        }
        }
}