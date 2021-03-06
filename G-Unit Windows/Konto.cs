﻿using System;

namespace G_Unit_Windows
{
    class Konto
    {
        public static string[] kontoTypeNavne = { "Løn", "Opsparing", "Lån" };
        public static int _kontoNummer;
        static string SQLSend;
        static string[] SQLData;

        private static void FindTransaktion()
        {
            Console.Clear();

            Console.Write("1) Søg med dato\n2) Søg med Trans.ID\n3) Søg med beløb\n");
            string valg = Console.ReadLine();
            Console.Clear();

            switch (valg)
            {
                case "1":
                    Console.Write("Søg \"fra\" dato (YYYY-MM-DD): ");
                    string datofra = Console.ReadLine();
                    Console.Write("Søg \"til\" dato (YYYY-MM-DD): ");
                    string datotil = Console.ReadLine();
                    TransaktionSøger($"select * from Transaktion where FK_kontonr = '{_kontoNummer}' and transdato >= convert(datetime, '{datofra}') and transdato <= convert(datetime, '{datotil}');");
                    break;
                case "2":
                    Console.Write("Indtast Transaktions ID: ");
                    string ID = Console.ReadLine();
                    TransaktionSøger($"select * from Transaktion where FK_kontonr = '{_kontoNummer}' and PK_transID = '{ID}'");
                    break;
                case "3":
                    Console.Write("Søg \"fra\". beløb: ");
                    string min = Console.ReadLine();
                    Console.Write("Søg \"til\". beløb: ");
                    string max = Console.ReadLine();
                    TransaktionSøger($"select * from Transaktion where FK_kontonr = '{_kontoNummer}' and beloeb > '{min}' and beloeb < '{max}';");
                    break;
                default:

                    break;
            }

            Console.Write("\nTryk tast.");
            Console.ReadKey();


        }

        public static string[] VisTransaktion(int _kontoNummer)
        {
            return TransaktionSøger($"select * from Transaktion where FK_kontonr = '{_kontoNummer}';");
        }

        // Hjælpefunktion til transaktion søgning.
        private static string[] TransaktionSøger(string SQLSend)
        {
            //string SQLGet = sql;
            SQLData = Database.SQLkommandoGet(SQLSend);

            if (SQLData.Length == 0)
            {
                return null;
            }

            int count = 0;
            string[] transArray = new string[SQLData.Length / 4];
            for (int i = 0; i < SQLData.Length / 4; i++)
            {
                //Console.WriteLine($"Transaktions ID: {transArr[0 + count]}, Trans. dato: {transArr[1 + count]}, Beløb: {transArr[2 + count]}, Kunde nummer: {transArr[3 + count]}");
                transArray[i] = ($"ID: {SQLData[0 + count]}, Beløb: {SQLData[2 + count]}, {SQLData[1 + count]},  Kontonr: {SQLData[3 + count]}");
                count += 4;
            }

            return transArray;
        }

        public static void OpretKonto(int kundenr, int kontoType)
        {
            int kontoNummer;

            // Opretter konto.
            SQLSend = $"IF exists (select 1 from Kunde where PK_kundenr = '{kundenr}') insert into Konto values(0, GETDATE(), null, (select PK_kundenr from Kunde where PK_kundenr = '{kundenr}') , '{kontoType}');";
            Database.SQLkommandoSet(SQLSend);

            // Finder senest oprettet kontonr til brug i kontomenu.
            SQLSend = $"select PK_kontonr from Konto where FK_kundenr = '{kundenr}' order by PK_kontonr desc;";
            SQLData = Database.SQLkommandoGet(SQLSend);
            kontoNummer = int.Parse(SQLData[0]);
            _kontoNummer = kontoNummer;
        }

        public static string[] VælgKonto(int kundenr)
        {
            // Find Konti
            SQLSend = $"select PK_kontonr, saldo, kontodato, kontoslutdato, FK_kontotypeID, kontotypenavn, rente from Konto, KontoType where FK_kundenr = {kundenr} and PK_kontotypeID = FK_kontotypeID;";
            SQLData = Database.SQLkommandoGet(SQLSend);

            int count = 0;
            string[] KontoArray = new string[SQLData.Length];

            ParseKonto(SQLData);

            for (int i = 0; i < SQLData.Length / 7; i++)
            {
                Array.Resize(ref KontoArray, i + 1);
                // Check om oprettelses dato er null, erstatter med "Ingen".
                string slutdato = SQLData[3 + count] == "" ? "Ingen" : SQLData[3 + count];

                // Ændre konto type nr til "lån", "opsparing" etc.
                string kontotype = kontoTypeNavne[int.Parse(SQLData[4 + count]) - 1];
                KontoArray[i] = $"{SQLData[0 + count]}, Saldo: kr. {SQLData[1 + count]} -- Type: {SQLData[5 + count]} Rente: {SQLData[6 + count]}% -- \n Oprettet: {SQLData[2 + count]} -- Konto slutdato: {slutdato}";
                count += 7;
            }
            return KontoArray;
        }

