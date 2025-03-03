using System;

namespace lab1 {
  public abstract class JewelryTemplate {
    public double weight = 0, pricePerGramm = 0;

    public JewelryTemplate(double weight, double pricePerGramm) {
      this.weight = weight;
      this.pricePerGramm = pricePerGramm;
    }

    public void Display() {
      Console.WriteLine($"Вес: {weight}");
      Console.WriteLine($"Цена за грамм: {pricePerGramm}");
    }

    public abstract double FullPrice();
  }
}