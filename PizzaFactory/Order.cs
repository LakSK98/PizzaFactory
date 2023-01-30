using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory
{
    public class Order : IOrder
    {
        private Guid OrderId;
        private List<Pizza> pizzaList;
        private int totalPrice;
        private Dictionary<string, int> coupons;
        private int discount;

        public Order()
        {
            OrderId = Guid.NewGuid();
            pizzaList = new List<Pizza>();
            totalPrice = 0;
            coupons = new Dictionary<string, int>() { { "Hello", 10 }, { "New", 5 } };
        }

        public void addNewPizza()
        {
                PizzaBuilder pizzaBuilder = new PizzaBuilder();
                Console.Write("Enter Pizza Size : ");
                pizzaBuilder.buildPizzaSize(getSize(Console.ReadLine()));
                while (true)
                {
                    Console.Write("Do you want to add topping (y/n): ");
                    if (Console.ReadLine().Equals("y"))
                    {
                        Console.Write("Enter Topping type you wish to add : ");
                        pizzaBuilder.buildPizzaTopping(getTopping(Console.ReadLine()));
                    }
                    else
                    {
                        break;
                    }
                }
                Pizza pizza = pizzaBuilder.getPizza();
                pizzaList.Add(pizza);
                totalPrice += pizza.Price;
        }

        public void getOrderDescription()
        {
            Console.WriteLine("***********ORDER DESCRIPTION***********");
            Console.WriteLine($"Order ID : {OrderId}");
            foreach(var pizza in pizzaList) {
                Console.WriteLine($"\nPizza ID : {pizza.Id}");
                Console.WriteLine($"Pizza Size : {pizza.Size}");
                Console.WriteLine("Pizza Toppings :");
                foreach(var topping in pizza.Toppings)
                {
                    Console.WriteLine($"\t {topping}");
                }
                Console.WriteLine($"Pizza Price : {pizza.Price}");
            }
            Console.WriteLine($"\nTotal Price : {totalPrice}\n");
        }

        public void claimDiscount(string coupon)
        {
            if(coupons.TryGetValue(coupon, out int discount))
            {
                this.discount = discount;
            }
            else
            {
                throw new Exception("Coupon is Invalid.");
            }
        }

        public void checkoutOrder()
        {
            Console.WriteLine("***********CHECKOUT DETAILS***********");
            Console.WriteLine($"Order ID : {OrderId}");
            foreach (var pizza in pizzaList)
            {
                Console.WriteLine($"\nPizza ID : {pizza.Id}");
                Console.WriteLine($"Pizza Size : {pizza.Size}");
                Console.WriteLine("Pizza Toppings :");
                foreach (var topping in pizza.Toppings)
                {
                    Console.WriteLine($"\t {topping}");
                }
                Console.WriteLine($"Pizza Price : {pizza.Price}");
            }
            Console.WriteLine($"\nDiscount : {discount}%");
            Console.WriteLine($"Total Price : {totalPrice*(1-((double)discount/100))}\n");
        }

        private Size getSize(string size)
        {
            if (size.Equals("small"))
            {
                return Size.SMALL;
            }else if (size.Equals("medium"))
            {
                return Size.MEDIUM;
            }else if (size.Equals("large"))
            {
                return Size.LARGE;
            }
            else
            {
                throw new Exception("Entered Size is invalid.");
            }
        }

        private Topping getTopping(string topping)
        {
            if (topping.Equals("cheese"))
            {
                return Topping.CHEESE;
            }
            else if (topping.Equals("ham"))
            {
                return Topping.HAM;
            }
            else if (topping.Equals("pepperoni"))
            {
                return Topping.PEPPERONI;
            }
            else
            {
                throw new Exception("Entered Topping is invalid.");
            }
        }

    }
}
