using POO3B135_34.DAL;
using POO3B135_34.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POO3B135_34.BLL
{
    public class BllPublishingCompany
    {
        private Dal database;

        public BllPublishingCompany()
        {
            database = Dal.getInstace;
        }

        public void inserPublishCompany(PublishingCompany company)
        {
            string query = string.Format($@"insert into TBL_Editora (idEditora,nome,endereco,UF) values('{company.Id}','{company.Name}','{company.Address}','{company.Uf}')");
            database.executeCommand(query);
        }

        public DataTable searchByPublishCompanyName(string name)
        {
            string query = string.Format($@"select TBL_Livro.idLivro,TBL_Autor.nome,TBL_Editora.nome,TBL_Livro.titulo,TBL_Livro.dataCadastro,TBL_Livro.numPaginas,TBL_Livro.valor
                       from (TBL_Livro inner join TBL_Autor on TBL_Livro.idAutor = TBL_Autor.idAutor
                       inner join TBL_Editora on TBL_Livro.idEditora = TBL_Editora.idEditora) where TBL_Editora.nome = '{name}'");

            DataTable data = database.getData(query);
            return data;
        }
    }
}