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
    class AdapterLancamentos : BaseAdapter<Lancamento>
    {

        List<Lancamento> DADOS;
        Activity C;

        public AdapterLancamentos(List<Lancamento> dados, Activity c)
        {

            DADOS = dados;
            C = c;

        }

        public override Lancamento this[int position]
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
            Categoria auxCategoria = Categoria.getCategoria(DADOS[position].idCategoria);

            if (view == null)
            {
                if(DADOS[position].tipoLancamento == 0)
                    view = C.LayoutInflater.Inflate(Resource.Layout.layout_lancamentos_debito, null);
                else
                    view = C.LayoutInflater.Inflate(Resource.Layout.layout_lancamentos_credito, null);
            }

            view.FindViewById<TextView>(Resource.Id.tvData).Text = DADOS[position].data;
            view.FindViewById<TextView>(Resource.Id.tvCategoria).Text = auxCategoria.nome;
            view.FindViewById<TextView>(Resource.Id.tvValor).Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", DADOS[position].valor);

            return view;

        }

    }

}