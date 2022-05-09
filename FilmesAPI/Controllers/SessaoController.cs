using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto createSessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(createSessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            var sessao = _context.Sessoes.Where(x => x.Id == id).FirstOrDefault();

            if (sessao == null)
            {
                return NotFound();
            }

            var readSessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(readSessaoDto);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            return Ok(_context.Sessoes.ToList());
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessaoPorId(int id, [FromBody] UpdateSessaoDto updateSessaoDto)
        {
            var sessao = _context.Sessoes.Where(x => x.Id == id).FirstOrDefault();

            if (sessao == null)
            {
                return NotFound();
            }

            _mapper.Map(updateSessaoDto, sessao);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSessaoPorId(int id)
        {
            var sessao = _context.Sessoes.Where(x => x.Id == id).FirstOrDefault();

            if (sessao == null)
            {
                return NotFound();
            }

            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
