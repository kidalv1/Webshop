using System;
using System.Data.Entity.Core.Objects;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;
using Webshop.Domain;


namespace Webshop.DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private WebshopContext context = new WebshopContext();
        private CourseRepo _courseRepo;
        private InvoiceRepo _invoice;
        private InvoiceDetailRepo _invoiceDetailRepo;
        private ProductPriceRepo _productPriceRepo;
        private VatRepo _vatRepo;
        private ProductRepo _product;

        public ProductRepo ProductRepo
        {
            get
            {

                if (this._product == null)
                {
                    this._product = new ProductRepo(context);
                }
                return _product;
            }
        }

        public VatRepo VatRepo
        {
            get
            {

                if (this._vatRepo == null)
                {
                    this._vatRepo = new VatRepo(context);
                }
                return _vatRepo;
            }
        }

        public ProductPriceRepo ProductPriceRepo
        {
            get
            {

                if (this._productPriceRepo == null)
                {
                    this._productPriceRepo = new ProductPriceRepo(context);
                }
                return _productPriceRepo;
            }
        }
        public InvoiceDetailRepo InvoiceDetailRepo
        {
            get
            {

                if (this._invoiceDetailRepo == null)
                {
                    this._invoiceDetailRepo = new InvoiceDetailRepo(context);
                }

                return _invoiceDetailRepo;
            }
        }

        public InvoiceRepo InvoiceRepo
        {
            get
            {

                if (this._invoice == null)
                {
                    this._invoice = new InvoiceRepo(context);
                }

                return _invoice;
            }
        }

        public CourseRepo CourseRepo
        {
            get
            {

                if (this._courseRepo == null)
                {
                    this._courseRepo = new CourseRepo(context);
                }
                return _courseRepo;
            }
        }

        public void Save()
        {
          
            context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

