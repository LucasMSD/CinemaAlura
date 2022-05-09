using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

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

        public Endereco AdicionarEndereco(CreateEnderecoDto createEnderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(createEnderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return endereco;
        }

        public ReadEnderecoDto? RecuperarEnderecoPorId(int enderecoId)
        {
            var endereco = _context.Enderecos.Where(x => x.Id == enderecoId).FirstOrDefault();

            if (endereco == null)
            {
                return null;
            }

            var readEnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

            return readEnderecoDto;
        }

        public IEnumerable<ReadEnderecoDto> RecuperarEnderecos()
        {
            var enderecos = _context.Enderecos.ToList();

            var readEnderecoDtoList = _mapper.Map<List<ReadEnderecoDto>>(enderecos);

            return readEnderecoDtoList;
        }

        public void AtualizarEnderecoPorId(int enderecoId, UpdateEnderecoDto updateEnderecoDto)
        {
            var endereco = _context.Enderecos.Where(x => x.Id == enderecoId).FirstOrDefault();

            if (endereco == null)
            {
                return;
            }

            _mapper.Map(updateEnderecoDto, endereco);

            _context.SaveChanges();

            return;
        }

        public void DeletarEnderecoPorId(int enderecoId)
        {
            var endereco = _context.Enderecos.Where(x => x.Id == enderecoId).FirstOrDefault();

            if (endereco == null)
            {
                return;
            }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return;
        }
    }
}
