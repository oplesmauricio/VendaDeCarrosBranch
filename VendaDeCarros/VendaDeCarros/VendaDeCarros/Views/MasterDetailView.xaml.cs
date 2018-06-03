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
        //excluir esse ctor
        public MasterDetailView()
        {
            InitializeComponent();
            this.Usuario.Nome = "x";
            this.Master = new MasterView(this.Usuario);
            this.Detail = new NavigationPage(new ListagemView(this.Usuario));
        }

        public MasterDetailView (Usuario pUsuario)
		{
			InitializeComponent ();
            this.Usuario = pUsuario;
            this.Master = new MasterView(pUsuario);
            this.Detail = new NavigationPage(new ListagemView(pUsuario));
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "MeusAgendamentos", (msg) =>
            {
                this.Detail = new NavigationPage(new AgendamentosUsuarioView());
                this.IsPresented = false;
            }
                        );

            MessagingCenter.Subscribe<Usuario>(this, "NovoAgendamento", (msg) =>
            {
                this.Detail = new NavigationPage(new ListagemView(this.Usuario));
                this.IsPresented = false;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Usuario>(this, "MeusAgendamentos");
        }
    }
}