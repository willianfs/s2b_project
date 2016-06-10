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
        public String data { get; set; }
        public String descricao { get; set; }
        public int tipoLancamento { get; set; }

        public int idCategoria { get; set; }
        public int idConta { get; set; }

        public Lancamento() { }

        public Lancamento(float valor, String data, String descricao, int tipoLancamento, int idCategoria, int idConta)
        {
            
            this.valor = valor;
            this.data = data;
            this.descricao = descricao;
            this.tipoLancamento = tipoLancamento;

            this.idCategoria = idCategoria;
            this.idConta = idConta;

        }

        public static void InsereLancamento(Lancamento lancamento)
        {

            var db = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "BD"));

            db.Insert(lancamento);

        }

        public static List<Lancamento> getLancamentos()
        {
            var database = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.MyDocuments), "BD"));
            return database.Table<Lancamento>().ToList<Lancamento>();
        }
        
    }
}