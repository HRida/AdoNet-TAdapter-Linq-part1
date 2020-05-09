using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamRevision
{
    public partial class Form3 : Form
    {
        NorthwindDataContext db = new NorthwindDataContext();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var query1 = from p in db.Products
                        select  p;

            //Select productID, ProductName, unitPrice from products
            var query2 = from p in db.Products
                        select new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.UnitPrice
                        };

            //Select  *  from products where ProductID = 1;
            var query3 = from p in db.Products
                        where p.ProductID == 1
                        select p;

            //Select  *  from products where supplierID = 5 and unitPrice > 20;
            var query4 = from p in db.Products
                        where p.SupplierID == 5 && p.UnitPrice > 20
                        select p;

            //Select  *  from products where supplierID = 5 OR p.SupplierID = 6;
            var query5 = from p in db.Products
                        where p.SupplierID == 5 || p.SupplierID == 6
                        select p;

            //Select  *  from products order by productID dec
            var query6 = from p in db.Products
                        orderby p.ProductID descending
                        select p;

            //Select  *  from products order by categoryID , unitPrice desc
            var query7 = from p in db.Products
                        orderby p.CategoryID ascending, p.UnitPrice descending
                        select p;

            //Select  top 10  from products
            var query8 = (from p in db.Products
                         select p).Take(10);

            //Returns 1st record
            var query9 = (from p in db.Products
                         select p).First();


            //Select  top 10  from products order by pID
            var query10 = (from p in db.Products
                         orderby p.ProductID
                         select p).Take(10);

            //Select  distinct  categoryID from products 
            var query11 = (from p in db.Products
                         select p.CategoryID).Distinct();

            //Select categoryID , count(categoryID) As newfield from products 
            var query12 = from p in db.Products
                        group p by p.CategoryID into g
                        select new
                        {
                            CategoryId = g.Key,
                            NewField = g.Count()
                        };

            //Select categoryID , avg(unitprice) as newfield from products groupBy categoryID
            var query13 = from p in db.Products
                        group p by p.CategoryID into g
                        select new
                        {
                            CategoryId = g.Key,
                            NewField = g.Average(k => k.UnitPrice)
                        };

            //Select categoryID , sum(unitprice) as newfield from products groupBy categoryID
            var query14 = from p in db.Products
                        group p by p.CategoryID into g
                        select new
                        {
                            CategoryId = g.Key,
                            NewField = g.Sum(k => k.UnitPrice)
                        };

            //Select * from productswhere categoryID = 1 Union select * from products where categoryID = 2
            var query15 = (from p in db.Products
                         where p.CategoryID == 1
                         select p)
                         .Union
                        (from m in db.Products
                         where m.CategoryID == 2
                         select m);


            //Select A.ProductID, A.productName, B.CategoryID, B.CtegoryName 
            //from products A, Categories B
            // where A.categoryID = B.categoryID and supplierId = 1 
            var query16 = from p in db.Products
                        from m in db.Categories
                        where p.CategoryID == m.CategoryID
                         && p.SupplierID == 1
                        select new
                        {
                            p.ProductID,
                            p.ProductName,
                            m.CategoryID,
                            m.CategoryName
                        };

            //Select * from products where productName like 'A%'
            var query17 = from p in db.Products
                        where p.ProductName.StartsWith("A")
                        select p;

            //Select * from products where productName like 'A%' and customerName like 'P%';
            var query18 = from c in db.Customers
                        from p in db.Products
                        where c.ContactName.StartsWith("A")
                         && p.ProductName.StartsWith("P")
                        select new
                        {
                            name = c.ContactName,
                            p.ProductName
                        };

            var query19 = (from emp in db.Employees
                        orderby emp.HireDate ascending
                        select emp);

            //Join
            var query20 = from ords in db.Orders
                          join dets in db.Order_Details
                          on ords.OrderID equals dets.OrderID
                          orderby ords.CustomerID ascending
                          select new
                          {
                              CustomerID = ords.CustomerID,
                              OrderDate = ords.OrderDate,
                              RequiredDate = ords.RequiredDate,
                              ShipAddress = ords.ShipAddress,
                              ShipCity = ords.ShipCity,
                              ShipCountry = ords.ShipCountry,
                              ShipZip = ords.ShipPostalCode,
                              ShippedTo = ords.ShipName,
                              OrderID = ords.OrderID,
                              NameOfProduct = dets.Product.ProductName,
                              QtyPerUnit = dets.Product.QuantityPerUnit,
                              Price = dets.Product.UnitPrice,
                              QtyOrdered = dets.Quantity,
                              Discount = dets.Discount
                          };

            var query21 = from c in db.Categories 
                          join p in db.Products 
                          on c equals p.Category 
                          select new { Category = c, p.ProductName };

            
            
            

            //UPDATE 
            /*
            var cc = from c in db.Customers
                     where c.City.StartsWith("Paris")
                     select c;
            foreach (var cust in cc)
                cust.City = "PARIS";
            db.SubmitChanges();
            var cd = from c in db.Customers
                     where c.City.StartsWith("Paris")
                     select c;
            
            var matchedCustomer = (from c in dc.GetTable<Customer>()
                                       where c.CustomerID == "AAAAA"
                                       select c).SingleOrDefault();
            matchedCustomer.CompanyName = "BXSW";
            matchedCustomer.ContactName = "Mookie Carbunkle";
            matchedCustomer.ContactTitle = "Chieftain";
            matchedCustomer.Address = "122 North Main Street";
            matchedCustomer.City = "Wamucka";
            matchedCustomer.Region = "DC";
            matchedCustomer.PostalCode = "78888";
            matchedCustomer.Country = "USA";
            matchedCustomer.Phone = "244-233-8977";
            matchedCustomer.Fax = "244-438-2933";
            dc.SubmitChanges(); 
            
            */

            //INSERT
            /*
            Product newProduct = new Product();
            newProduct.ProductName = "RC helicopter";
            db.Products.InsertOnSubmit(newProduct);
            db.SubmitChanges();
             
             
            
            var matchedCustomer = (from c in dc.GetTable<Customer>()
                                       where c.CustomerID == "AAAAA"
                                       select c).SingleOrDefault();
            System.Data.Linq.Table<Customer> customers = dc.GetTable<Customer>();
            Customer cust = new Customer();

            cust.CustomerID = "AAAAA";
            cust.CompanyName = "BXSW";
            cust.ContactName = "Mookie Carbunkle";
            cust.ContactTitle = "Chieftain";
            cust.Address = "122 North Main Street";
            cust.City = "Wamucka";
            cust.Region = "DC";
            cust.PostalCode = "78888";
            cust.Country = "USA";
            cust.Phone = "244-233-8977";
            cust.Fax = "244-438-2933";
            
            customers.InsertOnSubmit(cust);
            customers.Context.SubmitChanges(); 
            
            */

            //DELETE
            /*
            //Multiple
            var pp = from p in db.Products
                     where p.ProductName.Contains("helicopter")  //  where p.ProductName.Equals("helicopter")
                     select p;
            db.Products.DeleteAllOnSubmit(pp);
            db.SubmitChanges();
            
            //Single
            var matchedCustomer = (from c in dc.GetTable<Customer>()
                                       where c.CustomerID == "AAAAA"
                                       select c).SingleOrDefault();
            dc.Customers.DeleteOnSubmit(matchedCustomer);
            dc.SubmitChanges();
            
            */

            dataGridView1.DataSource = query20.ToList();
        }

        private void gettableButton_Click(object sender, EventArgs e)
        {
            System.Data.Linq.Table<Employee> emp = db.GetTable<Employee>();
            dataGridView1.DataSource = emp;

            //System.Data.Linq.Table<Shipper> ship = db.GetTable<Shipper>();
            //dataGridView1.DataSource = ship;

            //System.Data.Linq.Table<Order> orders = db.GetTable<Order>();
            //dataGridView1.DataSource = orders;

            //...
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            //Creating a new Customer
            Customer c1 = new Customer();
            c1.CustomerID = "AAAAA";
            c1.Address = "554 Westwind Avenue";
            c1.City = "Wichita";
            c1.CompanyName = "Holy Toledo";
            c1.ContactName = "Frederick Flintstone";
            c1.ContactTitle = "Boss";
            c1.Country = "USA";
            c1.Fax = "316-335-5933";
            c1.Phone = "316-225-4934";
            c1.PostalCode = "67214";
            c1.Region = "EA";

            Order_Detail od = new Order_Detail();
            od.Discount = .25f;
            od.ProductID = 1;
            od.Quantity = 25;
            od.UnitPrice = 25.00M;

            Order o = new Order();
            o.Order_Details.Add(od);
            o.Freight = 25.50M;
            o.EmployeeID = 1;
            o.CustomerID = "AAAAA";

            c1.Orders.Add(o);

            using (NorthwindDataContext dc = new NorthwindDataContext())
            {
                var table = dc.GetTable<Customer>();
                table.InsertOnSubmit(c1);
                dc.SubmitChanges();
            }
        }

        private void cascadeButton_Click(object sender, EventArgs e)
        {
            using (NorthwindDataContext dc = new NorthwindDataContext())
            {

                var q =
                    (from c in dc.GetTable<Customer>()
                     where c.CustomerID == "AAAAA"
                     select c).Single<Customer>();

                foreach (Order ord in q.Orders)
                {
                    dc.GetTable<Order>().DeleteOnSubmit(ord);

                    foreach (Order_Detail od in ord.Order_Details)
                    {
                        dc.GetTable<Order_Detail>().DeleteOnSubmit(od);
                    }
                }

                dc.GetTable<Customer>().DeleteOnSubmit(q);
                dc.SubmitChanges();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (NorthwindDataContext dc = new NorthwindDataContext())
            {

                var q =
                    (from c in dc.GetTable<Customer>()
                     where c.CustomerID == "AAAAA"
                     select c).Single<Customer>();

                dc.GetTable<Customer>().DeleteOnSubmit(q);
                dc.SubmitChanges();
            }
        }
    }
}
