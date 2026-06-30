using System;
using System.Collections.Generic;
using System.Data.SQLite;
using ShoesShopMS.Database;
using ShoesShopMS.Models;

namespace ShoesShopMS.Services
{
    public class DialogService
    {
        public static int AddProductDialog()
        {
            var product = new Product
            {
                ArticleNumber = "NEW-001",
                ProductType = "Shoe",
                Brand = "Test",
                PurchasePrice = 500,
                SalePrice = 1000,
                CurrentStock = 10,
                MinimumStock = 5
            };
            return ProductService.AddProduct(product) ? 1 : 0;
        }

        public static int AddCustomerDialog()
        {
            var customer = new Customer
            {
                CustomerName = "Test Customer",
                Phone = "0300-1234567",
                Address = "Test Address"
            };
            return CustomerService.AddCustomer(customer);
        }

        public static int AddSupplierDialog()
        {
            var supplier = new Supplier
            {
                SupplierName = "Test Supplier",
                Phone = "0300-9876543",
                Address = "Test Address"
            };
            return SupplierService.AddSupplier(supplier);
        }
    }
}
