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

        public Conta(String descricao, bool isValorNegativo)
        {
            
            this.descricao = descricao;
            this.isValorNegativo = isValorNegativo;

        }

        public Conta(int id_conta, String descricao, bool isValorNegativo)
        {

            this.id_conta = id_conta;
            this.descricao = descricao;
            this.isValorNegativo = isValorNegativo;

        }

        public static bool contaExiste(String descricaoConta)
        {
            bool result = false;

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            List<Conta> lstConta = dataBase.Query<Conta>("SELECT * FROM Conta WHERE UPPER(descricao) = ?", descricaoConta.ToUpper());

            if (lstConta.Count > 0) result = true;

            return result;

        }

        public static Conta getConta(String descricaoConta)
        {

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            List<Conta> lstConta = dataBase.Query<Conta>("SELECT * FROM Conta WHERE UPPER(descricao) = ?", descricaoConta.ToUpper());
            
            return lstConta[0];

        }

        public static Conta getConta(int id_conta)
        {

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            List<Conta> lstConta = dataBase.Query<Conta>("SELECT * FROM Conta WHERE id_conta = ?", id_conta);

            return lstConta[0];

        }

        public static List<String> getNomesConta()
        {

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            List<Conta> lstConta = dataBase.Table<Conta>().ToList();
            var lstContaNome = new List<String>();
            foreach (var conta in lstConta)
            {
                lstContaNome.Add(conta.descricao);
            }
            return lstContaNome;
        }

        public static void InsereConta(Conta conta)
        {

            var db = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BD"));
            
            db.Insert(conta);

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

       public List<Conta> FindAll()
        {
            var db = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BD"));
            return db.Table<Conta>().ToList();
        }

       
    }
}