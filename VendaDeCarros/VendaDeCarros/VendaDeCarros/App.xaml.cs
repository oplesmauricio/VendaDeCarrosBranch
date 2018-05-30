﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendaDeCarros.Models;
using VendaDeCarros.Views;
using Xamarin.Forms;

namespace VendaDeCarros
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new LoginView();
            //MainPage = new MasterDetailView();
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            MessagingCenter.Subscribe<Usuario>(this, "Sucesso", (usuario) =>
            {
                //MainPage = new NavigationPage(new ListagemView());
                MainPage = new MasterDetailView(usuario);
            });
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
