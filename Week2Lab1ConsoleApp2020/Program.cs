﻿/* #############################
 * 
 * Author: Johnathon Mc Grory
 * Date : 13th October 2020
 * Description : Lab 2 C# Code for using Linq with a code - first database approach
 * 
 * ############################# */

using ActivityTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week2Lab1ConsoleApp2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int UpperLimit = 10;
            string category = "Hardware";
            Activity.Track("Creating Console App");
            Console.ReadKey();
            Activity.Track("Data Seeded");
            list_categories();
            list_products();
            list_products_specified_quantity(UpperLimit);
            list_product_value();
            list_category_products(category);
            list_supplier_parts();
            //AddProduct();
            Activity.Track("Lab Finished");

        }

        //private static void AddProduct()
        //{
        //    using(DbBusinessContext db = new DbBusinessContext())
        //    {
        //        db.SupplierProducts.Add(new SupplierProduct
        //        {
        //            DateFirstSupplied = DateTime.Now,
        //            FK_Product = new Product
        //            {
        //                category = db.Categories.Find(1),
        //                DateFirstissued = DateTime.Now,
        //                Description = "New Product",
        //                QuantityInStock = 22,
        //                UnitPrice = 0.40f
        //            },
        //            FK_Supplier = new Supplier { SupplierName = "New Suppler", SupplierAddressLine1 = "New Supplier Addr1", SupplierAddressLine2 = "Addr2" }
        //        });
        //    }
        //}

        private static void list_supplier_parts()
        {
            using (DbBusinessContext db = new DbBusinessContext())
            {
                var suppliersAndParts = (from Suppliers in db.Suppliers
                                         join SupplierProducts in db.SupplierProducts
                                         on Suppliers.SupplierID equals SupplierProducts.SupplierID
                                         join Products in db.Products
                                         on SupplierProducts.ProductID equals Products.ID
                                         orderby Suppliers.SupplierName
                                         select new
                                         {
                                             Suppliers.SupplierName,
                                             Products.Description,
                                         });

                Console.WriteLine("Query 6 List all the suppliers and their Parts ordered by supplier name");
                foreach (var item in suppliersAndParts)
                {
                    //calls a method that replaces the "{", "," and "}" with spaces for formatting so that the output looks more natural
                    string result = ModifiedList(item);
                    Console.WriteLine(result);
                }
            }
        }
        public static string ModifiedList(object item)
        {
            string list = (item.ToString()).Replace("," , "     ").Replace("{", "").Replace("}", "    ");
            return list;
        }

        private static void list_category_products(string category)
        {
            using (DbBusinessContext db = new DbBusinessContext())
            {
                var query1 = from Product in db.Products
                             join Category in db.Categories
                             on Product.CategoryID equals Category.CategoryID
                             where Category.Description.ToLower() == category.ToLower()
                             select Product;

                var list = query1.ToList();

                Console.WriteLine("Query 5 Products where the Category is 'Hardware'");
                foreach (var item in list)
                {
                
                        Console.WriteLine("{0} {1}", item.ID, item.Description);
                 
                }
                Console.WriteLine("----------");
                Console.ReadKey();
            }
        }

        private static void list_product_value()
        {
            using (DbBusinessContext db = new DbBusinessContext())
            {
                List<Product> Query = db.Products.ToList();

                Console.WriteLine("Query 4 Product List together with their total value");
                foreach (var item in Query)
                {
                    float totalValue = item.QuantityInStock * item.UnitPrice;
                    Console.WriteLine("{0} {1}", item.ID, item.Description, totalValue);
                }
                Console.WriteLine("----------");
                Console.ReadKey();
            }
        }

        private static void list_products_specified_quantity(int UpperLimit)
        {
            using (DbBusinessContext db = new DbBusinessContext())
            {
                List<Product> Query = db.Products.ToList();

                Console.WriteLine("Query 3 Product List With a Quantity less than {0}", UpperLimit);
                foreach (var item in Query)
                {
                    if (item.QuantityInStock < UpperLimit)
                    {
                        Console.WriteLine("{0} {1}", item.ID, item.Description);
                    }
                    else
                    {

                    }
                }
                Console.WriteLine("----------");
                Console.ReadKey();
            }
        }

        private static void list_products()
        {
            using (DbBusinessContext db = new DbBusinessContext())
            {
                List<Product> Query = db.Products.ToList();

                Console.WriteLine("Query 2 Product List");
                foreach (var item in Query)
                {
                    Console.WriteLine("{0} {1}", item.ID, item.Description);
                }
                Console.WriteLine("----------");
                Console.ReadKey();
            }
        }

        private static void list_categories()
        {
            using (DbBusinessContext db = new DbBusinessContext())
            {
                List<Category> Query = db.Categories.ToList();

                Console.WriteLine("Query 1 Category List");
                foreach (var item in Query)
                {
                    Console.WriteLine("{0}", item.Description);
                }
                Console.WriteLine("----------");
                Console.ReadKey();
            }
        }
    }
}
