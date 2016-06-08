using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace happyWallet
{
    class Categoria
    {
        [PrimaryKey, AutoIncrement]
        public int idCategoria { get; set; }
        public String nome { get; set; }

    }
}