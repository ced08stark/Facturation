using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Serialisation;

namespace Facturation.DAL
{
    public class BaseRepository<T>
    {

        protected List<T> datas;
        protected Serializer<List<T>> serializer;
        protected readonly string PATH;

        public BaseRepository()
        {
            datas = new List<T>();
            PATH = $"Data/{typeof(T).Name}.json";
            FileInfo fi = new FileInfo(PATH);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            serializer = new Serializer<List<T>>(Mode.JSON, PATH);
        }


        public void Add(T obj)
        {
            FileInfo fi = new FileInfo(PATH);
            if (fi.Exists && fi.Length > 0)
            {
                datas = serializer.Deserialise();
            }
            //foreach (var data in datas)
            //{
            //    if (data.Equals(obj))
            //    {
            //        throw new DuplicateWaitObjectException($"{typeof(T).Name} already exists");
            //    }
            //}

            datas.Add(obj);

        }

        public void Delete(T obj)
        {
            FileInfo fi = new FileInfo(PATH);
            if (fi.Exists && fi.Length > 0)
            {
                datas = serializer.Deserialise();
            }
            int index = IndexOf(obj);
            for (int i = 0; i < datas.Count; i++)
            {
                if (datas[i].Equals(obj))
                {
                    index = i;
                }
            }
            if (index >= 0)
            {
                datas.RemoveAt(index);
            }

        }

        public void Save()
        {
            serializer.Serialise(datas);

        }

        public List<T> Restore()
        {
            FileInfo fi = new FileInfo(PATH);
            if (fi.Exists && fi.Length > 0)
            {
                return datas = serializer.Deserialise();
            }
            return null;
        }

        public int IndexOf(T obj)
        {
            var index = -1;
            for (int i = 0; i < datas.Count; i++)
            {
                if (datas[i].Equals(obj))
                {
                    index = i;
                }
            }
            return index;
        }




    }
}
