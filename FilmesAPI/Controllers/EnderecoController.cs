using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto createEnderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(createEnderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            var endereco = _context.Enderecos.Where(x => x.Id == id).FirstOrDefault();

            if (endereco == null)
            {
                return NotFound();
            }

            ReadEnderecoDto readEnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(readEnderecoDto);
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            return Ok(_context.Enderecos);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEnderecoPorId(int id, [FromBody] UpdateEnderecoDto updateEnderecoDto)
        {
            var endereco = _context.Enderecos.Where(x => x.Id == id).FirstOrDefault();

            if (endereco == null)
            {
                return NotFound();
            }

            _mapper.Map(updateEnderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEnderecoPorId(int id)
        {
            var endereco = _context.Enderecos.Where(x => x.Id == id).FirstOrDefault();

            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
