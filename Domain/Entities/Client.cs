using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Client : Entity
    {
        public Client(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
    }
}
