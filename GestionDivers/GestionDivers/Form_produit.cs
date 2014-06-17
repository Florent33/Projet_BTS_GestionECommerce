using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace GestionDivers
{
    public partial class Form_produit : Form
    {
        public Form_produit()
        {
            InitializeComponent();
        }
        SqlConnection connexion = new SqlConnection(@"Data Source=.\sqlexpress;Integrated Security=True");
        SqlCommand command = new SqlCommand();

        internal static void show()
        {
            throw new NotImplementedException();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ajouterProduit_Click(object sender, EventArgs e)
        {
            try
            {
                command.Connection = connexion;
                command.CommandType = CommandType.Text;
                connexion.Open();

                command.CommandText = "INSERT INTO Produit (IdProduit, Reference, LibProd, Description, PrixHT, CodeBarreFabricant) VALUES ("+ comboBox1.Text +",'"+ textBox1.Text +"','"+ textBox2.Text +"','"+ textBox3.Text +"','"+ textBox4.Text +"','"+ textBox5.Text +"')";

                command.ExecuteNonQuery();
                connexion.Close();
                MessageBox.Show("Votre produit a bien été ajouté");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Une erreur s'est produite. Veuillez recommencer !!!");
                connexion.Close();
            }
        }

        private void modifierProduit_Click(object sender, EventArgs e)
        {
            try
            {
                command.Connection = connexion;
                command.CommandType = CommandType.Text;
                connexion.Open();

                command.CommandText = "UPDATE Produit SET Reference='"+ textBox1.Text +"', LibProd='"+ textBox2.Text +"', Description='"+ textBox3.Text +"', PrixHT='"+ textBox4.Text +"', CodebarreFabricant='"+ textBox5.Text +"' WHERE IdProduit='"+ comboBox1.Text +"' ";

                command.ExecuteNonQuery();
                connexion.Close();
                MessageBox.Show("Votre produit a bien été modifié");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Une erreur s'est produite. Veuillez recommencer !!!");
                connexion.Close();
            }
        }

        private void supprimerProduit_Click(object sender, EventArgs e)
        {
            try
            {
                command.Connection = connexion;
                command.CommandType = CommandType.Text;
                connexion.Open();

                command.CommandText = "DELETE FROM Produit WHERE IdProduit="+ comboBox1.Text +"";

                command.ExecuteNonQuery();
                connexion.Close();
                MessageBox.Show("Votre produit a bien été supprimé");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Une erreur s'est produite. Veuillez recommencer !!!");
                connexion.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            menu m = new menu();
            m.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'dataSet1.Produit'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.produitTableAdapter.Fill(this.dataSet1.Produit);

        }
    }
}