using System;

namespace lab1
{
    public class BaseJewelry: JewelryTemplate
    {

        public BaseJewelry(double weight, double pricePerGramm): base(weight, pricePerGramm)
        {}

        public override double FullPrice()
        {
           return weight * pricePerGramm;
        }
    }

}