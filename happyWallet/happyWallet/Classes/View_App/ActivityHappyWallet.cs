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

        private ListView lstMainContas;

        private int RESULT_LANCAMENTO = 0;
        private int RESULT_CONTA = 1;
        private int RESULT_CATEGORIA = 2;
        private int RESULT_Consultar = 3;

        SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

        protected override void OnCreate(Bundle bundle)
        {

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            dataBase.CreateTable<Conta>();
            dataBase.CreateTable<Lancamento>();
            dataBase.CreateTable<Categoria>();

            //InsertCategoria(dataBase);

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ActivityHappyWallet);

            btnMainConsultar = FindViewById<Button>(Resource.Id.btnMainConsultar);
            btnMainAdicionar = FindViewById<Button>(Resource.Id.btnMainAdicionar);
            btnMainAdicionarConta = FindViewById<Button>(Resource.Id.btnMainAdicionarConta);
            btnMainAdicionarCategoria = FindViewById<Button>(Resource.Id.btnMainAdicionarCategoria);

            tvMainSaldo = FindViewById<TextView>(Resource.Id.tvMainSaldo);
            tvMainCredito = FindViewById<TextView>(Resource.Id.tvMainCredito);
            tvMainDebito = FindViewById<TextView>(Resource.Id.tvMainDebito);

            lstMainContas = FindViewById<ListView>(Resource.Id.lstMainContas);
            atualizarSlados();

            btnMainConsultar.Click += Consultar_Click;
            btnMainAdicionar.Click += Adicionar_Click;
            btnMainAdicionarConta.Click += AdicionarConta_Click;
            btnMainAdicionarCategoria.Click += AdicionarCategoria_Click;

        }

        private void atualizarSlados()
        {

            List<Saldo> mListaSaldo = Saldo.getSaldosContas();
            AdapterSaldoContas mBase = new AdapterSaldoContas(mListaSaldo, this);

            lstMainContas.Adapter = mBase;

            double credito = 0;
            double debito = 0;

            for (int i = 0; i < mListaSaldo.Count; i++)
            {

                credito += mListaSaldo[i].credito;
                debito += mListaSaldo[i].debito;

            }

            tvMainCredito.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", credito);
            tvMainDebito.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", debito);
            tvMainSaldo.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", credito - debito);

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {

            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {

                if (requestCode == RESULT_LANCAMENTO) {

                    Toast.MakeText(this, "Lançamento cadastrado com sucesso", ToastLength.Short).Show();
                    atualizarSlados();

                }
                else if (requestCode == RESULT_CONTA)
                {

                    Toast.MakeText(this, "Conta cadastrada com sucesso", ToastLength.Short).Show();
                    atualizarSlados();

                }
                else if (requestCode == RESULT_CATEGORIA)
                {

                    Toast.MakeText(this, "Categoria cadastrada com sucesso", ToastLength.Short).Show();

                }
                else if (requestCode == RESULT_Consultar)
                {

                    atualizarSlados();

                }

            }

        }

        private void AdicionarCategoria_Click(object sender, EventArgs e)
        {
            StartActivityForResult(typeof(CadastrarCategoria), RESULT_CATEGORIA);
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            StartActivityForResult(typeof(ActivityConsultarLancamentos),RESULT_Consultar);
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            StartActivityForResult(typeof(CadastrarLancamento), RESULT_LANCAMENTO);
        }

        private void AdicionarConta_Click(object sender, EventArgs e)
        {
            StartActivityForResult(typeof(CadastrarConta), RESULT_CONTA);
        }

        /*public void InsertCategoria(SQLiteConnection database)
        {
            List<String> lstCategoria = new List<string> { "Entretenimento", "Alimentação", "Educação" };

            foreach (var nomeCategoria in lstCategoria)
            {
                Categoria categoria = new Categoria(nomeCategoria);
                database.Insert(categoria);

            }

            database.Dispose();
        }*/

        
    }
}