using AgainSchoolService.Interfaces;
using AgainSchoolService.ViewModel;
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
    public partial class FormLoginAdmin : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IAdmin service;

        public FormLoginAdmin(IAdmin service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<AdminViewModel> list = service.GetList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AdminFIO == textBoxLogin.Text && list[i].Password == textBoxPassword.Text)
                {
                    var form = Container.Resolve<FormMain>();
                    form.ShowDialog();
                }
            }
            textBoxLogin.Clear();
            textBoxPassword.Clear();
            return;
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRegistration>();
            form.ShowDialog();
        }
    }
}
