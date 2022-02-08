using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CRUDmvvm.Data;
using CRUDmvvm.Droid.SQlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(BancoSqLite))]
namespace CRUDmvvm.Droid.SQlite
{

    public class BancoSqLite : IBancoSqLite
    {
        public SQLiteConnection GetConexao()
        {
            try
            {
                string arquivodb = "mvvm.db3";
                string caminho = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                //string caminho = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path);

                string local = Path.Combine(caminho, arquivodb);

                SQLiteConnection conexao = new SQLiteConnection(local);
                return conexao;


            }
            catch (Exception ex)
            {
                string d = ex.ToString();
                return null;
            }
        }
    }
}