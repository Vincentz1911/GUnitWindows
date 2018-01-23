namespace G_Unit_Windows
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NyKundeMenu = new System.Windows.Forms.Button();
            this.FindKundeMenu = new System.Windows.Forms.Button();
            this.SletKundeMenu = new System.Windows.Forms.Button();
            this.OpretKundeNavn = new System.Windows.Forms.TextBox();
            this.OpretKundeCPR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OpretKundeKnap = new System.Windows.Forms.Button();
            this.OpretNyKundeGruppe = new System.Windows.Forms.GroupBox();
            this.FindKundeGruppe = new System.Windows.Forms.GroupBox();
            this.DropDownFind = new System.Windows.Forms.ComboBox();
            this.FindKundeKnap = new System.Windows.Forms.Button();
            this.FindKundeSøg = new System.Windows.Forms.TextBox();
            this.FindKundeListe = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.KundeMenuGruppe = new System.Windows.Forms.GroupBox();
            this.OpretKontoMenu = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxKonti = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Kundenr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.KundeSlut = new System.Windows.Forms.TextBox();
            this.KundeStart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.KundeCPR = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.KundeNavn = new System.Windows.Forms.TextBox();
            this.comboBoxKontoType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.OpretKontoKnap = new System.Windows.Forms.Button();
            this.OpretNyKontoGruppe = new System.Windows.Forms.GroupBox();
            this.TransaktionsListe = new System.Windows.Forms.ListBox();
            this.OpretNyKundeGruppe.SuspendLayout();
            this.FindKundeGruppe.SuspendLayout();
            this.KundeMenuGruppe.SuspendLayout();
            this.OpretNyKontoGruppe.SuspendLayout();
            this.SuspendLayout();
            // 
            // NyKundeMenu
            // 
            this.NyKundeMenu.Location = new System.Drawing.Point(16, 49);
            this.NyKundeMenu.Margin = new System.Windows.Forms.Padding(4);
            this.NyKundeMenu.Name = "NyKundeMenu";
            this.NyKundeMenu.Size = new System.Drawing.Size(165, 28);
            this.NyKundeMenu.TabIndex = 0;
            this.NyKundeMenu.Text = "Ny kunde";
            this.NyKundeMenu.UseVisualStyleBackColor = true;
            this.NyKundeMenu.Click += new System.EventHandler(this.NyKundeMenu_Click);
            // 
            // FindKundeMenu
            // 
            this.FindKundeMenu.Location = new System.Drawing.Point(16, 85);
            this.FindKundeMenu.Margin = new System.Windows.Forms.Padding(4);
            this.FindKundeMenu.Name = "FindKundeMenu";
            this.FindKundeMenu.Size = new System.Drawing.Size(165, 28);
            this.FindKundeMenu.TabIndex = 1;
            this.FindKundeMenu.Text = "Find kunde";
            this.FindKundeMenu.UseVisualStyleBackColor = true;
            this.FindKundeMenu.Click += new System.EventHandler(this.FindKundeMenu_Click);
            // 
            // SletKundeMenu
            // 
            this.SletKundeMenu.Location = new System.Drawing.Point(201, 174);
            this.SletKundeMenu.Margin = new System.Windows.Forms.Padding(4);
            this.SletKundeMenu.Name = "SletKundeMenu";
            this.SletKundeMenu.Size = new System.Drawing.Size(121, 28);
            this.SletKundeMenu.TabIndex = 2;
            this.SletKundeMenu.Text = "Slet kunde";
            this.SletKundeMenu.UseVisualStyleBackColor = true;
            this.SletKundeMenu.Click += new System.EventHandler(this.SletKundeMenu_Click);
            // 
            // OpretKundeNavn
            // 
            this.OpretKundeNavn.Location = new System.Drawing.Point(99, 43);
            this.OpretKundeNavn.Margin = new System.Windows.Forms.Padding(4);
            this.OpretKundeNavn.Name = "OpretKundeNavn";
            this.OpretKundeNavn.Size = new System.Drawing.Size(211, 22);
            this.OpretKundeNavn.TabIndex = 3;
            this.OpretKundeNavn.TextChanged += new System.EventHandler(this.OpretKundeNavn_TextChanged);
            // 
            // OpretKundeCPR
            // 
            this.OpretKundeCPR.Location = new System.Drawing.Point(99, 75);
            this.OpretKundeCPR.Margin = new System.Windows.Forms.Padding(4);
            this.OpretKundeCPR.Name = "OpretKundeCPR";
            this.OpretKundeCPR.Size = new System.Drawing.Size(211, 22);
            this.OpretKundeCPR.TabIndex = 4;
            this.OpretKundeCPR.TextChanged += new System.EventHandler(this.OpretKundeCPR_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Navn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "CPR";
            // 
            // OpretKundeKnap
            // 
            this.OpretKundeKnap.Location = new System.Drawing.Point(210, 105);
            this.OpretKundeKnap.Margin = new System.Windows.Forms.Padding(4);
            this.OpretKundeKnap.Name = "OpretKundeKnap";
            this.OpretKundeKnap.Size = new System.Drawing.Size(100, 28);
            this.OpretKundeKnap.TabIndex = 7;
            this.OpretKundeKnap.Text = "Opret kunde";
            this.OpretKundeKnap.UseVisualStyleBackColor = true;
            this.OpretKundeKnap.Click += new System.EventHandler(this.OpretKundeKnap_Click);
            // 
            // OpretNyKundeGruppe
            // 
            this.OpretNyKundeGruppe.Controls.Add(this.OpretKundeNavn);
            this.OpretNyKundeGruppe.Controls.Add(this.OpretKundeKnap);
            this.OpretNyKundeGruppe.Controls.Add(this.OpretKundeCPR);
            this.OpretNyKundeGruppe.Controls.Add(this.label2);
            this.OpretNyKundeGruppe.Controls.Add(this.label1);
            this.OpretNyKundeGruppe.Location = new System.Drawing.Point(200, 50);
            this.OpretNyKundeGruppe.Margin = new System.Windows.Forms.Padding(4);
            this.OpretNyKundeGruppe.Name = "OpretNyKundeGruppe";
            this.OpretNyKundeGruppe.Padding = new System.Windows.Forms.Padding(4);
            this.OpretNyKundeGruppe.Size = new System.Drawing.Size(350, 150);
            this.OpretNyKundeGruppe.TabIndex = 8;
            this.OpretNyKundeGruppe.TabStop = false;
            this.OpretNyKundeGruppe.Text = "Opret ny kunde";
            this.OpretNyKundeGruppe.Visible = false;
            // 
            // FindKundeGruppe
            // 
            this.FindKundeGruppe.Controls.Add(this.DropDownFind);
            this.FindKundeGruppe.Controls.Add(this.FindKundeKnap);
            this.FindKundeGruppe.Controls.Add(this.FindKundeSøg);
            this.FindKundeGruppe.Controls.Add(this.label4);
            this.FindKundeGruppe.Location = new System.Drawing.Point(200, 250);
            this.FindKundeGruppe.Name = "FindKundeGruppe";
            this.FindKundeGruppe.Size = new System.Drawing.Size(350, 150);
            this.FindKundeGruppe.TabIndex = 10;
            this.FindKundeGruppe.TabStop = false;
            this.FindKundeGruppe.Text = "Find kunde";
            // 
            // DropDownFind
            // 
            this.DropDownFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDownFind.FormattingEnabled = true;
            this.DropDownFind.Items.AddRange(new object[] {
            "Navn",
            "Kundenr",
            "Kontonr",
            "CPRnr"});
            this.DropDownFind.Location = new System.Drawing.Point(99, 34);
            this.DropDownFind.Name = "DropDownFind";
            this.DropDownFind.Size = new System.Drawing.Size(211, 24);
            this.DropDownFind.TabIndex = 11;
            this.DropDownFind.SelectedIndexChanged += new System.EventHandler(this.DropDownFind_SelectedIndexChanged);
            // 
            // FindKundeKnap
            // 
            this.FindKundeKnap.Location = new System.Drawing.Point(210, 96);
            this.FindKundeKnap.Margin = new System.Windows.Forms.Padding(4);
            this.FindKundeKnap.Name = "FindKundeKnap";
            this.FindKundeKnap.Size = new System.Drawing.Size(100, 28);
            this.FindKundeKnap.TabIndex = 8;
            this.FindKundeKnap.Text = "Find Kunde";
            this.FindKundeKnap.UseVisualStyleBackColor = true;
            this.FindKundeKnap.Click += new System.EventHandler(this.FindKundeKnap_Click);
            // 
            // FindKundeSøg
            // 
            this.FindKundeSøg.Location = new System.Drawing.Point(99, 66);
            this.FindKundeSøg.Margin = new System.Windows.Forms.Padding(4);
            this.FindKundeSøg.Name = "FindKundeSøg";
            this.FindKundeSøg.Size = new System.Drawing.Size(211, 22);
            this.FindKundeSøg.TabIndex = 8;
            this.FindKundeSøg.TextChanged += new System.EventHandler(this.FindKundeSøg_TextChanged);
            // 
            // FindKundeListe
            // 
            this.FindKundeListe.FormattingEnabled = true;
            this.FindKundeListe.ItemHeight = 16;
            this.FindKundeListe.Location = new System.Drawing.Point(967, 50);
            this.FindKundeListe.Name = "FindKundeListe";
            this.FindKundeListe.Size = new System.Drawing.Size(274, 340);
            this.FindKundeListe.TabIndex = 12;
            this.FindKundeListe.SelectedIndexChanged += new System.EventHandler(this.FindKundeListe_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Søg";
            // 
            // KundeMenuGruppe
            // 
            this.KundeMenuGruppe.Controls.Add(this.OpretKontoMenu);
            this.KundeMenuGruppe.Controls.Add(this.label9);
            this.KundeMenuGruppe.Controls.Add(this.comboBoxKonti);
            this.KundeMenuGruppe.Controls.Add(this.label8);
            this.KundeMenuGruppe.Controls.Add(this.Kundenr);
            this.KundeMenuGruppe.Controls.Add(this.SletKundeMenu);
            this.KundeMenuGruppe.Controls.Add(this.label7);
            this.KundeMenuGruppe.Controls.Add(this.label6);
            this.KundeMenuGruppe.Controls.Add(this.KundeSlut);
            this.KundeMenuGruppe.Controls.Add(this.KundeStart);
            this.KundeMenuGruppe.Controls.Add(this.label5);
            this.KundeMenuGruppe.Controls.Add(this.KundeCPR);
            this.KundeMenuGruppe.Controls.Add(this.label3);
            this.KundeMenuGruppe.Controls.Add(this.KundeNavn);
            this.KundeMenuGruppe.Location = new System.Drawing.Point(600, 50);
            this.KundeMenuGruppe.Name = "KundeMenuGruppe";
            this.KundeMenuGruppe.Size = new System.Drawing.Size(350, 340);
            this.KundeMenuGruppe.TabIndex = 13;
            this.KundeMenuGruppe.TabStop = false;
            this.KundeMenuGruppe.Text = "Kundemenu";
            // 
            // OpretKontoMenu
            // 
            this.OpretKontoMenu.Location = new System.Drawing.Point(201, 290);
            this.OpretKontoMenu.Margin = new System.Windows.Forms.Padding(4);
            this.OpretKontoMenu.Name = "OpretKontoMenu";
            this.OpretKontoMenu.Size = new System.Drawing.Size(121, 28);
            this.OpretKontoMenu.TabIndex = 15;
            this.OpretKontoMenu.Text = "Opret Ny Konto";
            this.OpretKontoMenu.UseVisualStyleBackColor = true;
            this.OpretKontoMenu.Click += new System.EventHandler(this.OpretKontoMenu_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 239);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Konti";
            // 
            // comboBoxKonti
            // 
            this.comboBoxKonti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKonti.FormattingEnabled = true;
            this.comboBoxKonti.Location = new System.Drawing.Point(23, 259);
            this.comboBoxKonti.Name = "comboBoxKonti";
            this.comboBoxKonti.Size = new System.Drawing.Size(299, 24);
            this.comboBoxKonti.TabIndex = 17;
            this.comboBoxKonti.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Kundenr";
            // 
            // Kundenr
            // 
            this.Kundenr.Location = new System.Drawing.Point(88, 33);
            this.Kundenr.Name = "Kundenr";
            this.Kundenr.ReadOnly = true;
            this.Kundenr.Size = new System.Drawing.Size(234, 22);
            this.Kundenr.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Slut";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Start";
            // 
            // KundeSlut
            // 
            this.KundeSlut.Location = new System.Drawing.Point(88, 145);
            this.KundeSlut.Name = "KundeSlut";
            this.KundeSlut.ReadOnly = true;
            this.KundeSlut.Size = new System.Drawing.Size(234, 22);
            this.KundeSlut.TabIndex = 12;
            // 
            // KundeStart
            // 
            this.KundeStart.Location = new System.Drawing.Point(88, 117);
            this.KundeStart.Name = "KundeStart";
            this.KundeStart.ReadOnly = true;
            this.KundeStart.Size = new System.Drawing.Size(234, 22);
            this.KundeStart.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "CPR";
            // 
            // KundeCPR
            // 
            this.KundeCPR.Location = new System.Drawing.Point(88, 89);
            this.KundeCPR.Name = "KundeCPR";
            this.KundeCPR.ReadOnly = true;
            this.KundeCPR.Size = new System.Drawing.Size(234, 22);
            this.KundeCPR.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Navn";
            // 
            // KundeNavn
            // 
            this.KundeNavn.Location = new System.Drawing.Point(88, 61);
            this.KundeNavn.Name = "KundeNavn";
            this.KundeNavn.ReadOnly = true;
            this.KundeNavn.Size = new System.Drawing.Size(234, 22);
            this.KundeNavn.TabIndex = 0;
            this.KundeNavn.TextChanged += new System.EventHandler(this.KundeNavn_TextChanged);
            // 
            // comboBoxKontoType
            // 
            this.comboBoxKontoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKontoType.FormattingEnabled = true;
            this.comboBoxKontoType.Items.AddRange(new object[] {
            "Løn",
            "Opsparing",
            "Lån"});
            this.comboBoxKontoType.Location = new System.Drawing.Point(23, 55);
            this.comboBoxKontoType.Name = "comboBoxKontoType";
            this.comboBoxKontoType.Size = new System.Drawing.Size(299, 24);
            this.comboBoxKontoType.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 35);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Konto type";
            // 
            // OpretKontoKnap
            // 
            this.OpretKontoKnap.Location = new System.Drawing.Point(201, 86);
            this.OpretKontoKnap.Margin = new System.Windows.Forms.Padding(4);
            this.OpretKontoKnap.Name = "OpretKontoKnap";
            this.OpretKontoKnap.Size = new System.Drawing.Size(121, 28);
            this.OpretKontoKnap.TabIndex = 20;
            this.OpretKontoKnap.Text = "Opret Konto";
            this.OpretKontoKnap.UseVisualStyleBackColor = true;
            this.OpretKontoKnap.Click += new System.EventHandler(this.OpretKontoKnap_Click);
            // 
            // OpretNyKontoGruppe
            // 
            this.OpretNyKontoGruppe.Controls.Add(this.OpretKontoKnap);
            this.OpretNyKontoGruppe.Controls.Add(this.comboBoxKontoType);
            this.OpretNyKontoGruppe.Controls.Add(this.label10);
            this.OpretNyKontoGruppe.Location = new System.Drawing.Point(600, 400);
            this.OpretNyKontoGruppe.Name = "OpretNyKontoGruppe";
            this.OpretNyKontoGruppe.Size = new System.Drawing.Size(350, 150);
            this.OpretNyKontoGruppe.TabIndex = 15;
            this.OpretNyKontoGruppe.TabStop = false;
            this.OpretNyKontoGruppe.Text = "Opret ny konto";
            this.OpretNyKontoGruppe.Visible = false;
            // 
            // TransaktionsListe
            // 
            this.TransaktionsListe.FormattingEnabled = true;
            this.TransaktionsListe.ItemHeight = 16;
            this.TransaktionsListe.Location = new System.Drawing.Point(967, 400);
            this.TransaktionsListe.Name = "TransaktionsListe";
            this.TransaktionsListe.Size = new System.Drawing.Size(274, 340);
            this.TransaktionsListe.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 690);
            this.Controls.Add(this.TransaktionsListe);
            this.Controls.Add(this.OpretNyKontoGruppe);
            this.Controls.Add(this.KundeMenuGruppe);
            this.Controls.Add(this.FindKundeGruppe);
            this.Controls.Add(this.FindKundeListe);
            this.Controls.Add(this.OpretNyKundeGruppe);
            this.Controls.Add(this.FindKundeMenu);
            this.Controls.Add(this.NyKundeMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "G-Unit Banking Systems Inc.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.OpretNyKundeGruppe.ResumeLayout(false);
            this.OpretNyKundeGruppe.PerformLayout();
            this.FindKundeGruppe.ResumeLayout(false);
            this.FindKundeGruppe.PerformLayout();
            this.KundeMenuGruppe.ResumeLayout(false);
            this.KundeMenuGruppe.PerformLayout();
            this.OpretNyKontoGruppe.ResumeLayout(false);
            this.OpretNyKontoGruppe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NyKundeMenu;
        private System.Windows.Forms.Button FindKundeMenu;
        private System.Windows.Forms.Button SletKundeMenu;
        private System.Windows.Forms.TextBox OpretKundeNavn;
        private System.Windows.Forms.TextBox OpretKundeCPR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OpretKundeKnap;
        private System.Windows.Forms.GroupBox OpretNyKundeGruppe;
        private System.Windows.Forms.GroupBox FindKundeGruppe;
        private System.Windows.Forms.TextBox FindKundeSøg;
        private System.Windows.Forms.Button FindKundeKnap;
        private System.Windows.Forms.ComboBox DropDownFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox FindKundeListe;
        private System.Windows.Forms.GroupBox KundeMenuGruppe;
        private System.Windows.Forms.Button OpretKontoMenu;
        private System.Windows.Forms.TextBox KundeNavn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox KundeCPR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Kundenr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox KundeSlut;
        private System.Windows.Forms.TextBox KundeStart;
        private System.Windows.Forms.ComboBox comboBoxKonti;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxKontoType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button OpretKontoKnap;
        private System.Windows.Forms.GroupBox OpretNyKontoGruppe;
        private System.Windows.Forms.ListBox TransaktionsListe;
    }
}

