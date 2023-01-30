using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory
{
    public class PizzaBuilder : IPizzaBuilder
    {
        private Pizza pizza;

        public PizzaBuilder() { 
            pizza = new Pizza();
        }

        public void buildPizzaSize(Size size)
        {
            pizza.setSize(size);
        }

        public void buildPizzaTopping(Topping topping)
        {
            pizza.addTopping(topping);
        }

        public Pizza getPizza()
        {
            return pizza;
        }
    }
}
