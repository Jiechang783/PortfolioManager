using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramwork.Entities;
using EntityFramwork.EntityDao;

namespace PortfolioManagerService.Models
{
    public class Portfilioandpnl
    {
        public int portfolioid;
        public string portfolioname;
        public double PNL;
        public Portfilioandpnl(int id,string name,double pnl)
        {
            this.portfolioid = id;
            this.portfolioname = name;
            this.PNL = pnl;
        }
        
        public static double Caculatepnl(int portfolitid)
        {
            decimal amountbefore = 0;
            decimal amountafter = 0;
            double pnl=0;
            List<Position> posilist=PositionDao.getPositionsByPortfolioId(portfolitid);

            foreach(Position p in posilist )
            {
                if(p.Type=="Stock")
                {
                    int isin = p.Isin;
                    amountafter += p.Quantity * p.Price;
                    amountbefore += p.Quantity * PriceHistoryDao.getLastPriceHistorysByisin(isin).Price;
                    

                   
                }
                else
                {
                    
                    
                }
            }
            pnl = Convert.ToDouble((amountafter - amountbefore) / amountbefore);
            return pnl;
        }


        


    }
}