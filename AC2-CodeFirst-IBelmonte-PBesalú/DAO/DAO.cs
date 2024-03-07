using AC2_CodeFirst_IBelmonte_PBesalú.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AC2_CodeFirst_IBelmonte_PBesalú.DAO
{
    class DAO : IDAO
    {
        private Entities.DbContextIBPB _context;

        private const string EMPLOYEES_CSV = "EMPLOYEES.csv";
        private const string CUSTOMERS_CSV = "CUSTOMERS.csv";
        private const string OFFICES_CSV = "OFFICES.csv";
        private const string ORDERDETAILS_CSV = "ORDERDETAILS.csv";
        private const string ORDERS_CSV = "ORDERS.csv";
        private const string PAYMENTS_CSV = "PAYMENTS.csv";
        private const string PRODUCTLINES_CSV = "PRODUCTLINES.csv";
        private const string PRODUCTS_CSV = "PRODUCTS.csv";

        public DAO(Entities.DbContextIBPB context)
        {
            this._context = context;
        }

        /// <summary>
        /// adds customers to the database
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void AddCustomer()
        {
            if (!File.Exists(CUSTOMERS_CSV))
            {
                throw new FileNotFoundException($"File not found: {CUSTOMERS_CSV}");
            }

            var customers = File.ReadLines(CUSTOMERS_CSV)
                .Skip(1) // Skip header line
                .Select(line =>
                {
                    var values = line.Split(',');
                    return new Customers
                    {
                        CustomerNumber = Convert.ToInt16(values[0]),
                        CustomerName = values[1],
                        ContactLastName = values[2],
                        ContactFirstName = values[3],
                        Phone = values[4],
                        AddressLine1 = values[5],
                        AddressLine2 = values[6],
                        City = values[7],
                        State = values[8],
                        PostalCode = values[9],
                        Country = values[10],
                        SalesRepEmployeeNumber = (int)(string.IsNullOrWhiteSpace(values[11]) ? (int?)null : Convert.ToInt16(values[11])),
                        CreditLimit = Convert.ToDecimal(values[12])
                    };
                });

            var customersBatch = new List<Customers>(1000);

            foreach (var customer in customers)
            {
                customersBatch.Add(customer);

                if (customersBatch.Count >= 1000)
                {
                    foreach (Customers c in customers)
                    {
                        customer.Employees = _context.Employees.Find(customer.SalesRepEmployeeNumber);
                    }

                    _context.Customers.AddRange(customers);
                    _context.SaveChanges();

                    customersBatch.Clear();
                }
            }

            if (customersBatch.Count > 0)
            {
                foreach (Customers customer in customers)
                {
                    customer.Employees = _context.Employees.Find(customer.SalesRepEmployeeNumber);
                }

                _context.Customers.AddRange(customers);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// adds employees to the database
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void AddEmployee()
        {
            if (!File.Exists(EMPLOYEES_CSV))
            {
                throw new FileNotFoundException($"File not found: {EMPLOYEES_CSV}");
            }

            var employees = File.ReadLines(EMPLOYEES_CSV)
                .Skip(1)
                .Select(line =>
                {
                    var values = line.Split(',');
                    return new Employees
                    {
                        EmployeeNumber = Convert.ToInt16(values[0]),
                        LastName = values[1],
                        FirstName = values[2],
                        Extension = values[3],
                        Email = values[4],
                        OfficeCode = values[5],
                        ReportsTo = (int)(string.IsNullOrWhiteSpace(values[6]) ? (int?)null : Convert.ToInt16(values[6])),
                        JobTitle = values[7]
                    };
                });

            foreach (var employee in employees)
            {
                employee.Offices = _context.Offices.Find(employee.OfficeCode);
                employee.ReportsTo = _context.Employees.Find(employee.ReportsTo).EmployeeNumber;
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// adds offices to the database
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void AddOffice()
        {
            if (!File.Exists(OFFICES_CSV))
            {
                throw new FileNotFoundException($"File not found: {OFFICES_CSV}");
            }

            var offices = File.ReadLines(OFFICES_CSV)
                .Skip(1) // Skip header line
                .Select(line =>
                {
                    var values = line.Split(',');
                    return new Offices
                    {
                        OfficeCode = values[0],
                        City = values[1],
                        Phone = values[2],
                        AddressLine1 = values[3],
                        AddressLine2 = values[4],
                        State = values[5],
                        Country = values[6],
                        PostalCode = values[7],
                        Territory = values[8]
                    };
                });

            var officesBatch = new List<Offices>(1000);

            foreach (var office in offices)
            {
                officesBatch.Add(office);

                if (officesBatch.Count >= 1000)
                {
                    _context.Offices.AddRange(offices);
                    _context.SaveChanges();

                    officesBatch.Clear();
                }
            }

            if (officesBatch.Count > 0)
            {
                _context.Offices.AddRange(offices);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// adds orders to the database
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void AddOrder()
        {
            if (!File.Exists(ORDERS_CSV))
            {
                throw new FileNotFoundException($"File not found: {ORDERS_CSV}");
            }

            var orders = File.ReadLines(ORDERS_CSV)
                .Skip(1)
                .Select(line =>
                {
                    var values = line.Split(',');
                    return new Orders
                    {
                        OrderNumber = Convert.ToInt16(values[0]),
                        OrderDate = Convert.ToDateTime(values[1]),
                        RequiredDate = Convert.ToDateTime(values[2]),
                        ShippedDate = (DateTime)(string.IsNullOrWhiteSpace(values[3]) ? (DateTime?)null : Convert.ToDateTime(values[3])),
                        Status = values[4],
                        Comments = values[5],
                        CustomerNumber = Convert.ToInt16(values[6])
                    };
                });

            foreach (var order in orders)
            {
                order.Customers = _context.Customers.Find(order.CustomerNumber);
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// adds order details to the database
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void AddOrderDetail()
        {
            if (!File.Exists(ORDERS_CSV))
            {
                throw new FileNotFoundException($"File not found: {ORDERS_CSV}");
            }

            var orders = File.ReadLines(ORDERS_CSV)
                .Skip(1) // Skip header line
                .Select(line =>
                {
                    var values = line.Split(',');
                    return new Orders
                    {
                        OrderNumber = Convert.ToInt16(values[0]),
                        OrderDate = Convert.ToDateTime(values[1]),
                        RequiredDate = Convert.ToDateTime(values[2]),
                        ShippedDate = (DateTime)(string.IsNullOrWhiteSpace(values[3]) ? (DateTime?)null : Convert.ToDateTime(values[3])),
                        Status = values[4],
                        Comments = values[5],
                        CustomerNumber = Convert.ToInt16(values[6])
                    };
                });

            var ordersBatch = new List<Orders>(1000);

            foreach (var order in orders)
            {
                ordersBatch.Add(order);

                if (ordersBatch.Count >= 1000)
                {
                    foreach (Orders o in orders)
                    {
                        o.Customers = _context.Customers.Find(o.CustomerNumber);
                    }

                    _context.Orders.AddRange(orders);
                    _context.SaveChanges();

                    ordersBatch.Clear();
                }
            }

            if (ordersBatch.Count > 0)
            {
                foreach (Orders o in orders)
                {
                    o.Customers = _context.Customers.Find(o.CustomerNumber);
                }

                _context.Orders.AddRange(orders);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// adds payments to the database
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void AddPayment()
        {
            if (!File.Exists(PAYMENTS_CSV))
            {
                throw new FileNotFoundException($"File not found: {PAYMENTS_CSV}");
            }

            var payments = File.ReadLines(PAYMENTS_CSV)
                .Skip(1) // Skip header line
                .Select(line =>
                {
                    var values = line.Split(',');
                    return new Payments
                    {
                        CustomerNumber = Convert.ToInt16(values[0]),
                        CheckNumber = values[1],
                        PaymentDate = Convert.ToDateTime(values[2]),
                        Amount = Convert.ToDouble(values[3])
                    };
                });

            var paymentsBatch = new List<Payments>(1000);

            foreach (var payment in payments)
            {
                paymentsBatch.Add(payment);

                if (paymentsBatch.Count >= 1000)
                {
                    foreach (Payments p in payments)
                    {
                        p.Customers = _context.Customers.Find(p.CustomerNumber);
                    }

                    _context.Payments.AddRange(payments);
                    _context.SaveChanges();

                    paymentsBatch.Clear();
                }
            }

            if (paymentsBatch.Count > 0)
            {
                foreach (Payments p in payments)
                {
                    p.Customers = _context.Customers.Find(p.CustomerNumber);
                }

                _context.Payments.AddRange(payments);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// adds products to the database
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void AddProduct()
        {
            if (!File.Exists(PRODUCTS_CSV))
            {
                throw new FileNotFoundException($"File not found: {PRODUCTS_CSV}");
            }

            var products = File.ReadLines(PRODUCTS_CSV)
                .Skip(1) // Skip header line
                .Select(line =>
                {
                    var values = line.Split(',');
                    return new Products
                    {
                        ProductCode = values[0],
                        ProductName = values[1],
                        ProductLines = values[2],
                        ProductScale = values[3],
                        ProductVendor = values[4],
                        ProductDescription = values[5],
                        QuantityInStock = Convert.ToInt16(values[6]),
                        BuyPrice = Convert.ToDouble(values[7]),
                        MSRP = Convert.ToDouble(values[8])
                    };
                });

            var productsBatch = new List<Products>(1000);

            foreach (var product in products)
            {
                productsBatch.Add(product);

                if (productsBatch.Count >= 1000)
                {
                    foreach (Products p in products)
                    {
                        p.ProductLine = _context.ProductLines.Find(p.ProductLine);
                    }

                    _context.Products.AddRange(products);
                    _context.SaveChanges();

                    productsBatch.Clear();
                }
            }

            if (productsBatch.Count > 0)
            {
                foreach (Products product in products)
                {
                    product.ProductLine = _context.ProductLines.Find(product.ProductLine);
                }

                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// adds product lines to the database
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void AddProductLine()
        {
            if (!File.Exists(PRODUCTLINES_CSV))
            {
                throw new FileNotFoundException($"File not found: {PRODUCTLINES_CSV}");
            }

            var productLines = File.ReadLines(PRODUCTLINES_CSV)
                .Skip(1)
                .Select(line =>
                {
                    var values = line.Split(',');
                    return new ProductLines
                    {
                        ProductLine = values[0],
                        TextDescription = values[1],
                        HtmlDescription = values[2],
                        Image = values[3]
                    };
                });

            foreach (var productLine in productLines)
            {
                _context.ProductLines.Add(productLine);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Importing data from CSV files to the database
        /// </summary>
        public void Import()
        {
            AddCustomer();
            AddEmployee();
            AddOffice();
            AddOrder();
            AddOrderDetail();
            AddPayment();
            AddProduct();
            AddProductLine();
        }

        /// <summary>
        /// quering employees
        /// </summary>
        public void QueringEmployees()
        {
            var employees = from e in _context.Employees select e;
        }

        /// <summary>
        /// quering customers
        /// </summary>
        public void QueringCustomers()
        {
            var customers = from c in _context.Customers select c;
        }

        /// <summary>
        /// quering offices
        /// </summary>
        public void QueringOffices()
        {
            var offices = from o in _context.Offices select o;
        }

        /// <summary>
        /// sorting employees by last name
        /// </summary>
        public void SortingEmployeesByLastName()
        {
            var employees = from e in _context.Employees orderby e.LastName select e;
        }

        /// <summary>
        /// filtering employees by office code
        /// </summary>
        public void FilteringEmployeesByOfficeCode()
        {
            var employees = from e in _context.Employees where e.OfficeCode == "1" select e;
        }

        /// <summary>
        /// group employees by office code
        /// </summary>
        public void GroupingEmployeesByOfficeCode()
        {
            var employees = from e in _context.Employees group e by e.OfficeCode;
        }

        /// <summary>
        /// join employees and offices
        /// </summary>
        public void JoiningEmployeesAndOffices()
        {
            var employees = from e in _context.Employees
                            join o in _context.Offices on e.OfficeCode equals o.OfficeCode
                            select new
                            {
                                e.LastName,
                                e.FirstName,
                                e.JobTitle,
                                o.City
                            };
        }

        /// <summary>
        /// join employees and customers
        /// </summary>
        public void JoiningEmployeesAndCustomers()
        {
            var employees = from e in _context.Employees
                            join c in _context.Customers on e.EmployeeNumber equals c.SalesRepEmployeeNumber
                            select new
                            {
                                e.LastName,
                                e.FirstName,
                                e.JobTitle,
                                c.CustomerName
                            };
        }

        /// <summary>
        /// join employees and customers, group by employee number
        /// </summary>
        public void JoiningEmployeesAndCustomersGroupingByEmployeeNumber()
        {
            var employees = from e in _context.Employees
                            join c in _context.Customers on e.EmployeeNumber equals c.SalesRepEmployeeNumber
                            group c by e.EmployeeNumber;
        }

        /// <summary>
        /// join employees and customers, group by employee number and count customers
        /// </summary>
        public void JoiningEmployeesAndCustomersGroupingByEmployeeNumberAndCountingCustomers()
        {
            var employees = from e in _context.Employees
                            join c in _context.Customers on e.EmployeeNumber equals c.SalesRepEmployeeNumber
                            group c by e.EmployeeNumber into g
                            select new
                            {
                                EmployeeNumber = g.Key,
                                CustomerCount = g.Count()
                            };
        }

        /// <summary>
        /// join employees and customers, group by employee number and count customers having more than one customer
        /// </summary>
        public void JoiningEmployeesAndCustomersGroupingByEmployeeNumberAndCountingCustomersHavingMoreThanOneCustomer()
        {
            var employees = from e in _context.Employees
                            join c in _context.Customers on e.EmployeeNumber equals c.SalesRepEmployeeNumber
                            group c by e.EmployeeNumber into g
                            where g.Count() > 1
                            select new
                            {
                                EmployeeNumber = g.Key,
                                CustomerCount = g.Count()
                            };
        }

        /// <summary>
        /// n
        /// </summary>
        public void NavigatingAmongstEntities()
        {
            var employees = from e in _context.Employees
                            join c in _context.Customers on e.EmployeeNumber equals c.SalesRepEmployeeNumber
                            select new
                            {
                                e.LastName,
                                e.FirstName,
                                e.JobTitle,
                                c.CustomerName
                            };
        }


    }
}
