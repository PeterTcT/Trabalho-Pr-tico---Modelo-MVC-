using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace POO3B135_34.DAL
{
    public class Dal
    {
        private const string conString = "Persist Security info=false ; server=localhost; database=bd_Livraria ;user=root ;pwd=;";
        MySqlConnection con;
        private Dal() { }

        private static Dal _intance;

        public static Dal getInstace => _intance ?? (_intance = new Dal());


        public void connect()
        {
            try
            {
                con = new MySqlConnection(conString);
                con.Open();
            }
            catch (MySqlException error)
            {
                throw new Exception(string.Format($@"Erro ao conectar ao banco de dados \n error: {error.Message}"));
            }
        }


        public DataTable getData(string query = "")
        {
            try
            {
                connect();
                MySqlDataAdapter data;
                DataTable table = new DataTable();
                if (string.IsNullOrEmpty(query))
                {
                    query = "select TBL_Livro.idLivro,TBL_Autor.nome,TBL_Editora.nome,TBL_Livro.titulo,TBL_Livro.dataCadastro,TBL_Livro.numPaginas,TBL_Livro.valor" +
                        " from (TBL_Livro inner join TBL_Autor on TBL_Livro.idAutor = TBL_Autor.idAutor " +
                        " inner join TBL_Editora on TBL_Livro.idEditora = TBL_Editora.idEditora)";
                    data = new MySqlDataAdapter(query, con);
                }
                else
                {
                    data = new MySqlDataAdapter(query, con);
                }
                data.Fill(table);
                return table;
            }
            catch (MySqlException error)
            {
                throw new Exception(string.Format($@"Erro ao executar consulta no banco de dados \n error: {error.Message}"));
            }
            finally
            {
                con.Close();
            }
        }

        public void executeCommand(string query)
        {
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();

            }
            catch (MySqlException error)
            {
                throw new Exception(string.Format($@"Erro ao executar comando \n error: {error.Message}"));
            }
            finally
            {
                con.Close();
            }
        }


    }
}
