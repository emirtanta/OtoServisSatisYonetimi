using OtoServisSatis.DAL;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.BL
{
    public class MarkaManager
    {
        DatabaseContext context = new DatabaseContext();

        public List<Marka> GetAll()
        {
            return context.Markalar.ToList();
        }

        public int Add(Marka marka)
        {
            context.Markalar.Add(marka);

            return context.SaveChanges();
        }

        public int Update(Marka marka)
        {
            context.Markalar.AddOrUpdate(marka);//gelen markayı güncelleme için

            return context.SaveChanges();
        }

        public int Delete(Marka marka)
        {
            context.Markalar.Remove(marka);

            return context.SaveChanges();
        }

        public Marka Get(int id)//bu metot kendisine gönderilen id'ye göre markayı getiri
        {
            return context.Markalar.Find(id);
        }
    }
}
