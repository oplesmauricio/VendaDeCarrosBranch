using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDeCarros.Models
{
    public class Agendamento
    {
        #region Propriedades
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        #endregion

        DateTime dataAgendamento;
        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }
            set
            {
                dataAgendamento = value;
            }
        }

        public string DataEHoraFormatada
        {
            get
            {
                return DataAgendamento.Add(HoraAgendamento)
                    .ToString("dd/MM/yyyy HH:mm");
            }
        }

        public Agendamento()
        {

        }

        public Agendamento(string pNome, string pFone, string pEmail, string pModelo, decimal pPreco, DateTime pDataAgendamento, TimeSpan pHoraAgendamento)
            :this( pNome,  pFone,  pEmail,  pModelo,  pPreco)
        {
            this.DataAgendamento = pDataAgendamento;
            this.HoraAgendamento = pHoraAgendamento;
        }

        public Agendamento(string pNome, string pFone, string pEmail, string pModelo, decimal pPreco)
        {
            this.Nome = pNome;
            this.Fone = pFone;
            this.Email = pEmail;
            this.Modelo = pModelo;
            this.Preco = pPreco;
        }
    }
}
