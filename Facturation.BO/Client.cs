using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation.BO
{
    public class Client
    {

        public List<Product> products;
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Ville { get; set; }
        public double Montant { get; set; }
        public string Date { get; set; }

        public Client()
        {
            products = new List<Product>();
        }

        public Client(string nom, string email, string telephone, string ville):this()
        {
            Nom = nom;
            Email = email;
            Telephone = telephone;
            Ville = ville;
       
        }

        public Client(string nom, string email, string telephone, string ville, List<Product> products)
        {
            Nom = nom;
            Email = email;
            Telephone = telephone;
            Ville = ville;
            this.products = products;
            Date = DateTime.Now.ToString();
          
        }


        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProduct()
        {
            var list = new List<Product>();
            foreach (var p in products)
            {
                list.Add(new Product(p.NomProduct, p.PriceUnit, p.QuantiteProduct));
            }
            return list;
        }

       

      

    }
}
