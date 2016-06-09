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
using SQLite;
using System.IO;

namespace happyWallet.Classes.Model
{
    class Conta
    {
        [PrimaryKey, AutoIncrement]
        public int id_conta { get; set; }
        public String descricao { get; set; }
        public bool isValorNegativo { get; set; }


        public Conta()
        {

        }

        public Conta(int pID, String pDescricao, bool pValorNegativo)
        {

            id_conta = pID;
            descricao = pDescricao;
            isValorNegativo = pValorNegativo;

        }

        public void InsereConta(string descConta, bool negativo)
        {
            var db = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BD"));
            


                // only insert the data if it doesn't already exist
                var newConta = new Conta();
                newConta.descricao = descConta;
                newConta.isValorNegativo = negativo;
                db.Insert(newConta);
            //Console.WriteLine("Reading data");
            //var table = db.Table<Conta>();
            //foreach (var s in table)
            //{
            //    Console.WriteLine(s.id_conta + " " + s.descricao + " " + s.isValorNegativo);
            //}

        }

        public void PesquisaConta()
        {
            var db = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BD"));
            // db.CreateTable<Conta>(); 
            // Conta conta = db.Get<Conta>(this.id_conta);
            //var stocksStartingWithA = db.Query<Conta>("SELECT * FROM Conta");
            var contas = db.Table<Conta>().ToList();
            foreach (var conta in contas)
            {
                Console.WriteLine(conta.id_conta + " "+ conta.descricao + " " + conta.isValorNegativo);
            }
       }
}
    }