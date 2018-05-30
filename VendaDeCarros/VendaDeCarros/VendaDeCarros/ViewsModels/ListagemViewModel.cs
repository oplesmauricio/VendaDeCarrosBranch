using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VendaDeCarros.Models;
using Xamarin.Forms;

namespace VendaDeCarros.ViewsModels
{
    public class ListagemViewModel : ViewModelBase
    {
        public ObservableCollection<Veiculo> Veiculos { get; set; }

        private Veiculo veiculoSelecionado;

        public Veiculo VeiculoSelecionado
        {
            get { return veiculoSelecionado; }
            set
            {
                veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        private bool aguarda;

        public bool Aguarda
        {
            get { return aguarda; }
            set
            {
                aguarda = value;
                OnPropertyChanged();
            }
        }


        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculos()
        {
            Aguarda = true;
            HttpClient client = new HttpClient();
            var resultado = await client.GetStringAsync("http://aluracar.herokuapp.com");
            
            var veiculoJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            foreach ( var veiculos in veiculoJson)
            {
                this.Veiculos.Add(new Veiculo
                {
                    Nome = veiculos.nome,
                    Preco = veiculos.preco
                });
            }

            Aguarda = false;
        }
    }

    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
