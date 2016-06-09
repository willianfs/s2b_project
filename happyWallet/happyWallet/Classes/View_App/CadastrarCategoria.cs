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
    [Activity(Label = "CadastrarCategoria")]
    class CadastrarCategoria : Activity
    {
        Button btCriarCategoria;
        EditText txtNomeCategoria;

        protected override void OnCreate(Bundle bundle)
        {
            var db = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BD"));
            db.CreateTable<Categoria>();

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CadastrarCategoria);
            this.ActionBar.SetDisplayHomeAsUpEnabled(true);

            btCriarCategoria = FindViewById<Button>(Resource.Id.btCriarCategoria);

            btCriarCategoria.Click += btCriarCategoria_Click;
            txtNomeCategoria = FindViewById<EditText>(Resource.Id.cxtxtNomeCategoria);
            
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


        void btCriarCategoria_Click(object sender, EventArgs e)
        {
            if(txtNomeCategoria.Text != "")
            {
                
                Categoria categoria = new Categoria();

                categoria.InsereCategoria(txtNomeCategoria.Text);

                Toast.MakeText(this, "Cadastrado com sucesso", ToastLength.Short).Show();
                txtNomeCategoria.Text = "";
            }
           else
                Toast.MakeText(this, "Digite um nome para a categoria", ToastLength.Short).Show();

        }
    }


}