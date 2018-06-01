using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using VendaDeCarros.Media;
using VendaDeCarros.Models;
using Xamarin.Forms;

namespace VendaDeCarros.ViewsModels
{
    public class MasterViewModel : ViewModelBase
    {
        public string Nome
        {
            get
            {
                return this.Usuario.Nome;
            }
            set
            {
                this.Usuario.Nome = value;
            }
        }

        public string Email
        {
            get { return this.Usuario.Email; }
            set { this.Usuario.Email = value; }
        }

        public string DataNascimento
        {
            get { return this.Usuario.DataNascimento; }
            set { this.Usuario.DataNascimento = value; }
        }

        public string Telefone
        {
            get { return this.Usuario.Telefone; }
            set { this.Usuario.Telefone = value; }
        }

        private bool editando = false;

        public bool Editando
        {
            get { return editando; }
            set
            {
                editando = value;
                OnPropertyChanged();
            }
        }

        private ImageSource fotoPerfil = "icon.png";

        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            private set
            {
                fotoPerfil = value;
                OnPropertyChanged();
            }
        }


        private readonly Usuario Usuario;

        public ICommand PageEditarPerfilCommand { get; private set; }
        public ICommand SalvarPerfilCommand { get; private set; }
        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand TirarFotoCommand { get; private set; }

        public MasterViewModel(Usuario pUsuario)
        {
            this.Usuario = pUsuario;

            DefinirComandos(pUsuario);
        }

        private void DefinirComandos(Usuario pUsuario)
        {
            PageEditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(pUsuario, "PageEditarPerfil");
            });

            SalvarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(pUsuario, "SucessoSalvarUsuario");
                this.Editando = false;
            });

            EditarPerfilCommand = new Command(() =>
            {
                this.Editando = true;
            });

            TirarFotoCommand = new Command(() =>
            {
                DependencyService.Get<ICamera>().TirarFoto();
            });

            MessagingCenter.Subscribe<byte[]>(this, "FotoTirada",
                (bytes) =>
                {
                    FotoPerfil = ImageSource.FromStream(() =>
                     new MemoryStream(bytes));
                });
        }
    }
}
