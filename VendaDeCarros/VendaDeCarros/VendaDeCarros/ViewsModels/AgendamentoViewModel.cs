using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendaDeCarros.Data;
using VendaDeCarros.Models;
using VendaDeCarros.Services;
using Xamarin.Forms;

namespace VendaDeCarros.ViewsModels
{
    public class AgendamentoViewModel : ViewModelBase
    {
        #region Propriedades
        public Agendamento Agendamento { get; set; }

        private string modelo;
        public string Modelo
        {
            get { return this.Agendamento.Modelo; }
            set { this.Agendamento.Modelo = value; }
        }

        private decimal preco;
        public decimal Preco
        {
            get { return this.Agendamento.Preco; }
            set { this.Agendamento.Preco = value; }
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
                return Agendamento.DataAgendamento;
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
        #endregion

        #region Commands
        public ICommand AgendamentoCommand { get; set; }
        #endregion

        #region Construtores
        public AgendamentoViewModel(Veiculo pVeiculo, Usuario pUsuario)
        {
            this.Agendamento = new Agendamento(pUsuario.Nome, pUsuario.Telefone, pUsuario.Email, pVeiculo.Nome, pVeiculo.Preco, false);
            
            //objetos anonimos ()
            AgendamentoCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "AgendamentoCommand");
            }, ()=>
            {
                return !string.IsNullOrEmpty(this.Nome) && !string.IsNullOrEmpty(this.Fone) && !string.IsNullOrEmpty(this.Email);
            });
        }
        #endregion

        #region Métodos Públicos
        public async void SalvarAgendamento()
        {
            AgendamentoService agendamentoService = new AgendamentoService();
            await agendamentoService.EnviarAgendamento(this.Agendamento);
        }
        #endregion

    }

    
}
