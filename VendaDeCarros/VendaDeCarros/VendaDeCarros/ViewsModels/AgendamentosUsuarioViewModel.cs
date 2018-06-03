using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VendaDeCarros.Models;
using VendaDeCarros.Data;
using Xamarin.Forms;
using System.Linq;

namespace VendaDeCarros.ViewsModels
{
    public class AgendamentosUsuarioViewModel : ViewModelBase
    {
        private ObservableCollection<Agendamento> lista = new ObservableCollection<Agendamento>();

        public ObservableCollection<Agendamento> Lista
        {
            get
            {
                return lista;
            }
            private set
            {
                lista = value;
                OnPropertyChanged();
            }
        }

        private Agendamento agendamentoSelecionadoReenvio;

        public Agendamento AgendamentoSelecionadoReenvio
        {
            get { return agendamentoSelecionadoReenvio; }
            set
            {
                if (value != null)
                {
                    agendamentoSelecionadoReenvio = value;
                    MessagingCenter.Send<Agendamento>(agendamentoSelecionadoReenvio, "AgendamentoSelecionadoReenvio");
                }
            }
        }


        public AgendamentosUsuarioViewModel()
        {
            AtualizarLista();
            //
        }

        public void AtualizarLista()
        {
            using (var connection = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(connection);
                var listaDB = dao.Lista;

                var query =
                    listaDB.OrderBy(l => l.DataAgendamento).ThenBy(l => l.HoraAgendamento);

                this.Lista.Clear();
                foreach (var itemDB in query)
                {
                    this.Lista.Add(itemDB);
                }
            }
        }
    }
}
