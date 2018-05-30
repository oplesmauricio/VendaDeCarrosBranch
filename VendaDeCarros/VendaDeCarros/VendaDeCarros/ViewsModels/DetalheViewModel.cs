using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using VendaDeCarros.Models;
using Xamarin.Forms;

namespace VendaDeCarros.ViewsModels
{
    public class DetalheViewModel : ViewModelBase
    {
        public Veiculo Veiculo { get; set; }

        public string TextoFreioAbs
        {
            get
            {
                return string.Format("Freio ABS - R$ {0},00", Veiculo.FREIO_ABS);
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar condicionado - R$ {0},00", Veiculo.AR_CONDICIONADO);
            }
        }

        public string TextoMp3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0},00", Veiculo.MP3_PLAYER);
            }
        }

        public bool TemFreioAbs
        {
            get
            {
                return Veiculo.TemFreioAbs;
            }
            set
            {
                Veiculo.TemFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMp3Player
        {
            get
            {
                return Veiculo.TemMp3Player;
            }
            set
            {
                Veiculo.TemMp3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }

        public ICommand ProximoCommand { get; set; }

        public DetalheViewModel(Veiculo pVeiculo)
        {
            this.Veiculo = pVeiculo;
            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(pVeiculo, "ProximoCommand");
            });
        }
    }
}
