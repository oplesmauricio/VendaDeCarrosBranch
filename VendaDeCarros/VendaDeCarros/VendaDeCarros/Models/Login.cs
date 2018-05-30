using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDeCarros.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public Login(string pEmail, string pSenha)
        {
            this.Email = pEmail;
            this.Senha = pSenha;
        }
    }
}
