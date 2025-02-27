using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Repository

{
    /// <summary>
    /// Classe que vai implementar a interface IGeneroRepository
    /// ou seja, vamos imolementar os métodos, toda a lógica do métodos.
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {

        /// <summary>
        /// variavél privada e somente leitura.
        /// </summary>
        private readonly Filmes_Context _context;



        /// <summary>
        /// Construtor do repositório
        /// Aqui toda vez que p construtor for chamado,
        /// os dados do contexto estarão disponiveis
        /// </summary>
        /// <param name="contexto"></param>
        public GeneroRepository(Filmes_Context contexto) 
        {
            _context = contexto;
        }



        public void Atualizar(Guid id, Genero genero)
        {
            try
            {
                Genero generosBuscado = _context.Generos.Find(id)!;

                if (generosBuscado != null)
                {
                    generosBuscado.Nome = genero.Nome;

                }
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Genero BuscarPorId(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Generos.Find(id)!;

                return generoBuscado;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// metodo para cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero"></param>

        public void Cadastrar(Genero novoGenero)
        {
            try
            {
                //adiciona um novo genero na tabela genero(BD)
                _context.Generos.Add(novoGenero);

                //Após o cadastro, salva as alterações
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Generos.Find(id)!;

                if (generoBuscado != null) 
                {
                    _context.Generos.Remove(generoBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public List<Genero> Listar()
        {
            try
            {
                List<Genero> ListaGeneros = _context.Generos.ToList();

                return ListaGeneros;
            }
            catch (Exception)
            {
                throw;
            }
             
        }


    }
}
