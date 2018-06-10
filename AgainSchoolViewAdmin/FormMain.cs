using AgainSchoolService.BindingModel;
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
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

       

        private readonly IMain service;

        

        public FormMain(IMain service)
        {
            InitializeComponent();
            this.service = service;

        }


        private void FormMain1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<OrderViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[6].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void турыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSections>();
            form.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClientOrder>();
            form.ShowDialog();
        }

        private void getOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormOrderPayment>();
            form.ShowDialog();
        }

        private void написатьКлиентуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMail>();
            form.ShowDialog();
        }

        private void buttonBonusFine_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormBonusFine>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.ShowDialog();
                LoadData();
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

       
    }
}