using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDeCarros.Models
{
    public class Usuario
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string dataNascimento;

        public string DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }


    }

    public class ResultadoLogin
    {
        public Usuario Usuario { get; set; }
    }
}
