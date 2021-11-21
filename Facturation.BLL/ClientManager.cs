using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturation.BO;
using Facturation.DAL;

namespace Facturation.BLL
{
    public class ClientManager
    {
        Client client;
        public List<Client> list;
        // public List<Product> GetProducts;
        private ClientRepository Repository;

        public ClientManager()
        {
            Repository = new ClientRepository();
            client = new Client();


        }

        public void AddClient(Client usr)
        {
            Repository.Clear();
            Repository.Add(usr);
            Repository.Save();

        }

        public void AddProduct(Product product)
        {
            client.AddProduct(product);
        }

        public List<Client> GetAll()
        {
            return Repository.Restore();
        }

        public List<Product> GetAllProduct()
        {
            return client.GetProduct();
        }

        public void DeleteProduct(int index)
        {
            client.DeleteProduct(index);
            Repository.Save();
        }

        public double Calcule(List<Product> products)
        {
            double result = 0;
            double sum = 0;
            foreach (var p in products)
            {
                result = (p.PriceUnit * p.QuantiteProduct);
                sum += result;

            }
            return sum+(sum*0.175);
        }
    }
}
