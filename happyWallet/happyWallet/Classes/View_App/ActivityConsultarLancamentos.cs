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

            List<Lancamento> mLista = new List<Lancamento>();
            mLista.Add(new Lancamento(1,23, new DateTime(2016,6,3),"Cachorro Quente", 1, 1));
            mLista.Add(new Lancamento(1, 23, new DateTime(2016, 6, 4), "Cemig", 2, 1));
            mLista.Add(new Lancamento(1, 23, new DateTime(2016, 6, 5), "Cinema", 3, 1));

            AdapterLancamentos mBase = new AdapterLancamentos(mLista, this);

            lstConsultarLancamentos.Adapter = mBase;

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
                    Finish();
                    return true;

                case Resource.Id.mi_Incluir:
                    StartActivity(typeof(CadastrarLancamento));
                    return true;

                default:
                    return base.OnMenuItemSelected(featureId, item);

            }

        }

    }
}