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
        public double PNLAvg;

        public ManagerInfo(int id,string name,double avg)
        {
            this.ManagerID = id;
            this.ManagerName = name;
            this.PNLAvg = avg;
        }

        

    }
}