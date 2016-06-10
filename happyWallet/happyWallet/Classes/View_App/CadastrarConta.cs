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
using SQLite;
using System.IO;

namespace happyWallet.Classes.View_App
{
    [Activity(Label = "CadastrarConta")]
    class CadastrarConta : Activity
    {
        Button btCriarConta;
        EditText txtNomeConta;
        CheckBox ckNegativo;
        protected override void OnCreate(Bundle bundle)
        {
            var db = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BD"));
            db.CreateTable<Conta>();

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CadastroConta);
            this.ActionBar.SetDisplayHomeAsUpEnabled(true);

            btCriarConta = FindViewById<Button>(Resource.Id.btCriarConta);

            btCriarConta.Click += btCriarConta_Click;
            txtNomeConta = FindViewById<EditText>(Resource.Id.cxtxtNomeConta);
            ckNegativo = FindViewById<CheckBox>(Resource.Id.isNegativo);

        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    Finish();
                    return true;
                default:
                    return base.OnMenuItemSelected(featureId, item);
            }
                    
        }


        void btCriarConta_Click(object sender, EventArgs e)
        {
            if(txtNomeConta.Text != "")
            {

                if (!Conta.contaExiste(txtNomeConta.Text))
                {

                    bool negativo;
                    if (ckNegativo.Checked == true)
                    {
                        negativo = true;
                    }
                    else
                        negativo = false;

                    Conta conta = new Conta(txtNomeConta.Text, negativo);

                    Conta.InsereConta(conta);

                    SetResult(Result.Ok);

                    Finish();

                }
                else
                    Toast.MakeText(this, "A conta informada já existe", ToastLength.Short).Show();

            }
           else
                Toast.MakeText(this, "Digite um nome para a conta", ToastLength.Short).Show();

        }
    }


}