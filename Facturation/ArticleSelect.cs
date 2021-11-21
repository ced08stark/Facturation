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
    public partial class ArticleSelect : Form
    {

        public List<Product> products;
        public ClientManager manager;
        public ArticleSelect()
        {
            InitializeComponent();
            products = new List<Product>();
            manager = new ClientManager();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ArticleSelect_Load(object sender, EventArgs e)
        {
            nom_txt.Text = Program.CurrentClient.Nom;
            email_txt.Text = Program.CurrentClient.Email;
            phone_txt.Text = Program.CurrentClient.Telephone;
            ville.Text = Program.CurrentClient.Ville;

            listViewProduct.Items.Clear();
            products = Program.CurrentProducts;

            foreach(var p in products)
            {
                var lvi = new ListViewItem(new string[] { p.NomProduct, p.PriceUnit.ToString(), p.QuantiteProduct.ToString() });
                lvi.Tag = p;
                listViewProduct.Items.Add(lvi);
            }
            
        }

        private void Btn_valide_Click(object sender, EventArgs e)
        {
            
            manager.AddClient(new Client(Program.CurrentClient.Nom, Program.CurrentClient.Email, Program.CurrentClient.Telephone, Program.CurrentClient.Ville, Program.CurrentProducts));
            MessageBox.Show("Achat effectuer avec succes une facture vous sera remise", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var form = new FormView();
            form.Show();
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int index = listViewProduct.FocusedItem.Index;
            manager.DeleteProduct(Program.CurrentClient, products[index]);
            listViewProduct.Items.Clear();
            products = manager.GetAllProduct();
            foreach (var p in products)
            {
                var liv = new ListViewItem(new string[] { p.NomProduct, p.PriceUnit.ToString(), p.QuantiteProduct.ToString() });
                listViewProduct.Items.Add(liv);
            }
        }
    }
}
