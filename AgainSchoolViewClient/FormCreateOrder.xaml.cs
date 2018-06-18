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

namespace AgainSchoolViewClient
{
    /// <summary>
    /// Логика взаимодействия для FormCreateOrder.xaml
    /// </summary>
    public partial class FormCreateOrder : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IClient serviceC;

        private readonly IEntry serviceT;

        private readonly IMain serviceM;


        public FormCreateOrder(IClient serviceC, IEntry serviceT, IMain serviceM)
        {
            InitializeComponent();
            Loaded += FormCreateOrder_Load;
            comboBoxProduct.SelectionChanged += comboBoxProduct_SelectedIndexChanged;
            comboBoxProduct.SelectionChanged += new SelectionChangedEventHandler(comboBoxProduct_SelectedIndexChanged);
            this.serviceC = serviceC;
            this.serviceT = serviceT;
            this.serviceM = serviceM;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                ClientViewModel Client = serviceC.GetElement(App.id);
                if (Client != null)
                {

                    textBoxClient.Text = Client.ClientFIO;
                    textBoxClient.IsEnabled=false;
              
                }
                List<EntryViewModel> listProduct = serviceT.GetList();
                if (listProduct != null)
                {
                    comboBoxProduct.DisplayMemberPath = "EntryName";
                    comboBoxProduct.SelectedValuePath = "Id";
                    comboBoxProduct.ItemsSource = listProduct;
                    comboBoxProduct.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxProduct.SelectedItem != null && !string.IsNullOrEmpty(textBoxHour.Text))
            {
                try
                {
                    int id = ((EntryViewModel)comboBoxProduct.SelectedItem).Id;
                    EntryViewModel product = serviceT.GetElement(id);
                    decimal Hour = Convert.ToDecimal(textBoxHour.Text);
                    textBoxSum.Text = (product.Price * Hour).ToString();
                 
            
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void textBoxHour_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxHour.Text))
            {
                MessageBox.Show("Заполните поле Часы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (textBoxClient.Text == null)
            {
                MessageBox.Show("Выберите себя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxProduct.SelectedItem == null)
            {
                MessageBox.Show("Выберите путешествие", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                serviceM.CreateOrder(new OrderBindingModel
                {
                    ClientId = App.id,
                    EntryId = ((EntryViewModel)comboBoxProduct.SelectedItem).Id,
                    Hour = Convert.ToInt32(textBoxHour.Text),
                    Summa = Convert.ToDecimal(textBoxSum.Text),
                    Status = "Не_оплачен"
                });
                MessageBox.Show("Сохранение прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = false;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}