using AgainSchoolService.BindingModel;
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
    public partial class FormBonusFine : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMain service;

        public int Id { set { id = value; } }

        private int? id;

        public FormBonusFine(IMain service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormBonusFine_Load(object sender, EventArgs e)
        {
            try
            {
                if (id.HasValue)
                {

                    OrderViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxSumm.Text = view.Summa.ToString();
                       
                    }                 
                }
                else
                {
                    MessageBox.Show("Не указана заявка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBonusFine.Text))
            {
                MessageBox.Show("Введите бонус/штраф", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            if (!string.IsNullOrEmpty(textBoxBonusFine.Text))
            {
                try
                {                    
                    int bon = Convert.ToInt32(textBoxBonusFine.Text);
                    int summ = Decimal.ToInt32(Convert.ToDecimal(textBoxSumm.Text));
                    if (bon > 50)
                    {
                        MessageBox.Show("Одумайтесь, скидка слишком велика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    service.BonusFineOrder(new OrderBindingModel
                        {
                            Id = id.Value,
                            BonusFine = summ * bon / 100,
                        });
                                       
                    MessageBox.Show("Бонус/Штраф начислен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
