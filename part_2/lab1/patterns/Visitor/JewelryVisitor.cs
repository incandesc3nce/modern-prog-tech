namespace lab1 {
  public interface IJewelry {
    public void Accept(IVisitor visitor);
  }

  public interface IVisitor {
     public void Visit(JewelryWithVisitor jewelry);
  }

  public class JewelryWithVisitor : IJewelry {
    public double weight;
    public double pricePerGramm;

    public JewelryWithVisitor() {
      weight = 0;
      pricePerGramm = 0;
    }

    public void Display() {
      System.Console.WriteLine($"Вес: {weight}, Цена за грамм: {pricePerGramm}");
    }

    public void Accept(IVisitor vs) {
      vs.Visit(this);
    }
  }

  public class JewelryVisitor : IVisitor {
    public double weight;
    public double pricePerGramm;

    public JewelryVisitor(double weight, double pricePerGramm) {
      this.weight = weight;
      this.pricePerGramm = pricePerGramm;
    }

    public void Visit(JewelryWithVisitor jewelry) {
      jewelry.weight = weight;
      jewelry.pricePerGramm = pricePerGramm;
    }
  }
}