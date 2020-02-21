using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source=DEV7\\SQLEXPRESS; initial catalog = Filmes; user Id=sa; pwd=sa@132";

        public void Cadastrar(GeneroDomain genero)
        {
            string Query = "insert into Genero (Nome) VALUES (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select IdGenero, Nome from Genero";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        generos.Add(genero);
                    }
                }
            }

            return generos;

        }

        public void Alterar(GeneroDomain generoDomain)
        {
            string Query = "update Genero set Nome = @Nome Where IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                cmd.Parameters.AddWithValue("@IdGenero", generoDomain.IdGenero);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "delete from Genero where IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "select IdGenero, Nome from Generos where IdGenero = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdFilme"])

                            ,
                            Nome = rdr["Titulo"].ToString()
                        };

                        return genero;
                    }

                    return null;
                }
            }
        }
    }
}

