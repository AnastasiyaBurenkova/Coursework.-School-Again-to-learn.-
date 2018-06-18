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
using AgainSchoolService.BindingModel;
using System.Windows.Forms;
using System.Data;

namespace AgainSchoolViewClient
{
    /// <summary>
    /// Логика взаимодействия для FormEntry.xaml
    /// </summary>
    public partial class FormEntry : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IEntry service;

        private int? id;

        private List<EntrySectionViewModel> EntrySections;

        public FormEntry(IEntry service)
        {
            InitializeComponent();
            Loaded += FormEntry_Load;
            this.service = service;
        }

        private void FormEntry_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    EntryViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.EntryName;
                        textBoxPrice.Text = view.Price.ToString();
                        EntrySections = view.EntrySections;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.InnerException.Message);
                    System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                EntrySections = new List<EntrySectionViewModel>();
        }

        private void LoadData()
        {
            try
            {
                if (EntrySections != null)
                {
                    dataGridViewProduct.ItemsSource = null;
                    dataGridViewProduct.ItemsSource = EntrySections;
                    dataGridViewProduct.Columns[0].Visibility = Visibility.Hidden;
                    dataGridViewProduct.Columns[1].Visibility = Visibility.Hidden;
                    dataGridViewProduct.Columns[2].Visibility = Visibility.Hidden;
                    dataGridViewProduct.Columns[3].Width = DataGridLength.Auto;                 
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.InnerException.Message);
                System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
              
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEntrySection>();
            if (form.ShowDialog() == true)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                        form.Model.EntryId = id.Value;
                    EntrySections.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedItem != null)
            {
                var form = Container.Resolve<FormEntrySection>();
                form.Model = EntrySections[dataGridViewProduct.SelectedIndex];
                if (form.ShowDialog() == true)
                {
                    EntrySections[dataGridViewProduct.SelectedIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedItem != null)
            {
                if (System.Windows.MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        EntrySections.RemoveAt(dataGridViewProduct.SelectedIndex);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
            decimal sum = 0;
            for (int i = 0; i < EntrySections.Count; i++)
            {               
                EntrySectionViewModel product = EntrySections[i];
                sum += Convert.ToDecimal(product.SectionPrice);
            }
            textBoxPrice.Text = sum.ToString();

        }
       
            private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                System.Windows.MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (EntrySections == null || EntrySections.Count == 0)
            {
                System.Windows.MessageBox.Show("Выберите кружки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                System.Windows.MessageBox.Show("Обновите, чтоб увидеть сумму", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                List<EntrySectionBindingModel> productComponentBM = new List<EntrySectionBindingModel>();
                for (int i = 0; i < EntrySections.Count; ++i)
                {
                    productComponentBM.Add(new EntrySectionBindingModel
                    {
                        Id = EntrySections[i].Id,
                        EntryId = EntrySections[i].EntryId,
                        SectionId = EntrySections[i].SectionId,
                        SectionPrice = EntrySections[i].SectionPrice
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new EntryBindingModel
                    {
                        Id = id.Value,
                        EntryName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        EntrySections = productComponentBM
                    });
                }
                else
                {
                    service.AddElement(new EntryBindingModel
                    {
                        EntryName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        EntrySections = productComponentBM
                    });
                }
                System.Windows.MessageBox.Show("Сохранение прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
