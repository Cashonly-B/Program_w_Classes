using System;
using System.Diagnostics.Contracts;
using System.Security.AccessControl;

// ========================================
public class Address
{
    private string _address;
    private string _city;
    private string _state;
    private string _country;

    public Address(string _address, string _city, string _state, string _country)
    {
        this._address = _address;
        this._city = _city;
        this._state = _state;
        this._country = _country;
    }

    public override string ToString() { return $"{_address}\n{_city}, {_state}, {_country}"; }
    public bool IsDomesticUSA() { return _country.ToLower() == "usa"; }
}

// ========================================
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string _name, Address _address)
    {
        this._name = _name;
        this._address = _address;
    } 

    public string GetName() { return _name; }
    public Address GetAddress() { return _address; }
    public bool IsDomesticUSA() { return _address.IsDomesticUSA(); }
}

// ========================================
public class Product
{
    private string _name;
    private string _id;
    private double _pricePerUnit;
    private int _quatity;

    public Product(string _name, string _id, double _pricePerUnit, int _quatity)
    {
        this._name = _name;
        this._id = _id;
        this._pricePerUnit = _pricePerUnit;
        this._quatity = _quatity;
    }

    public string GetName() { return _name; }
    public string ProductID() {return _id; }
    public double TotalCost() { return _pricePerUnit * _quatity; }
}

// ========================================
public class Order
{
    private Customer _customer;
    private List<Product> _cart;

    public Order(Customer _customer)
    {
        this._customer = _customer;
        _cart = new List<Product>();
    }

    // Adding Items
    public void AddItem(Product product)
    {
        _cart.Add(product);
    }

    public double CalTotalCost()
    {
        double total = 0;
        foreach (var product in _cart)
        {
            total += product.TotalCost();
        }
        double shippingCost = _customer.IsDomesticUSA() ? 5 : 35; //ChatGPT Generated
        total += shippingCost;

        return total;
    }

    public string PackingLabel()
    {
        string label = "Packing label: \n";
        foreach (var product in _cart)
        {
            label += $"{product.GetName()} (ID: {product.ProductID()})\n";
        }

        return label;
    }

    public string ShippingLabel()
    {
        return $"Shipping label: \n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}


// ========================================
public class Program
{
    public static void Main()
    {
        // Create
        Address address1 = new Address("123 Chrome Street", "Swellview", "CA", "USA");
        Address address2 = new Address("4775 Brick Wall Circle", "Cancun", "CN", "Mexico");

        Customer customer1 = new Customer("Derek Henry", address1);
        Customer customer2 = new Customer("Juan Jellyson", address2);

        Product product1 = new Product("Table", "TN39DFN893NQ",  60.00, 2);
        Product product2 = new Product("Monitor", "M34789VNW9X",  150.00, 1);
        Product product3 = new Product("Backpack", "B10X0N20CVS",  40.00, 4);
        Product product4 = new Product("Couch", "C21D08NV23",  350.00, 2);

        // Orders
        Order order1 = new Order(customer1);
        order1.AddItem(product1);
        order1.AddItem(product2);

        Order order2 = new Order(customer2);
        order2.AddItem(product3);
        order2.AddItem(product4);

        // Display
        List<Order> orders = new List<Order> { order1, order2 };
        foreach (var order in orders)
        {
            Console.WriteLine(order.PackingLabel());
            Console.WriteLine(order.ShippingLabel());
            Console.WriteLine($"Total Cost: ${order.CalTotalCost()}\n");
        }
    }
}