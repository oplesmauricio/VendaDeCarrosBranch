using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDeCarros.Models
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;
        public bool TemFreioAbs;
        public bool TemArCondicionado;
        public bool TemMp3Player;
        public string valorTotal;

        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }

        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Valor Total: {0}",
                    Preco
                    + (TemFreioAbs ? FREIO_ABS : 0)
                    + (TemArCondicionado ? AR_CONDICIONADO : 0)
                    + (TemMp3Player ? MP3_PLAYER : 0));
            }
        }

    }
}
