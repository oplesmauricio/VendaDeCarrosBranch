using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaDeCarros.Models;
using VendaDeCarros.ViewsModels;
using Xamarin.Forms;

namespace VendaDeCarros.Views
{
	public partial class ListagemView : ContentPage
	{
        public ListagemViewModel ViewModel { get; set; }

        public List<Veiculo> Veiculos { get; set; }

        public Usuario Usuario { get; set; }

        public ListagemView(Usuario pUsuario)
		{
			InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.Usuario = pUsuario;
            this.BindingContext = this.ViewModel;
		}
        
        protected async override void OnAppearing()
        {
            AssinarMensagens();

            await this.ViewModel.GetVeiculos();

        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                            (msg) =>
                            {
                                Navigation.PushAsync(new DetalheView(msg, this.Usuario));
                            });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
                (msg) =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de veiculos", "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            CancelarAssinatura();
        }

        private void CancelarAssinatura()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }
    }
}
