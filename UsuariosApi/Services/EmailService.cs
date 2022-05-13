using MailKit.Net.Smtp;
using MimeKit;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class EmailService
    {
        private IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void EnviarEmail(string[] destinatarios, string assunto, int usuarioId, string codigoAtivacao)
        {
            Mensagem mensagem = new Mensagem(destinatarios, assunto, usuarioId, codigoAtivacao);

            var emailMensagem = CriarCorpoEmail(mensagem);

            EnviarEmail(emailMensagem);
        }

        private void EnviarEmail(MimeMessage mensagemEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_config.GetValue<string>("EmailSettings:SmtpServer"), _config.GetValue<int>("EmailSettings:Port"), true);

                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_config.GetValue<string>("EmailSettings:From"), _config.GetValue<string>("EmailSettings:Password"));

                    client.Send(mensagemEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CriarCorpoEmail(Mensagem mensagem)
        {
            var mensagemEmail = new MimeMessage();

            mensagemEmail.From.Add(new MailboxAddress("", _config.GetValue<string>("EmailSettings:From")));
            mensagemEmail.To.AddRange(mensagem.Destinatarios);
            mensagemEmail.Subject = mensagem.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemEmail;
        }
    }
}
