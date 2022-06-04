using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet.Models;

namespace AdoNet.Builders
{
    public class OrderFilterBuilder
    {
        private StringBuilder _queryBuilder = new StringBuilder("SELECT * FROM Orders o WHERE ");

        private List<string> _filtersList = new List<string>();

        public OrderFilterBuilder AddStatus(OrderStatus status)
        {
            _filtersList.Add("o.Status = '" + status + "'");
            return this;
        }

        public OrderFilterBuilder AddProductId(int id)
        {
            _filtersList.Add("o.ProductId = '" + id + "'");
            return this;
        }

        public string Build() => _queryBuilder.Append(string.Join(" and ", _filtersList)).ToString();
    }
}
