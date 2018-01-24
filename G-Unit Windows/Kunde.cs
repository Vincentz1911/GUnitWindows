using System;

namespace G_Unit_Windows
{
    class Kunde
    {
        public static int[] PK_kundenr;
        public static string[] kundenavn, CPR, SQLData;
        public static DateTime?[] kundedato, kundeslutdato;
        public static string SQLSend;

        //******************* KUNDEMENU *******************
        public static void KundeMenu(int kundenr)
        {
            SQLSend = $"select * from Kunde where PK_kundenr like '{kundenr}'";
            SQLData = Database.SQLkommandoGet(SQLSend);
            ParseKunde(SQLData);
        }

        //******************* OPRET KUNDE *******************
        public static void OpretKunde(string navn, string CPRString)
        {
            //Sender data til database
            SQLSend = $"INSERT INTO Kunde values('{navn}', GetDate(), '','{CPRString}')";
            Database.SQLkommandoSet(SQLSend);
            //Modtager kundenr fra database baseret på CPR nr
            string SQLGet = $"SELECT * from Kunde where CPR = '{CPRString}';";
            SQLData = Database.SQLkommandoGet(SQLGet);
            ParseKunde(SQLData);
        }

        //******** CHECKER OM DER ER EKSISTERENDE CPR NR *********
        public static bool CheckCPR(string str)
        {
            SQLSend = $"select CPR from Kunde where CPR = '{str}'";
            SQLData = Database.SQLkommandoGet(SQLSend);
            if (SQLData.Length == 0) return true;
            else return false;
        }

        //******************* FIND KUNDE *******************
        public static void FindKunde(string str, int valg, int sorter)
        {
            //string str;
            switch (valg.ToString())
            {
                case "1": // Søger efter kundenavn
                    if (sorter == 1) SQLSend = $"select * from Kunde where kundenavn like '%{str}%'";
                    else SQLSend = $"select * from Kunde where kundenavn like '%{str}%' order by kundenavn";
                    break;

                case "2": // Søger efter kunde på kundenummer
                    if (sorter == 1) SQLSend = $"select * from Kunde where PK_kundenr like '%{str}%'";
                    else SQLSend = $"select * from Kunde where PK_kundenr like '%{str}%' order by kundenavn";
                    break;

                case "3": // Søger efter kunde baseret på kontonummer
                    if (sorter == 1) SQLSend = $"select PK_kundenr, kundenavn, kundedato, kundeslutdato, CPR from Konto, Kunde where PK_kontonr = '{str}' and PK_kundenr = FK_kundenr";
                    else SQLSend = $"select PK_kundenr, kundenavn, kundedato, kundeslutdato, CPR from Konto, Kunde where PK_kontonr = '{str}' and PK_kundenr = FK_kundenr order by kundenavn";
                    break;

                case "4": // Søger efter kunde på CPR-nummer
                    if (sorter == 1) SQLSend = $"select * from Kunde where CPR like '%{str}%'";
                    else SQLSend = $"select * from Kunde where CPR like '%{str}%' order by kundenavn";
                    break;

                default:
                    //Program.Menu();
                    break;
            }
            SQLData = Database.SQLkommandoGet(SQLSend);
            ParseKunde(SQLData);
        }

        //******************* SLET KUNDE *******************
        public static void SletKunde(string str)
        {
            SQLSend = $"UPDATE Kunde set kundeslutdato = GetDate() where PK_kundenr = '{str}';";
            Database.SQLkommandoSet(SQLSend);
            SQLSend = $"select * from Kunde where PK_kundenr like '{str}'";
            SQLData = Database.SQLkommandoGet(SQLSend);
            ParseKunde(SQLData);
        }

        public static void AktiverKunde(int kundenr)
        {
            SQLSend = $"UPDATE Kunde set kundeslutdato = '' where PK_kundenr = '{kundenr}';";
            Database.SQLkommandoSet(SQLSend);
            SQLSend = $"select * from Kunde where PK_kundenr like '{kundenr}'";
            SQLData = Database.SQLkommandoGet(SQLSend);
            ParseKunde(SQLData);
        }


        public static void RetKunde(string nytnavn, string str)
        {
            SQLSend = $"UPDATE Kunde set kundenavn = '{nytnavn}' where PK_kundenr = '{str}';";
            Database.SQLkommandoSet(SQLSend);
            SQLSend = $"select * from Kunde where PK_kundenr like '{str}'";
            SQLData = Database.SQLkommandoGet(SQLSend);
            ParseKunde(SQLData);
        }

        //******************* PARSE SQL KUNDE TIL C# *******************
        static void ParseKunde(string[] SQLData)
        {
            int count = 0;
            PK_kundenr = null;

            if (SQLData.Length != 0) //Checker at datastrømmen ikke er tom
            {
                for (int i = 0; i < SQLData.Length; i += 5)
                {
                    //Forøger arrays med 1
                    Array.Resize(ref PK_kundenr, count + 1);
                    Array.Resize(ref kundenavn, count + 1);
                    Array.Resize(ref kundedato, count + 1);
                    Array.Resize(ref kundeslutdato, count + 1);
                    Array.Resize(ref CPR, count + 1);

                    //Tager datastrømmen fra SQL og parser den med trinstørrelse af antal variabler
                    PK_kundenr[count] = int.Parse(SQLData[i]);
                    kundenavn[count] = SQLData[i + 1];
                    kundedato[count] = Convert.ToDateTime(SQLData[i + 2]);
                    if (SQLData[i + 3] != "") { kundeslutdato[count] = Convert.ToDateTime(SQLData[i + 3]); } else kundeslutdato[count] = null;
                    CPR[count] = SQLData[i + 4];
                    count++;
                }
            }
        }
    }
}