        public static decimal[] rente;
        public static float[] saldo;
        public static int[] PK_kontonr, FK_kontotypeID;
        public static DateTime?[] kontodato, kontoslutdato;
        public static string[] kontotypenavn;

        static void ParseKonto(string[] SQLData)
        {
            int count = 0;
            for (int i = 0; i < SQLData.Length; i += 7)
            {
                //PK_kontonr, saldo, kontodato, kontoslutdato, FK_kontotypeID
                //Forøger arrays med 1
                Array.Resize(ref PK_kontonr, count + 1);
                Array.Resize(ref saldo, count + 1);
                Array.Resize(ref kontodato, count + 1);
                Array.Resize(ref kontoslutdato, count + 1);
                Array.Resize(ref FK_kontotypeID, count + 1);
                Array.Resize(ref kontotypenavn, count + 1);
                Array.Resize(ref rente, count + 1);

                //Tager datastrømmen fra SQL og parser den med trinstørrelse af antal variabler
                PK_kontonr[count] = int.Parse(SQLData[i]);
                saldo[count] = float.Parse(SQLData[i + 1]);
                kontodato[count] = Convert.ToDateTime(SQLData[i + 2]);
                if (SQLData[i + 3] != "") { kontoslutdato[count] = Convert.ToDateTime(SQLData[i + 3]); } else kontoslutdato[count] = null;
                FK_kontotypeID[count] = int.Parse(SQLData[i + 4]);
                kontotypenavn[count] = SQLData[i + 5];
                rente[count] = decimal.Parse(SQLData[i + 6]);

                count++;
            }
        }

        public static void SletKonto(int _kontoNummer)
        {
            SQLSend = $"if exists (select 1 from Konto where PK_kontonr = '{_kontoNummer}')  update Konto set kontoslutdato = GETDATE() where PK_kontonr = '{_kontoNummer}';";
            Database.SQLkommandoSet(SQLSend);
        }

        public static void IndsætBeløb(string strBeløb, int _kontoNummer)
        {
            SQLSend = $"if exists (select 1 from Konto where PK_kontonr = {_kontoNummer})  update Konto set saldo = saldo + {strBeløb} where PK_kontonr = {_kontoNummer};";
            Database.SQLkommandoSet(SQLSend);
            OpretTransaktion(strBeløb, _kontoNummer);
        }

        public static void HævBeløb(string strBeløb, int _kontoNummer)
        {
            SQLSend = $"if exists (select 1 from Konto where PK_kontonr = {_kontoNummer})  update Konto set saldo = saldo - {strBeløb} where PK_kontonr = {_kontoNummer};";
            Database.SQLkommandoSet(SQLSend);
            OpretTransaktion($"-{strBeløb}", _kontoNummer);
        }

        public static void OverførBeløb(int fraKonto, string tilKonto, string strBeløb)
        {
            SQLSend = $"update Konto set saldo = saldo - {strBeløb} where PK_kontonr = '{fraKonto}';";
            Database.SQLkommandoSet(SQLSend);

            SQLSend = $"select 1 from Konto where PK_kontonr = {tilKonto};";
            SQLData = Database.SQLkommandoGet(SQLSend);

            if (SQLData.Length != 0)
            {
                SQLSend = $"update Konto set saldo = saldo + {strBeløb} where PK_kontonr = {tilKonto};";
                Database.SQLkommandoSet(SQLSend);
                SQLSend = $"insert into Transaktion values (GETDATE(), '{strBeløb}', {tilKonto}); ";
                Database.SQLkommandoSet(SQLSend);
            }
            else
            {
                SQLSend = $"insert into Transaktion values (GETDATE(), '{strBeløb}', null); ";
                Database.SQLkommandoSet(SQLSend);
            }
            //Opret af transaktion. 
            OpretTransaktion($"-{strBeløb}", fraKonto);
            //OpretTransaktion($"{strBeløb}", int.Parse(tilKonto));
        }

        public static float CheckSaldo(int str)
        {
            string SQLGet = $"select saldo from Konto where PK_Kontonr = {str}";
            string[] saldo = Database.SQLkommandoGet(SQLGet);
            float floatSaldo = float.Parse(saldo[0]);
            return floatSaldo;
        }

        public static void OpretTransaktion(string beløb, int kontoNummer)
        {
            string SQLSend = $"insert into Transaktion values (GETDATE(), '{beløb}', {kontoNummer}); ";
            Database.SQLkommandoSet(SQLSend);
        }
    }
}