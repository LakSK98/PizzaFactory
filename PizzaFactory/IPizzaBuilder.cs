using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory
{
    public interface IPizzaBuilder
    {
        void buildPizzaSize(Size size);
        void buildPizzaTopping(Topping topping);
        Pizza getPizza();
    }
}
