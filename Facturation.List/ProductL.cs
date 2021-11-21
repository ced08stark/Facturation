using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation.List
{
    public class ProductL
    {

        public string NomProduct { get; set; }
        public double PriceUnit { get; set; }
        public int QuantiteProduct { get; set; }
        public double Montant { get; set; }

        public ProductL(string nomP, double pu, int quantiteP)
        {
            NomProduct = nomP;
            PriceUnit = pu;
            QuantiteProduct = quantiteP;
            
        }

        
    }
}
