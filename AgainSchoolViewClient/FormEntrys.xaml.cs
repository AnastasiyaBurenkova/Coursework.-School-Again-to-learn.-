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
using System.Windows.Shapes;
using Unity.Attributes;
using Unity;
using AgainSchoolService.Interfaces;
using AgainSchoolService.ViewModel;

namespace AgainSchoolViewClient
{
    /// <summary>
    /// Логика взаимодействия для FormEntrys.xaml
    /// </summary>
    public partial class FormEntrys : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IEntry service;

        public FormEntrys(IEntry service)
        {
            InitializeComponent();
            Loaded += FormEntrys_Load;
            this.service = service;
        }

        private void FormEntrys_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<EntryViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridViewProducts.ItemsSource = list;
                    dataGridViewProducts.Columns[0].Visibility = Visibility.Hidden;
                    dataGridViewProducts.Columns[1].Width = DataGridLength.Auto;
                    dataGridViewProducts.Columns[3].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEntry>();
            if (form.ShowDialog() == true)
                LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedItem != null)
            {
                var form = Container.Resolve<FormEntry>();
                form.Id = ((EntryViewModel)dataGridViewProducts.SelectedItem).Id;
                if (form.ShowDialog() == true)
                    LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    int id = ((EntryViewModel)dataGridViewProducts.SelectedItem).Id;
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
