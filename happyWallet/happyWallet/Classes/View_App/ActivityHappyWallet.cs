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
using SQLite;
using System.IO;

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
        private Button btnMainAdicionarConta;
        private Button btnMainAdicionarCategoria;
       
        protected override void OnCreate(Bundle bundle)
        {

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            dataBase.CreateTable<Conta>();
            dataBase.CreateTable<Lancamento>();
            dataBase.CreateTable<Categoria>();

            InsertCategoria(dataBase);

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ActivityHappyWallet);

            btnMainConsultar = FindViewById<Button>(Resource.Id.btnMainConsultar);
            btnMainAdicionar = FindViewById<Button>(Resource.Id.btnMainAdicionar);
            btnMainAdicionarConta = FindViewById<Button>(Resource.Id.btnMainAdicionarConta);
            btnMainAdicionarCategoria = FindViewById<Button>(Resource.Id.btnMainAdicionarCategoria);

            tvMainSaldo = FindViewById<TextView>(Resource.Id.tvMainSaldo);
            tvMainCredito = FindViewById<TextView>(Resource.Id.tvMainCredito);
            tvMainDebito = FindViewById<TextView>(Resource.Id.tvMainDebito);

            //lstMainContas = FindViewById<ListView>(Resource.Id.lstMainContas);
            
            /*
            List<Saldo> mLista = new List<Saldo>();
            mLista.Add(new Saldo(new Conta(1, "Carteira", false), 10, 5));
            mLista.Add(new Saldo(new Conta(2, "Banco", true), 15, 25));
            mLista.Add(new Saldo(new Conta(3, "Alimentação", false), 73, 52));
            */

            double credito = 0;
            double debito = 0;

            /*
            for (int i = 0; i < mLista.Count; i++)
            {

                credito += mLista[i].credito;
                debito += mLista[i].debito;

            }
            */

            tvMainCredito.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", credito);
            tvMainDebito.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", debito);
            tvMainSaldo.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", credito - debito);

            //  AdapterSaldoContas mBase = new AdapterSaldoContas(mLista, this);

            //  lstMainContas.Adapter = mBase;

            btnMainConsultar.Click += Consultar_Click;
            btnMainAdicionar.Click += Adicionar_Click;
            btnMainAdicionarConta.Click += AdicionarConta_Click;
            btnMainAdicionarCategoria.Click += AdicionarCategoria_Click;

        }

        private void AdicionarCategoria_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CadastrarCategoria));
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ActivityConsultarLancamentos));
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CadastrarLancamento));
        }

        private void AdicionarConta_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CadastrarConta));
        }

        public void InsertCategoria(SQLiteConnection database)
        {
            List<String> lstCategoria = new List<string> { "Entretenimento", "Alimentação", "Educação" };

            foreach (var nomeCategoria in lstCategoria)
            {
                Categoria categoria = new Categoria(nomeCategoria);
                database.Insert(categoria);

            }

            database.Dispose();
        }
    }
}