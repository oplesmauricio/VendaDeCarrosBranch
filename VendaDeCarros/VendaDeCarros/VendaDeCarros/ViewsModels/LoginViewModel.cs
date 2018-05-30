using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using VendaDeCarros.Models;
using Xamarin.Forms;

namespace VendaDeCarros.ViewsModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                LoginService loginService = new LoginService();
                await loginService.FazerLogin(new Login(usuario, senha));
            }, () =>
            {
                return !string.IsNullOrEmpty(usuario)
                        && !string.IsNullOrEmpty(senha);
            });
        }

         
    }
}
