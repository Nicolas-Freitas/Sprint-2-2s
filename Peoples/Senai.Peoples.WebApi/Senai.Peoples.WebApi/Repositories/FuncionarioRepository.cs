using Senai.Peoples.WebApi.Domaing;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string StringConexao = "Data Source=DEV7\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";

        public void Cadastrar(FuncionarioDomain funcionario)
        {
            string Query = "insert into Funcionarios (Nome,Sobrenome,DataNasc) values (@Nome,@Sobrenome,@DataNasc)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                cmd.Parameters.AddWithValue("@DataNasc", funcionario.DataNasc);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select IdFuncionario, Nome, Sobrenome, DataNasc from Funcionarios";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            Nome = rdr[1].ToString(),

                            Sobrenome = rdr[2].ToString(),

                            DataNasc = Convert.ToDateTime(rdr["DataNasc"])
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "select IdFuncionario, Nome, Sobrenome, DataNasc from Funcionarios where IdFuncionario = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNasc = Convert.ToDateTime(rdr["DataNasc"])
                        };

                        return funcionario;
                    }

                    return null;
                }
            }
        }
        public void Deletar(int id)
        {
            string Query = "delete from Funcionarios where IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(FuncionarioDomain funcionario)
        {
            

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "update Funcionarios set Nome = @Nome, Sobrenome = @Sobrenome, DataNasc = @DataNasc where IdFuncionario = @IdFuncionario";
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                cmd.Parameters.AddWithValue("@DataNasc", funcionario.DataNasc);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionario.IdFuncionario);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
}


