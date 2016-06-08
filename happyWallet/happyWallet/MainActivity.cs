using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;


namespace happyWallet
{
    [Activity(Label = "happyWallet", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "DB"));
 
            dataBase.CreateTable<Conta>();

            var conta = new Conta();
            conta.descricao = "Carteira";
            conta.isValorNegativo = true;

            dataBase.Insert(conta);

            dataBase.CreateTable<Categoria>();

            var categoria = new Categoria();
            categoria.nome = "Entreterimento";

            dataBase.Insert(categoria);
            var cat = dataBase.Find<Categoria>(categoria.idCategoria);
            dataBase.CreateTable<Lancamento>();

            var lancamento = new Lancamento();       

            
            lancamento.data = DateTime.Now;
            lancamento.valor = 25f;
            lancamento.descricao = "Valor gasto na compra de uma bala";
        //    lancamento.conta = new Conta();
            lancamento.categoria = cat;

            try
            {
                dataBase.Insert(lancamento);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.GetType());
            }
            

            // Set our view from the "main" layout resource
            //    SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //    Button button = FindViewById<Button>(Resource.Id.MyButton);

            //     button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}
