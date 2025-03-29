using System.Collections.Generic;
using System.Text;

namespace ProductOrderingSystem
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal total = 0;
            foreach (var product in _products)
            {
                total += product.CalculateTotalCost();
            }

            total += _customer.IsInUSA() ? 5 : 35;

            return total;
        }

        public string GetPackingLabel()
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine("PACKING LABEL");
            label.AppendLine("-------------");
            foreach (var product in _products)
            {
                label.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
            }
            return label.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine("SHIPPING LABEL");
            label.AppendLine("--------------");
            label.AppendLine(_customer.GetName());
            label.Append(_customer.GetAddress().GetFullAddress());
            return label.ToString();
        }
    }
}
