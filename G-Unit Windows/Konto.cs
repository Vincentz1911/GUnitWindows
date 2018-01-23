using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace G_Unit_Windows
{
    class Konto
    {

        public static string[] kontoTypeNavne = { "Løn", "Opsparing", "Lån" };
        public static int _kontoNummer;

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
        private static string[] TransaktionSøger(string sql)
        {
            string SQLGet = sql;
            string[] transArr = Database.SQLkommandoGet(SQLGet);
            
            if (transArr.Length == 0)
            {
                Console.Write("Ingen transaktioner fundet!");
                return null;
            }

            int count = 0;
            string[] transArray = new string[transArr.Length/4];
            for (int i = 0; i < transArr.Length / 4; i++)
            {
                //Console.WriteLine($"Transaktions ID: {transArr[0 + count]}, Trans. dato: {transArr[1 + count]}, Beløb: {transArr[2 + count]}, Kunde nummer: {transArr[3 + count]}");
                transArray[i]=($"ID: {transArr[0 + count]}, Beløb: {transArr[2 + count]}, {transArr[1 + count]},  Kunde nummer: {transArr[3 + count]}");
                count += 4;
            }

            return transArray;
        }

        public static void OpretKonto(int kundenr, int kontoType)
        {
            int kontoNummer;

            // Opretter konto.
            string SQLSend = $"IF exists (select 1 from Kunde where PK_kundenr = '{kundenr}') insert into Konto values(0, GETDATE(), null, (select PK_kundenr from Kunde where PK_kundenr = '{kundenr}') , '{kontoType}');";
            Database.SQLkommandoSet(SQLSend);

            // Finder senest oprettet kontonr til brug i kontomenu.
            string SQLGet = $"select PK_kontonr from Konto where FK_kundenr = '{kundenr}' order by PK_kontonr desc;";
            string strKontonummer = Database.SQLkommandoGet(SQLGet)[0];
            kontoNummer = int.Parse(strKontonummer);
            _kontoNummer = kontoNummer;
        }

        public static string[] VælgKonto(int kundenr)
        {
            // Find Konti
            string SQLGet = $"select PK_kontonr, saldo, kontodato, kontoslutdato, FK_kontotypeID from Konto where FK_kundenr = {kundenr};";
            string[] kontoArr = Database.SQLkommandoGet(SQLGet);

            int count = 0;
            string[] KontoArray = new string[kontoArr.Length];

            for (int i = 0; i < kontoArr.Length/5; i ++)
            {
                Array.Resize(ref KontoArray, i + 1);
                // Check om oprettelses dato er null, erstatter med "Ingen".
                string slutdato = kontoArr[3 + count] == "" ? "Ingen" : kontoArr[3 + count];

                // Ændre konto type nr til "lån", "opsparing" etc.
                string kontotype = kontoTypeNavne[int.Parse(kontoArr[4 + count]) - 1];
                KontoArray[i] = $"{kontoArr[0 + count]}, Saldo: kr. {kontoArr[1 + count]} -- Type: {kontotype} -- Oprettet: {kontoArr[2 + count]} -- Konto slutdato: {slutdato}";
//                KontoArray[i] = $"{kontoArr[0 + count]}, Saldo: {kontoArr[1 + count]}, Oprettelses dato: {kontoArr[2 + count]}, Konto slut dato: {slutdato}, Konto Type: {kontoArr[4 + count]}";
                //Console.WriteLine($"Kontonr: {kontoArr[0 + count]}, Saldo: {kontoArr[1 + count]}, Oprettelses dato: {kontoArr[2 + count]}, Konto slut dato: {slutdato}, Konto Type: {kontotype}");
                count += 5;
            }
            return KontoArray;
        }

        public static void SletKonto(int _kontoNummer)
        {
            string SQLSend = $"if exists (select 1 from Konto where PK_kontonr = '{_kontoNummer}')  update Konto set kontoslutdato = GETDATE() where PK_kontonr = '{_kontoNummer}';";
            Database.SQLkommandoSet(SQLSend);
        }

        public static void IndsætBeløb(string strBeløb, int _kontoNummer)
        {
            string SQLSend = $"if exists (select 1 from Konto where PK_kontonr = {_kontoNummer})  update Konto set saldo = saldo + {strBeløb} where PK_kontonr = {_kontoNummer};";
            Database.SQLkommandoSet(SQLSend);
            OpretTransaktion(strBeløb, _kontoNummer);
        }

        public static void HævBeløb(string strBeløb, int _kontoNummer)
        {
            string SQLSend = $"if exists (select 1 from Konto where PK_kontonr = {_kontoNummer})  update Konto set saldo = saldo - {strBeløb} where PK_kontonr = {_kontoNummer};";
            Database.SQLkommandoSet(SQLSend);
            OpretTransaktion($"-{strBeløb}", _kontoNummer);
        }

        public static void OverførBeløb()
        {
            /*int fraKonto = _kontoNummer;
            string tilKonto = IndtastKontonummer();
            string strBeløb = IndtastBeløb();

            string SQLSend = $"update Konto set saldo = saldo - {strBeløb} where PK_kontonr = '{fraKonto}';";
            Database.SQLkommandoSet(SQLSend);

            SQLSend = $"update Konto set saldo = saldo + {strBeløb} where PK_kontonr = {tilKonto};";
            Database.SQLkommandoSet(SQLSend);

            Console.WriteLine($"{strBeløb} overført fra kontonummer '{fraKonto}' til {tilKonto};");

            // Opret af transaktion. 
            OpretTransaktion($"-{strBeløb}", fraKonto);
            OpretTransaktion($"{strBeløb}", int.Parse(tilKonto));

            Console.Write("Tryk tast for afslut.");
            Console.ReadKey();
            Console.Clear();

            KontoMenu();
            */
        }

        // Hjælpefunktion til bruger input.
        public static string IndtastKontonummer()
        {
            string kontoNummer;

            while (true)
            {
                Console.Write("Indtast Konto Nummer: ");
                kontoNummer = Console.ReadLine();

                if (!int.TryParse(kontoNummer, out var x))
                {
                    Console.Write($"\nUgyldigt Kontonummer {x}.\n");
                    continue;
                }
                break;
            }

            return kontoNummer;
        }

        // Hjælpefunktion til bruger input.
        public static string IndtastBeløb(string strBeløb)
        {
//            string ;

            while (true)
            {

                // Normalisering af beløb.
                strBeløb = strBeløb.Replace("-", "").Replace("+", "").Replace(",", ".");

                if (!float.TryParse(strBeløb, out var x))
                {
                    Console.Write($"\nUgyldigt beløb {x}.\n");
                    continue;
                }
                break;
            }
            return strBeløb;
        }

        public static void OpretTransaktion(string beløb, int kontoNummer)
        {
            string SQLSend = $"insert into Transaktion values (GETDATE(), '{beløb}', {kontoNummer}); ";
            Database.SQLkommandoSet(SQLSend);
        }
    }
}