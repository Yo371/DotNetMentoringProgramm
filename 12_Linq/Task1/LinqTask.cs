using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        private static void ThrowArgumentNullExceptionIfNull<T>(IEnumerable<T> list)
        {
            if (list == null) throw new ArgumentNullException();
        }

        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            ThrowArgumentNullExceptionIfNull(customers);
            return customers.Where(c => (c.Orders.Sum(o => o.Total)) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            ThrowArgumentNullExceptionIfNull(customers);
            ThrowArgumentNullExceptionIfNull(suppliers);


            return customers.Select(
                c => (c, suppliers.Where(s => s.City.Equals(c.City) && s.Country.Equals(c.Country))));
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            ThrowArgumentNullExceptionIfNull(customers);
            ThrowArgumentNullExceptionIfNull(suppliers);

            return customers.GroupJoin(suppliers,
                c => new { c.City, c.Country },
                s => new { s.City, s.Country },
                (c, s) => (c, s));

        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            ThrowArgumentNullExceptionIfNull(customers);
            return customers.Where(c => c.Orders.Any(o => o.Total > limit));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            ThrowArgumentNullExceptionIfNull(customers);
            return customers.Where(c => c.Orders.Length > 0).Select((c, d) => (c, c.Orders.Min(o => o.OrderDate)));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            ThrowArgumentNullExceptionIfNull(customers);
            return Linq4(customers)
                .OrderBy(c => c.dateOfEntry)
                .ThenBy(c => c.dateOfEntry)
                .ThenByDescending(c => c.customer.Orders.Sum(o => o.Total))
                .ThenBy(c => c.customer.CompanyName);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            ThrowArgumentNullExceptionIfNull(customers);
            return customers.Where(c =>
                c.PostalCode.Any(char.IsLetter) || string.IsNullOrWhiteSpace(c.Region) || !c.Phone.StartsWith("("));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            ThrowArgumentNullExceptionIfNull(products);

            return products.GroupBy(p => p.Category, (c, p) =>
                new Linq7CategoryGroup()
                {
                    Category = c,
                    UnitsInStockGroup = p.GroupBy(
                        item => item.UnitsInStock,
                        item => item.UnitPrice,
                        (count, price) =>
                            new Linq7UnitsInStockGroup()
                            {
                                UnitsInStock = count,
                                Prices = price.OrderBy(price => price)
                            })
                });
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            ThrowArgumentNullExceptionIfNull(products);
            return products.GroupBy(p => (p.UnitPrice <= cheap) ? cheap
                : ((p.UnitPrice <= middle) ? middle
                    : expensive), (c, p) => (c, p));

        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            ThrowArgumentNullExceptionIfNull(customers);
            return customers
                .GroupBy(c => c.City)
                .Select(g => (g.Key, (int)Math.Round(g.Average(c => c.Orders.Sum(o => o.Total))),
                    (int)Math.Round(g.Average(c => c.Orders.Length))));
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            ThrowArgumentNullExceptionIfNull(suppliers);
            var result = suppliers.OrderBy(s => s.Country.Length)
                .ThenBy(s => s.Country)
                .Select(s => s.Country).Distinct()
                .ToList();

            return string.Join("", result);
        }
    }
}