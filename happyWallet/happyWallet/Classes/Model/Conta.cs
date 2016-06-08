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

namespace happyWallet.Classes.Model
{
    class Conta
    {
        [PrimaryKey, AutoIncrement]
        public int id_conta { get; set; }
        public String descricao { get; set; }
        public bool isValorNegativo { get; set; }

        public Conta(int pID, String pDescricao, bool pValorNegativo)
        {

            id_conta = pID;
            descricao = pDescricao;
            isValorNegativo = pValorNegativo;

        }

    }
}