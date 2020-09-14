using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO3B135_34.DTO
{
    public class PublishingCompany
    {
        private int id;
        private string name;
        private string address;
        private string uf;

        public PublishingCompany(string name, string address, string uf)
        {
            this.Id = Guid.NewGuid().GetHashCode();
            this.Name = name;
            this.Address = address;
            this.Uf = uf;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("O nome da editora não pode ser vazio");
                else
                    name = value;
            } 
        }
        public string Address { get => address; set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("O endereço da editora não pode ser vazio");
                else if (value.Length > 50)
                    throw new Exception("O endereço não pode ter mais de 50 caracteres");
                else
                    address = value;
            } 
        }
        public string Uf { get => uf; set
            {               
                 if (value.Length > 2 || value.Length < 1)
                    throw new Exception("O uf da editora não pode conter mais de 2 e nem menos de 2 caracteres");
                 else
                    uf = value;
            }
        }
    }
}