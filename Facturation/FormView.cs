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
using Facturation.List;
using Microsoft.Reporting.WinForms;

namespace Facturation
{
    public partial class FormView : Form
    {
        ClientManager manager;
        List<Client> list;
        List<ClientL> ClientL;
        List<Product> products;
        public FormView()
        {
           
            InitializeComponent();
            manager = new ClientManager();
            list = new List<Client>();
            ClientL = new List<ClientL>();
            products = new List<Product>();

        }

        private void FormView_Load(object sender, EventArgs e)
        {

            list = manager.GetAll();
            this.reportViewer1.LocalReport.ReportPath = "Facture.rdlc";

           

            
            List<ClientL> lists = new List<ClientL>();
            for (int i = 0; i < list.Count; i++)
                if (i == list.Count-1)
                    lists.Add(new Facturation.List.ClientL(list[i].Nom, list[i].Email, list[i].Telephone, list[i].Ville, manager.Calcule(Program.CurrentProducts)));

            this.reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("DataSet1", lists)
            );
            List <ProductL> prod = new List<ProductL>();
            int k =0;
            for(int i=0; i<list.Count; i++)
            {
                while(i == list.Count-1 && k < list[list.Count-1].products.Count)
                {
                    prod.Add(new Facturation.List.ProductL(list[i].products[k].NomProduct, list[i].products[k].PriceUnit, list[i].products[k].QuantiteProduct));
                    k++;
                }
                        
            }
            this.reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSet2", prod)
                    );

            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }

        private void ReportViewer1_Load(object sender, EventArgs e)
        {
            list = manager.GetAll();
        }
    }
}
