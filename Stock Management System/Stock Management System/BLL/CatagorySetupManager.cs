using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management_System.DAL;
using Stock_Management_System.Model;

namespace Stock_Management_System.BLL
{
    class CatagorySetupManager
    {

        CatagorySetupRepository DalFolder = new CatagorySetupRepository(); // Create a new Instance or Object store data in DalFolder variable for passing value
        public bool Insert(CatagorySetup ca)    // Calling Insert Method from DAL with passing parameters
        {
            bool chk = DalFolder.Insert(ca);
            return chk;
        }
    }    
}
