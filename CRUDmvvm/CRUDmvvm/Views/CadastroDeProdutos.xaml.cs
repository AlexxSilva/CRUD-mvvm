using CRUDmvvm.Models;
using CRUDmvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDmvvm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroDeProdutos : ContentPage
    {
        CadastroProdutosViewModel viewModel;
        public CadastroDeProdutos()
        {
            InitializeComponent();
            viewModel = new CadastroProdutosViewModel();
            BindingContext = viewModel;
        }

        public CadastroDeProdutos(Produto produto)
        {
            InitializeComponent();
            viewModel = new CadastroProdutosViewModel()
            {
                Id = produto.Id,
                DescricaoProduto = produto.Descricao,
                UnidadeProduto  = produto.Unidade
               
            };

            BindingContext = viewModel;
            
        }
    }
}