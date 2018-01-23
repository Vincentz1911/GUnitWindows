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


        public Form1()
        {
            InitializeComponent();
            DropDownFind.SelectedIndex = 0;
            comboBoxKontoType.SelectedIndex = 0;
            AllInvisible();
            OpretNyKundeGruppe.Location = new Point(200, 50);
            FindKundeGruppe.Location = new Point(200, 50);
            KundeMenuGruppe.Location = new Point(200, 50);
            OpretNyKontoGruppe.Location = new Point(200, 400);
            FindKundeListe.Location = new Point(500, 50);
            //TransaktionsListe.Location = new Point(600, 50);
            TransaktionerGruppe.Location = new Point(500, 50);
        }

        private void AllInvisible()
        {
            OpretNyKundeGruppe.Visible = false;
            FindKundeGruppe.Visible = false;
            KundeMenuGruppe.Visible = false;
            OpretNyKontoGruppe.Visible = false;
            FindKundeListe.Visible = false;
            //TransaktionsListe.Visible = false;
            TransaktionerGruppe.Visible = false;
        }

        private void NyKundeMenu_Click(object sender, EventArgs e)
        {
            AllInvisible();
            OpretNyKundeGruppe.Visible = true;
        }
        private void FindKundeMenu_Click(object sender, EventArgs e)
        {
            AllInvisible();
            FindKundeGruppe.Visible = true;
            FindKundeListe.Items.Clear();
        }

        private void OpretKundeKnap_Click(object sender, EventArgs e)
        {
            Kunde.OpretKunde(OpretKundeNavn.Text, OpretKundeCPR.Text);
            OpretKundeNavn.Clear(); OpretKundeCPR.Clear();
            AllInvisible();
            KundeMenuGruppe.Visible = true;
            KundeMenuUpdate();
        }

        private void FindKundeKnap_Click(object sender, EventArgs e)
        {
            FindKundeListe.Items.Clear();
            Kunde.FindKunde(FindKundeSøg.Text, DropDownFind.SelectedIndex + 1);

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
                for (int i = 0; i < Kunde.PK_kundenr.Length; i++)
                {
                    string str = Kunde.PK_kundenr[i] + "-" + Kunde.kundenavn[i] + "-" + Kunde.CPR[i];
                    FindKundeListe.Items.Add(str);
                }
                FindKundeListe.Visible = true;
            }
        }

        private void FindKundeListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] FindKundeSplitArray = FindKundeListe.SelectedItem.ToString().Split('-');
            Kunde.FindKunde(FindKundeSplitArray[0], 2);
            FindKundeListe.Items.Clear();
            AllInvisible();
            KundeMenuGruppe.Visible = true;
            KundeMenuUpdate();           
        }

        private void KundeMenuUpdate()
        {

            KundeNavn.Text = Kunde.kundenavn[0];
            KundeCPR.Text = Kunde.CPR[0];
            Kundenr.Text = Kunde.PK_kundenr[0].ToString();
            KundeStart.Text = Kunde.kundedato[0].ToString();

            if (Kunde.kundeslutdato[0] != null)
            {
                KundeSlut.Text = Kunde.kundeslutdato[0].ToString();
                SletKundeMenu.Visible = false;
                OpretKontoMenu.Visible = false;
            }
            else
            {
                SletKundeMenu.Visible = true;
                OpretKontoMenu.Visible = true;
                KundeSlut.Text = "";
            }

            string[] KontoArray = Konto.VælgKonto(Kunde.PK_kundenr[0]);
            KontiListe.Items.Clear();
            foreach (var item in KontoArray)
            {
                KontiListe.Items.Add(item);
            }

            //KontiListe.SetSelected(0, true);
            //KontiListe.SelectedIndex = KontiIndex;

        }

        private void SletKundeMenu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ønsker du at slette kunden " + Kunde.kundenavn[0] + " (" + Kunde.PK_kundenr[0] + ")?", "Slet kunde?", MessageBoxButtons.YesNo);
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
            OpretNyKontoGruppe.Visible = true;
        }

        private void OpretKontoKnap_Click(object sender, EventArgs e)
        {
            Konto.OpretKonto(Kunde.PK_kundenr[0], comboBoxKontoType.SelectedIndex + 1);
            KundeMenuUpdate();
            OpretNyKontoGruppe.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void KontiListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            TransaktionerGruppe.Visible = true;

            string[] KontoSplitArray = KontiListe.SelectedItem.ToString().Split(',');

            AktivKontinr = int.Parse(KontoSplitArray[0]);

            Konto.VisTransaktion(AktivKontinr);
            TransaktionUpdate(AktivKontinr);
        }

        private void IndbetalKnap_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(KontiListe.SelectedItem.ToString());
            //string[] KontoSplitArray = KontiListe.SelectedItem.ToString().Split(',');
            Konto.IndsætBeløb(IndtastTransaktion.Text, AktivKontinr);
            TransaktionUpdate(AktivKontinr);
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
            KundeMenuUpdate();
            //KontiListe.SetSelected(0, true);
        }

        private void UdbetalKnap_Click(object sender, EventArgs e)
        {
            //string[] KontoSplitArray = KontiListe.SelectedItem.ToString().Split(',');
            Konto.HævBeløb(IndtastTransaktion.Text, AktivKontinr);
            TransaktionUpdate(AktivKontinr);

        }

        private void SletKontoKnap_Click(object sender, EventArgs e)
        {
            Konto.SletKonto(AktivKontinr);
        }
    }
}
