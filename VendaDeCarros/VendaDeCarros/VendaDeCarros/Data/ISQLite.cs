using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDeCarros.Data
{
    public interface ISQLite
    {
        SQLiteConnection PegarConexao();
    }
}
