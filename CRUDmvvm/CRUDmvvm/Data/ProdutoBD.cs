using CRUDmvvm.Data;
using CRUDmvvm.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRUDmvvm.SQLite
{
    public class ProdutoBD
    {
        public string IncluirProduto(Produto prod)
        {
            try
            {
                using (var conexao = DependencyService.Get<IBancoSqLite>().GetConexao())
                {
                    conexao.Insert(prod);
                    return prod.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                string _E = ex.ToString(); 
                return "";
            }
        }
        public bool AlterarProduto(Produto prod)
        {
            try
            {
                using (var conexao = DependencyService.Get<IBancoSqLite>().GetConexao())
                {
                    int up = conexao.Update(prod);
                    return up == 1;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteProduto(Produto prod)
        {
            try
            {
                using (var conexao = DependencyService.Get<IBancoSqLite>().GetConexao())
                {
                    int up = conexao.Delete(prod);
                    return up == 1;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<Produto> ListarProdutos(string Descricao)
        {
            try
            {
                string _Where = "";
                if (!string.IsNullOrEmpty(Descricao))
                    _Where = "Where Descricao like '% " + Descricao +  "%'";

                using (var conexao = DependencyService.Get<IBancoSqLite>().GetConexao())
                {

                    var query = conexao.Query<Produto>("select * from Produto " + _Where);

                    return query;
                }
            }
            catch (Exception ex)
            {
                string _ex = ex.ToString();
                return null;
            }
        }
    }
}
