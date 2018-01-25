using System;
using System.Drawing;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace G_Unit_Windows
{
    public partial class Form1 : Form
    {
        static int AktivKontonr = 0;
        static string KontoInfo = "";

        Timer t = new Timer();

        public Form1()
        {
            t.Enabled = true;
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();

            InitializeComponent();
            Size = new Size(1150, 650);
            DropDownFind.SelectedIndex = 0;
            comboBoxKontoType.SelectedIndex = 0;
            DropDownSorter.SelectedIndex = 0;
            AllInvisible();

            int posX = 210, posX2 = 570;

            RetKundeGruppe.Location = new Point(posX, 145);
            OpretNyKundeGruppe.Location = new Point(posX, 20);
            FindKundeGruppe.Location = new Point(posX, 20);
            KundeMenuGruppe.Location = new Point(posX, 20);
            OpretKontoGruppe.Location = new Point(25, 287);
            TransaktionerGruppe.Location = new Point(posX2, 20);
            KundeListeGruppe.Location = new Point(posX2, 20);
            LoginBox.Location = new Point(410, 225);
            MainMenu.Visible = false;
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //            DigiClockTextBox.Text = DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss");
            DigiClockTextBox.Text = DateTime.Now.ToString();
        }

        private void AllInvisible()
        {
            OpretNyKundeGruppe.Visible = false;
            FindKundeGruppe.Visible = false;
            KundeMenuGruppe.Visible = false;
            OpretKontoGruppe.Visible = false;
            TransaktionerGruppe.Visible = false;
            KundeListeGruppe.Visible = false;
            RetKundeGruppe.Visible = false;
        }

        private void KundeMenuUpdate()
        {
            KundeNavn.Text = Kunde.kundenavn[0];
            KundeCPR.Text = Kunde.CPR[0];
            Kundenr.Text = Kunde.PK_kundenr[0].ToString();
            KundeStart.Text = Kunde.kundedato[0].ToString();

            if (Kunde.kundeslutdato[0] != null)
            {
                AktivKunde.Checked = true;
                KundeSlut.Text = Kunde.kundeslutdato[0].ToString();
                OpretKontoMenu.Visible = false;
            }
            else
            {
                AktivKunde.Checked = false;
                OpretKontoMenu.Visible = true;
                KundeSlut.Text = "";
            }

            string[] KontoArray = Konto.VælgKonto(Kunde.PK_kundenr[0]);
            KontiListe.Items.Clear();

            for (int i = 0; i < KontoArray.Length; i++)
            {
                if (Konto.kontoslutdato[i] == null)
                {
                    KontiListe.Items.Add(KontoArray[i]);
                }
            }

            if (AktivKontonr == 0) TransaktionerGruppe.Visible = false;
            else TransaktionerGruppe.Visible = true;

        }
        private void OpretKundeMenu_Click(object sender, EventArgs e)
        {
            AllInvisible();
            OpretNyKundeGruppe.Visible = true;
            AktivKontonr = 0;
        }
        private void OpretKundeKnap_Click(object sender, EventArgs e)
        {

            if (OpretKundeNavn.Text == "")
            {
                MessageBox.Show("Navnet mangler. Prøv igen.");
                return;
            }

            if (OpretKundeCPR.Text.Length != 10 || !(Int64.TryParse(OpretKundeCPR.Text, out Int64 CPRnr)))
            {
                MessageBox.Show("CPR nummeret er ugyldigt. Prøv igen.");
                return;
            }

            bool checkCPR = Kunde.CheckCPR(OpretKundeCPR.Text);
            if (!checkCPR)
            {
                MessageBox.Show("CPR nummeret eksisterer allerede!");
                OpretKundeCPR.Clear();
                return;
            }

            Kunde.OpretKunde(OpretKundeNavn.Text, OpretKundeCPR.Text);
            OpretKundeNavn.Clear(); OpretKundeCPR.Clear();
            AllInvisible();
            KundeMenuGruppe.Visible = true;
            KundeMenuUpdate();
        }
        private void SletKundeMenu_Click(object sender, EventArgs e)
        {
            if (KontiListe.Items.Count > 0)
            {
                MessageBox.Show("Kunden kan ikke slettes da der stadig er aktive konti.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Ønsker du at slette kunden " + Kunde.kundenavn[0] + " (kundenr: " + Kunde.PK_kundenr[0] + ")?", "Slet kunde?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Kunde.SletKunde(Kunde.PK_kundenr[0].ToString());

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            KundeMenuUpdate();
        }
        private void AktivKunde_CheckedChanged(object sender, EventArgs e)
        {
            if (AktivKunde.Checked == true)
            {
                if (KontiListe.Items.Count > 0)
                {
                    MessageBox.Show("Kunden kan ikke slettes da der stadig er aktive konti.");
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Ønsker du at slette kunden " + Kunde.kundenavn[0] + " (kundenr: " + Kunde.PK_kundenr[0] + ")?", "Slet kunde?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Kunde.SletKunde(Kunde.PK_kundenr[0].ToString());

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                KundeMenuUpdate();
            }

            else
            {
                Kunde.AktiverKunde(Kunde.PK_kundenr[0]);
                KundeMenuUpdate();
            }

            //
        }
        private void RetKundeMenu_Click(object sender, EventArgs e)
        {
            RetKundeNavn.Text = Kunde.kundenavn[0];
            RetKundeGruppe.Visible = true;
        }
        private void RetKundeKnap_Click(object sender, EventArgs e)
        {
            if (RetKundeNavn.Text != "")
            {
                Kunde.RetKunde(RetKundeNavn.Text, Kunde.PK_kundenr[0].ToString());
                RetKundeGruppe.Visible = false;
                KundeMenuUpdate();
            }
            else MessageBox.Show("Navn kan ikke være tomt! Prøv igen.");
        }
        private void FortrydNavnKnap_Click(object sender, EventArgs e)
        {
            RetKundeGruppe.Visible = false;
        }

        private void FindKundeMenu_Click(object sender, EventArgs e)
        {
            AllInvisible();
            FindKundeGruppe.Visible = true;
            FindKundeListe.Items.Clear();
            AktivKontonr = 0;
        }
        private void FindKundeKnap_Click(object sender, EventArgs e)
        {
            FindKundeListe.Items.Clear();
            Kunde.FindKunde(FindKundeSøg.Text, DropDownFind.SelectedIndex + 1, DropDownSorter.SelectedIndex + 1);

            if (Kunde.PK_kundenr == null)
            {
                MessageBox.Show("Ingen kunder fundet");
                FindKundeSøg.Clear();
                return;
            }

            if (Kunde.PK_kundenr.Length == 1)
            {
                FindKundeListe.Items.Clear();
                AllInvisible();
                KundeMenuGruppe.Visible = true;
                KundeMenuUpdate();
            }
            else
            {
                KundeListeGruppe.Visible = true;
                for (int i = 0; i < Kunde.PK_kundenr.Length; i++)
                {
                    string str = Kunde.PK_kundenr[i] + "-" + Kunde.kundenavn[i] + "-" + Kunde.CPR[i];
                    if (Kunde.kundeslutdato[i] != null) str += " - Slettet";
                    FindKundeListe.Items.Add(str);
                }

                //FindKundeListe.Visible = true;
            }
        }
        private void FindKundeListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FindKundeListe.SelectedItem != null)
            {
                string[] FindKundeSplitArray = FindKundeListe.SelectedItem.ToString().Split('-');
                Kunde.FindKunde(FindKundeSplitArray[0], 2, 1);
                FindKundeListe.Items.Clear();
                AllInvisible();
                KundeMenuGruppe.Visible = true;
                KundeMenuUpdate();
            }
        }

        private void OpretKontoMenu_Click(object sender, EventArgs e)
        {
            OpretKontoGruppe.Visible = true;
        }
        private void OpretKontoKnap_Click(object sender, EventArgs e)
        {
            Konto.OpretKonto(Kunde.PK_kundenr[0], comboBoxKontoType.SelectedIndex + 1);
            KundeMenuUpdate();
            OpretKontoGruppe.Visible = false;
        }
        private void FortrydOpretKontoKnap_Click(object sender, EventArgs e)
        {
            OpretKontoGruppe.Visible = false;
        }
        private void SletKontoKnap_Click(object sender, EventArgs e)
        {
            //if (Konto.saldo[])
            float saldo = Konto.CheckSaldo(AktivKontonr);
            if (saldo != 0)
            {
                MessageBox.Show("Saldoen er ikke i nul, og kan derfor ikke slettes.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Er du sikker på at du vil slette kontoen??", "Slet konto?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Konto.SletKonto(AktivKontonr);

                AktivKontonr = 0;
                TransaktionUpdate(AktivKontonr);
                KontoInfoBox.Clear();
                KundeMenuUpdate();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


            //KundeMenuUpdate();
        }
        private void KontiListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KontiListe.SelectedItem != null)
            {
                TransaktionerGruppe.Visible = true;

                KontoInfo = KontiListe.SelectedItem.ToString();
                string[] KontoSplitArray = KontoInfo.Split(',');
                AktivKontonr = int.Parse(KontoSplitArray[0]);
                KontoInfoBox.Text = KontoInfo;


                Konto.VisTransaktion(AktivKontonr);

                TransaktionUpdate(AktivKontonr);

            }
        }

        private void IndbetalKnap_Click(object sender, EventArgs e)
        {
            IndtastTransaktion.Text.Replace("+", "").Replace("-", "").Replace("*", "").Replace("/", "");
            if (IndtastTransaktion.Text != "" && decimal.TryParse(IndtastTransaktion.Text, out decimal deci) && deci > 0)
            {
                Konto.IndsætBeløb(IndtastTransaktion.Text.Replace(",", "."), AktivKontonr);
                TransaktionUpdate(AktivKontonr);
            }
            else
            {
                MessageBox.Show("Ukendt beløb. Prøv igen");
                OverførTilKonto.Clear();
            }
        }
        private void UdbetalKnap_Click(object sender, EventArgs e)
        {
            //IndtastTransaktion.Text.Replace("-", "");
            if (IndtastTransaktion.Text != "" && decimal.TryParse(IndtastTransaktion.Text, out decimal deci) && deci > 0)
            {
                Konto.HævBeløb(IndtastTransaktion.Text.Replace(",", "."), AktivKontonr);
                TransaktionUpdate(AktivKontonr);
            }
            else
            {
                MessageBox.Show("Ukendt beløb. Prøv igen");
                OverførTilKonto.Clear();
            }

        }
        private void OverførKnap_Click(object sender, EventArgs e)
        {
            IndtastTransaktion.Text.Replace("+", "").Replace("-", "").Replace("*", "").Replace("/", "");
            if (OverførTilKonto.Text != "" && decimal.TryParse(OverførTilKonto.Text, out decimal deci) && IndtastTransaktion.Text != "" && decimal.TryParse(IndtastTransaktion.Text, out deci) && deci > 0)
            {
                Konto.OverførBeløb(AktivKontonr, OverførTilKonto.Text, IndtastTransaktion.Text);
                TransaktionUpdate(AktivKontonr);
            }
            else
            {
                MessageBox.Show("Ukendt beløb eller kontonr. Prøv igen");
                OverførTilKonto.Clear();
            }

        }
        private void TransaktionUpdate(int KontiIndex)
        {
            IndtastTransaktion.Clear();
            string[] transarray = Konto.VisTransaktion(KontiIndex);

            TransaktionsListe.Items.Clear();
            if (transarray != null)
            {
                foreach (var item in transarray)
                {
                    TransaktionsListe.Items.Add(item);
                }
            }
            SaldoBox.Text = Konto.CheckSaldo(AktivKontonr).ToString();
            KundeMenuUpdate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Database.DataSource = "(local)";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Database.DataSource = ".\\SQLEXPRESS";
        }

        private SoundPlayer Player = new SoundPlayer();
        private void Music_CheckedChanged(object sender, EventArgs e)
        {
            if (Music.Checked)
            {
                Player.SoundLocation = @"intro.wav";
                Player.PlayLooping();
            }
            else
            {
                Player.Stop();
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private void Opret_Click(object sender, EventArgs e)
        {
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, Brugerpassword.Text);

            // Check if user already exists.
            string SQLGet = $"select 1 from BrugerLogin where Loginnavn = '{Brugernavn.Text}';";
            if (Database.SQLkommandoGet(SQLGet).Length > 0)
            {
                MessageBox.Show("Brugernavn optaget!");
                return;
            }

            // Else create user with password.
            string SQLSend = $"insert into BrugerLogin values ('{Brugernavn.Text}', '{hash}')";
            Database.SQLkommandoSet(SQLSend);

            MessageBox.Show("Bruger Oprettet!");
        }
        private void Login_Click(object sender, EventArgs e)
        {
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, Brugerpassword.Text);

            string SQLGet = $"select 1 from BrugerLogin where Loginnavn = '{Brugernavn.Text}' and Loginpassword = '{hash}';";

            if (Database.SQLkommandoGet(SQLGet).Length <= 0)
            {
                MessageBox.Show("Login failed!");
                return;
            }

            MessageBox.Show("Login success!!");
            LoginBox.Visible = false;
            MainMenu.Visible = true;

        }
    }
}
