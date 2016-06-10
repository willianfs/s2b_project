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

        public Categoria()
        {

        }

        public Categoria(String nome)
        {

            this.nome = nome;

        }

        public Categoria(int idCategoria, String nome)
        {

            this.idCategoria = idCategoria;
            this.nome = nome;

        }

        public static bool categoriaExiste(String descricaoCategoria)
        {
            bool result = false;

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            List<Categoria> lstCategoria = dataBase.Query<Categoria>("SELECT * FROM Categoria WHERE UPPER(nome) = ?", descricaoCategoria.ToUpper());

            if (lstCategoria.Count > 0) result = true;

            return result;

        }

        public static Categoria getCategoria(int idCategoria)
        {

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            List<Categoria> lstCategoria = dataBase.Query<Categoria>("SELECT * FROM Categoria WHERE idCategoria = ?", idCategoria);

            return lstCategoria[0];

        }

        public static Categoria getCategoria(String descricaoCategoria)
        {

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            List<Categoria> lstCategoria = dataBase.Query<Categoria>("SELECT * FROM Categoria WHERE UPPER(nome) = ?", descricaoCategoria.ToUpper());

            return lstCategoria[0];


        }
        public static List<String> getNomesCategoria()
        {

            SQLiteConnection dataBase = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.MyDocuments), "BD"));

            List<Categoria> lstCategoria = dataBase.Table<Categoria>().ToList();
            var lstCategoriaNome = new List<String>();
            foreach (var categoria in lstCategoria)
            {
                lstCategoriaNome.Add(categoria.nome);
            }
            return lstCategoriaNome;

        }
        public static void InsereCategoria(Categoria categoria)
        {
            var db = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BD"));
            
            db.Insert(categoria);
            
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