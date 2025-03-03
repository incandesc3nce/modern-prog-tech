namespace lab1 {
  public class JewelryAdapter
  {
      public double FullPrice(BaseJewelry jewelry)
      {

          return jewelry.weight * jewelry.pricePerGramm;
      }
  }
}
