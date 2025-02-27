using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Repository
{

    /// <summary>
    /// Classe que vai implementar a interface IGeneroRepository
    /// ou seja, vamos imolementar os métodos, toda a lógica do métodos.
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {
        private readonly Filmes_Context _context;

        public FilmeRepository(Filmes_Context contexto)
        {
            _context = contexto;
        }
        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                _context.Filmes.Add(novoFilme);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filmes.Include(g => g.Genero)

                //Seleciona o que quer trazer na requisicao
                .Select(f => new Filme
                {
                    IdFilme = f.IdFilme,
                    Titulo = f.Titulo,

                    Genero = new Genero
                    {
                        Nome = f.Genero!.Nome
                    }
                })

                .ToList();

                return listaDeFilmes;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Atualizar(Guid id, Filme filme)
        {
            Filme filmeBuscado = _context.Filmes.Find(id)!;

            if (filmeBuscado != null)
            {
                filmeBuscado.Titulo = filme.Titulo;
                filmeBuscado.IdGenero = filme.IdGenero;

            }
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id)!;

                if (filmeBuscado != null)
                {
                    _context.Filmes.Remove(filmeBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id)!;

                return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Atualizar(Guid id, Genero filme)
        {
            throw new NotImplementedException();
        }

        public List<Filme> ListarPorGenero(Guid idGenero)
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filmes.Include(g => g.Genero).Where(f => f.IdGenero).ToList();

                return listaDeFilmes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
