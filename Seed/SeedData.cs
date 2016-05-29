using Database;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Linq;

namespace DataSeed
{
    static class Delta
    {
        static string sourceData = @"C:\MistralProjects\Invoicer\Invoicer.xls";
        static InvoicerContext context = new InvoicerContext();

        static void Main(string[] args)
        {
            Seed();
            Console.ReadKey();
        }

        public static void Seed()
        {
            Console.Clear();

            getComp();
            getCust();
            getArt();                                                
            Console.ReadKey();
        }

        static void getArt()
        {
            Console.Write("Seeding Articles: ");
            DataTable rawData = OpenExcel(sourceData, "Article");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Article article = new Article();
                article.Name = getString(row, 0);
                article.Price = getDouble(row, 1);
                article.InStock = getInteger(row, 2);
               
                N++;
                context.Articles.Add(article);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getCust()
        {
            Console.Write("Seeding Customers: ");
            DataTable rawData = OpenExcel(sourceData, "Customer");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Customer customer = new Customer();
                customer.Name = getString(row, 0);
                customer.CompanyName = getString(row, 1);
                customer.Address = getString(row, 2);
                customer.City = getString(row, 3);
                customer.ZIP = getString(row, 4);
                customer.Phone = getString(row, 5);
                
                N++;
                context.Customers.Add(customer);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getComp()
        {
            Console.Write("Seeding Companies: ");
            DataTable rawData = OpenExcel(sourceData, "Company");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Company company = new Company();
                company.Name = getString(row, 0);
                company.Address = getString(row, 1);
                company.City = getString(row, 2);
                company.ZIP = getString(row, 3);
                company.Phone = getString(row, 4);

                N++;
                context.Companies.Add(company);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        //returning corresponding values from the excel file
        static string getString(DataRow row, int index)
        {
            return row.ItemArray.GetValue(index).ToString();
        }

        static int getInteger(DataRow row, int index)
        {
            return Convert.ToInt32(row.ItemArray.GetValue(index).ToString());
        }

        static bool getBool(DataRow row, int index)
        {
            return (row.ItemArray.GetValue(index).ToString().ToLower() == "yes");
        }

        static double getDouble(DataRow row, int index)
        {
            return Convert.ToDouble(row.ItemArray.GetValue(index).ToString());
        }

        //creating connection with the excel sheet
        static DataTable OpenExcel(string path, string sheet)
        {
            var cs = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
            OleDbConnection conn = new OleDbConnection(cs);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", sheet), conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}