using POO3B135_34.DAL;
using POO3B135_34.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POO3B135_34.BLL
{
    public class BllAuthor
    {
        private Dal database;

        public BllAuthor()
        {
            database = Dal.getInstace;
        }


        public void insertAuthor(Author author)
        {
            string query = string.Format($@"insert into TBL_Autor (idAutor,nome,idade) values('{author.Id}','{author.Name}','{author.Age}')");
            database.executeCommand(query);
        }


        public DataTable searchByAuthorName(string name)
        {
            string query = string.Format($@"select TBL_Livro.idLivro,TBL_Autor.nome,TBL_Editora.nome,TBL_Livro.titulo,TBL_Livro.dataCadastro,TBL_Livro.numPaginas,TBL_Livro.valor
                       from (TBL_Livro inner join TBL_Autor on TBL_Livro.idAutor = TBL_Autor.idAutor
                       inner join TBL_Editora on TBL_Livro.idEditora = TBL_Editora.idEditora) where TBL_Autor.nome = '{name}'");
            DataTable data = database.getData(query);
            return data;
        }
    }
}