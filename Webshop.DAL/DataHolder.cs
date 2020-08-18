using System;
using System.Collections.Generic;
using System.Linq;
using Webshop.DAL.Entit;

namespace Webshop.DAL
{
    public static class DataHolder
    {
        private static List<Course> GetMobileCourses()
        {
            List<Course> courses = new List<Course>
            {
                new Course("Objective C", 50, null),
                new Course("Ionic", 50, null),
                new Course("Android Studio", 20, null),
            };

            return courses;
        }

        private static List<Course> GetTestingCourses()
        {
            List<Course> courses = new List<Course>
            {
                new Course("Unit testing", 50, null),
                new Course("Functional testing", 15, null),
                new Course("Regression testing", 15, null),
            };

            return courses;
        }

        private static List<Course> GetAdvancedCourses()
        {
            List<Course> courses = new List<Course>
            {
                new Course("Blazor", 50, null),
                new Course("History of .NET", 10, null),
                new Course("NHibernate", 30, null),
            };

            return courses;
        }

        private static List<Course> GetBasicsCourses()
        {
            List<Course> courses = new List<Course>
            {
                new Course("Entity Framework", 20, null),
                new Course("Web API", 30, null),
                new Course("MVC", 30, null),
            };

            return courses;
        }

        private static List<Course> GetFrontEndCourses()
        {
            List<Course> courses = new List<Course>
            {
                new Course("Sass", 20, null),
                new Course("Vue", 20, null),
                new Course("Bootstrap", 30, null),
            };

            return courses;
        }

        public static List<InvoiceDetail> GetFrontEndInvoiceDetails()
        {
            List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>
            {
                new InvoiceDetail(7, GetFrontEndCourses().ElementAt(0).Id, 1),
                new InvoiceDetail(9, GetFrontEndCourses().ElementAt(1).Id, 1),
                new InvoiceDetail(6, GetFrontEndCourses().ElementAt(2).Id, 1),
            };

            return invoiceDetails;
        }

        public static List<InvoiceDetail> GetBasicsInvoiceDetails()
        {
            List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>
            {
                new InvoiceDetail(15, GetBasicsCourses().ElementAt(0).Id, 1),
                new InvoiceDetail(15, GetBasicsCourses().ElementAt(1).Id, 1),
                new InvoiceDetail(10, GetBasicsCourses().ElementAt(2).Id, 1),
            };

            return invoiceDetails;
        }

        public static List<InvoiceDetail> GetAdvancedInvoiceDetails()
        {
            List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>
            {
                new InvoiceDetail(5, GetAdvancedCourses().ElementAt(0).Id, 1),
                new InvoiceDetail(11, GetAdvancedCourses().ElementAt(1).Id, 1),
                new InvoiceDetail(6, GetAdvancedCourses().ElementAt(2).Id, 1),
            };

            return invoiceDetails;
        }

        public static List<InvoiceDetail> GetTestingInvoiceDetails()
        {
            List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>
            {
                new InvoiceDetail(10, GetTestingCourses().ElementAt(0).Id, 1),
                new InvoiceDetail(3, GetTestingCourses().ElementAt(1).Id, 1),
                new InvoiceDetail(2, GetTestingCourses().ElementAt(2).Id, 1),
            };

            return invoiceDetails;
        }

        public static List<InvoiceDetail> GetMobileInvoiceDetails()
        {
            List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>
            {
                new InvoiceDetail(7, GetMobileCourses().ElementAt(0).Id, 1),
                new InvoiceDetail(15, GetMobileCourses().ElementAt(1).Id, 1),
                new InvoiceDetail(3, GetMobileCourses().ElementAt(2).Id, 1),
            };

            return invoiceDetails;
        }

        public static List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice(DateTime.Now, true, false, "randomCode123", GetFrontEndInvoiceDetails(), null, null, null),
                new Invoice(DateTime.Now, false, false, "random123", GetBasicsInvoiceDetails(), null, null, null),
                new Invoice(DateTime.Now, true, false, "Code123", GetAdvancedInvoiceDetails(), null, null, null),
                new Invoice(DateTime.Now, true, false, "randomCode", GetTestingInvoiceDetails(), null, null, null),
                new Invoice(DateTime.Now, false, false, "randomCode548", GetMobileInvoiceDetails(), null, null, null),
            };

            return invoices;
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product("Front-end", 20, DateTime.Now, DateTime.Now, GetFrontEndCourses(), GetVats(), GetProductPrices()[0]),
                new Product(".NET Basics", 10, DateTime.Now, DateTime.Now, GetBasicsCourses(), GetVats(), GetProductPrices()[1]),
                new Product(".NET Advanced", 10, DateTime.Now, DateTime.Now, GetAdvancedCourses(), GetVats(), GetProductPrices()[2]),
                new Product("Testing", 30, DateTime.Now, DateTime.Now, GetTestingCourses(), GetVats(), GetProductPrices()[3]),
                new Product("Mobile", 10, DateTime.Now, DateTime.Now, GetMobileCourses(), GetVats(), GetProductPrices()[4]),
            };

            return products;
        }

        public static List<ProductPrice> GetProductPrices()
        {
            List<ProductPrice> productPrices = new List<ProductPrice>
            {
                new ProductPrice(70, DateTime.Now, DateTime.Now),
                new ProductPrice(80, DateTime.Now, DateTime.Now),
                new ProductPrice(10, DateTime.Now, DateTime.Now),
                new ProductPrice(30, DateTime.Now, DateTime.Now),
                new ProductPrice(10, DateTime.Now, DateTime.Now),
            };

            return productPrices;
        }

        public static List<Vat> GetVats()
        {
            List<Vat> vats = new List<Vat>
            {
                new Vat(0),
                new Vat(6),
                new Vat(12),
                new Vat(21)
            };

            return vats;
        }
    }
}