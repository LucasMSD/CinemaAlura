using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Gerente AdicionarGerente(CreateGerenteDto createGerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(createGerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return gerente;
        }

        public ReadGerenteDto? RecuperarGerentePorId(int gerenteId)
        {
            var gerente = _context.Gerentes.Where(x => x.Id == gerenteId).FirstOrDefault();

            if (gerente == null)
            {
                return null;
            }

            var readGerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

            return readGerenteDto;
        }

        public IEnumerable<ReadGerenteDto> RecuperarGerentes()
        {
            var gerentes = _context.Gerentes.ToList();

            var readGerenteDtoList = _mapper.Map<List<ReadGerenteDto>>(gerentes);

            return readGerenteDtoList;
        }

        public void AtualizarGerentePorId(int gerenteId, UpdateGerenteDto updateGerenteDto)
        {
            var gerente = _context.Gerentes.Where(x => x.Id == gerenteId).FirstOrDefault();

            if (gerente == null)
            {
                return;
            }

            _mapper.Map(updateGerenteDto, gerente);
            
            _context.SaveChanges();

            return;
        }

        public void DeletarGerentePorId(int gerenteId)
        {
            var gerente = _context.Gerentes.Where(x => x.Id == gerenteId).FirstOrDefault();

            if (gerente == null)
            {
                return;
            }

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return;
        }
    }
}
