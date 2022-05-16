using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UsuariosApi.Data.Requests;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        private EmailService _emailService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService, EmailService service)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = service;
        }

        public IdentityUser<int> RecuperarUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedEmail == email.ToUpper());
        }

        public IdentityUser<int> RecuperarUsuarioPorUserName(string userName)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == userName.ToUpper());
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultIdentity.Result.Succeeded)
            {
                var identityUser = RecuperarUsuarioPorUserName(request.UserName);

                var token = _tokenService.CreateToken(identityUser, _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login Falhou");
        }

        public Result SolicitarResetSenhaUsuario(SolicitarResetRequest solicitarResetRequest)
        {
            var identityUser = RecuperarUsuarioPorEmail(solicitarResetRequest.Email);

            if (identityUser == null)
            {
                return Result.Fail("Nenhum usuário encontrado com o email enviado.");
            }

            var codigoDeRedefinicao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

            var encodedCode = HttpUtility.UrlEncode(codigoDeRedefinicao);

            //_emailService.EnviarEmail(new[] { identityUser.Email }, "Código de redefinição de senha.", identityUser.Id, encodedCode);

            return Result.Ok().WithSuccess(codigoDeRedefinicao);
        }

        public Result ResetSenhaUsuario(EfetuarResetRequest efetuarResetRequest)
        {
            var identityUser = RecuperarUsuarioPorEmail(efetuarResetRequest.Email);

            if (identityUser == null)
            {
                return Result.Fail("Usuário não encontrado");
            }

            var resultIdentity = _signInManager.UserManager.ResetPasswordAsync(identityUser, efetuarResetRequest.CodigoRedefinicao, efetuarResetRequest.Password);

            if (resultIdentity.Result.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao redefinir a senha");
        }
    }
}
