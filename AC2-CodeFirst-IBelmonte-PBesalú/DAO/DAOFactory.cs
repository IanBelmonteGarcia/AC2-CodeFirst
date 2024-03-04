using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.DAO
{
    public class DAOFactory
    {
        public static IDAO GetDAO()
        {
            return new DAO();
        }
    }
}
