using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendaDeCarros.Models;

namespace VendaDeCarros.Data
{
    class AgendamentoDAO
    {
        private readonly SQLiteConnection connection;

        private List<Agendamento> list;

        public List<Agendamento> Lista
        {
            get
            {
                return connection.Table<Agendamento>().ToList();
            }
            private set
            {
                list = value;
            }
        }


        public AgendamentoDAO(SQLiteConnection connection)
        {
            this.connection = connection;
            this.connection.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento pAgendamento)
        {
            connection.Insert(pAgendamento);
        }
    }
}
