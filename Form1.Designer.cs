
namespace GestionDvd2
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lstDvd = new System.Windows.Forms.ListBox();
            this.btnAjoutDvd = new System.Windows.Forms.Button();
            this.btnSupprDvd = new System.Windows.Forms.Button();
            this.btnModifDvd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.txtDuree = new System.Windows.Forms.TextBox();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.txtAjoutGenre = new System.Windows.Forms.TextBox();
            this.lstActeur = new System.Windows.Forms.ListBox();
            this.cboActeur = new System.Windows.Forms.ComboBox();
            this.txtAjoutActeur = new System.Windows.Forms.TextBox();
            this.btnSupprGenre = new System.Windows.Forms.Button();
            this.btnAjoutGenre = new System.Windows.Forms.Button();
            this.btnAjoutActeurDvd = new System.Windows.Forms.Button();
            this.btnSupprActeurDvd = new System.Windows.Forms.Button();
            this.btnSupprActeur = new System.Windows.Forms.Button();
            this.btnAjoutActeur = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liste des Dvd";
            // 
            // lstDvd
            // 
            this.lstDvd.FormattingEnabled = true;
            this.lstDvd.ItemHeight = 16;
            this.lstDvd.Location = new System.Drawing.Point(37, 39);
            this.lstDvd.Name = "lstDvd";
            this.lstDvd.Size = new System.Drawing.Size(554, 564);
            this.lstDvd.TabIndex = 1;
            this.lstDvd.SelectedIndexChanged += new System.EventHandler(this.lstDvd_SelectedIndexChanged);
            // 
            // btnAjoutDvd
            // 
            this.btnAjoutDvd.Location = new System.Drawing.Point(607, 9);
            this.btnAjoutDvd.Name = "btnAjoutDvd";
            this.btnAjoutDvd.Size = new System.Drawing.Size(198, 29);
            this.btnAjoutDvd.TabIndex = 2;
            this.btnAjoutDvd.Text = "Ajout Dvd (sans les acteurs)";
            this.btnAjoutDvd.UseVisualStyleBackColor = true;
            this.btnAjoutDvd.Click += new System.EventHandler(this.btnAjoutDvd_Click);
            // 
            // btnSupprDvd
            // 
            this.btnSupprDvd.Location = new System.Drawing.Point(607, 41);
            this.btnSupprDvd.Name = "btnSupprDvd";
            this.btnSupprDvd.Size = new System.Drawing.Size(198, 29);
            this.btnSupprDvd.TabIndex = 3;
            this.btnSupprDvd.Text = "Suppr Dvd";
            this.btnSupprDvd.UseVisualStyleBackColor = true;
            this.btnSupprDvd.Click += new System.EventHandler(this.btnSupprDvd_Click);
            // 
            // btnModifDvd
            // 
            this.btnModifDvd.Location = new System.Drawing.Point(607, 72);
            this.btnModifDvd.Name = "btnModifDvd";
            this.btnModifDvd.Size = new System.Drawing.Size(198, 29);
            this.btnModifDvd.TabIndex = 4;
            this.btnModifDvd.Text = "Modif (titre durée genre)";
            this.btnModifDvd.UseVisualStyleBackColor = true;
            this.btnModifDvd.Click += new System.EventHandler(this.btnModifDvd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(870, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Titre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(860, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Durée";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(860, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Genre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(852, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Acteurs";
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(913, 9);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(379, 22);
            this.txtTitre.TabIndex = 9;
            // 
            // txtDuree
            // 
            this.txtDuree.Location = new System.Drawing.Point(913, 44);
            this.txtDuree.Name = "txtDuree";
            this.txtDuree.Size = new System.Drawing.Size(135, 22);
            this.txtDuree.TabIndex = 10;
            // 
            // cboGenre
            // 
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(913, 80);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(380, 24);
            this.cboGenre.TabIndex = 11;
            // 
            // txtAjoutGenre
            // 
            this.txtAjoutGenre.Location = new System.Drawing.Point(913, 118);
            this.txtAjoutGenre.Name = "txtAjoutGenre";
            this.txtAjoutGenre.Size = new System.Drawing.Size(380, 22);
            this.txtAjoutGenre.TabIndex = 12;
            // 
            // lstActeur
            // 
            this.lstActeur.FormattingEnabled = true;
            this.lstActeur.ItemHeight = 16;
            this.lstActeur.Location = new System.Drawing.Point(912, 155);
            this.lstActeur.Name = "lstActeur";
            this.lstActeur.Size = new System.Drawing.Size(380, 372);
            this.lstActeur.TabIndex = 13;
            // 
            // cboActeur
            // 
            this.cboActeur.FormattingEnabled = true;
            this.cboActeur.Location = new System.Drawing.Point(912, 542);
            this.cboActeur.Name = "cboActeur";
            this.cboActeur.Size = new System.Drawing.Size(379, 24);
            this.cboActeur.TabIndex = 14;
            // 
            // txtAjoutActeur
            // 
            this.txtAjoutActeur.Location = new System.Drawing.Point(912, 581);
            this.txtAjoutActeur.Name = "txtAjoutActeur";
            this.txtAjoutActeur.Size = new System.Drawing.Size(379, 22);
            this.txtAjoutActeur.TabIndex = 15;
            // 
            // btnSupprGenre
            // 
            this.btnSupprGenre.Location = new System.Drawing.Point(1299, 75);
            this.btnSupprGenre.Name = "btnSupprGenre";
            this.btnSupprGenre.Size = new System.Drawing.Size(120, 33);
            this.btnSupprGenre.TabIndex = 16;
            this.btnSupprGenre.Text = "Suppr genre";
            this.btnSupprGenre.UseVisualStyleBackColor = true;
            this.btnSupprGenre.Click += new System.EventHandler(this.btnSupprGenre_Click);
            // 
            // btnAjoutGenre
            // 
            this.btnAjoutGenre.Location = new System.Drawing.Point(1299, 114);
            this.btnAjoutGenre.Name = "btnAjoutGenre";
            this.btnAjoutGenre.Size = new System.Drawing.Size(120, 33);
            this.btnAjoutGenre.TabIndex = 17;
            this.btnAjoutGenre.Text = "Ajout genre";
            this.btnAjoutGenre.UseVisualStyleBackColor = true;
            this.btnAjoutGenre.Click += new System.EventHandler(this.btnAjoutGenre_Click);
            // 
            // btnAjoutActeurDvd
            // 
            this.btnAjoutActeurDvd.AccessibleDescription = "";
            this.btnAjoutActeurDvd.Location = new System.Drawing.Point(1299, 164);
            this.btnAjoutActeurDvd.Name = "btnAjoutActeurDvd";
            this.btnAjoutActeurDvd.Size = new System.Drawing.Size(31, 23);
            this.btnAjoutActeurDvd.TabIndex = 18;
            this.btnAjoutActeurDvd.Text = "+";
            this.btnAjoutActeurDvd.UseVisualStyleBackColor = true;
            this.btnAjoutActeurDvd.Click += new System.EventHandler(this.btnAjoutActeurDvd_Click);
            // 
            // btnSupprActeurDvd
            // 
            this.btnSupprActeurDvd.Location = new System.Drawing.Point(1299, 193);
            this.btnSupprActeurDvd.Name = "btnSupprActeurDvd";
            this.btnSupprActeurDvd.Size = new System.Drawing.Size(31, 23);
            this.btnSupprActeurDvd.TabIndex = 19;
            this.btnSupprActeurDvd.Text = "-";
            this.btnSupprActeurDvd.UseVisualStyleBackColor = true;
            this.btnSupprActeurDvd.Click += new System.EventHandler(this.btnSupprActeurDvd_Click);
            // 
            // btnSupprActeur
            // 
            this.btnSupprActeur.Location = new System.Drawing.Point(1299, 537);
            this.btnSupprActeur.Name = "btnSupprActeur";
            this.btnSupprActeur.Size = new System.Drawing.Size(120, 33);
            this.btnSupprActeur.TabIndex = 20;
            this.btnSupprActeur.Text = "Suppr Acteur";
            this.btnSupprActeur.UseVisualStyleBackColor = true;
            this.btnSupprActeur.Click += new System.EventHandler(this.btnSupprActeur_Click);
            // 
            // btnAjoutActeur
            // 
            this.btnAjoutActeur.Location = new System.Drawing.Point(1299, 576);
            this.btnAjoutActeur.Name = "btnAjoutActeur";
            this.btnAjoutActeur.Size = new System.Drawing.Size(120, 33);
            this.btnAjoutActeur.TabIndex = 21;
            this.btnAjoutActeur.Text = "Ajout acteur";
            this.btnAjoutActeur.UseVisualStyleBackColor = true;
            this.btnAjoutActeur.Click += new System.EventHandler(this.btnAjoutActeur_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 629);
            this.Controls.Add(this.btnAjoutActeur);
            this.Controls.Add(this.btnSupprActeur);
            this.Controls.Add(this.btnSupprActeurDvd);
            this.Controls.Add(this.btnAjoutActeurDvd);
            this.Controls.Add(this.btnAjoutGenre);
            this.Controls.Add(this.btnSupprGenre);
            this.Controls.Add(this.txtAjoutActeur);
            this.Controls.Add(this.cboActeur);
            this.Controls.Add(this.lstActeur);
            this.Controls.Add(this.txtAjoutGenre);
            this.Controls.Add(this.cboGenre);
            this.Controls.Add(this.txtDuree);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnModifDvd);
            this.Controls.Add(this.btnSupprDvd);
            this.Controls.Add(this.btnAjoutDvd);
            this.Controls.Add(this.lstDvd);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstDvd;
        private System.Windows.Forms.Button btnAjoutDvd;
        private System.Windows.Forms.Button btnSupprDvd;
        private System.Windows.Forms.Button btnModifDvd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.TextBox txtDuree;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.TextBox txtAjoutGenre;
        private System.Windows.Forms.ListBox lstActeur;
        private System.Windows.Forms.ComboBox cboActeur;
        private System.Windows.Forms.TextBox txtAjoutActeur;
        private System.Windows.Forms.Button btnSupprGenre;
        private System.Windows.Forms.Button btnAjoutGenre;
        private System.Windows.Forms.Button btnAjoutActeurDvd;
        private System.Windows.Forms.Button btnSupprActeurDvd;
        private System.Windows.Forms.Button btnSupprActeur;
        private System.Windows.Forms.Button btnAjoutActeur;
    }
}

