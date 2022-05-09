using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

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

        public Sessao AdicionarSessao(CreateSessaoDto createSessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(createSessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return sessao;
        }

        public ReadSessaoDto? RecuperarSessaoPorId(int sessaoId)
        {
            var sessao = _context.Sessoes.Where(x => x.Id == sessaoId).FirstOrDefault();

            if (sessao == null)
            {
                return null;
            }

            var readSessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return readSessaoDto;
        }

        public IEnumerable<ReadSessaoDto> RecuperarSessoes()
        {
            var sessoes = _context.Sessoes.ToList();

            var readSessaoDtoList = _mapper.Map<List<ReadSessaoDto>>(sessoes);

            return readSessaoDtoList;
        }

        public void AtualizarSessaoPorId(int sessaoId, UpdateSessaoDto updateSessaoDto)
        {
            var sessao = _context.Sessoes.Where(x => x.Id == sessaoId).FirstOrDefault();

            if (sessao == null)
            {
                return;
            }

            _mapper.Map(updateSessaoDto, sessao);

            _context.SaveChanges();

            return;
        }

        public void DeletarSessaoPorId(int sessaoId)
        {
            var sessao = _context.Sessoes.Where(x => x.Id == sessaoId).FirstOrDefault();

            if (sessao == null)
            {
                return;
            }

            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();

            return;
        }
    }
}
