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
    [Activity(Label = "CadastrarLancamento")]
    public class CadastrarLancamento : Activity
    {

        private Spinner spnCadastrarLancamentoConta;
        private Spinner spnCadastrarLancamentoCategoria;
        private Spinner spnCadastrarLancamentoTipo;

        private EditText edtCadastrarLancamentoValor;
        private Button btnCadastrarLancamentoData;
        private TimePicker pckCadastrarLancamento;
        private EditText edtCadastrarLancamentoObs;

        SQLiteConnection database = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.MyDocuments), "BD"));

        protected override void OnCreate(Bundle savedInstanceState)
        {
            

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityCadastrarLancamento);

            this.ActionBar.SetDisplayHomeAsUpEnabled(true);

            spnCadastrarLancamentoConta = FindViewById<Spinner>(Resource.Id.spnCadastrarLancamentoConta);
            spnCadastrarLancamentoCategoria = FindViewById<Spinner>(Resource.Id.spnCadastrarLancamentoCategoria);
            spnCadastrarLancamentoTipo = FindViewById<Spinner>(Resource.Id.spnCadastrarLancamentoTipo);

            var adapterConta = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, Conta.getNomesConta());
            spnCadastrarLancamentoConta.Adapter = adapterConta;
            
            var adapterCategoria = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, Categoria.getNomesCategoria());
            spnCadastrarLancamentoCategoria.Adapter = adapterCategoria;

            String[] itens = { "Débito", "Crédito" };
            var adapterTipo = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, itens);
            spnCadastrarLancamentoTipo.Adapter = adapterTipo;

            edtCadastrarLancamentoValor = FindViewById<EditText>(Resource.Id.edtCadastrarLancamentoValor);
            btnCadastrarLancamentoData = FindViewById<Button>(Resource.Id.btnCadastrarLancamentoData);
            pckCadastrarLancamento = FindViewById<TimePicker>(Resource.Id.pckCadastrarLancamento);
            edtCadastrarLancamentoObs = FindViewById<EditText>(Resource.Id.edtCadastrarLancamentoObs);

            btnCadastrarLancamentoData.Click += btnCadastrarLancamentoData_Click;
            
        }

        private void btnCadastrarLancamentoData_Click(object sender, EventArgs e)
        {
            
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
                {
                    btnCadastrarLancamentoData.Text = time.Day + "/" + time.Month + "/" + time.Year;
                });

            frag.Show(FragmentManager, DatePickerFragment.TAG);

        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.menu_cadastramento_lancamento, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {

            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                case Resource.Id.mi_Salvar:
                    
                    Conta auxConta = Conta.getConta(spnCadastrarLancamentoConta.SelectedItem.ToString());
                    Categoria auxCategoria = Categoria.getCategoria(spnCadastrarLancamentoCategoria.SelectedItem.ToString());
                    Saldo saldo = Saldo.getSaldo(auxConta.descricao);
                    float valor = float.Parse(edtCadastrarLancamentoValor.Text);

                    Console.Write(auxConta.isValorNegativo.ToString() + " --- " + ((saldo.credito - saldo.debito) < valor).ToString());

                    if (auxConta.isValorNegativo && ((saldo.credito - saldo.debito) < valor && spnCadastrarLancamentoTipo.SelectedItemPosition == 0))
                    {

                        Toast.MakeText(this, "Sem saldo para a conta selecionada", ToastLength.Short).Show();

                    } else
                    {

                        Lancamento lancamento = new Lancamento(valor,
                                                                btnCadastrarLancamentoData.Text,
                                                                edtCadastrarLancamentoObs.Text,
                                                                spnCadastrarLancamentoTipo.SelectedItemPosition,
                                                                auxConta.id_conta,
                                                                auxCategoria.idCategoria);

                        Lancamento.InsereLancamento(lancamento);

                        SetResult(Result.Ok);

                        Finish();
                        
                    }
                    return true;

                default:
                    return base.OnMenuItemSelected(featureId, item);

            }

        }
        
    }

}