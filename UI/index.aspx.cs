using POO3B135_34.BLL;
using POO3B135_34.DAL;
using POO3B135_34.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POO3B135_34.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BllBooks bllBooks = new BllBooks();
        BllAuthor BllAuthor = new BllAuthor();
        BllPublishingCompany bllCompany = new BllPublishingCompany();



        protected void Page_Load(object sender, EventArgs e)
        {
            fiilTable();
        }

        public void fiilTable(DataTable table = null)
        {

            if (table == null)
            {
                booksTable.DataSource = bllBooks.getAllData();

                booksTable.DataBind();


            }
            else
            {
                booksTable.DataSource = table;

                booksTable.DataBind();


            }

        }

        protected void addBook_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book(bookName.Text, int.Parse(bookQPages.Text), double.Parse(bookValue.Text));
                Author author = new Author(authorName.Text, 17);
                BllAuthor.insertAuthor(author);
                PublishingCompany company = new PublishingCompany(publishCompanyName.Text, "Rua x", "AZ");
                bllCompany.inserPublishCompany(company);
                bllBooks.insertBook(book, author.Id, company.Id);
                fiilTable();
            }
            catch (Exception error)
            {
                messager.Text = error.Message;
            }
        }

        protected void searchByAuthor_Click(object sender, EventArgs e)
        {
            string nameOfAuthor = authorName.Text;
            if (!string.IsNullOrEmpty(nameOfAuthor))
            {
                try
                {
                    DataTable data = BllAuthor.searchByAuthorName(nameOfAuthor);
                    filTableIfTheQueryReturnData(data, nameOfAuthor);
                }
                catch (Exception error)
                {
                    messager.Text = error.Message;
                }
            }
            else
            {
                messager.Text = "impossível pesquisar,o nome do autor está vazio";
            }
        }

        protected void searchByPublishCompany_Click(object sender, EventArgs e)
        {
            string companyName = publishCompanyName.Text;
            if (!string.IsNullOrEmpty(companyName))
            {
                try
                {
                    DataTable data = bllCompany.searchByPublishCompanyName(companyName);
                    filTableIfTheQueryReturnData(data, companyName);

                }
                catch (Exception error)
                {
                    messager.Text = error.Message;
                }
            }
            else
            {
                messager.Text = "impossível pesquisar,o nome da editora está vazio";
            }
        }

        protected void searchByBook_Click(object sender, EventArgs e)
        {
            string nameOfBook = bookName.Text;
            if (!string.IsNullOrEmpty(nameOfBook))
            {
                try
                {
                    DataTable data = bllBooks.searchByBookName(nameOfBook);
                    filTableIfTheQueryReturnData(data, nameOfBook);
                }
                catch (Exception error)
                {
                    messager.Text = error.Message;
                }
            }
            else
            {
                messager.Text = "impossível pesquisar,o nome do livro está vazio";
            }
        }


        public void filTableIfTheQueryReturnData(DataTable data, string nameSearched)
        {
            if (data.Rows.Count == 0)
            {
                messager.Text = string.Format($@"Não foram encontrados nenhum dado sobre a(o) {nameSearched}");
            }
            else
            {
                fiilTable(data);
            }
        }

        protected void booksTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                bllBooks.deletBook(e.Values[0].ToString());
                fiilTable();
            }
            catch (Exception error)
            {
                messager.Text = error.Message;
            }
        }

        protected void booksTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            booksTable.EditIndex = e.NewEditIndex;
            fiilTable();

        }

        protected void booksTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            booksTable.EditIndex = -1;
            fiilTable();

        }

        protected void booksTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                int id = int.Parse(e.NewValues[0].ToString());
                string title = e.NewValues[3].ToString();
                string dtRegistration = DateTime.Parse(e.NewValues[4].ToString()).ToString("yyyy-MM-dd");
                int qPages = int.Parse(e.NewValues[5].ToString());
                double value = double.Parse(e.NewValues[6].ToString());
                Book book = new Book(id, title, dtRegistration, qPages, value);
                bllBooks.editBook(book);
                booksTable.EditIndex = -1;
                fiilTable();

            }
            catch (Exception error)
            {
                messager.Text = error.Message;
            }
        }
    }
}