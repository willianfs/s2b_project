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
using System.Globalization;
using happyWallet.Classes.Model;

namespace happyWallet.Classes
{
    class AdapterSaldoContas : BaseAdapter<Saldo>
    {

        List<Saldo> DADOS;
        Activity C;

        public AdapterSaldoContas(List<Saldo> dados, Activity c)
        {

            DADOS = dados;
            C = c;

        }

        public override Saldo this[int position]
        {
            get
            {
                return DADOS[position];
            }
        }

        public override int Count
        {
            get
            {
                return DADOS.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, Android.Views.View convertView, ViewGroup parent)
        {

            View view = convertView;

            if (view == null)
            {
                view = C.LayoutInflater.Inflate(Resource.Layout.layout_saldo, null);
            }


            view.FindViewById<TextView>(Resource.Id.tvConta).Text = DADOS[position].conta.descricao;
            view.FindViewById<TextView>(Resource.Id.tvCredito).Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DADOS[position].credito);
            view.FindViewById<TextView>(Resource.Id.tvDebito).Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DADOS[position].debito);
            view.FindViewById<TextView>(Resource.Id.tvSaldo).Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DADOS[position].credito - DADOS[position].debito);

            return view;

        }

    }

}