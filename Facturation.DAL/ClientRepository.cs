using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Serialisation;
using Facturation.BO;

namespace Facturation.DAL
{
    public class ClientRepository:BaseRepository<Client>
    {

        public ClientRepository() : base()
        {
            datas = new List<Client>();
            serializer = new Serializer<List<Client>>(Mode.JSON, PATH);
            Restore();
        }


        public void Clear()
        {
            for(int i=0; i<datas.Count; i++)
            {
                datas.RemoveAt(i); 
            }
           
        }

        


    }
}
