using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionDivers
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_client f1= new Form_client();
            f1.Show();
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_produit f2 = new Form_produit();
            f2.Show();
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e) {}
    }
}
