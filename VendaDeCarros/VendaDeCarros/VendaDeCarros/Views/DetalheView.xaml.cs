using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaDeCarros.Models;
using VendaDeCarros.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendaDeCarros.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheView : ContentPage
	{
        public Veiculo Veiculo { get; set; }
        public Usuario Usuario { get; set; }

        public DetalheView (Veiculo pVeiculo, Usuario pUsuario)
		{
			InitializeComponent ();
            //this.Title = pVeiculo.Nome;
            this.Veiculo = pVeiculo;
            this.Usuario = pUsuario;
            BindingContext = new DetalheViewModel(pVeiculo);
		}

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "ProximoCommand", (msg) =>
            {
                Navigation.PushAsync(new AgendamentoView(msg, this.Usuario));
            });
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "ProximoCommand");
        }
    }
}