using CRUDmvvm.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRUDmvvm.Data
{
    public class CriaTabelasSqLite
    {
        public static void CriaTabelasBanco()
        {
            try
            {
                using (var conexao = DependencyService.Get<IBancoSqLite>().GetConexao())
                {
                    conexao.CreateTable<Produto>();
                }
            }
            catch (Exception ex)
            {
                _ = ex.ToString();
               
            }
        }
    }
}
