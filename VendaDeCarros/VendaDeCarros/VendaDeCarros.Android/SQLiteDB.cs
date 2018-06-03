using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using VendaDeCarros.Data;
using VendaDeCarros.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDB))]
namespace VendaDeCarros.Droid
{
    public class SQLiteDB : ISQLite
    {
        private const string NOME_ARQUIVO_DB = "Agendamento.db3";

        public SQLiteConnection PegarConexao()
        {
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, NOME_ARQUIVO_DB);

            return new SQLite.SQLiteConnection(caminhoDB);
        }
    }
}