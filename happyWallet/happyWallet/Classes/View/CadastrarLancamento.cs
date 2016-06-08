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

namespace happyWallet.Classes.View
{
    [Activity(Label = "CadastrarLancamento")]
    public class CadastrarLancamento : Activity
    {

        private Spinner spnCadastrarLancamentoConta;
        private Spinner spnCadastrarLancamentoCategoria;

        private EditText edtCadastrarLancamentoValor;
        private Button btnCadastrarLancamentoData;
        private Button btnCadastrarLancamentoHora;
        private EditText edtCadastrarLancamentoObs;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityCadastrarLancamento);

            this.ActionBar.SetDisplayHomeAsUpEnabled(true);

            spnCadastrarLancamentoConta = FindViewById<Spinner>(Resource.Id.spnCadastrarLancamentoConta);
            spnCadastrarLancamentoCategoria = FindViewById<Spinner>(Resource.Id.spnCadastrarLancamentoCategoria);

            edtCadastrarLancamentoValor = FindViewById<EditText>(Resource.Id.edtCadastrarLancamentoValor);
            btnCadastrarLancamentoData = FindViewById<Button>(Resource.Id.btnCadastrarLancamentoData);
            btnCadastrarLancamentoHora = FindViewById<Button>(Resource.Id.btnCadastrarLancamentoHora);
            edtCadastrarLancamentoObs = FindViewById<EditText>(Resource.Id.edtCadastrarLancamentoObs);

            btnCadastrarLancamentoData.Click += btnCadastrarLancamentoData_Click;
            btnCadastrarLancamentoHora.Click += (sender, e) =>
            {
                //getting values from TImePicker via CurrentHour/CurrentMinutes
                //btnCadastrarLancamentoHora.Text = String.Format("{0} : {1}", TimePicker.c.CurrentHour, picker.CurrentMinute);
            };


        }

        private void btnCadastrarLancamentoData_Click(object sender, EventArgs e)
        {
            
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
                {
                    btnCadastrarLancamentoData.Text = time.Day + "/" + time.Month + "/" + time.Year;
                });

            frag.Show(FragmentManager, DatePickerFragment.TAG);

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
        
    }

}