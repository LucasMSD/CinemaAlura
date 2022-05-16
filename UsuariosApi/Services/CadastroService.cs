using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;

        public CadastroService(UserDbContext context, IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastrarUsuario(CreateUsuarioDto createUsuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(createUsuarioDto);
            var usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);

            var resultIdentity = _userManager.CreateAsync(usuarioIdentity, createUsuarioDto.Password).Result;

            _userManager.AddToRoleAsync(usuarioIdentity, "regular");

            if (resultIdentity.Succeeded)
            {
                var codigoAtivacao = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                var encodedCode = HttpUtility.UrlEncode(codigoAtivacao);

                _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de Ativação de conta", usuarioIdentity.Id, encodedCode);

                return Result.Ok().WithSuccess(codigoAtivacao);
            }

            return Result.Fail("Falha ao cadastrar usuário.");
        }

        public Result AtivarContaUsuario(AtivarContaRequest ativarContaRequest)
        {
            var identityUser = _userManager.Users.FirstOrDefault(user => user.Id == ativarContaRequest.UsuarioId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, ativarContaRequest.CodigoAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}
