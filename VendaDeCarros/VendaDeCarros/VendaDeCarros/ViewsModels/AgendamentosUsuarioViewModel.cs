using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VendaDeCarros.Models;
using VendaDeCarros.Data;
using Xamarin.Forms;

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

        public AgendamentosUsuarioViewModel()
        {
            using (var connection = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(connection);
                var listaDB = dao.Lista;
                this.Lista.Clear();
                foreach(var itemDB in listaDB)
                {
                    this.Lista.Add(itemDB);
                }
            }
            //
        }

    }
}
