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
    class Saldo
    {

        public Conta conta { get; set; }
        public double credito { get; set; }
        public double debito { get; set; }

        public Saldo()
        {

        }

        public Saldo(Conta pConta, double pCredito, double pDebito)
        {

            conta = pConta;
            credito = pCredito;
            debito = pDebito;
        }

        public static Saldo getSaldo(String descConta)
        {

            var database = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.MyDocuments), "BD"));
            
            Saldo saldo = new Saldo();
            saldo.conta = Conta.getConta(descConta);

            List<Lancamento> lstLancamento = database.Query<Lancamento>("SELECT * FROM Lancamento WHERE idConta = ?", saldo.conta.id_conta);
            foreach (var lancamento in lstLancamento)
            {

                if (lancamento.tipoLancamento == 0)
                {

                    saldo.debito += lancamento.valor;

                }
                else
                    saldo.credito += lancamento.valor;


            }

            return saldo;

        }

        public static List<Saldo> getSaldosContas()
        {

            var database = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.MyDocuments), "BD"));

            List<Conta> listaConta = new Conta().FindAll();
            List<Saldo> listaSaldo = new List<Saldo>();

            foreach (var conta in listaConta)
            {
                Saldo saldo = new Saldo();
                saldo.conta = conta;

                List<Lancamento> lstLancamento = database.Query<Lancamento>("SELECT * FROM Lancamento WHERE idConta = ?", conta.id_conta);
                foreach (var lancamento in lstLancamento)
                {

                    if(lancamento.tipoLancamento == 0)
                    {

                        saldo.debito+= lancamento.valor;

                    }
                    else
                        saldo.credito += lancamento.valor;


                }

                listaSaldo.Add(saldo);

            }

            return listaSaldo;
        }

    }

}