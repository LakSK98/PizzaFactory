using PizzaFactory;

try
{
    Order order = new Order();
    int i = 0;
    while (true)
    {
        Console.Write(i++ == 0 ? "Do you want pizza ?(y/n) : " : "Do you want more pizza ?(y/n) : ");
        if (Console.ReadLine().Equals("y"))
        {
            order.addNewPizza();
        }
        else
        {
            break;
        }
    }
    Console.Clear();
    order.getOrderDescription();
    order.claimDiscount("Hello");
    order.checkoutOrder();
}catch(Exception e)
{
    Console.WriteLine(e.Message);
}
