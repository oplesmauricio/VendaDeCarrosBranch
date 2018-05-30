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
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin", async (exc) =>
            {
                await DisplayAlert("Login", exc.Message, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }
    }
}