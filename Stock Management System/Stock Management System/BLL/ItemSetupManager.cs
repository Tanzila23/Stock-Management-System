using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management_System.DAL;
using Stock_Management_System.Model;

namespace Stock_Management_System.BLL
{
    class ItemSetupManager
    {
        ItemSetupRepository rs = new ItemSetupRepository();
        public bool Insert(ItemSetup st)
        {
            bool chk = rs.Insert(st);
            return chk;
        }
    }
}
