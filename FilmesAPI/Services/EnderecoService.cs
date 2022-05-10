using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result<Endereco> AdicionarEndereco(CreateEnderecoDto createEnderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(createEnderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return Result.Ok(endereco);
        }

        public Result<ReadEnderecoDto> RecuperarEnderecoPorId(int enderecoId)
        {
            var endereco = _context.Enderecos.Where(x => x.Id == enderecoId).FirstOrDefault();

            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrato.");
            }

            var readEnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

            return Result.Ok(readEnderecoDto);
        }

        public Result<List<ReadEnderecoDto>> RecuperarEnderecos()
        {
            var enderecos = _context.Enderecos.ToList();

            var readEnderecoDtoList = _mapper.Map<List<ReadEnderecoDto>>(enderecos);

            return Result.Ok(readEnderecoDtoList);
        }

        public Result AtualizarEnderecoPorId(int enderecoId, UpdateEnderecoDto updateEnderecoDto)
        {
            var endereco = _context.Enderecos.Where(x => x.Id == enderecoId).FirstOrDefault();

            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado.");
            }

            _mapper.Map(updateEnderecoDto, endereco);

            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletarEnderecoPorId(int enderecoId)
        {
            var endereco = _context.Enderecos.Where(x => x.Id == enderecoId).FirstOrDefault();

            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado.");
            }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
