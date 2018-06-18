using AgainSchoolService.Interfaces;
using AgainSchoolService.ViewModel;
using AgainSchoolViewClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace AgainSchoolViewAdmin
{
    public partial class FormClientOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IClient serviceC;
        public FormClientOrder(IClient serviceC)
        {
            InitializeComponent();
            this.serviceC = serviceC;
        }

        private void FormClientOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<ClientViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxClient.DisplayMember = "ClientFIO";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listC;
                    comboBoxClient.SelectedItem = null;
                }
                int id = Convert.ToInt32(comboBoxClient.SelectedValue);
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGetOrders_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxClient.Text))
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<ClientViewModel> list = serviceC.GetList();

            for (int i = 0; i < list.Count; i++)
            {
                if (comboBoxClient.SelectedValue != null)
                {
                    App.id = list[i].Id;
                    var form = Container.Resolve<FormOrders>();
                    form.ShowDialog();

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
