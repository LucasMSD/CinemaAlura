using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private UserManager<IdentityUser<int>> _userManager;
        private IMapper _mapper;

        public UsuarioService(UserManager<IdentityUser<int>> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Result<List<Usuario>> RecuperarUsuarios()
        {
            return Result.Ok(_mapper.Map<List<Usuario>>(_userManager.Users.ToList()));
        }
    }
}
