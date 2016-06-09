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
    class Categoria
    {
        [PrimaryKey, AutoIncrement]
        public int idCategoria { get; set; }
        public String nome { get; set; }

        public Categoria() { }

        public Categoria(String nome) {

            this.nome = nome;

        }

        public Categoria(int idCategoria, String nome)
        {

            this.idCategoria = idCategoria;
            this.nome = nome;

        }

        public void InsereCategoria(string descCategoria)
        {
            var db = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BD"));



            // only insert the data if it doesn't already exist
            var newCategoria = new Categoria();
            newCategoria.nome = descCategoria;
            db.Insert(newCategoria);

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
            var categorias = db.Table<Categoria>().ToList();
            foreach (var categoria in categorias)
            {
                Console.WriteLine(categoria.idCategoria + " " + categoria.nome);
            }
        }

    }
}