using POO3B135_34.DAL;
using POO3B135_34.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POO3B135_34.BLL
{

    public class BllBooks
    {
        private Dal database;

        public BllBooks()
        {
            database = Dal.getInstace;
        }


        public DataTable getAllData()
        {
            DataTable data = database.getData();
            return data;
        }

        public void insertBook(Book book,int authorId, int publishCompanyId)
        {
            string query = string.Format($@"insert into TBL_Livro(idLivro,idAutor,idEditora,titulo,dataCadastro,numPaginas,valor) values(null,'{authorId}','{publishCompanyId}','{book.Title}','{book.DtRegistration}','{book.QPages}','{book.Value}')");
            database.executeCommand(query);
        }

        public void deletBook(string bookId)
        {
            string query = string.Format($@"delete from TBL_Livro where idLivro = {bookId}");
            database.executeCommand(query);

        }

        public void editBook(Book book)
        {
            string query = string.Format($@"update TBL_Livro set titulo = '{book.Title}', dataCadastro = '{book.DtRegistration}', numPaginas = '{book.QPages}', valor = '{book.Value}' where idLivro = '{book.BookId}' ");
            database.executeCommand(query);
        }


        public DataTable searchByBookName(string name)
        {
            string query = string.Format($@"select TBL_Livro.idLivro,TBL_Autor.nome,TBL_Editora.nome,TBL_Livro.titulo,TBL_Livro.dataCadastro,TBL_Livro.numPaginas,TBL_Livro.valor
                       from (TBL_Livro inner join TBL_Autor on TBL_Livro.idAutor = TBL_Autor.idAutor
                       inner join TBL_Editora on TBL_Livro.idEditora = TBL_Editora.idEditora) where TBL_Livro.titulo = '{name}'");

            DataTable data = database.getData(query);
            return data;
        }

    }
}