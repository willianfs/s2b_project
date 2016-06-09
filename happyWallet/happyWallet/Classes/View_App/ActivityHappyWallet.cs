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
using System.Globalization;

namespace happyWallet.Classes.View_App
{
    [Activity(Label = "HappyWallet", MainLauncher = true)]
    class Main : Activity
    {

        private TextView tvMainSaldo;
        private TextView tvMainCredito;
        private TextView tvMainDebito;

        private Button btnMainConsultar;
        private Button btnMainAdicionar;

        private ListView lstMainContas;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ActivityHappyWallet);

            btnMainConsultar = FindViewById<Button>(Resource.Id.btnMainConsultar);
            btnMainAdicionar = FindViewById<Button>(Resource.Id.btnMainAdicionar);

            tvMainSaldo = FindViewById<TextView>(Resource.Id.tvMainSaldo);
            tvMainCredito = FindViewById<TextView>(Resource.Id.tvMainCredito);
            tvMainDebito = FindViewById<TextView>(Resource.Id.tvMainDebito);

            lstMainContas = FindViewById<ListView>(Resource.Id.lstMainContas);
            
            List<Saldo> mLista = new List<Saldo>();
            mLista.Add(new Saldo(new Conta(1, "Carteira", false), 10, 5));
            mLista.Add(new Saldo(new Conta(2, "Banco", true), 15, 25));
            mLista.Add(new Saldo(new Conta(3, "Alimentação", false), 73, 52));

            double credito = 0;
            double debito = 0;

            for (int i = 0; i < mLista.Count; i++)
            {

                credito += mLista[i].credito;
                debito += mLista[i].debito;

            }

            tvMainCredito.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", credito);
            tvMainDebito.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", debito);
            tvMainSaldo.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", credito - debito);

            AdapterSaldoContas mBase = new AdapterSaldoContas(mLista, this);

            lstMainContas.Adapter = mBase;

            btnMainAdicionar.Click += Adicionar_Click;
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CadastrarLancamento));
        }
    }
}