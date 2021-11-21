using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturation.BLL;
using Facturation.BO;

namespace Facturation
{
    public partial class Form1 : Form
    {

        public Client client;
        public ClientManager manager;
        public Form1()
        {
            InitializeComponent();
            client = new Client();
            manager = new ClientManager();
        }

        private void NomProduit_txt_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (nomProduit_txt.Text)
            {
                case "Ordinateur":
                    prix_txt.Text = "500000";
                    break;
                case "Telephone":
                    prix_txt.Text = "250000";
                    break;
                case "Televiseur":
                    prix_txt.Text = "350000";
                    break;
                case "Tablette":
                    prix_txt.Text = "200000";
                    break;
                case "I Pad":
                    prix_txt.Text = "700000";
                    break;
            }

            
            
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            if (Program.CurrentProducts == null)
            {
                Program.CurrentProducts = new List<Product>();
            }    
            Program.CurrentProducts.Add(new Product(nomProduit_txt.Text, double.Parse(prix_txt.Text), (int)quantite_txt.Value));
            nomProduit_txt.Text = string.Empty;
            prix_txt.Text = string.Empty;
            quantite_txt.Value = 0;
        }

        private void Btn_valide_Click(object sender, EventArgs e)
        {
            Program.CurrentClient = new Client(nom_txt.Text, email_txt.Text, phone_txt.Text, ville.Text);
            var form = new ArticleSelect();
            form.Show();
            this.Close();
        }

        private void Prix_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
