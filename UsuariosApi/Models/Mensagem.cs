using MimeKit;

namespace UsuariosApi.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatarios { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinarios, string assunto, int usuarioId, string codigoAtivacao)
        {
            Destinatarios = new List<MailboxAddress>();
            Destinatarios.AddRange(destinarios.Select(x => new MailboxAddress("", x)));
            Assunto = assunto;
            Conteudo = $"https://localhost:7268/ativar?UsuarioId={usuarioId}&CodigoAtivacao={codigoAtivacao}";
        }
    }
}
