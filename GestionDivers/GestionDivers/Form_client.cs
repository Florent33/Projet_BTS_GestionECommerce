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
    public partial class Form_client : Form
    {
        public Form_client()
        {
            InitializeComponent();
        }
        SqlConnection connexion = new SqlConnection(@"Data Source=.\sqlexpress;Integrated Security=True");
        SqlCommand command = new SqlCommand();

        private void IdProduit_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ajouterClient_Click(object sender, EventArgs e)
        {
            try
            {
                command.Connection = connexion;
                command.CommandType = CommandType.Text;
                connexion.Open();

                string sexe = "";
                if (radioButton1.Checked)
                {
                    sexe = "1";
                }
                if(radioButton2.Checked)
                {
                    sexe = "2";
                }

                command.CommandText = "INSERT INTO Client (NumClient, Societe, Civilite, NomContact, PrenomContact, InitialePrenom, Telephone, Mobile, Fax, Email, NumeroSIRETClient) VALUES ("+ comboBox1.Text +",'"+ textBox1.Text +"','" + sexe + "','"+ textBox2.Text +"','" + textBox3.Text + "','"+ textBox4.Text +"','"+ textBox5.Text +"','"+ textBox6.Text +"','"+ textBox7.Text +"','"+ textBox8.Text +"','"+ textBox9.Text +"')";

                command.ExecuteNonQuery();
                connexion.Close();
                MessageBox.Show("Votre client a bien été ajouté");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Une erreur s'est produite. Veuillez recommencer !!!");
                connexion.Close();
            }
        }

        private void modifierClient_Click(object sender, EventArgs e)
        {
            try
            {
                command.Connection = connexion;
                command.CommandType = CommandType.Text;
                connexion.Open();

                string sexe = "";
                if (radioButton1.Checked)
                {
                    sexe = "1";
                }
                if(radioButton2.Checked)
                {
                    sexe = "2";
                }

                command.CommandText = "UPDATE Client SET Societe='"+ textBox1.Text +"', Civilite='"+ sexe +"', NomContact='"+ textBox2.Text +"', PrenomContact='"+ textBox3.Text +"', InitialePrenom='"+ textBox4.Text +"', Telephone='"+ textBox5.Text +"', Mobile='"+ textBox6.Text +"', Fax='"+ textBox7.Text +"', Email='"+textBox8.Text+"', NumeroSIRETClient='"+ textBox9.Text+"' WHERE NumClient='"+ comboBox1.Text +"' ";

                command.ExecuteNonQuery();
                connexion.Close();
                MessageBox.Show("Votre client a bien été modifié");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Une erreur s'est produite. Veuillez recommencer !!!");
                connexion.Close();
            }
        }

        private void supprimerClient_Click(object sender, EventArgs e)
        {
            try
            {
                command.Connection = connexion;
                command.CommandType = CommandType.Text;
                connexion.Open();

                command.CommandText = "DELETE FROM Client WHERE NumClient="+ comboBox1.Text +"";

                command.ExecuteNonQuery();
                connexion.Close();
                MessageBox.Show("Votre client a bien été supprimé");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Une erreur s'est produite. Veuillez recommencer !!!");
                connexion.Close();
            }
        }

        /*internal static void show()
        {
            Form1 f = new Form1();
            f.Show();
        }*/
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            command.Connection = connexion;
            command.CommandType = CommandType.Text;
            connexion.Open();

            //dataGridView1.DataSource = BindingSource;
            command.CommandText = "SELECT NumClient, Societe, Civilite, NomContact, PrenomContact, InitialePrenom, Telephone, Mobile, Fax, Email, NumeroSIRETClient FROM Client";

            command.ExecuteNonQuery();
            connexion.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            menu m = new menu();
            m.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'dataSet1.Client'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.clientTableAdapter.Fill(this.dataSet1.Client);

        }
    }
}
