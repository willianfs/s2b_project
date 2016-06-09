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
using happyWallet.Classes.Model;
using System.IO;

namespace happyWallet.Classes.Model
{
    class Lancamento
    {
        [PrimaryKey, AutoIncrement]
        public int idLancamento { get; set; }
        public float valor { get; set; }
        public DateTime data { get; set; }
        public String descricao { get; set; }

        public Categoria categoria { get; set; }
        public Conta conta { get; set; }

        public Lancamento(int idLancamento, float valor, DateTime data, String descricao, Categoria categoria,Conta conta)
        {

            this.idLancamento = idLancamento;
            this.valor = valor;
            this.data = data;
            this.descricao = descricao;

            this.categoria = categoria;
            this.conta = conta;

        public List<Lancamento> ListaLancamento()
        {
            var database = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.MyDocuments), "BD"));
            return database.Table<Lancamento>().ToList<Lancamento>();
        }
    }
}