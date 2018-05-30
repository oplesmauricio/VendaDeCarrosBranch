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

        public ListagemView()
		{
			InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;
		}
        
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                (msg) =>
                {
                    Navigation.PushAsync(new DetalheView(msg));
                });

            this.ViewModel.GetVeiculos();

        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
