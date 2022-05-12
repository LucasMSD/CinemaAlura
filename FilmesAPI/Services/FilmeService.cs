using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
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

        public Result<Filme> AdicionarFilme(CreateFilmeDto createFilmeDto)
        {
            var filme = _mapper.Map<Filme>(createFilmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return Result.Ok(filme);
        }

        public Result<ReadFilmeDto> RecuperarFilmePorId(int filmeId)
        {
            var filme = _context.Filmes.Where(x => x.Id == filmeId).FirstOrDefault();

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado.");
            }

            var readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
            readFilmeDto.HoraDaConsulta = DateTime.Now;

            return Result.Ok(readFilmeDto);
        }

        public Result<List<ReadFilmeDto>>RecuperarFilmes(int? classificacaoEtaria)
        {
            var filmes = _context.Filmes.Where(x => classificacaoEtaria == null || x.ClassificacaoEtaria == classificacaoEtaria).ToList();

            var readFilmeDtoList = _mapper.Map<List<ReadFilmeDto>>(filmes);
            readFilmeDtoList.ForEach(readFilmeDto => readFilmeDto.HoraDaConsulta = DateTime.Now);

            return Result.Ok(readFilmeDtoList);
        }

        public Result AtualizarFilmePorId(int filmeId, UpdateFilmeDto updateFilmeDto)
        {
            var filme = _context.Filmes.Where(x => x.Id == filmeId).FirstOrDefault();

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado.");
            }

            _mapper.Map(updateFilmeDto, filme);

            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletarFilmePorId(int filmeId)
        {
            var filme = _context.Filmes.Where(x => x.Id == filmeId).FirstOrDefault();

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado.");
            }

            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
