using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

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

        public Result<Gerente> AdicionarGerente(CreateGerenteDto createGerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(createGerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return Result.Ok(gerente);
        }

        public Result<ReadGerenteDto> RecuperarGerentePorId(int gerenteId)
        {
            var gerente = _context.Gerentes.Where(x => x.Id == gerenteId).FirstOrDefault();

            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado.");
            }

            var readGerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

            return Result.Ok(readGerenteDto);
        }

        public Result<List<ReadGerenteDto>> RecuperarGerentes()
        {
            var gerentes = _context.Gerentes.ToList();

            var readGerenteDtoList = _mapper.Map<List<ReadGerenteDto>>(gerentes);

            return Result.Ok(readGerenteDtoList);
        }

        public Result AtualizarGerentePorId(int gerenteId, UpdateGerenteDto updateGerenteDto)
        {
            var gerente = _context.Gerentes.Where(x => x.Id == gerenteId).FirstOrDefault();

            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado.");
            }

            _mapper.Map(updateGerenteDto, gerente);
            
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletarGerentePorId(int gerenteId)
        {
            var gerente = _context.Gerentes.Where(x => x.Id == gerenteId).FirstOrDefault();

            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado.");
            }

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
