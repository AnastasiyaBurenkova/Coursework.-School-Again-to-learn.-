using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity.Attributes;
using Unity;
using AgainSchoolService.Interfaces;
using AgainSchoolService.ViewModel;
using AgainSchoolService.BindingModel;

namespace AgainSchoolViewAdmin
{
    public partial class FormSection : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ISection service;

        private int? id;

        public FormSection(ISection service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormComponent_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SectionViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.SectionName;
                        textBoxPriceSection.Text = view.PriceSection.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new SectionBindingModel
                    {
                        Id = id.Value,
                        SectionName = textBoxName.Text,
                        PriceSection = Convert.ToInt32(textBoxPriceSection.Text)
                    });
                }
                else
                {
                    service.AddElement(new SectionBindingModel
                    {
                        SectionName = textBoxName.Text,
                        PriceSection = Convert.ToInt32(textBoxPriceSection.Text)
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

