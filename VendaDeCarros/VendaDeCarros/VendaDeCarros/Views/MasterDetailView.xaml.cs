using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaDeCarros.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendaDeCarros.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetailView : MasterDetailPage
	{
        public readonly Usuario Usuario;

        public MasterDetailView (Usuario pUsuario)
		{
			InitializeComponent ();
            this.Usuario = pUsuario;
            this.Master = new MasterView(pUsuario);
		}
	}
}