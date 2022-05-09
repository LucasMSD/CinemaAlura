using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Filme AdicionarFilme(CreateFilmeDto createFilmeDto)
        {
            var filme = _mapper.Map<Filme>(createFilmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return filme;
        }

        public ReadFilmeDto? RecuperarFilmePorId(int filmeId)
        {
            var filme = _context.Filmes.Where(x => x.Id == filmeId).FirstOrDefault();

            if (filme == null)
            {
                return null;
            }

            var readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);

            return readFilmeDto;
        }

        public IEnumerable<ReadFilmeDto> RecuperarFilmes(int? classificacaoEtaria)
        {
            var filmes = _context.Filmes.Where(x => classificacaoEtaria == null || x.ClassificacaoEtaria == classificacaoEtaria);

            var readFilmeDtoList = _mapper.Map<List<ReadFilmeDto>>(filmes);

            return readFilmeDtoList;
        }

        public void AtualizarFilmePorId(int id, UpdateFilmeDto updateFilmeDto)
        {
            var filme = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return;
            }

            _mapper.Map(updateFilmeDto, filme);

            _context.SaveChanges();

            return;
        }

        public void DeletarFilmePorId(int id)
        {
            var filme = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return;
            }

            _context.Remove(filme);
            _context.SaveChanges();

            return;
        }
    }
}
