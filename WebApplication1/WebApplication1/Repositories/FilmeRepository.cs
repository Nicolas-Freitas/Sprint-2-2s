using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source=DEV7\\SQLEXPRESS; initial catalog = Filmes; user Id=sa; pwd=sa@132";

        public void Cadastrar(FilmeDomain filme)
        {
            string Query = "insert into Filme (Titulo) values (@Titulo)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select IdFilme, Titulo from Filme";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();  

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        filmes.Add(filme);
                    }
                }
            }

            return filmes;

        }

        public void Alterar(FilmeDomain filmeDomain)
        {
            string Query = "update Filme set Titulo = @Titulo Where IdFilme = @IdFilme";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filmeDomain.Titulo);
                cmd.Parameters.AddWithValue("@IdFilme", filmeDomain.IdFilme);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }



        public void Deletar(int id)
        {
            string Query = "delete from Filme where IdFilme = @IdFilme";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@IdFilme", id);
                con.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "select IdFilme, Titulo from Filme where IdFilme = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"])

                            ,
                            Titulo = rdr["Titulo"].ToString()
                        };

                        return filme;
                    }

                    return null;
                }
            }
        }

       
    }
}
