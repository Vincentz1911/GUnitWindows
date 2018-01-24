using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G_Unit_Windows
{
    public partial class Form1 : Form
    {
        static int AktivKontinr = 0;
        static string KontoInfo = "";

        public Form1()
        {
            InitializeComponent();
            Size = new Size(860, 430);
            DropDownFind.SelectedIndex = 0;
            comboBoxKontoType.SelectedIndex = 0;
            DropDownSorter.SelectedIndex = 0;
            AllInvisible();
            RetKundeGruppe.Location = new Point(150, 100);
            OpretNyKundeGruppe.Location = new Point(150, 20);
            FindKundeGruppe.Location = new Point(150, 20);
            KundeMenuGruppe.Location = new Point(150, 20);
            //OpretKontoGruppe.Location = new Point(27, 265);
            TransaktionerGruppe.Location = new Point(420, 20);
            KundeListeGruppe.Location = new Point(420, 20);

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
        private void Form1_Load(object sender, EventArgs e)
        {

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
                SletKundeMenu.Visible = false;
                OpretKontoMenu.Visible = false;
            }
            else
            {
                AktivKunde.Checked = false;
                SletKundeMenu.Visible = true;
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

            if (AktivKontinr == 0)
            {
                TransaktionerGruppe.Visible = false;
            }
            else
            {
                TransaktionerGruppe.Visible = true;
            }

            //foreach (var item in KontoArray)
            //{
            //    if (Konto.kontoslutdato[count])
            //    KontiListe.Items.Add(item);
            //}

            //KontiListe.SetSelected(0, true);
            //KontiListe.SelectedIndex = KontiIndex;

        }
        private void NyKundeMenu_Click(object sender, EventArgs e)
        {
            AllInvisible();
            OpretNyKundeGruppe.Visible = true;
            AktivKontinr = 0;
        }
        private void FindKundeMenu_Click(object sender, EventArgs e)
        {
            AllInvisible();
            FindKundeGruppe.Visible = true;
            FindKundeListe.Items.Clear();
            AktivKontinr = 0;
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
                KundeMenuUpdate();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }
        private void OpretKontoMenu_Click(object sender, EventArgs e)
        {
            TransaktionerGruppe.Visible = false;
            OpretKontoGruppe.Visible = true;
        }
        private void OpretKontoKnap_Click(object sender, EventArgs e)
        {
            Konto.OpretKonto(Kunde.PK_kundenr[0], comboBoxKontoType.SelectedIndex + 1);
            KundeMenuUpdate();
            OpretKontoGruppe.Visible = false;
        }
        private void SletKontoKnap_Click(object sender, EventArgs e)
        {
            //if (Konto.saldo[])
            float saldo = Konto.CheckSaldo(AktivKontinr);
            if (saldo != 0)
            {
                MessageBox.Show("Saldoen er ikke i nul, og kan derfor ikke slettes.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Er du sikker på at du vil slette kontoen??", "Slet konto?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Konto.SletKonto(AktivKontinr);
                //KundeMenuUpdate();

                AktivKontinr = 0;
                TransaktionUpdate(AktivKontinr);
                KontoInfoBox.Clear();

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


            KundeMenuUpdate();
        }
        private void KontiListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KontiListe.SelectedItem != null)
            {
                TransaktionerGruppe.Visible = true;

                KontoInfo = KontiListe.SelectedItem.ToString();
                string[] KontoSplitArray = KontoInfo.Split(',');

                AktivKontinr = int.Parse(KontoSplitArray[0]);
                
                Konto.VisTransaktion(AktivKontinr);
                KontoInfoBox.Text = KontoInfo;
                TransaktionUpdate(AktivKontinr);

            }
        }

        private void IndbetalKnap_Click(object sender, EventArgs e)
        {
            IndtastTransaktion.Text.Replace("+", "").Replace("-", "").Replace("*", "").Replace("/", "");
            if (IndtastTransaktion.Text != "" && decimal.TryParse(IndtastTransaktion.Text, out decimal deci) && deci > 0)
            {
                Konto.IndsætBeløb(IndtastTransaktion.Text.Replace(",", "."), AktivKontinr);
                TransaktionUpdate(AktivKontinr);
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
                Konto.HævBeløb(IndtastTransaktion.Text.Replace(",", "."), AktivKontinr);
                TransaktionUpdate(AktivKontinr);
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
                Konto.OverførBeløb(AktivKontinr, OverførTilKonto.Text, IndtastTransaktion.Text);
                TransaktionUpdate(AktivKontinr);
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
            
            KontoInfoBox.Text = KontoInfo;
            KundeMenuUpdate();
            //KontiListe.SetSelected(0, true);
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Database.DataSource = "(local)";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Database.DataSource = ".\\SQLEXPRESS";
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
        private void FortrydOpretKontoKnap_Click(object sender, EventArgs e)
        {
            OpretKontoGruppe.Visible = false;
        }
        private void FortrydNavnKnap_Click(object sender, EventArgs e)
        {
            RetKundeGruppe.Visible = false;
        }


    }
}
