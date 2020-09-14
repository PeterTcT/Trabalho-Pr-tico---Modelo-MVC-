using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO3B135_34.DTO
{
    public class Book
    {
        private int bookId;
        private string title;
        private string dtRegistration;
        private int qPages;
        private double value;

        public Book(string title,int qPages, double value)
        {
            int temporaryId = Guid.NewGuid().GetHashCode();
                this.BookId = temporaryId < 0 ? temporaryId *-1 : temporaryId;
                this.Title = title;
                this.DtRegistration = DateTime.Now.Date.ToString("yyyy-MM-dd");
                this.QPages = qPages;
                this.Value = value;
        }


        public Book(int bookId, string title, string dtRegistration,int qPages, double value)
        {
            this.BookId = bookId;
            this.Title = title;
            this.DtRegistration = dtRegistration;
            this.QPages = qPages;
            this.Value = value;
        }

        public int BookId { get => bookId; set => bookId = value;}
        public string Title { 
            get => title; set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("O título do livro não pode ser vazio!");
                else
                    title = value;
            }
        }
        public string DtRegistration { 
            get => dtRegistration; set
            {
                if (value == null)
                    throw new Exception("A data não pode ser vazia");
                else
                    dtRegistration = value;
            } 
        }
        public int QPages { get => qPages; set => qPages = value; }
        public double Value { get => value; set => this.value = value; }
    }
}