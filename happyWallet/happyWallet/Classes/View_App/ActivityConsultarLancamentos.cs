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

namespace happyWallet.Classes.View_App
{
    [Activity(Label = "Lançamentos")]
    public class ActivityConsultarLancamentos : Activity
    {

        private ListView lstConsultarLancamentos;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityConsultarlancamentos);

            this.ActionBar.SetDisplayHomeAsUpEnabled(true);

            lstConsultarLancamentos = FindViewById<ListView>(Resource.Id.lstConsultarLancamentos);

            atualizarLista();



        }

        private void atualizarLista()
        {

            List<Lancamento> mLista = Lancamento.getLancamentos();

            AdapterLancamentos mBase = new AdapterLancamentos(mLista, this);

            lstConsultarLancamentos.Adapter = mBase;

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {

            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {

               Toast.MakeText(this, "Lançamento cadastrado com sucesso", ToastLength.Short).Show();
                atualizarLista();

            }

        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.menu_consulta_lancamento, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {

            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    SetResult(Result.Ok);
                    Finish();
                    return true;

                case Resource.Id.mi_Incluir:
                    StartActivityForResult(typeof(CadastrarLancamento),0);
                    return true;

                default:
                    return base.OnMenuItemSelected(featureId, item);

            }

        }

    }
}