using EntityFramwork.Context;
using EntityFramwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.EntityDao
{
   public class PositionDao
    {
        public PositionDao() { }


        public static int setPosition(Position a)
        {

            //  Position b = new Position() { PositionId = 1, FirstName = "zhang", LastName = "Tingting", Email = "zhangtingting.code@gmail", telephone = "1111111111", Role = "admin" };
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Positions.Add(a);
                int result = db.SaveChanges();
                return result;
            }
        }

        public static int deletePositions(Position b)
        {
            
            using (DatabaseContext context = new DatabaseContext())
            {
                var Position = context.Positions.FirstOrDefault(row => row.PositionId == b.PositionId);
                if (Position != null)
                {
                    context.Positions.Remove(Position);
                }

                //db.Positions.Remove(b);
                int result = context.SaveChanges();
                return result;
            }
        }




        public static List<Position> getPositions()
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Position> uers = new List<Position>();
                foreach (Position temp in db.Positions)
                {
                    uers.Add(temp);
                }
                return uers;
            }
        }

        public static List<Position> getPositionsByPortfolioId(int portfolioId)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Position> positions = new List<Position>();
                foreach (Position temp in db.Positions)
                {
                    if (temp.PortfolioId == portfolioId) {
                        positions.Add(temp);
                    }   
                }
                return positions;
            }
        }

        public static Position getPositionsById(int id)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Position> uers = new List<Position>();
                foreach (Position temp in db.Positions)
                {
                    if (temp.PositionId == id)
                    {
                        return temp;
                    }
                }
                return null;
            }
        }

        public static int updatePositions(Position w)
        {

            DatabaseContext db = new DatabaseContext();
            Position us = db.Positions.Single(x => x.PositionId == w.PositionId);
            if (us == null)
                throw new ArgumentOutOfRangeException("ws");
            db.Entry(us).CurrentValues.SetValues(w);  //更新实体
            int result = db.SaveChanges();
            return result;
        }
    }
}
