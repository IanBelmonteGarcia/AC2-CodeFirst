using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.DAO
{
    public interface IDAO
    {
        public void AddCustomer(string[] line);
        public void AddEmployee(string[] line);
        public void AddOffice(string[] line);
        public void AddOrder(string[] line);
        public void AddOrderDetail(string[] line);
        public void AddPayment(string[] line);
        public void AddProduct(string[] line);
        public void AddProductLine(string[] line);
        public void Import();
    }
}
