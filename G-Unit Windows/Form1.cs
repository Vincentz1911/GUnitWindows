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
            FindKundeListe.Location = new Point(600, 50);
            TransaktionsListe.Location = new Point(600, 50);
        }

        private void AllInvisible()
        {
            OpretNyKundeGruppe.Visible = false;
            FindKundeGruppe.Visible = false;
            KundeMenuGruppe.Visible = false;
            OpretNyKontoGruppe.Visible = false;
            FindKundeListe.Visible = false;
            TransaktionsListe.Visible = false;

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
                    string str = Kunde.kundenavn[i] + " " + Kunde.CPR[i];
                    FindKundeListe.Items.Add(str);
                }
                FindKundeListe.Visible = true;
            }
        }

        void FindKundeListe_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = FindKundeListe.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(index.ToString());
            }
        }

        private void FindKundeListe_SelectedIndexChanged(object sender, EventArgs e)
        {

            MessageBox.Show(FindKundeListe.SelectedItem.ToString());
        }

        private void KundeMenuUpdate()
        {
            KundeNavn.Text = Kunde.kundenavn[0];
            KundeCPR.Text = Kunde.CPR[0];
            Kundenr.Text = Kunde.PK_kundenr[0].ToString();
            KundeStart.Text = Kunde.kundedato[0].ToString();
            KundeSlut.Text = Kunde.kundeslutdato[0].ToString();

            comboBoxKonti.Items.Add("");

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
            OpretNyKontoGruppe.Visible = false;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FindKundeSøg_TextChanged(object sender, EventArgs e)
        {

        }
        private void DropDownFind_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void KundeNavn_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpretKundeNavn_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpretKundeCPR_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
