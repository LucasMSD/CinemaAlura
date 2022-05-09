using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto createFilmeDto)
        {
            Filme filme = _mapper.Map<Filme>(createFilmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecupararFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria)
        {
            var readFilmeDtoList = _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Where(x => classificacaoEtaria == null || x.ClassificacaoEtaria <= classificacaoEtaria));

            if (!readFilmeDtoList.Any())
            {
                return NotFound();
            }

            return Ok(readFilmeDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult RecupararFilmesPorId(int id)
        {
            var filme = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return NotFound();
            }

            ReadFilmeDto readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
            readFilmeDto.HoraDaConsulta = DateTime.Now;
            return Ok(readFilmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilmePorId([FromBody] UpdateFilmeDto updateFilmeDto, int id)
        {
            var filme = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return NotFound();
            }

            _mapper.Map(updateFilmeDto, filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilmePorId(int id)
        {
            var filme = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return NotFound();
            }

            _context.Filmes.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}