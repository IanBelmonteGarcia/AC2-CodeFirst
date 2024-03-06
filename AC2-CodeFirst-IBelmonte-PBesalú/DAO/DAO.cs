using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2_CodeFirst_IBelmonte_PBesalú.DAO
{
    class DAO : IDAO
    {
        private Entities.DbContextIBPB _context;

        public DAO(Entities.DbContextIBPB context)
        {
            this._context = context;
        }
        public void AddCustomer(string[] line)
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(string[] line)
        {
            throw new NotImplementedException();
        }

        public void AddOffice(string[] line)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(string[] line)
        {
            throw new NotImplementedException();
        }

        public void AddOrderDetail(string[] line)
        {
            throw new NotImplementedException();
        }

        public void AddPayment(string[] line)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(string[] line)
        {
            throw new NotImplementedException();
        }

        public void AddProductLine(string[] line)
        {
            throw new NotImplementedException();
        }

        public void Import()
        {
            throw new NotImplementedException();
        }
    }
}
