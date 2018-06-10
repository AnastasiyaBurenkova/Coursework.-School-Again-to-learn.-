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
    /// Логика взаимодействия для FormLetterPDF.xaml
    /// </summary>
    public partial class FormLetterPDF : Window
    {
        public FormLetterPDF()
        {
            InitializeComponent();
        }
        private void buttonSave_Click(object sender, EventArgs e)
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
            SendEmail(textBoxMail.Text);
            Close();
        }

        private void SendEmail(string mailAddress)
        {
            MailMessage objMailMessage = new MailMessage();
            String filePath = "";
            try
            {
                filePath = "Отчет по записям на кружки.pdf";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            SmtpClient client = new SmtpClient("smtp.mail.ru", 25);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("nastya.burenkova.98@mail.ru", "21980623b");
            string from = "nastya.burenkova.98@mail.ru";
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
            string subject = "Отчет по записям на кружки";
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
            Close();

        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
