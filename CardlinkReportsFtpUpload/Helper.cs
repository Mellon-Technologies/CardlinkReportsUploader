using NLog;
using Sentry;
using System;
using System.Net;
using System.Net.Mail;

namespace CardlinkReportsFtpUpload
{

    public static class Helper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void SendEmail(string _exception)
        {
            MailMessage mail = new MailMessage(Properties.Settings.Default.EmailFrom, Properties.Settings.Default.EmailTo);
            var client = new SmtpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            client.Port = Properties.Settings.Default.SmtpPort;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Host = Properties.Settings.Default.SmtpHostIp;
            var un = Properties.Settings.Default.NetworkCredentialUserName;
            var pass = Properties.Settings.Default.NetworkCredentialPassword;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(un, pass);
            mail.Subject = Properties.Settings.Default.EmailSubject;
            mail.Body = _exception;

            try
            {
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                logger.Error(ex, ex.Message, ex.InnerException);
            }
            finally
            {
                client?.Dispose();
                mail?.Dispose();
            }
        }
    }
}