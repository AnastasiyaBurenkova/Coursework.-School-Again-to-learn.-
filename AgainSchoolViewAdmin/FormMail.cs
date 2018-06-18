using AgainSchoolService.Interfaces;
using AgainSchoolService.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace AgainSchoolViewAdmin
{
    public partial class FormMail : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IClient serviceC;
        private readonly IMain serviceM;
        public static string file;
        public FormMail(IClient serviceC, IMain serviceM)
        {
            InitializeComponent();
            this.serviceC = serviceC;
            this.serviceM = serviceM;
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            fo.ShowDialog();
            file = fo.FileName;

        }

        private void buttonSendEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxClientEmail.Text))
            {
                MessageBox.Show("Заполните E-mail", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("againschool21@gmail.com", "21980623bB");
            string from = "againschool21@gmail.com";
            string mail = textBoxClientEmail.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            int id = Convert.ToInt32(comboBoxClient.SelectedValue);
            ClientViewModel name = serviceC.GetElement(id);
            OrderViewModel EntryName = serviceM.GetElement(id);
            string subject = "Школа";
            String text = "Уважаемый клиент, " + name.ClientFIO + "! Просим оплатить ваши записи на кружки " + EntryName.EntryName;
            MailMessage message = new MailMessage(from, mail, subject, text);
            try
            {
                Attachment sendfile = new Attachment(file);
                message.Attachments.Add(sendfile);

            }
            catch
            {
                MessageBox.Show("Файл не выбран ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {

                client.Send(message);
                MessageBox.Show("Письмо отправлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void FormMail_Load(object sender, EventArgs e)
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
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void CalcEmail()
        {
            if (comboBoxClient.SelectedValue != null)
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxClient.SelectedValue);
                    ClientViewModel mail = serviceC.GetElement(id);


                    textBoxClientEmail.Text = mail.Mail.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcEmail();
        }
    }
}

