using CRUDmvvm.Data;
using CRUDmvvm.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDmvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CriaTabelasSqLite.CriaTabelasBanco();
            MainPage = new NavigationPage(new ListaDeProdutos());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
