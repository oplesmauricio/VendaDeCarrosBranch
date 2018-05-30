using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDeCarros.Models
{
    public class ListagemVeiculos
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemVeiculos()
        {
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "carro1", Preco = 10000},
                new Veiculo { Nome = "carro2", Preco = 11000},
                new Veiculo { Nome = "carro3", Preco = 12000},
                new Veiculo { Nome = "carro4", Preco = 13000},
                new Veiculo { Nome = "carro5", Preco = 14000},
                new Veiculo { Nome = "carro6", Preco = 15000}
            };
        }
    }
}
