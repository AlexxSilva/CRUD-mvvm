using CRUDmvvm.aRecursos.MVVM;
using CRUDmvvm.Models;
using CRUDmvvm.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUDmvvm.ViewModels
{
    public class CadastroProdutosViewModel : BaseViewModel
    {

        //private Produto _produto;
        //public Produto Produto
        //{
        //    get { return _produto; }
        //    set
        //    {
        //        SetProperty(ref _produto, value);
        //    }
        //}

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                SetProperty(ref _Id, value);
            }
        }

        private string _descricaoProduto;
        public string DescricaoProduto
        {
            get { return _descricaoProduto; }
            set
            {
                SetProperty(ref _descricaoProduto, value);
            }
        }

        private string _unidadeProduto;
        public string UnidadeProduto
        {
            get { return _unidadeProduto; }
            set
            {
                SetProperty(ref _unidadeProduto, value);
            }
        }

        public ICommand OkCommand { get; set; }
        public ICommand CancelarCommand { get; set; }

        public CadastroProdutosViewModel()
        {
            OkCommand = new Xamarin.Forms.Command(Ok);
            CancelarCommand = new Xamarin.Forms.Command(Cancelar);
        }

        private void Ok()
        {

            if (Id == 0)
            {
                Produto prod = new Produto
                {
                    Descricao = DescricaoProduto,
                    Unidade = UnidadeProduto
                };
                
                
                new ProdutoBD().IncluirProduto(prod);
                MessagingCenter.Send<Produto>(prod, "CarregarTela");
            }
            else
            {
                Produto prod = new Produto
                {
                    Id = Id,
                    Descricao = DescricaoProduto,
                    Unidade = UnidadeProduto
                };

                new ProdutoBD().AlterarProduto(prod);
                MessagingCenter.Send<Produto>(prod, "CarregarTela");
            }

           

            App.Current.MainPage.Navigation.PopAsync();
        }

        private void Cancelar()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
