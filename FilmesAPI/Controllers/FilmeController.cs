using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase  
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecupararFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecupararFilmesPorId(int id)
        {
            var filme = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return NotFound();
            }

            return Ok(filme);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilmePorId([FromBody] Filme filme, int id)
        {
            var filmeAntigo = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();

            if (filmeAntigo == null)
            {
                return NotFound();
            }

            filmeAntigo.Titulo = filme.Titulo;
            filmeAntigo.Diretor = filme.Diretor;
            filmeAntigo.Genero = filme.Genero;
            filmeAntigo.Duracao = filme.Duracao;

            _context.Update(filmeAntigo);
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