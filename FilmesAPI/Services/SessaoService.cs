using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result<Sessao> AdicionarSessao(CreateSessaoDto createSessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(createSessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return Result.Ok(sessao);
        }

        public Result<ReadSessaoDto> RecuperarSessaoPorId(int sessaoId)
        {
            var sessao = _context.Sessoes.Where(x => x.Id == sessaoId).FirstOrDefault();

            if (sessao == null)
            {
                return Result.Fail("Sessao não encontrada.");
            }

            var readSessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Result.Ok(readSessaoDto);
        }

        public Result<List<ReadSessaoDto>> RecuperarSessoes()
        {
            var sessoes = _context.Sessoes.ToList();

            var readSessaoDtoList = _mapper.Map<List<ReadSessaoDto>>(sessoes);

            return Result.Ok(readSessaoDtoList);
        }

        public Result AtualizarSessaoPorId(int sessaoId, UpdateSessaoDto updateSessaoDto)
        {
            var sessao = _context.Sessoes.Where(x => x.Id == sessaoId).FirstOrDefault();

            if (sessao == null)
            {
                return Result.Fail("Sessao não encontrada.");
            }

            _mapper.Map(updateSessaoDto, sessao);

            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletarSessaoPorId(int sessaoId)
        {
            var sessao = _context.Sessoes.Where(x => x.Id == sessaoId).FirstOrDefault();

            if (sessao == null)
            {
                return Result.Fail("Sessao não encontrada.");
            }

            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
