using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturation.BO;

namespace Facturation.List
{
    public class ClientL
    {
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Ville { get; set; }
        public string date { get; set; }
        public double Montant { get; set; }
        

        public ClientL(string nom, string email, string telephone, string ville, double montant)
        {
            Nom = nom;
            Email = email;
            Telephone = telephone;
            Ville = ville;
            date = DateTime.Now.ToString();
            Montant = montant;
        }
    }
}
