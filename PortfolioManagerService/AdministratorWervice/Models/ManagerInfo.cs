using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorWervice.Models
{
    public class ManagerInfo
    {

        public int ManagerID;
        public string ManagerName;
        public double PNLSum;

        public ManagerInfo(int id,string name,double sum)
        {
            this.ManagerID = id;
            this.ManagerName = name;
            this.PNLSum = sum;
        }

        

    }
}