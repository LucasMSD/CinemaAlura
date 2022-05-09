using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto createGerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(createGerenteDto);

            _context.Add(gerente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            var gerente = _context.Gerentes.Where(x => x.Id == id).FirstOrDefault();

            if (gerente == null)
            {
                return NotFound();
            }

            var readGerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

            return Ok(readGerenteDto);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            return Ok(_context.Gerentes.ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult  DeletarGerentePorId(int id)
        {
            var gerente = _context.Gerentes.Where(x => x.Id == id).FirstOrDefault();

            if (gerente == null)
            {
                return NotFound();
            }

            _context.Remove(gerente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
