using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDmvvm.Data
{
    public interface IBancoSqLite
    {
        SQLiteConnection GetConexao();
    }
}
