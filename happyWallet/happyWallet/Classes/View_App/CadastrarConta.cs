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

namespace happyWallet.Classes.View_App
{
    [Activity(Label = "CadastrarConta")]
    class CadastrarConta : Activity
    {
        Button btCriarConta;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CadastroConta);
            this.ActionBar.SetDisplayHomeAsUpEnabled(true);

            btCriarConta = FindViewById<Button>(Resource.Id.btCriarConta);

            btCriarConta.Click += btCriarConta_Click;
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

        }
    }


}