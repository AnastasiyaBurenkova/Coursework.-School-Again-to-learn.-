using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AgainSchoolViewClient
{
    /// <summary>
    /// Логика взаимодействия для FormLetter.xaml
    /// </summary>
    public partial class FormLetter : Window
    {
        public FormLetter()
        {
            InitializeComponent();
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMail.Text))
            {
                MessageBox.Show("Заполните Email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string mail = textBoxMail.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            if (comboBoxFormat.Text == "")
            {
                MessageBox.Show("Выберите формат получаемого файла", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SendEmail(textBoxMail.Text, comboBoxFormat.Text);
            
        }

        private void SendEmail(string mailAddress, string formatFile)
        {
            MailMessage objMailMessage = new MailMessage();
            String filePath = "";

            if (formatFile == "doc")
            {
                try
                {
                    filePath = @"C:\Список кружков.doc";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (formatFile == "xls")
            {
                try
                {
                    filePath = @"C:\Список кружков.xls";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("againschool21@gmail.com", "21980623bB");
            string from = "againschool21@gmail.com";
            string mail = textBoxMail.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            string subject = "Список кружков";
            String text = " ";
            MailMessage message = new MailMessage(from, mail, subject, text);
            string file = filePath;
            try
            {

                Attachment sendfile = new Attachment(file, MediaTypeNames.Application.Octet);
                message.Attachments.Add(sendfile);

            }
            catch
            {
                MessageBox.Show("Ошибка получения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            try
            {
                client.Send(message);
                MessageBox.Show("Письмо получено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
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
