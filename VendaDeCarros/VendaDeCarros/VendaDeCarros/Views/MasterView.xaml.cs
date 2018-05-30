using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaDeCarros.Models;
using VendaDeCarros.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendaDeCarros.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterView : TabbedPage
	{
		public MasterView (Usuario pUsuario)
		{
			InitializeComponent ();
            this.BindingContext = new MasterViewModel(pUsuario);
		}

        protected override void OnAppearing()
        {
            AssinarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "PageEditarPerfil", (pUsuario) =>
            {
                this.CurrentPage = this.Children[1];
            });

            MessagingCenter.Subscribe<Usuario>(this, "SucessoSalvarUsuario", (pUsuario) =>
            {
                this.CurrentPage = this.Children[0];
            });
        }

        protected override void OnDisappearing()
        {
            CancelarMensagens();
        }

        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "PageEditarPerfil");
            MessagingCenter.Unsubscribe<Usuario>(this, "SucessoSalvarUsuario");
        }
    }
}