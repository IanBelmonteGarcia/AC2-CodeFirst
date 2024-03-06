using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.DAO
{
    public interface IDAO
    {
        public void AddCustomer();
        public void AddEmployee();
        public void AddOffice();
        public void AddOrder();
        public void AddOrderDetail();
        public void AddPayment();
        public void AddProduct();
        public void AddProductLine();
        public void Import();
    }
}
