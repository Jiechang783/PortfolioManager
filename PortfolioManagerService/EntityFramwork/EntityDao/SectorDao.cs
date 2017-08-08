using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
   public class SectorDao
    {   

        public static int addSector(Sector Sector)
        {
            //  Sectors b = new Sectors() { SectorsId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Sectors.Add(Sector);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deleteSector(Sector sector)
        {
            // Sectors b = new Sectors() { SectorsId = 2, FirstName = "a", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                var removeSector = db.Sectors.FirstOrDefault(row => row.SectorId == sector.SectorId);

                if (removeSector != null)
                {
                    db.Sectors.Remove(removeSector);
                }

                int result = db.SaveChanges();
                return result;
            }
        }

        public static List<Sector> getSectors()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Sector> Sectors = new List<Sector>();

                foreach (Sector Sector in db.Sectors)
                {
                    Sectors.Add(Sector);
                }

                return Sectors;
            }
        }

        public static Sector getSectorBySectorId(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Sector> uers = new List<Sector>();

                foreach (Sector Sector in db.Sectors)
                {
                    if (Sector.SectorId == id)
                    {
                        return Sector;
                    }
                }

                return null;
            }
        }



        public static int updateSector(Sector sector)
        {
            DatabaseContext db = new DatabaseContext();
            Sector updateSector = db.Sectors.Single(x => x.SectorId == sector.SectorId);

            if (updateSector == null)
            {
                throw new ArgumentOutOfRangeException("Web Service");
            }

            db.Entry(updateSector).CurrentValues.SetValues(sector);  //更新实体
            int result = db.SaveChanges();
            return result;
        }
    }
}

