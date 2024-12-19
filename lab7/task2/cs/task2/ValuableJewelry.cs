namespace task2 {
    public class ValuableJewelry : Jewelry {
        
        public double GetFullPricePerGramm() {
          return base.GetFullPricePerGramm() * 2;
        }
        
        public ValuableJewelry() : base() {
        }

        public ValuableJewelry(double arg_weight, double arg_pricePerGramm) : base(arg_weight, arg_pricePerGramm) {
        }
    }
}