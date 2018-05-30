using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDeCarros.Models
{
    public class Agendamento
    {
        #region Propriedades
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
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

    }
}
