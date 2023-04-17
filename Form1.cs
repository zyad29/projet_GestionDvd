using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionDvd2
{
    public partial class Form1 : Form
    {
        // proprietes
        private string chaineConnexion = "server=localhost;user id=root;database=gestiondvd2";
        private int numDvd = -1; // mémorise le numéro du dvd sélectionné

        public Form1()
        {
            InitializeComponent();
            //initialisation de la fenêtre avec la liste des dvd
            this.initFenetre();

            //Test de connexion

            /*MySqlConnection mysqlConnection = new MySqlConnection(chaineConnexion);
            try
            {
                mysqlConnection.Open();
                MessageBox.Show("Connection success");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }*/

        }

        /**
         * Initialisation de la fenêtre en remplissant la liste des dvd
         */
        private void initFenetre()
        {
            // remplissage de la liste des genres
            this.remplirCombo("libelle", "genre", this.cboGenre);
            // remplissage de la liste des acteurs
            this.remplirCombo("nom", "acteur", this.cboActeur);
            // remplissage de la liste des dvd
            this.remplirListe("titre", "dvd", this.lstDvd);
            // place le focus sur la liste des dvd
            this.lstDvd.Select();
        }

        /**
         * Remplit une liste avec des informations provenant de la base de données
         */
        private void remplirListe(string leChamp, string laTable, ListBox laListe)
        {
            // vide la liste avant de la remplir
            laListe.Items.Clear();
            // récupération des informations
            ConnexionSql crs = new ConnexionSql(this.chaineConnexion);
            crs.reqSelect("select " + leChamp + " from " + laTable);
            // boucle sur le curseur
            while (!crs.fin())
            {
                laListe.Items.Add((string)crs.champ(leChamp));
                crs.suivant();
            }
            crs.close();
            // Si un item est présent, le premier est sélectionné, sinon aucun
            if (laListe.Items.Count != 0)
            {
                laListe.SelectedIndex = 0;
            }
            else
            {
                laListe.SelectedIndex = -1;
            }
        }

        /**
         * Remplit un combo avec des informations provenant de la base de données
         */
        private void remplirCombo(string leChamp, string laTable, ComboBox leCombo)
        {
            //vide la liste avant de la remplir
            leCombo.Items.Clear();

            //récupération des informations
            ConnexionSql crs = new ConnexionSql(this.chaineConnexion);
            crs.reqSelect("select " + leChamp + " from " + laTable);

            //boucle sur le curseur
            while (!crs.fin())
            {
                leCombo.Items.Add((string)crs.champ(leChamp));
                crs.suivant();
            }
            crs.close();

            //par défaut séléction d'aucun item
            leCombo.SelectedIndex = -1;
        }



        /**
         * Méthode événementielle sur le changement de sélection d'un dvd
         */
        private void lstDvd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //demande de mise à jour de l'affichage des informations du dvd
            this.affichInfosDvd();
        }

        /**
         * Affiche les informations du dvd actuellement sélectionné
         */
        private void affichInfosDvd()
        {
            // affichage uniquement si un dvd est sélectionné
            if (this.lstDvd.Items.Count != 0)
            {
                // récupération des informations du dvd actuellement sélectionné
                ConnexionSql crs = new ConnexionSql(this.chaineConnexion);
                crs.reqSelect("select * from dvd limit " + this.lstDvd.SelectedIndex + ",1");
                // contrôle si la récupération s'est bien passée
                if (!crs.fin())
                {
                    this.cboActeur.SelectedIndex = -1;
                    this.numDvd = (int)crs.champ("numdvd");
                    this.txtTitre.Text = (crs.champ("titre")).ToString();
                    this.txtDuree.Text = (crs.champ("duree")).ToString();
                    // sélection du genre correspondant au dvd
                    ConnexionSql crsGenre = new ConnexionSql(this.chaineConnexion);
                    crsGenre.reqSelect("select libelle from genre where numgenre=" + (crs.champ("numgenre")).ToString());
                    if (!crsGenre.fin())
                    { // contrôle qu'on a bien un genre (normalement il doit y en avoir un)
                        this.cboGenre.SelectedItem = (crsGenre.champ("libelle")).ToString();
                    }
                    crsGenre.close();
                    // récupération des acteurs du dvd
                    ConnexionSql crsActeur = new ConnexionSql(this.chaineConnexion);
                    crsActeur.reqSelect("select nom from acteur a join acteur_dvd d on (a.numacteur=d.numacteur) where numdvd=" + this.numDvd);
                    this.lstActeur.Items.Clear();
                    while (!crsActeur.fin())
                    {
                        this.lstActeur.Items.Add((crsActeur.champ("nom")).ToString());
                        crsActeur.suivant();
                    }
                    crsActeur.close();
                }
                crs.close();
            }
            else
            {
                this.numDvd = -1; // aucun dvd sélectionné
            }
        }


        /**
            * Tentative de suppression d'un genre
        */

        private void btnSupprGenre_Click(object sender, EventArgs e)
        {
            //requete de recherche de lien entre genre que l'on veur supprimer et dvd
            string requete = "select * from dvd d join genre g on (d.numgenre=g.numgenre) where libelle=\"" + this.cboGenre.SelectedItem + "\"";
            //gestion de la suppression du genre, si c'est possible
            this.supprDansCombo(this.cboGenre, requete, "genre", "libelle");
            //place le focus sur la liste des dvd
            this.lstDvd.Select();
        }



        /**
         * Tentative de suppression d'un acteur
         */
        private void btnSupprActeur_Click(object sender, EventArgs e)
        {
            //requete de recherche de lien entre acteur que l'on veut supprimer et dvd
            string requete = "select * from dvd d join acteur_dvd ad on (d.numdvd=ad.numdvd) join acteur a on (ad.numacteur=a.numacteur) where a.nom=\"" + this.cboActeur.SelectedItem + "\"";
            //gestion de la suppression de l'acteur, si c'est possible
            this.supprDansCombo(this.cboActeur, requete, "acteur", "nom");
            //place le focus sur la liste des dvd
            this.lstDvd.Select();
        }



        /**
         * Ajout d'un nouveau genre en contrôlant qu'il n'existe pas déjà (nom unique obligatoire)
         */
        private void btnAjoutGenre_Click(object sender, EventArgs e)
        {
            this.ajoutDansCombo(this.txtAjoutGenre, this.cboGenre, "genre", "libelle");
            //place le focus sur la liste des dvd
            this.lstDvd.Select();
        }



        /**
         * Ajout d'un nouvel acteur en contrôlant qu'il n'existe pas déjà (nom unique obligatoire)
         */
        private void btnAjoutActeur_Click(object sender, EventArgs e)
        {
            this.ajoutDansCombo(this.txtAjoutActeur, this.cboActeur, "acteur", "nom");
            //place le focus sur la liste des dvd
            this.lstDvd.Select();
        }

        /**
        * Suppression d'un item dans un combo
        */
        private void supprDansCombo(ComboBox leCombo, string requete, string laTable, string leChamp)
        {
            //contrôle si un élément est sélectionné
            if(leCombo.SelectedIndex != -1)
            {
                //exécute la requete de recherche de liens pour savoir si la suppression est possible ou non
                ConnexionSql crs = new ConnexionSql(this.chaineConnexion);
                crs.reqSelect(requete);
                if (!crs.fin())
                {
                    MessageBox.Show("Impossible de supprimer : cet élément est lié à un dvd");
                }
                else
                {
                    //suppression
                    ConnexionSql crsDelete = new ConnexionSql(this.chaineConnexion);
                    crsDelete.reqUpdate("delete from " + laTable + " where " + leChamp + "=\"" + leCombo.SelectedItem + "\"");
                    leCombo.Items.Remove(leCombo.SelectedItem);
                    crsDelete.close();
                }
            }
        }
        /**
         * tentative d'ajout d'un éléent dans un combo (à partir de la saisie dans la zone de texte du dessous)
         */
        private void ajoutDansCombo(TextBox leTexte, ComboBox leCombo, string laTable, string leChamp)
        {
            //contrôle que la zone de saisie d'un nouvel élément est bien remplie
            if(leTexte.Text != "")
            {
                //contrôle si le nom n'est pas déjà présent dans la liste
                if(leCombo.FindString(leTexte.Text) != -1)
                {
                    MessageBox.Show("Ajout impossible : l'élément existe déjà");
                }
                else
                {
                    //ajout
                    ConnexionSql crsAdd = new ConnexionSql(this.chaineConnexion);
                    crsAdd.reqUpdate("insert into " + laTable + " (" + leChamp + ") values (\"" + leTexte.Text + "\")");
                    leCombo.Items.Add(leTexte.Text);
                    crsAdd.close();
                    //la zone de saisie est vidée
                    leTexte.Text = "";
                }
            }
        }



        /**
         * Ajoute un acteur dans la liste des acteurs du film
         */
        private void btnAjoutActeurDvd_Click(object sender, EventArgs e)
        {
            //contrôle si un acteur est bien sélectionné dans le combo
            if(this.cboActeur.SelectedIndex != -1)
            {
                
                //contrôle si l'acteur n'est pas déjà présent
                if(this.lstActeur.FindString(this.cboActeur.SelectedItem.ToString()) != -1)
                {
                    MessageBox.Show("Acteur déjà présent dans ce dvd");
                }

                else
                {
                    //récupération du numéro correspondant à l'acteur
                    ConnexionSql crs = new ConnexionSql(this.chaineConnexion);
                    crs.reqSelect("select numacteur from acteur where nom=\"" + this.cboActeur.SelectedItem + "\"");
                    if (!crs.fin())
                    {
                        //ajout dans la liste et la table
                        ConnexionSql crsAdd = new ConnexionSql(this.chaineConnexion);
                        crsAdd.reqUpdate("insert into acteur_dvd(numdvd, numacteur) values (" + this.numDvd + ", " + (crs.champ("numacteur")).ToString() + ")");
                        this.lstActeur.Items.Add(this.cboActeur.SelectedItem);
                        crsAdd.close();
                    }
                    crs.close();
                }
            }
            //place le focus sur la liste des dvd
            this.lstDvd.Select();
        }



        /**
         * Supprime un acteur de la liste des acteurs du film
         */
        private void btnSupprActeurDvd_Click(object sender, EventArgs e)
        {
            //contrôle si une ligne est bien sélectionné
            if(this.lstActeur.SelectedIndex != -1)
            {
                //récupération du numéro correspondant à l'acteur
                ConnexionSql crs = new ConnexionSql(this.chaineConnexion);
                crs.reqSelect("select numacteur from acteur where nom=\"" + this.lstActeur.SelectedItem + "\"");
                if (!crs.fin())
                {
                    //suppression dans la liste et la table
                    ConnexionSql crsSuppr = new ConnexionSql(this.chaineConnexion);
                    crsSuppr.reqUpdate("delete from acteur_dvd where numdvd = " + this.numDvd + " and numacteur = " + (crs.champ("numacteur")).ToString());
                    this.lstActeur.Items.Remove(this.lstActeur.SelectedItem);
                    crsSuppr.close();
                }
                crs.close();
            }
            //place le focus sur la liste des dvd
            this.lstDvd.Select();
        }



        /**
        * Ajout d'un novueau dvd avec les informations saisies
        */
        private void btnAjoutDvd_Click(object sender, EventArgs e)
        {
            //contrôle si toutes les zones sont saisies
            if(this.txtTitre.Text != "" && this.txtDuree.Text != "" && this.cboGenre.SelectedIndex != -1)
            {
                //contrôle si le dvd n'existe pas déjà (contrôle juste sur le titre)
                if(this.lstDvd.FindString(this.txtTitre.Text) != -1)
                {
                    MessageBox.Show("Le titre existe déjà : ajout impossible");
                }
                else
                {
                    //avertissement sur le fait que les acteurs du film doivent être ajoutés après coup
                    MessageBox.Show("Attention, seuls le titre, la durée et le genre sont mémorisés. Les acteurs doivent être ajoutés à postériori.");
                    //récupération du numéro correspondant au genre
                    ConnexionSql crs = new ConnexionSql(this.chaineConnexion);
                    crs.reqSelect("select numgenre from genre where libelle=\"" + this.cboGenre.SelectedItem + "\"");
                    if (!crs.fin())
                    {
                        //ajout dans la table
                        ConnexionSql crsAdd = new ConnexionSql(this.chaineConnexion);
                        crsAdd.reqUpdate("insert into dvd (numgenre, titre, duree) values (" + (crs.champ("numgenre")).ToString() + ",\"" + this.txtTitre.Text + "\", " + this.txtDuree.Text + ")");
                        crsAdd.close();
                    }
                    crs.close();
                    //réinitialisation de la fenêtre
                    this.initFenetre();
                }
            }
        }



        /**
         * Demande de suppression d'un dvd
         */
        private void btnSupprDvd_Click(object sender, EventArgs e)
        {
            //demande de confirmation de suppression
            if(MessageBox.Show("Voulez-vous vraiment supprimer ce dvd ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //suppression des acteurs du dvd et du dvd lui-même
                ConnexionSql crsSuppr = new ConnexionSql(this.chaineConnexion);
                crsSuppr.reqUpdate("delete from acteur_dvd where numdvd=" + this.numDvd);
                crsSuppr.reqUpdate("delete from dvd where numdvd=" + this.numDvd);
                crsSuppr.close();
                //réinitialisation de la fenêtre
                this.initFenetre();
            }
        }



        /**
         * Enregistrement des modifications apportées au dvd (excepté les acteurs)
         */
        private void btnModifDvd_Click(object sender, EventArgs e)
        {
            //contrôle si le dvd n'existe pas déjà (contrôle juste sur le titre)
            if(this.lstDvd.FindString(this.txtTitre.Text) != -1 && this.lstDvd.FindString(this.txtTitre.Text) != this.lstDvd.SelectedIndex)
            {
                MessageBox.Show("Le titre existe déjà pour un autre dvd : modification impossible");
            }
            else
            {
                //avertissement sur le fait que les acteurs du film ne sont pas modifiés ici
                MessageBox.Show("Attention, seuls le titre, la durée et le genre sont modifiés");
                //récupération du numéro correspondant au genre
                ConnexionSql crs = new ConnexionSql(this.chaineConnexion);
                crs.reqSelect("select numgenre from genre where libelle=\"" + this.cboGenre.SelectedItem + "\"");
                if (!crs.fin())
                {
                    //Modification dans la table
                    ConnexionSql crsAdd = new ConnexionSql(this.chaineConnexion);
                    crsAdd.reqUpdate("update dvd set titre=\"" + this.txtTitre.Text + "\", duree=" + this.txtDuree.Text + ", numgenre=" + (crs.champ("numgenre")).ToString() + "where numdvd=" + this.numDvd);
                    crsAdd.close();
                }
                crs.close();
                //réinitialisation de la fenêtre
                this.initFenetre();
            }
        }


    }
}
