using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using VendaDeCarros.Models;
using Xamarin.Forms;

namespace VendaDeCarros.ViewsModels
{
    public class AgendamentoViewModel : ViewModelBase
    {
        public Agendamento Agendamento { get; set; }

        public Veiculo Veiculo
        {
            get { return Agendamento.Veiculo; }
            set { Agendamento.Veiculo = value; }
        }

        public string Nome
        {
            get { return Agendamento.Nome; }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        public string Fone
        {
            get { return Agendamento.Fone; }
            set
            {
                Agendamento.Fone = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        public string Email
        {
            get { return Agendamento.Email; }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento = DateTime.Today;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }

        public ICommand AgendamentoCommand { get; set; }

        public AgendamentoViewModel(Veiculo pVeiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = pVeiculo;
            //objetos anonimos ()
            AgendamentoCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "AgendamentoCommand");
            }, ()=>
            {
                return !string.IsNullOrEmpty(this.Nome) && !string.IsNullOrEmpty(this.Fone) && !string.IsNullOrEmpty(this.Email);
            });
        }

        public async void SalvarAgendamento()
        {
            HttpClient client = new HttpClient();

            var dataHoraAgendamento = new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);

            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Fone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await client.PostAsync("https://aluracar.herokuapp.com/salvaragendamento", conteudo);

            if(resposta.IsSuccessStatusCode)
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }
        }
    }
}
