using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaDeCarros.Models;
using VendaDeCarros.Services;
using VendaDeCarros.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendaDeCarros.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentosUsuarioView : ContentPage
	{
        readonly AgendamentosUsuarioViewModel viewModel;

        public AgendamentosUsuarioView()
		{
			InitializeComponent ();
            this.viewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = this.viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionadoReenvio",
            async (agendamento) =>
            {
                if (!agendamento.Confirmado)
                {
                    var reenviar = await DisplayAlert("Reenviar", "Deseja Reenviar o agendamento?", "Sim", "Não");
                    if (reenviar)
                    {
                        AgendamentoService agendamentoService = new AgendamentoService();
                        await agendamentoService.EnviarAgendamento(agendamento);
                        this.viewModel.AtualizarLista();
                    }
                }

            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", async (agendamento) =>
            {
                await DisplayAlert("Reeenviar", "Reenvio bem sucedido", "Ok");
            });

            MessagingCenter.Subscribe<Agendamento>(this, "FalhaAgendamento", async (agendamento) =>
            {
                await DisplayAlert("Reenviar", "Falha no Reenvio", "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSelecionadoReenvio");
        }
    }
}