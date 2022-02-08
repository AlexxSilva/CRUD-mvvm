using CRUDmvvm.aRecursos.MVVM;
using CRUDmvvm.Models;
using CRUDmvvm.SQLite;
using CRUDmvvm.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUDmvvm.ViewModels
{
    public class ListaDeProdutosViewModel : BaseViewModel
    {
        private List<Produto> _listaProdutos;
        public List<Produto> ListaProdutos
        {
            get { return _listaProdutos; }
            set
            {
                SetProperty(ref _listaProdutos, value);
            }
        }

        private string _filtroProdutos;
        public string FiltroProdutos
        {
            get { return _filtroProdutos; }
            set
            {
                SetProperty(ref _filtroProdutos, value);
            }
        }
        public ICommand NovoProdutoCommand { get; set; }
        public ICommand AlterarProdutoCommand { get; set; }

        public ICommand ExcluirProdutoCommand { get; set; }
        

        public ListaDeProdutosViewModel()
        {
            ListaProdutos = new ProdutoBD().ListarProdutos(FiltroProdutos);

            NovoProdutoCommand = new Xamarin.Forms.Command(NovoProduto);
            AlterarProdutoCommand = new Xamarin.Forms.Command(AlterarProduto);
            ExcluirProdutoCommand = new Xamarin.Forms.Command(ExcluirProduto);

            MessagingCenter.Subscribe<Produto>(this, "CarregarTela", (sender) =>
            {
                ListaProdutos = new ProdutoBD().ListarProdutos(FiltroProdutos);
            });

        }


        private async void NovoProduto()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CadastroDeProdutos());
        }

        private async void AlterarProduto(object sender)
        {
            var produto = (Produto)sender;

            await App.Current.MainPage.Navigation.PushAsync(new CadastroDeProdutos(produto));
        }

        private async void ExcluirProduto(object sender)
        {
            var produto = (Produto)sender;

            bool Ok = await App.Current.MainPage.DisplayAlert("Exclusão do produto",
                                            "Confirma a exclusão do produto " + produto.Descricao + " ?"
                                            , "Sim", "Não");

            if (Ok)
            {
                new ProdutoBD().DeleteProduto(produto);

                ListaProdutos = new ProdutoBD().ListarProdutos(FiltroProdutos);
            }
        }
    }
}
