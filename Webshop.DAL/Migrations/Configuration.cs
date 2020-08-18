using System.Collections.Generic;

namespace Webshop.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Webshop.DAL.WebshopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Webshop.DAL.WebshopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            SeedList(DataHolder.GetInvoices(), context._Invoices);
            SeedList(DataHolder.GetProductPrices(), context._ProductPrices);
            SeedList(DataHolder.GetProducts(), context._Products);
        }

        private void SeedList<TEntity>(List<TEntity> items, DbSet<TEntity> dbSet) where TEntity : class
        {
            foreach (TEntity item in items)
            {
                dbSet.AddOrUpdate(item);
            }
        }

    }
}
