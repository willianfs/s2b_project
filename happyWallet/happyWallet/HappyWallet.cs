using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace happyWallet
{
    [Activity(Label = "happyWallet", MainLauncher = true, Icon = "@drawable/icon")]
    public class HappyWallet : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ActivityHappyWallet);

            ListView lstSaldoGeral = FindViewById<ListView>(Resource.Id.lstSaldoGeral);

            // create the grid item mapping
            String[] from = new String[] { "Saldo", "Crédito", "Débito" };
            int[] to = new int[] { Resource.Id.tvSaldo, Resource.Id.tvCredito, Resource.Id.tvDebito};

            // use a SimpleCursorAdapter
            lstSaldoGeral.Adapter = new SimpleCursorAdapter(this, Android.Resource.Layout.SimpleListItem1, null,from,to);
            
        }
    }
}

