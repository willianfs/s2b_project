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
using happyWallet.Classes.Model;

namespace happyWallet.Classes
{
    class Saldo
    {

        public Conta conta { get; set; }
        public double credito { get; set; }
        public double debito { get; set; }

        public Saldo(Conta pConta, double pCredito, double pDebito)
        {

            conta = pConta;
            credito = pCredito;
            debito = pDebito;
            
        }

    }

}