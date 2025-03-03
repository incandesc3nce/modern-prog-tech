namespace lab1
{

    public abstract class JewelryFactory
    {
        public abstract AbstractJewelry CreateJewelry(double weight, double pricePerGramm, params object[] parameters);
    }

    public class RingFactory : JewelryFactory
    {
        public override AbstractJewelry CreateJewelry(double weight, double pricePerGramm, params object[] parameters)
        {
            return new Ring(weight, pricePerGramm, (double)parameters[0], (string)parameters[1]);
        }
    }

    public class NecklaceFactory : JewelryFactory
    {
        public override AbstractJewelry CreateJewelry(double weight, double pricePerGramm, params object[] parameters)
        {
            return new Necklace(weight, pricePerGramm, (double)parameters[0]);
        }
    }
}