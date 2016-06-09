using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace happyWallet.Classes.Model
{
    class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "DB2"));

            dataBase.CreateTable<Conta>();
            dataBase.CreateTable<Lancamento>();
            dataBase.CreateTable<Categoria>();

            InsertCategoria(dataBase);       

            /*
            List<Lancamento> lstLancamento = dataBase.Table<Lancamento>().ToList();

            foreach (var item in lstLancamento)
            {
                Console.WriteLine("Lançamento {0}", item.idLancamento);
            }

            var lancamento = new Lancamento();

            Categoria categoria = new Categoria();
            categoria.nome = "Alimentação";
            dataBase.Insert(categoria);
            Categoria getCategoria = dataBase.Get<Categoria>(categoria.idCategoria);

            Conta conta = new Conta();
            conta.descricao = "Poupança";
            conta.isValorNegativo = false;
            dataBase.Insert(conta);
            Conta getConta = dataBase.Get<Conta>(conta.id_conta);

            lancamento.data = "";
            lancamento.valor = 1000f;
            lancamento.descricao = "Valor referente a venda de bala";
            lancamento.idConta = getCategoria.idCategoria;
            lancamento.idCategoria = getConta.id_conta;

            try
            {
                dataBase.Insert(lancamento);
                Console.WriteLine("Inserido com sucesso");

                foreach (var item in lstLancamento)
                {
                    Console.WriteLine("Lançamento {0}", item.idLancamento);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.GetType().ToString());
            }

        */

        }

        public void InsertCategoria(SQLiteConnection database)
        {
            List<String> lstCategoria = new List<string> { "Entretenimento", "Alimentação", "Educação" };

            foreach (var nomeCategoria in lstCategoria)
            {
                Categoria categoria = new Categoria(nomeCategoria);
                database.Insert(categoria);

            }

            database.Dispose();
        }


    }
}
