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

namespace happyWallet
{
    class Lancamento
    {
        public int idLancamento { get; set; }
        public float valor { get; set; }
        public DateTime data { get; set; }
        public String descricao { get; set; }

        public Categoria categoria { get; set; }

        
    }
}