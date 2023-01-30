using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory
{
    public class Pizza : IPizza
    {
        private int price = 0;
        private Size size;
        private List<Topping> toppings = new List<Topping>();

        public Guid Id { get; set; }
        public int Price { get { return price;} }
        public Size Size { get { return size;} }
        public List<Topping> Toppings { get { return toppings; } }
        
        public Pizza() { 
            Id = Guid.NewGuid();
        }
        public void setSize(Size size)
        {
            this.size = size;
            switch(size)
            {
                case Size.SMALL: this.price = 10; break;
                case Size.MEDIUM: this.price = 12; break;
                case Size.LARGE: this.price = 14; break;
            }
        }

        public void addTopping(Topping topping)
        {
            toppings.Add(topping);
            this.price += 2;
        }
    }
}
