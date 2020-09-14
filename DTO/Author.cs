using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO3B135_34.DTO
{
    public class Author
    {
        private int id;
        private string name;
        private int age;

        public Author( string name, int age)
        {
            this.Id = Guid.NewGuid().GetHashCode();
            this.Name = name;
            this.Age = age;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("O nome do autor não deve ser vazio");
                else
                    name = value;
            } 
        }
        public int Age { get => age; set => age = value; }
    }
}