using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VendaDeCarros.Data;
using VendaDeCarros.Models;
using Xamarin.Forms;

namespace VendaDeCarros.Services
{
    class AgendamentoService
    {
        public async Task EnviarAgendamento(Agendamento pAgendamento)
        {
            HttpClient client = new HttpClient();

            var dataHoraAgendamento = new DateTime(pAgendamento.DataAgendamento.Year, pAgendamento.DataAgendamento.Month, pAgendamento.DataAgendamento.Day,
                pAgendamento.HoraAgendamento.Hours, pAgendamento.HoraAgendamento.Minutes, pAgendamento.HoraAgendamento.Seconds);

            var json = JsonConvert.SerializeObject(new
            {
                nome = pAgendamento.Nome,
                fone = pAgendamento.Fone,
                email = pAgendamento.Email,
                carro = pAgendamento.Modelo,
                preco = pAgendamento.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await client.PostAsync("https://aluracar.herokuapp.com/salvaragendamento", conteudo);

            pAgendamento.Confirmado = resposta.IsSuccessStatusCode;

            SalvarAgendamentoDB(pAgendamento);

            if (pAgendamento.Confirmado)
            {
                MessagingCenter.Send<Agendamento>(pAgendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }
        }

        #region Métodos Privados
        private void SalvarAgendamentoDB(Agendamento pAgendamento)
        {
            using (var connection = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(connection);
                dao.Salvar(pAgendamento);
            }
        }
        #endregion
    }
}
