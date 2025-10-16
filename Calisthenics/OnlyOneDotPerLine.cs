namespace CursoRefactoring.Calisthenics;

public class Address
{
    private readonly string city;

    public Address(string city)
    {
        this.city = city;
    }

    public string GetCity()
    {
        return city;
    }
}

public class Customer
{
    private readonly Address address;

    public Customer(Address address)
    {
        this.address = address;
    }

    public Address GetAddress()
    {
        return address;
    }
}

public class Order
{
    private readonly Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public Customer GetCustomer()
    {
        return customer;
    }
}

public class OrderExample
{
    public static void RunExample()
    {
        var order = new Order(new Customer(new Address("Madrid")));
        Console.WriteLine(order.GetCustomer().GetAddress().GetCity());
    }
}