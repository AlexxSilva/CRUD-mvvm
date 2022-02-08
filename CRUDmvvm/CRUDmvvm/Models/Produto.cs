using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDmvvm.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
    }
}
