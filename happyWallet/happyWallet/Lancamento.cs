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
using happyWallet.Classes.Model;

namespace happyWallet
{
    class Lancamento
    {
        [PrimaryKey, AutoIncrement]
        public int idLancamento { get; set; }
        public float valor { get; set; }
        public DateTime data { get; set; }
        public String descricao { get; set; }

        public Categoria categoria { get; set; }
        public Conta conta { get; set; }


    }
}