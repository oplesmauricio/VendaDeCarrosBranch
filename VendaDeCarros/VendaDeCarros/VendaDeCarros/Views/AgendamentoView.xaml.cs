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
	public partial class AgendamentoView : ContentPage
	{
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView (Veiculo pVeiculo, Usuario pUsuario)
		{
			InitializeComponent ();
            //this.Title = pVeiculo.Nome;
            this.ViewModel = new AgendamentoViewModel(pVeiculo, pUsuario);
            this.BindingContext = this.ViewModel;
		}

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoCommand", async (msg) =>
            {
                var confirma = await DisplayAlert("Salvar Agendamento", "Deseja mesmo enviar o agendamento?",
                    "Sim", "Não");

                if (confirma)
                {
                    this.ViewModel.SalvarAgendamento();
                DisplayAlert("Agendamento",
    string.Format(@"Nome: {0}
\n Fone: {1}
E-mail: {2}
Data Agendamento: {3}
Hora Agendamento: {4}
Veiculo: {5}",
    ViewModel.Agendamento.Nome,
    ViewModel.Agendamento.Fone,
    ViewModel.Agendamento.Email,
    ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
    ViewModel.Agendamento.HoraAgendamento,
    ViewModel.Agendamento.Modelo),
        "Ok");
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", async (msg) =>
            {
                await DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "Ok");
                await Navigation.PopToRootAsync();
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", async (msg) =>
            {
                await DisplayAlert("Agendamento", "Falha ao agendar o test drive! Verifique os dados e tente novamente", "Ok");
                await Navigation.PopToRootAsync();
            });
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoCommand");

            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");

            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}