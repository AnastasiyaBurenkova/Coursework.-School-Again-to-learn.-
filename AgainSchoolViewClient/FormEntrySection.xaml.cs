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
using AgainSchoolService.ViewModel;
using AgainSchoolService.Interfaces;

namespace AgainSchoolViewClient
{
    /// <summary>
    /// Логика взаимодействия для FormEntrySection.xaml
    /// </summary>
    public partial class FormEntrySection : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public EntrySectionViewModel Model { set { model = value; } get { return model; } }

        private readonly ISection service;

        private EntrySectionViewModel model;

        public FormEntrySection(ISection service)
        {
            InitializeComponent();
            Loaded += FormEntrySection_Load;
            comboBoxComponent.SelectionChanged += comboBoxComponent_SelectedIndexChanged;

            comboBoxComponent.SelectionChanged += new SelectionChangedEventHandler(comboBoxComponent_SelectedIndexChanged);
            this.service = service;
        }

        private void FormEntrySection_Load(object sender, EventArgs e)
        {
            List<SectionViewModel> list = service.GetList();
            try
            {
                if (list != null)
                {
                    comboBoxComponent.DisplayMemberPath = "SectionName";
                    comboBoxComponent.SelectedValuePath = "Id";
                    comboBoxComponent.ItemsSource = list;
                    comboBoxComponent.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (model != null)
            {
                comboBoxComponent.IsEnabled = false;
                foreach (SectionViewModel item in list)
                {
                    if (item.SectionName == model.SectionName)
                    {
                        comboBoxComponent.SelectedItem = item;
                    }
                }
            }
        }

        private void CalcSum()
        {
            try
            {
                int id = ((SectionViewModel)comboBoxComponent.SelectedItem).Id;
                SectionViewModel product = service.GetElement(id);
                textBoxCount.Text = product.PriceSection.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void comboBoxComponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (comboBoxComponent.SelectedItem == null)
            {
                MessageBox.Show("Выберите кружок", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (textBoxCount.Text == null)
            {
                MessageBox.Show("Укажите цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new EntrySectionViewModel
                    {
                        SectionId = Convert.ToInt32(comboBoxComponent.SelectedValue),
                        SectionName = comboBoxComponent.Text,
                        SectionPrice = Convert.ToDecimal(textBoxCount.Text)
                    };
                }
                MessageBox.Show("Сохранение прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}