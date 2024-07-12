using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal TotalCost()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.TotalCost();
        }
        total += customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public string PackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var product in products)
        {
            sb.AppendLine($"{product.Name} ({product.ProductId})");
        }
        return sb.ToString();
    }

    public string ShippingLabel()
    {
        return $"{customer.Name}\n{customer.Address.FullAddress()}";
    }
}
